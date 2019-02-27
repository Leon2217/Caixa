using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmDebito : Form
    {
        #region INSTANCIAMENTO CLASSES
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        CredDeb cd = new CredDeb();
        credDebDAO cdDAO = new credDebDAO();
        PessoaDAO pesDAO = new PessoaDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        Sangria san = new Sangria();
        SangriaDAO sanDAO = new SangriaDAO();
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

        public frmDebito()
        {
            InitializeComponent();
        }

        private void frmDebito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
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

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {     
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

        public void CarregarComboFornecedor()
        {
            cmbFornecedor.DataSource = pesDAO.ListarF();
            cmbFornecedor.DisplayMember = "nome";
            cmbFornecedor.ValueMember = "ID";
            codpes = cmbFornecedor.SelectedValue.ToString();
        }

        public void CarregarComboFunc()
        {
            cmbFornecedor.DataSource = pesDAO.ListarFU();
            cmbFornecedor.DisplayMember = "nome";
            cmbFornecedor.ValueMember = "ID";
            codpes = cmbFornecedor.SelectedValue.ToString();
            //pessoa = cmbFornecedor.Text;
        }

        private void frmDebito_Load(object sender, EventArgs e)
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

            }          
            cmbFornecedor.Text = "";
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            valor = txtValor.Text.ToString().Replace(".","");
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            txtDesc.BackColor = Color.Empty;
            desc = txtDesc.Text.ToString();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text==string.Empty||
                mskData.MaskFull==false||
                mskHr.MaskFull==false||
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

                    op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$" + "\n Descrição : " + desc + "\n Data : " + data + "\n Hora : " + hora + "\n Responsável : " + responsa,
                        "Salvando!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        #region PAGAMENTO
                        if (chkPag.Checked == true && chkF.Checked == true && chkOutros.Checked == false)
                        {
                            san.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                            san.Valor = txtValor.Text.ToString().Replace(".", "");
                            sanDAO.Inserir(san);

                            var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                         where frm is InicialCaixa
                                         select frm;

                            if (qrForm != null && qrForm.Count() > 0)
                            {
                                ((InicialCaixa)qrForm.First()).Atualizadados();
                            }


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
                                cd.Cred_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Deb_db = "0,00";
                                cd.Responsa_db = UsuarioDAO.login;
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
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
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
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
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                    ger.Func = "0,00";
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
                                cd.Cred_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Deb_db = "0,00";
                                cd.Responsa_db = UsuarioDAO.login;
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
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
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
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
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion
                            }

                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = f;
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                else
                                {
                                    string zero1 = "0.00";
                                    vgDAO.Inserir(zero1);
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();

                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = f;
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion


                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = f;
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                else
                                {
                                    string zero1 = "0.00";
                                    vgDAO.Inserir(zero1);
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();

                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = "";
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion
                            }



                        }
                        #endregion

                        #region FORNECEDOR
                        if (chkF.Checked == true && chkPag.Checked == false)
                        {
                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                            //GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();
                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = f;
                                ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Cred_g = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }
                            else
                            {
                                string zero = "0.00";
                                vgDAO.Inserir(zero);
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = f;
                                ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Cred_g = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                        }
                        #endregion

                        #region MICROSTATION
                        if (chkMicrostation.Checked == true)
                        {
                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString();
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString();
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                            //GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update(valor);
                                vgDAO.Verificavalor();
                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = txtDesc.Text.ToString(); ;
                                ger.Deb_g = "0,00";
                                ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
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
                                ger.Desc_g = txtDesc.Text.ToString();
                                ger.Deb_g = "0,00";
                                ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                ger.Func = "0,00";
                                ger.Forn = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                        }
                        #endregion

                        #region FUNCIONARIO
                        if (chkFuncionario.Checked == true)
                        {
                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                            //GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();
                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = f;
                                ger.Forn = "0,00";
                                ger.Deb_g = "0,00";
                                ger.Cred_g = "0,00";
                                ger.Func = txtValor.Text.ToString().Replace(".", "");
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }
                            else
                            {
                                string zero = "0.00";
                                vgDAO.Inserir(zero);
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = f;
                                ger.Forn = "0,00";
                                ger.Deb_g = "0,00";
                                ger.Cred_g = "0,00";
                                ger.Func = txtValor.Text.ToString().Replace(".", "");
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                        }
                        #endregion

                        #region OUTROS PDV
                        if (chkPag.Checked == true && chkF.Checked == false && chkOutros.Checked == true)
                        {
                            san.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                            san.Valor = txtValor.Text.ToString().Replace(".", "");
                            sanDAO.Inserir(san);

                            var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                         where frm is InicialCaixa
                                         select frm;

                            if (qrForm != null && qrForm.Count() > 0)
                            {
                                ((InicialCaixa)qrForm.First()).Atualizadados();
                            }


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
                                cd.Cred_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Deb_db = "0,00";
                                cd.Responsa_db = UsuarioDAO.login;
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
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
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
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
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                    ger.Func = "0,00";
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
                                cd.Cred_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Deb_db = "0,00";
                                cd.Responsa_db = UsuarioDAO.login;
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
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
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
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
                                    ger.Forn = "0,00";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = txtValor.Text.ToString().Replace(".", "");
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion
                            }

                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = "";
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                else
                                {
                                    string zero1 = "0.00";
                                    vgDAO.Inserir(zero1);
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();

                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = "";
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion


                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = "";
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                else
                                {
                                    string zero1 = "0.00";
                                    vgDAO.Inserir(zero1);
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();

                                    #region GERAL
                                    ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                    ger.Desc_g = "";
                                    ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion
                            }



                        }
                        #endregion   

                        #region OUTROS ONLY
                        if (chkOutros.Checked == true && chkPag.Checked == false)
                        {
                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString() + " " + f;
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                            //GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();
                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = "";
                                ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Cred_g = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }
                            else
                            {
                                string zero = "0.00";
                                vgDAO.Inserir(zero);
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = "";
                                ger.Forn = txtValor.Text.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Cred_g = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                        }
                        #endregion

                        #region NENHUM
                        if (chkF.Checked == false && chkPag.Checked == false && chkFuncionario.Checked == false && chkOutros.Checked == false && chkMicrostation.Checked == false)
                        {
                            if (vcDAO.Verificavalor() == true)
                            {
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString();
                                cd.Deb_db = txtValor.Text.ToString().ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);

                                aud.Acao = "INSERIU MOV DEBITO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion

                            }
                            else
                            {
                                string zero = "0.00";
                                vcDAO.Inserir(zero);
                                vcDAO.Update2(valor);
                                vcDAO.Verificavalor();
                                #region CREDITO DEBITO
                                cd.Data = Convert.ToDateTime(mskData.Text);
                                cd.Hora = Convert.ToDateTime(mskHr.Text);
                                cd.Desc_db = txtDesc.Text.ToString();
                                cd.Deb_db = txtValor.Text.ToString().Replace(".", "");
                                cd.Cred_db = "0,00";
                                cd.Responsa_db = txtResponsa.Text.ToString();
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;
                                cdDAO.Inserir(cd);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                            //GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();
                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = "";
                                ger.Forn = "0,00";
                                ger.Deb_g = txtValor.Text.ToString().Replace(".", "");
                                ger.Cred_g = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }
                            else
                            {
                                string zero = "0.00";
                                vgDAO.Inserir(zero);
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(mskData.Text);
                                ger.Desc_g = "";
                                ger.Forn = "0,00";
                                ger.Deb_g = txtValor.Text.ToString().Replace(".", "");
                                ger.Cred_g = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                ((frmMovimentoCaixa)this.Owner).AtualizaDados();
                                #endregion
                            }


                        }
                        #endregion

                        MessageBox.Show("Informações cadastradas com sucesso !!!");
                        Limpar();                      
                    }
                }
                catch
                {
                }
            }                
        }

        public void Limpar()
        {
            txtValor.Text = "0,00";
            string datatela = DateTime.Now.ToShortDateString();
            string hrtela = DateTime.Now.ToShortTimeString();
            mskData.Text = datatela;
            mskHr.Text = hrtela;
            chkFuncionario.Checked = false;
            chkMicrostation.Checked = false;
            chkPag.Checked = false;
            chkF.Checked = false;
            chkOutros.Checked = false;
            cmbFornecedor.Text = "";
            txtDesc.Clear();
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
                chkMicrostation.Enabled = false;
                chkFuncionario.Enabled = false;
                chkOutros.Enabled = false;

                try
                {
                    CarregarComboFornecedor();
                }
                catch
                {

                }                
            }
            else if (chkPag.Checked == true)
            {
                cmbFornecedor.Enabled = false;
                cmbFornecedor.SelectedIndex = -1;
                chkFuncionario.Enabled = false;
                chkMicrostation.Enabled = false;
                chkOutros.Enabled = true;
            }
            else
            {
                cmbFornecedor.Enabled = false;
                cmbFornecedor.SelectedIndex = -1;
                chkFuncionario.Enabled = true;
                chkMicrostation.Enabled = true;
                chkOutros.Enabled = true;
            }
        }

        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkFuncionario.Checked == true || chkF.Checked == true)
            {
                f = cmbFornecedor.Text;
                try
                {
                    codpes = cmbFornecedor.SelectedValue.ToString();
                }
                catch
                {
                }
            }
            else
            {
                f = null;
            }
        }

        private void chkPag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOutros.Checked == true && chkPag.Checked == true)
            {
                chkF.Checked = false;
                txtDesc.Text = "Pagamento";
                cmbFornecedor.SelectedIndex = -1;
                chkMicrostation.Enabled = false;
            }
            else
            {
                if (chkPag.Checked == true)
                {
                    txtDesc.Text = "Pagamento";
                    chkF.Checked = true;
                    chkMicrostation.Enabled = false;
                }
                else
                {
                    chkF.Checked = false;
                    txtDesc.Clear();
                    chkMicrostation.Enabled = true;
                }
            }           
        }

        private void chkMicrostation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMicrostation.Checked == true)
            {
                txtDesc.Text = "PAGAMENTO BOLETO M";
                chkPag.Enabled = false;
                chkF.Enabled = false;
                chkFuncionario.Enabled = false;
                chkOutros.Enabled = false;
            }
            else
            {
                chkF.Enabled = true;
                txtDesc.Text = "";
                chkPag.Enabled = true;
                chkFuncionario.Enabled = true;
                chkOutros.Enabled = true;
            }
        }

        private void chkFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFuncionario.Checked == true)
            {
                chkOutros.Enabled = false;
                chkF.Enabled = false;
                chkMicrostation.Enabled = false;
                chkPag.Enabled = false;
                cmbFornecedor.Enabled = true;
                try
                {
                    CarregarComboFunc();
                }
                catch
                {
                }
            }
            else
            {
                chkOutros.Enabled = true;
                chkF.Enabled = true;
                chkMicrostation.Enabled = true;
                chkPag.Enabled = true;
                cmbFornecedor.SelectedIndex = -1;
                cmbFornecedor.Enabled = false;
                
            }
        }

        private void chkOutros_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOutros.Checked == true)
            {
                chkPag.Enabled = true;
                chkF.Checked = false;
                chkF.Enabled = false;
                chkMicrostation.Enabled = false;
                cmbFornecedor.SelectedIndex = -1;
                cmbFornecedor.Enabled = false;
                chkFuncionario.Enabled = false;
                f = null;
            }
            else
            {
                chkMicrostation.Enabled = true;
                chkPag.Checked = false;
                chkPag.Enabled = true;
                chkF.Enabled = true;
                chkFuncionario.Enabled = true;                
            }
        }
    }
}
