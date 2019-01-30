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
    public partial class frmCredito : Form
    {
        #region INSTANCIAMENTO CLASSES
        Credito cred = new Credito();
        CreditoDAO credDAO = new CreditoDAO();
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        CredDeb cd = new CredDeb();
        credDebDAO cdDAO = new credDebDAO();
        PessoaDAO pesDAO = new PessoaDAO();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Valorgeral vg = new Valorgeral();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        #endregion

        #region VAR
        string valor;
        string desc;
        string data;
        string hora;
        string responsa;
        string codpes;
        string f;
        #endregion
        public frmCredito()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text==string.Empty||mskData.MaskFull==false
                ||mskHr.MaskFull==false||
                txtResponsa.Text==string.Empty)
            {
                if (txtDesc.Text == string.Empty)
                    txtDesc.BackColor = Color.Red;

                if (mskData.MaskFull == false)
                    mskData.BackColor = Color.Red;

                if (mskHr.MaskFull == false)
                    mskHr.BackColor = Color.Red;

                if (txtResponsa.Text == string.Empty)
                    txtResponsa.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    DialogResult op;

                    op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$"+"\n Descrição : "+desc+"\n Data : "+data+"\n Hora : "+hora+"\n Responsável : "+responsa,
                        "Salvando!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        #region CREDITO
                 
                        cred.Valor = txtValor.ToString().Replace(".","");
                        cred.Desc_credito = txtDesc.Text.ToString();
                        cred.Data = Convert.ToDateTime(mskData.Text);
                        cred.Hora = Convert.ToDateTime(mskHr.Text);
                        cred.Responsavel = txtResponsa.Text.ToString();
                        credDAO.Inserir(cred);

                        aud.Acao = "INSERIU MOV CREDITO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                        #endregion


                        if (vcDAO.Verificavalor()==true)
                        {
                            vcDAO.Update(valor);
                            vcDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(mskData.Text);
                            cd.Hora = Convert.ToDateTime(mskHr.Text);
                            cd.Desc_db =txtDesc.Text.ToString() +" "+ f;
                            cd.Cred_db = txtValor.Text.ToString().Replace(".","");
                            cd.Deb_db = "0,00";
                            cd.Responsa_db = txtResponsa.Text.ToString();
                            cd.Total = vcDAO.Vc.Valor;
                            cdDAO.Inserir(cd);
                            ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                            #endregion
                        }
                        else
                        {
                            string zero = "0.00";
                            vcDAO.Inserir(zero);
                            vcDAO.Update(valor);
                            vcDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(mskData.Text);
                            cd.Hora = Convert.ToDateTime(mskHr.Text);
                            cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                            cd.Cred_db = txtValor.Text.ToString().Replace(".","");
                            cd.Deb_db = "0,00";
                            cd.Responsa_db = txtResponsa.Text.ToString();
                            cd.Total = vcDAO.Vc.Valor;
                            cdDAO.Inserir(cd);
                            ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                            #endregion
                        }


                        //GERAL
                        if (vgDAO.Verificavalor()==true)
                        {
                            vgDAO.Update(valor);
                            vgDAO.Verificavalor();
                            #region GERAL
                            ger.Data = Convert.ToDateTime(mskData.Text);
                            ger.Desc_g = "";
                            ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Func = "0,00";
                            ger.Forn = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);
                            ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                            #endregion
                        }
                        else
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(valor);
                            vgDAO.Verificavalor();

                            #region GERAL
                            ger.Data = Convert.ToDateTime(mskData.Text);        
                            ger.Desc_g = "";
                            ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                            ger.Deb_g = "0,00";
                            ger.Func = "0,00";
                            ger.Forn = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);
                            ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                            #endregion
                        }



                        MessageBox.Show("Informações cadastradas com sucesso !!!");
                        Limpar();

                        aud.Acao = "INSERIU CRÉDITO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                }
                catch
                {

                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
            }

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

        public void Limpar()
        {
            txtValor.Text = "0,00";
            txtDesc.Clear();
            cmbFornecedor.Text = "";
            chkF.Checked = false;
            string datatela = DateTime.Now.ToShortDateString();
            string hrtela = DateTime.Now.ToShortTimeString();
            mskData.Text = datatela;
            mskHr.Text = hrtela;
            txtResponsa.Clear();
        }

        public void CarregarComboFornecedor()
        {
            cmbFornecedor.DataSource = pesDAO.ListarF();
            cmbFornecedor.DisplayMember = "nome";
            cmbFornecedor.ValueMember = "ID";
            codpes = cmbFornecedor.SelectedValue.ToString();

        }

        private void frmCredito_Load(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            string datatela = DateTime.Now.ToShortDateString();
            string hrtela = DateTime.Now.ToShortTimeString();
            mskData.Text = datatela;
            mskHr.Text = hrtela;

            txtResponsa.Text = UsuarioDAO.login;

            try
            {
                CarregarComboFornecedor();
                cmbFornecedor.SelectedIndex = -1;

            }
            catch
            {
                MessageBox.Show("Favor cadastrar fornecedores primeiro");
            }
    
            cmbFornecedor.Text = "";
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            valor = txtValor.Text.ToString().Replace(".","");
        }

        private void frmCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }

            
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskHr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtResponsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            txtDesc.BackColor = Color.Empty;
            desc = txtDesc.Text.ToString();

        }

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            mskData.BackColor = Color.Empty;
            data = mskData.Text.ToString();
        }

        private void mskHr_TextChanged(object sender, EventArgs e)
        {
            mskHr.BackColor = Color.Empty;
            hora = mskHr.Text.ToString();
        }

        private void txtResponsa_TextChanged(object sender, EventArgs e)
        {
            txtResponsa.BackColor = Color.Empty;
            responsa = txtResponsa.Text;
        }

        private void mskData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtResponsa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsSeparator(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void chkF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkF.Checked == true)
            {
                cmbFornecedor.Enabled = true;
            }
            else
            {
                cmbFornecedor.Enabled = false;
                cmbFornecedor.SelectedIndex = -1;
            }
        }

        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFornecedor.Text != string.Empty && cmbFornecedor.Enabled==true)
            {
                f = cmbFornecedor.Text.ToString();
            }
        }
    }
}
