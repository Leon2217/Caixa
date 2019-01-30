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
    public partial class frmSangria : Form
    {
        #region INSTANCIAMENTO CLASSES
        CredDeb cd = new CredDeb();
        credDebDAO cdDAO = new credDebDAO();
        Valorcaixa vc = new Valorcaixa();
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        Sangria san = new Sangria();
        SangriaDAO sanDAO = new SangriaDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Valorgeral vg = new Valorgeral();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        string valor;
        #endregion
        public frmSangria()
        {
            InitializeComponent();
        }

        private void frmSangria_Load(object sender, EventArgs e)
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

        private void txtSangria_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtSangria);
            valor = txtSangria.Text.ToString().Replace(".", "");

        }

        private void txtSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$",
                "Salvando!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                try
                {
                    san.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                    san.Valor = txtSangria.Text.ToString().Replace(".", "");
                    sanDAO.Inserir(san);

                    if (vcDAO.Verificavalor() == true)
                    {
                        vcDAO.Update(valor);
                        vcDAO.Verificavalor();

                        #region CREDITO DEBITO
                        string datatela = DateTime.Now.ToShortDateString();
                        string hrtela = DateTime.Now.ToShortTimeString();
                        cd.Data = Convert.ToDateTime(datatela);
                        cd.Hora = Convert.ToDateTime(hrtela);
                        cd.Desc_db = "Entrada sangria PDV";
                        cd.Cred_db = txtSangria.Text.ToString().Replace(".", "");
                        cd.Deb_db = "0,00";
                        cd.Responsa_db = UsuarioDAO.login;
                        cd.Total = vcDAO.Vc.Valor;
                        cdDAO.Inserir(cd);

                        #endregion

                        #region GERAL
                        if (vgDAO.Verificavalor() == true)
                        {
                            vgDAO.Update(valor);
                            vgDAO.Verificavalor();
                            #region GERAL
                            ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                            ger.Desc_g = "";
                            ger.Cred_g = txtSangria.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }
                        else
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(valor);
                            vgDAO.Verificavalor();

                            #region GERAL
                            ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                            ger.Desc_g = "";
                            ger.Cred_g = txtSangria.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Func = "0,00";
                            ger.Forn = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        string zero = "0.00";
                        vcDAO.Inserir(zero);
                        vcDAO.Update(valor);
                        vcDAO.Verificavalor();
                        #region CREDITO DEBITO
                        string datatela = DateTime.Now.ToShortDateString();
                        string hrtela = DateTime.Now.ToShortTimeString();
                        cd.Data = Convert.ToDateTime(datatela);
                        cd.Hora = Convert.ToDateTime(hrtela);
                        cd.Desc_db = "Entrada sangria PDV";
                        cd.Cred_db = txtSangria.Text.ToString().Replace(".", "");
                        cd.Deb_db = "0,00";
                        cd.Responsa_db = UsuarioDAO.login;
                        cd.Total = vcDAO.Vc.Valor;
                        cdDAO.Inserir(cd);

                        #endregion

                        #region GERAL
                        if (vgDAO.Verificavalor() == true)
                        {
                            vgDAO.Update(valor);
                            vgDAO.Verificavalor();
                            #region GERAL
                            ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                            ger.Desc_g = "";
                            ger.Cred_g = txtSangria.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }
                        else
                        {
                            string zero1 = "0.00";
                            vgDAO.Inserir(zero1);
                            vgDAO.Update(valor);
                            vgDAO.Verificavalor();

                            #region GERAL
                            ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                            ger.Desc_g = "";
                            ger.Cred_g = txtSangria.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }
                        #endregion
                    }


                    MessageBox.Show("Informações salvas com sucesso !!!");

                    aud.Acao = "INSERIU SANGRIA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);

                    ((InicialCaixa)this.Owner).Atualizadados();

                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
            }

        }

        private void frmSangria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtSangria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void btnRelatório_Click(object sender, EventArgs e)
        {
            relatSangria s = new relatSangria();
            s.Owner = this;
            s.ShowDialog();
        }
    }
}
