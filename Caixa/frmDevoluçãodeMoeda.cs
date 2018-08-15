using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmDevoluçãodeMoeda : Form
    {
        DevMoeda dm = new DevMoeda();
        DevMoedaDAO dmDAO = new DevMoedaDAO();
        Valorcxm cxm = new Valorcxm();
        ValorcxmDAO cxmDAO = new ValorcxmDAO();
        ValorcaixaDAO vcxDAO = new ValorcaixaDAO();
        EntradaDev ed = new EntradaDev();
        EntradaDevDAO edDAO = new EntradaDevDAO();
        credDebDAO cdDAO = new credDebDAO();
        CredDeb cd = new CredDeb();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Valorgeral vg = new Valorgeral();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        public frmDevoluçãodeMoeda()
        {
            InitializeComponent();
        }

        private void frmDevoluçãodeMoeda_Load(object sender, EventArgs e)
        {
            Moeda(ref txtSangria);
        }

        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {
            }
        }
                private void frmDevoluçãodeMoeda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?",
                    "Salvando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    try
                    {
                        dm.Valor = txtSangria.Text.ToString().Replace(".", "");
                        dm.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        dm.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        dm.Responsavel = UsuarioDAO.login;
                        dmDAO.Inserir(dm);

                        MessageBox.Show("Informações salvas com sucesso!!!");

                      
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }


                    if (cxmDAO.Verificavalor() == true)
                    {
                        #region SUBTRAINDO NO CAIXA DE MOEDA
                        cxm.Valor = txtSangria.Text.ToString().Replace(".", "");
                        cxmDAO.Update2(cxm);
                        #endregion

                        cxmDAO.Verificavalor();
                        #region INSERINDO NA TABELA ENTRADA_DEV
                        ed.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        ed.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        ed.Desc_ed = "Saída p/ caixa";
                        ed.Saida_ed = txtSangria.Text.ToString().Replace(".", "");
                        ed.Entrada_ed = "0,00";
                        ed.Responsa_ed = UsuarioDAO.login;
                        ed.Total = cxmDAO.Vcm.Valor;
                        edDAO.Inserir(ed);
                        #endregion

                        #region SOMANDO NO CAIXA NORMAL
                        if (vcxDAO.Verificavalor() == true)
                        {
                            string valor = txtSangria.Text.ToString().Replace(".", "");
                            vcxDAO.Update(valor);
                        }
                        else
                        {
                            string zero1 = "0.00";
                            vcxDAO.Inserir(zero1);
                            string valor = txtSangria.Text.ToString().Replace(".", "");
                            vcxDAO.Update(valor);
                        }
                        #endregion

                        vcxDAO.Verificavalor();
                        #region CREDITO DEBITO
                        cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        cd.Desc_db = "Entrada caixa moeda";
                        cd.Cred_db = txtSangria.Text.ToString().Replace(".", "");
                        cd.Deb_db = "0,00";
                        cd.Responsa_db = UsuarioDAO.login;
                        cd.Total = vcxDAO.Vc.Valor;
                        cdDAO.Inserir(cd);

                        #endregion



                        //GERAL
                        if (vgDAO.Verificavalor() == true)
                        {
                            vgDAO.Update(txtSangria.Text.ToString().Replace(".", ""));
                            vgDAO.Verificavalor();
                            #region GERAL
                            ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                            ger.Desc_g = "CRÉDITO";
                            ger.Cred_g = txtSangria.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);
                   
                            #endregion
                        }
                        else
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(txtSangria.Text.ToString().Replace(".", ""));
                            vgDAO.Verificavalor();

                            #region GERAL
                            ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                            ger.Desc_g = "CRÉDITO";
                            ger.Cred_g = txtSangria.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }

                        txtSangria.Clear();
                    }
                    else
                    {

                    }

                }
            }
            catch
            {
                MessageBox.Show("Favor verificar as informações digitadas !!!");
            }



        }

        private void txtSangria_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtSangria);
        }

        private void txtSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
