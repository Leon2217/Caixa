using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmPesquisaPessoa : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        Pessoa pes = new Pessoa();
        PessoaDAO pesDAO = new PessoaDAO();
        TipoDAO tpDAO = new TipoDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        TipopessoaDAO tpsDAO = new TipopessoaDAO();
        Tipopessoa tp = new Tipopessoa();
        Endereco end = new Endereco();
        EnderecoDAO endDAO = new EnderecoDAO();
        #endregion

        Boolean update;
        Boolean Pesquisa;
        string codtp;
        string codtp2;
        string codtp3;
        string codtp4;
        int i, qtdRegistro;
        string codpes;
        string id;
        public frmPesquisaPessoa()
        {
            InitializeComponent();
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            frmExcluirFunc v = new frmExcluirFunc();
            v.Owner = this;
            v.ShowDialog();
        }

        public void CarregarComboTipo()
        {
            cmbTipo1.DataSource = tpDAO.ListarTipo();
            cmbTipo1.DisplayMember = "tipo";
            cmbTipo1.ValueMember = "ID";
            codtp = cmbTipo1.SelectedValue.ToString();
        }

        public void CarregarComboTipo2()
        {
            cmbTipo2.DataSource = tpDAO.ListarTipo();
            cmbTipo2.DisplayMember = "tipo";
            cmbTipo2.ValueMember = "ID";
            codtp2 = cmbTipo2.SelectedValue.ToString();
        }

        public void CarregarComboTipo3()
        {
            cmbTipo3.DataSource = tpDAO.ListarTipo();
            cmbTipo3.DisplayMember = "tipo";
            cmbTipo3.ValueMember = "ID";
            codtp3 = cmbTipo3.SelectedValue.ToString();
        }

        public void CarregarComboTipo4()
        {
            cmbTipo4.DataSource = tpDAO.ListarTipo();
            cmbTipo4.DisplayMember = "tipo";
            cmbTipo4.ValueMember = "ID";
            codtp4 = cmbTipo4.SelectedValue.ToString();
        }

        private void mskCpfPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (mskCpfPesquisa.MaskFull == false)
            {
                mskCnpjPesquisa.Enabled = true;
            }
            else
            {
                mskCnpjPesquisa.Enabled = false;
            }

            if (mskCpfPesquisa.MaskFull == true)
            {
                if (pesDAO.VerificaCPFNJ(mskCpfPesquisa.Text) == true)
                {
                    txtN.Text = pesDAO.Pes.N_casa.ToString();
                    txtNome.Text = pesDAO.Pes.Nome;
                    txtIm.Text = pesDAO.Pes.Im;
                    txtIe.Text = pesDAO.Pes.Ie;
                    txtFornecimento.Text = pesDAO.Pes.Fornecimento;
                    txtRs.Text = pesDAO.Pes.Rs;
                    mskCep.Text = pesDAO.Pes.Cep;
                    txtBairro.Text = pesDAO.Pes.Bairro;
                    txtUf.Text = pesDAO.Pes.Uf;
                    txtRua.Text = pesDAO.Pes.Rua;
                    txtCidade.Text = pesDAO.Pes.Cidade;
                    mskCel.Text = pesDAO.Pes.Cel;
                    mskTel.Text = pesDAO.Pes.Tel;
                    txtEmail.Text = pesDAO.Pes.Email;
                    txtObs.Text = pesDAO.Pes.Obs;

                    update = true;

                    CarregarComboTipo();
                    CarregarComboTipo2();
                    CarregarComboTipo3();
                    CarregarComboTipo4();
                    txtNome.Enabled = true;
                    txtUf.Enabled = true;
                    mskCep.Enabled = true;
                    txtRua.Enabled = true;
                    txtN.Enabled = true;
                    txtCidade.Enabled = true;
                    mskTel.Enabled = true;
                    mskCel.Enabled = true;
                    txtBairro.Enabled = true;
                    txtEmail.Enabled = true;
                    txtObs.Enabled = true;
                    chkIe.Enabled = true;
                    txtIm.Enabled = true;
                    txtFornecimento.Enabled = true;
                    txtRs.Enabled = true;
                    cmbTipo1.Enabled = true;
                    txtNome.Visible = true;
                    lblNome.Visible = true;

                    pesDAO.VerificaTipo(mskCpfPesquisa.Text);
                    try
                    {
                        cmbTipo1.Text = PessoaDAO.tp0.ToString();
                    }
                    catch
                    {
                        cmbTipo1.Text = "";
                    }
                    try
                    {
                        cmbTipo3.Text = PessoaDAO.tp1.ToString();
                    }
                    catch
                    {
                        cmbTipo3.Text = "";
                    }
                    try
                    {
                        cmbTipo2.Text = PessoaDAO.tp2.ToString();
                    }
                    catch
                    {
                        cmbTipo2.Text = "";
                    }
                    try
                    {
                        cmbTipo4.Text = PessoaDAO.tp3.ToString();
                    }
                    catch
                    {
                        cmbTipo4.Text = "";
                    }
                }
                else
                {
                }
            }
            else
            {
                mskCpfPesquisa.BackColor = Color.Empty;

                update = false;

                txtN.Clear();
                txtNome.Clear();
                txtRs.Clear();
                txtCidade.Clear();
                txtUf.Clear();
                txtRua.Clear();
                txtFornecimento.Clear();
                txtIm.Clear();
                mskCel.Clear();
                mskTel.Clear();
                txtObs.Clear();
                txtBairro.Clear();
                mskCnpjPesquisa.Clear();
                txtEmail.Clear();
                mskCep.Clear();
                cmbTipo1.Text = "";
                cmbTipo2.Text = "";
                cmbTipo3.Text = "";
                cmbTipo4.Text = "";

                txtN.Enabled = false;
                txtNome.Enabled = false;
                mskCep.Enabled = false;
                txtUf.Enabled = false;
                txtCidade.Enabled = false;
                txtBairro.Enabled = false;
                txtEmail.Enabled = false;
                txtRua.Enabled = false;
                mskCel.Enabled = false;
                mskTel.Enabled = false;
                txtObs.Enabled = false;
                txtRs.Enabled = false;
                txtFornecimento.Enabled = false;
                txtIm.Enabled = false;
                cmbTipo1.Enabled = false;
                cmbTipo2.Enabled = false;
                cmbTipo3.Enabled = false;
                cmbTipo4.Enabled = false;
                txtNome.Visible = false;
                lblNome.Visible = false;
            }
        }

        private void mskCnpjPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (mskCnpjPesquisa.MaskFull == false)
            {
                mskCpfPesquisa.Enabled = true;
            }
            else
            {
                mskCpfPesquisa.Enabled = false;
            }

            if (mskCnpjPesquisa.MaskFull == true)
            {
                if (pesDAO.VerificaCPFNJ(mskCnpjPesquisa.Text) == true)
                {
                    txtN.Text = pesDAO.Pes.N_casa.ToString();
                    txtNome.Text = pesDAO.Pes.Nome;
                    txtIm.Text = pesDAO.Pes.Im;
                    txtIe.Text = pesDAO.Pes.Ie;
                    txtFornecimento.Text = pesDAO.Pes.Fornecimento;
                    txtRs.Text = pesDAO.Pes.Rs;
                    mskCep.Text = pesDAO.Pes.Cep;
                    txtBairro.Text = pesDAO.Pes.Bairro;
                    txtUf.Text = pesDAO.Pes.Uf;
                    txtRua.Text = pesDAO.Pes.Rua;
                    txtCidade.Text = pesDAO.Pes.Cidade;
                    mskCel.Text = pesDAO.Pes.Cel;
                    mskTel.Text = pesDAO.Pes.Tel;
                    txtEmail.Text = pesDAO.Pes.Email;
                    txtObs.Text = pesDAO.Pes.Obs;


                    update = true;

                    CarregarComboTipo();
                    CarregarComboTipo2();
                    CarregarComboTipo3();
                    CarregarComboTipo4();
                    txtNome.Enabled = true;
                    txtUf.Enabled = true;
                    mskCep.Enabled = true;
                    txtRua.Enabled = true;
                    txtN.Enabled = true;
                    txtCidade.Enabled = true;
                    mskTel.Enabled = true;
                    mskCel.Enabled = true;
                    txtBairro.Enabled = true;
                    txtEmail.Enabled = true;
                    txtObs.Enabled = true;
                    chkIe.Enabled = true;
                    txtIm.Enabled = true;
                    txtFornecimento.Enabled = true;
                    txtRs.Enabled = true;
                    cmbTipo1.Enabled = true;
                    lblFantasia.Visible = true;
                    lblNome.Visible = true;
                    txtNome.Visible = true;



                    pesDAO.VerificaTipo(mskCnpjPesquisa.Text);
                    try
                    {
                        cmbTipo1.Text = PessoaDAO.tp0.ToString();
                    }
                    catch
                    {
                        cmbTipo1.Text = "";
                    }
                    try
                    {
                        cmbTipo3.Text = PessoaDAO.tp1.ToString();
                    }
                    catch
                    {
                        cmbTipo3.Text = "";
                    }
                    try
                    {
                        cmbTipo2.Text = PessoaDAO.tp2.ToString();
                    }
                    catch
                    {
                        cmbTipo2.Text = "";
                    }
                    try
                    {
                        cmbTipo4.Text = PessoaDAO.tp3.ToString();
                    }
                    catch
                    {
                        cmbTipo4.Text = "";
                    }
                }
                else
                {
                }
            }
            else
            {
                mskCnpjPesquisa.BackColor = Color.Empty;

                update = false;

                txtN.Clear();
                txtNome.Clear();
                txtRs.Clear();
                txtCidade.Clear();
                txtUf.Clear();
                txtRua.Clear();
                txtFornecimento.Clear();
                txtIm.Clear();
                mskCel.Clear();
                mskTel.Clear();
                txtObs.Clear();
                txtBairro.Clear();
                mskCpfPesquisa.Clear();
                txtEmail.Clear();
                mskCep.Clear();

                cmbTipo1.Text = "";
                cmbTipo2.Text = "";
                cmbTipo3.Text = "";
                cmbTipo4.Text = "";

                txtN.Enabled = false;
                txtNome.Enabled = false;
                mskCep.Enabled = false;
                txtUf.Enabled = false;
                txtCidade.Enabled = false;
                txtBairro.Enabled = false;
                txtEmail.Enabled = false;
                txtRua.Enabled = false;
                mskCel.Enabled = false;
                mskTel.Enabled = false;
                txtObs.Enabled = false;
                txtRs.Enabled = false;
                txtFornecimento.Enabled = false;
                txtIm.Enabled = false;
                cmbTipo1.Enabled = false;
                cmbTipo2.Enabled = false;
                cmbTipo3.Enabled = false;
                cmbTipo4.Enabled = false;
                txtNome.Visible = false;
                lblFantasia.Visible = false;
                lblNome.Visible = false;
            }
        }

        private void frmPesquisaPessoa_Load(object sender, EventArgs e)
        {
            toolTip1.InitialDelay = 500;
            toolTip1.AutoPopDelay = 3000;

            toolTip1.SetToolTip(this.btnCadastrar, "Atualizar informações");
            toolTip1.SetToolTip(this.btnLimpar, "Cancelar/Limpar campos");
            toolTip1.SetToolTip(this.btnGrid, "Visualizar clientes cadastrados");
            toolTip1.SetToolTip(this.btnExcluir, "Excluir informações");
        }

        public void AtualizaNome(string nome)
        {
            chkNome.Checked = true;
            txtPesqNome.Text = nome;
        }

        public void Bloq()
        {
            Limpar();

            txtN.Enabled = false;
            txtNome.Enabled = false;
            mskCep.Enabled = false;
            txtUf.Enabled = false;
            txtCidade.Enabled = false;
            txtBairro.Enabled = false;
            txtEmail.Enabled = false;
            txtRua.Enabled = false;
            mskCel.Enabled = false;
            mskTel.Enabled = false;
            txtObs.Enabled = false;
            txtRs.Enabled = false;
            txtFornecimento.Enabled = false;
            txtIm.Enabled = false;
            cmbTipo1.Enabled = false;
            cmbTipo2.Enabled = false;
            cmbTipo3.Enabled = false;
            cmbTipo4.Enabled = false;
            txtIe.Enabled = false;
        }
        public void Limpar()
        {
            txtN.Clear(); mskCpfPesquisa.Clear(); mskCnpjPesquisa.Clear();
            txtNome.Clear();
            txtRs.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            txtRua.Clear();
            txtFornecimento.Clear();
            txtIe.Text = "Isento";
            txtIm.Clear();
            mskCel.Clear();
            mskTel.Clear();
            txtObs.Clear();
            txtBairro.Clear();
            txtEmail.Clear();
            mskCep.Clear();
            cmbTipo1.Text = "";
            cmbTipo2.Text = "";
            cmbTipo3.Text = "";
            cmbTipo4.Text = "";
            txtCpfnj.Clear();
            lblFisJur.Text = "";
            txtPesqNome.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Bloq();
            txtPesqNome.Clear();
            chkCpfCnpj.Checked = false;
            chkNome.Checked = false;
            txtPesqNome.Visible = false;
        }

        private void chkIe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIe.Checked == true)
            {
                txtIe.Enabled = true;
                txtIe.Clear();
            }
            else
            {
                txtIe.Enabled = false;
                txtIe.Text = "Isento";
            }
        }

        private void cmbTipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }

        }

        private void cmbTipo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }
        }

        private void cmbTipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }
        }

        private void cmbTipo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }
        }

        private void cmbTipo1_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }           
        }

        private void cmbTipo3_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }
        }

        private void cmbTipo2_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }

            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }

            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }
        }

        private void cmbTipo4_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipo1.Text != string.Empty)
                cmbTipo3.Enabled = true;
            else
            {
                cmbTipo3.Enabled = false;
                cmbTipo3.Text = "";
            }
            if (cmbTipo3.Text != string.Empty)
                cmbTipo2.Enabled = true;
            else
            {
                cmbTipo2.Enabled = false;
                cmbTipo2.Text = "";
            }
            if (cmbTipo2.Text != string.Empty)
                cmbTipo4.Enabled = true;
            else
            {
                cmbTipo4.Enabled = false;
                cmbTipo4.Text = "";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtPesqNome.Text != string.Empty)
            {
                DialogResult op;

                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    pesDAO.ExcluirNome(txtPesqNome.Text, txtCpfnj.Text);
                    MessageBox.Show("Excluído com sucesso !!!");

                    Bloq();

                    aud.Acao = "EXCLUIU PESSOA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);
                }
                else
                {
                }
            }

            if (mskCpfPesquisa.MaskFull == true)
            {
                DialogResult op;

                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    pesDAO.Excluir(mskCpfPesquisa.Text);
                    MessageBox.Show("Excluído com sucesso !!!");

                    Bloq();

                    aud.Acao = "EXCLUIU PESSOA FÍSICA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);
                }
                else
                {
                }
            }
            else
            {
                if (mskCnpjPesquisa.MaskFull == true)
                {
                    DialogResult op;

                    op = MessageBox.Show("Deseja realmente excluir?",
                        "Excluir?", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        pesDAO.Excluir(mskCnpjPesquisa.Text);
                        MessageBox.Show("Excluído com sucesso !!!");

                        Bloq();

                        aud.Acao = "EXCLUIU PESSOA JURÍDICA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    else
                    {
                    }
                }
            }
        }

        private void frmPesquisaPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            #region FÍSICO
            if (mskCpfPesquisa.MaskFull == true)
            {
                if (txtNome.Text == string.Empty)
                {
                    if (txtNome.Text == string.Empty)
                        txtNome.BackColor = Color.Red;



                    MessageBox.Show("Favor preencher o campo em vermelho!!!");

                }
                else
                {
                    try
                    {
                        pes.Nome = txtNome.Text;
                        pes.Tipo = "Física";
                        pes.Cpfnj = mskCpfPesquisa.Text;
                        pes.Im = txtIm.Text;
                        pes.Ie = txtIe.Text;
                        pes.Fornecimento = txtFornecimento.Text;
                        pes.Rs = txtRs.Text;

                        pes.Email = txtEmail.Text;
                        pes.Cel = mskCel.Text;
                        pes.Tel = mskTel.Text;
                        pes.Obs = txtObs.Text;

                        pesDAO.Update(pes);
                        //pesDAO.VerificaID();

                        //end.Tipo = "Primário";
                        end.Cep = mskCep.Text;
                        end.Uf = txtUf.Text;
                        end.Cidade = txtCidade.Text;
                        end.Bairro = txtBairro.Text;
                        end.Rua = txtRua.Text;
                        try
                        {
                            end.N_casa = Convert.ToInt32(txtN.Text);
                        }
                        catch
                        {

                        }

                        end.Id_pessoa = pesDAO.Pes.Id_pessoa;
                        endDAO.Update3(end);

                        string id = pesDAO.Pes.Id_pessoa.ToString();

                        tpsDAO.Excluir(id);

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text != string.Empty)
                        {

                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }


                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo4.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }
                        }

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text == string.Empty && cmbTipo2.Text == string.Empty && cmbTipo4.Text == string.Empty)
                        {

                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                        }

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text == string.Empty && cmbTipo4.Text == string.Empty)
                        {

                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }


                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                        }

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text == string.Empty)
                        {

                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }


                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }


                            tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                        }

                        MessageBox.Show("Informações atualizadas com sucesso!");

                        Bloq();


                        aud.Acao = "ATUALIZOU PESSOA FÍSICA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas!!!");
                    }

                }
            }
            #endregion

            #region JURÍDICA
            else
            {
                if (mskCnpjPesquisa.MaskFull == true)
                {
                    if (txtNome.Text == string.Empty)
                    {
                        if (txtNome.Text == string.Empty)
                            txtNome.BackColor = Color.Red;

                        MessageBox.Show("Favor preencher o campo em vermelho!!!");

                    }
                    else
                    {
                        try
                        {
                            pes.Nome = txtNome.Text;
                            pes.Tipo = "Jurídica";
                            pes.Cpfnj = mskCnpjPesquisa.Text;
                            pes.Im = txtIm.Text;
                            pes.Ie = txtIe.Text;
                            pes.Rs = txtRs.Text;
                            pes.Fornecimento = txtFornecimento.Text;



                            pes.Email = txtEmail.Text;
                            pes.Cel = mskCel.Text;
                            pes.Tel = mskTel.Text;
                            pes.Obs = txtObs.Text;

                            pesDAO.Update(pes);
                            //pesDAO.VerificaID();

                            end.Tipo = "Primário";
                            end.Cep = mskCep.Text;
                            end.Uf = txtUf.Text;
                            end.Cidade = txtCidade.Text;
                            end.Bairro = txtBairro.Text;
                            end.Rua = txtRua.Text;
                            try
                            {
                                end.N_casa = Convert.ToInt32(txtN.Text);
                            }
                            catch
                            {

                            }

                            end.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            endDAO.Update3(end);

                            tpsDAO.Excluir(pesDAO.Pes.Id_pessoa.ToString());

                            if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text != string.Empty)
                            {

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo4.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }
                            }

                            if (cmbTipo1.Text != string.Empty && cmbTipo3.Text == string.Empty && cmbTipo2.Text == string.Empty && cmbTipo4.Text == string.Empty)
                            {

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                                tpsDAO.Inserir(tp);
                            }

                            if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text == string.Empty && cmbTipo4.Text == string.Empty)
                            {

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                                tpsDAO.Inserir(tp);

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                tpsDAO.Inserir(tp);
                            }

                            if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text == string.Empty)
                            {

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                                try
                                {
                                    tpsDAO.Inserir(tp);
                                }
                                catch
                                {

                                }
                            }

                            MessageBox.Show("Informações atualizadas com sucesso!");

                            Bloq();


                            aud.Acao = "ATUALIZOU PESSOA JURÍDICA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                        }
                        catch
                        {
                            MessageBox.Show("Favor verificar as informações digitadas!!!");
                        }


                    }

                }





            }
            #endregion

            #region NOME
            if (txtPesqNome.Text != string.Empty)
            {
                if (txtNome.Text == string.Empty)
                {
                    if (txtNome.Text == string.Empty)
                        txtNome.BackColor = Color.Red;

                    MessageBox.Show("Favor preencher o campo em vermelho!!!");

                }
                else
                {
                    try
                    {
                        pes.Nome = txtNome.Text;
                        pes.Tipo = lblFisJur.Text;
                        pes.Cpfnj = txtCpfnj.Text;
                        pes.Im = txtIm.Text;
                        pes.Ie = txtIe.Text;
                        pes.Fornecimento = txtFornecimento.Text;
                        pes.Rs = txtRs.Text;

                        pes.Email = txtEmail.Text;
                        pes.Cel = mskCel.Text;
                        pes.Tel = mskTel.Text;
                        pes.Obs = txtObs.Text;

                        pesDAO.Update(pes);

                        end.Cep = mskCep.Text;
                        end.Uf = txtUf.Text;
                        end.Cidade = txtCidade.Text;
                        end.Bairro = txtBairro.Text;
                        end.Rua = txtRua.Text;
                        try
                        {
                            end.N_casa = Convert.ToInt32(txtN.Text);
                        }
                        catch
                        {

                        }

                        end.Id_pessoa = pesDAO.Pes.Id_pessoa;
                        endDAO.Update3(end);



                        if (pesDAO.Listapessoa == null)
                        {
                            id = pesDAO.Pes.Id_pessoa.ToString();
                        }
                        else
                        {
                            id = pesDAO.Listapessoa.Rows[i]["ID"].ToString();
                        }



                        tpsDAO.Excluir(id);

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text != string.Empty)
                        {

                            if (pesDAO.Listapessoa == null)
                            {
                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            }
                            else
                            {
                                tp.Id_pessoa = Convert.ToInt32(pesDAO.Listapessoa.Rows[i]["ID"].ToString());
                            }





                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }



                            tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }


                            tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }


                            tp.Id_tipo = Convert.ToInt32(cmbTipo4.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }
                        }

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text == string.Empty && cmbTipo2.Text == string.Empty && cmbTipo4.Text == string.Empty)
                        {

                            if (pesDAO.Listapessoa == null)
                            {
                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            }
                            else
                            {
                                tp.Id_pessoa = Convert.ToInt32(pesDAO.Listapessoa.Rows[i]["ID"].ToString());
                            }
                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                        }

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text == string.Empty && cmbTipo4.Text == string.Empty)
                        {



                            if (pesDAO.Listapessoa == null)
                            {
                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            }
                            else
                            {
                                tp.Id_pessoa = Convert.ToInt32(pesDAO.Listapessoa.Rows[i]["ID"].ToString());
                            }





                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }



                            tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                        }

                        if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text == string.Empty)
                        {

                            if (pesDAO.Listapessoa == null)
                            {
                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                            }
                            else
                            {
                                tp.Id_pessoa = Convert.ToInt32(pesDAO.Listapessoa.Rows[i]["ID"].ToString());
                            }
                            tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                            tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                            tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                            try
                            {
                                tpsDAO.Inserir(tp);
                            }
                            catch
                            {

                            }

                        }

                        MessageBox.Show("Informações atualizadas com sucesso!");

                        Bloq();


                        aud.Acao = "ATUALIZAR PESSOA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas!!!");
                    }

                }
            }
            #endregion
        }

        private void mskCep_TextChanged(object sender, EventArgs e)
        {
            mskCep.BackColor = Color.Empty;
            if (mskCep.MaskFull == true)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCep.Text);

                    ds.ReadXml(xml);

                    txtRua.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                    txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                    txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                    txtUf.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "O CEP digitado é invalido");
                }
            }
            else
            {
                txtBairro.Clear();
                txtUf.Clear();
                txtRua.Clear();
                txtCidade.Clear();
            }
        }

        private void mskCpfPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtIm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtRs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtFornecimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtUf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtBairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtRua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskCel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtObs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtIe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void cmbTipo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void cmbTipo1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void cmbTipo3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void cmbTipo4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void chkCpfCnpj_CheckedChanged(object sender, EventArgs e)
        {
            Bloq();
            if (chkCpfCnpj.Checked == true)
            {
                lblCpf.Visible = true;
                lblCnpjPesq.Visible = true;
                mskCpfPesquisa.Visible = true;
                mskCnpjPesquisa.Visible = true;
                lblNomee.Visible = false;
                txtPesqNome.Visible = false;
                chkNome.Enabled = false;
            }
            else
            {
                lblCpf.Visible = false;
                lblCnpjPesq.Visible = false;
                mskCpfPesquisa.Visible = false;
                mskCnpjPesquisa.Visible = false;
                chkNome.Enabled = true;
            }
        }

        private void chkNome_CheckedChanged(object sender, EventArgs e)
        {
            Bloq();
            if (chkNome.Checked == true)
            {
                lblNomee.Visible = true;
                txtPesqNome.Visible = true;
                chkCpfCnpj.Enabled = false;
                btnAnt.Visible = true;
                btnProx.Visible = true;
            }
            else
            {
                lblNomee.Visible = false;
                txtPesqNome.Visible = false;
                chkCpfCnpj.Enabled = true;
                txtPesqNome.Clear();
                btnAnt.Visible = false;
                btnProx.Visible = false;
            }
        }

        private void btnProx_Click(object sender, EventArgs e)
        {
            btnAnt.Enabled = true;

            i++;

            if (i < qtdRegistro)
            {
                codpes = pesDAO.Listapessoa.Rows[i]["ID"].ToString();

                txtCpfnj.Text = pesDAO.Listapessoa.Rows[i]["cpfnj"].ToString();
                txtBairro.Text = pesDAO.Listapessoa.Rows[i]["bairro"].ToString();
                txtCidade.Text = pesDAO.Listapessoa.Rows[i]["cidade"].ToString();
                txtIm.Text = pesDAO.Listapessoa.Rows[i]["im"].ToString();
                txtUf.Text = pesDAO.Listapessoa.Rows[i]["uf"].ToString();
                lblFisJur.Text = pesDAO.Listapessoa.Rows[i]["fisjur"].ToString();

                txtNome.Text = pesDAO.Listapessoa.Rows[i]["nome"].ToString();
                txtN.Text = pesDAO.Listapessoa.Rows[i]["num"].ToString();
                txtRua.Text = pesDAO.Listapessoa.Rows[i]["rua"].ToString();

                mskCep.Text = pesDAO.Listapessoa.Rows[i]["cep"].ToString();
                txtIe.Text = pesDAO.Listapessoa.Rows[i]["ie"].ToString();
                txtFornecimento.Text = pesDAO.Listapessoa.Rows[i]["fornecimento"].ToString();
                txtEmail.Text = pesDAO.Listapessoa.Rows[i]["email"].ToString();
                mskTel.Text = pesDAO.Listapessoa.Rows[i]["tel"].ToString();
                mskCel.Text = pesDAO.Listapessoa.Rows[i]["cel"].ToString();
                txtObs.Text = pesDAO.Listapessoa.Rows[i]["obs"].ToString();
                txtRs.Text = pesDAO.Listapessoa.Rows[i]["rs"].ToString();
            }
            else
            {
                btnProx.Enabled = false;
            }

            if (i == qtdRegistro - 1)
            {
                btnProx.Enabled = false;
            }

            pesDAO.VerificaTipo(txtCpfnj.Text);
            try
            {
                cmbTipo1.Text = PessoaDAO.tp0.ToString();
            }
            catch
            {
                cmbTipo1.Text = "";
            }
            try
            {
                cmbTipo3.Text = PessoaDAO.tp1.ToString();
            }
            catch
            {
                cmbTipo3.Text = "";
            }
            try
            {
                cmbTipo2.Text = PessoaDAO.tp2.ToString();
            }
            catch
            {
                cmbTipo2.Text = "";
            }
            try
            {
                cmbTipo4.Text = PessoaDAO.tp3.ToString();
            }
            catch
            {
                cmbTipo4.Text = "";
            }
        }

        private void btnAnt_Click(object sender, EventArgs e)
        {
            btnProx.Enabled = true;

            i--;

            if (i >= 0)
            {
                codpes = pesDAO.Listapessoa.Rows[i]["ID"].ToString();

                txtCpfnj.Text = pesDAO.Listapessoa.Rows[i]["cpfnj"].ToString();
                txtBairro.Text = pesDAO.Listapessoa.Rows[i]["bairro"].ToString();
                txtCidade.Text = pesDAO.Listapessoa.Rows[i]["cidade"].ToString();
                txtIm.Text = pesDAO.Listapessoa.Rows[i]["im"].ToString();
                txtUf.Text = pesDAO.Listapessoa.Rows[i]["uf"].ToString();
                lblFisJur.Text = pesDAO.Listapessoa.Rows[i]["fisjur"].ToString();

                txtNome.Text = pesDAO.Listapessoa.Rows[i]["nome"].ToString();
                txtN.Text = pesDAO.Listapessoa.Rows[i]["NUM"].ToString();
                txtRua.Text = pesDAO.Listapessoa.Rows[i]["rua"].ToString();

                mskCep.Text = pesDAO.Listapessoa.Rows[i]["cep"].ToString();
                txtIe.Text = pesDAO.Listapessoa.Rows[i]["ie"].ToString();
                txtFornecimento.Text = pesDAO.Listapessoa.Rows[i]["fornecimento"].ToString();
                txtEmail.Text = pesDAO.Listapessoa.Rows[i]["email"].ToString();
                mskTel.Text = pesDAO.Listapessoa.Rows[i]["tel"].ToString();
                mskCel.Text = pesDAO.Listapessoa.Rows[i]["cel"].ToString();
                txtObs.Text = pesDAO.Listapessoa.Rows[i]["obs"].ToString();
                txtRs.Text = pesDAO.Listapessoa.Rows[i]["rs"].ToString();

                if (i == 0)
                {
                    btnAnt.Enabled = false;
                }

                pesDAO.VerificaTipo(txtCpfnj.Text);
                try
                {
                    cmbTipo1.Text = PessoaDAO.tp0.ToString();
                }
                catch
                {
                    cmbTipo1.Text = "";
                }
                try
                {
                    cmbTipo3.Text = PessoaDAO.tp1.ToString();
                }
                catch
                {
                    cmbTipo3.Text = "";
                }
                try
                {
                    cmbTipo2.Text = PessoaDAO.tp2.ToString();
                }
                catch
                {
                    cmbTipo2.Text = "";
                }
                try
                {
                    cmbTipo4.Text = PessoaDAO.tp3.ToString();
                }
                catch
                {
                    cmbTipo4.Text = "";
                }
            }
        }
        private void txtRua_TextChanged(object sender, EventArgs e)
        {
            txtRua.BackColor = Color.Empty;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.Empty;
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }

        private void txtFornecimento_TextChanged(object sender, EventArgs e)
        {
            txtRs.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }

        private void txtUf_TextChanged(object sender, EventArgs e)
        {
            txtUf.BackColor = Color.Empty;
        }

        private void txtN_TextChanged(object sender, EventArgs e)
        {
            txtN.BackColor = Color.Empty;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void txtCpfnj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtPesqNome_TextChanged(object sender, EventArgs e)
        {
            if (txtPesqNome.Text != string.Empty)
            {
                if (pesDAO.VerificaNOMEPESQ(txtPesqNome.Text) == true)
                {
                    codpes = pesDAO.Pes.Id_pessoa.ToString();

                    lblFisJur.Text = pesDAO.Pes.Fisjur.ToString();
                    txtCpfnj.Text = pesDAO.Pes.Cpfnj.ToString();
                    txtN.Text = pesDAO.Pes.N_casa.ToString();
                    txtNome.Text = pesDAO.Pes.Nome;
                    txtIm.Text = pesDAO.Pes.Im;
                    txtIe.Text = pesDAO.Pes.Ie;
                    txtFornecimento.Text = pesDAO.Pes.Fornecimento;
                    txtRs.Text = pesDAO.Pes.Rs;
                    mskCep.Text = pesDAO.Pes.Cep;
                    txtBairro.Text = pesDAO.Pes.Bairro;
                    txtUf.Text = pesDAO.Pes.Uf;
                    txtRua.Text = pesDAO.Pes.Rua;
                    txtCidade.Text = pesDAO.Pes.Cidade;
                    mskCel.Text = pesDAO.Pes.Cel;
                    mskTel.Text = pesDAO.Pes.Tel;
                    txtEmail.Text = pesDAO.Pes.Email;
                    txtObs.Text = pesDAO.Pes.Obs;

                    update = true;

                    CarregarComboTipo();
                    CarregarComboTipo2();
                    CarregarComboTipo3();
                    CarregarComboTipo4();
                    txtNome.Enabled = true;
                    txtUf.Enabled = true;
                    mskCep.Enabled = true;
                    txtRua.Enabled = true;
                    txtN.Enabled = true;
                    txtCidade.Enabled = true;
                    mskTel.Enabled = true;
                    mskCel.Enabled = true;
                    txtBairro.Enabled = true;
                    txtEmail.Enabled = true;
                    txtObs.Enabled = true;
                    chkIe.Enabled = true;
                    txtIm.Enabled = true;
                    txtFornecimento.Enabled = true;
                    txtRs.Enabled = true;
                    cmbTipo1.Enabled = true;
                    txtNome.Visible = true;
                    lblNome.Visible = true;
                    txtCpfnj.Visible = true;
                    lblCpfNj.Visible = true;

                    if (pesDAO.Listapessoa != null)
                    {
                        qtdRegistro = pesDAO.Listapessoa.Rows.Count;

                        i = 0;

                        btnProx.Enabled = true;
                    }
                    else
                    {
                        btnProx.Enabled = false;
                        btnAnt.Enabled = false;
                    }

                    pesDAO.VerificaTipo(txtCpfnj.Text);
                    try
                    {
                        cmbTipo1.Text = PessoaDAO.tp0.ToString();
                    }
                    catch
                    {
                        cmbTipo1.Text = "";
                    }
                    try
                    {
                        cmbTipo3.Text = PessoaDAO.tp1.ToString();
                    }
                    catch
                    {
                        cmbTipo3.Text = "";
                    }
                    try
                    {
                        cmbTipo2.Text = PessoaDAO.tp2.ToString();
                    }
                    catch
                    {
                        cmbTipo2.Text = "";
                    }
                    try
                    {
                        cmbTipo4.Text = PessoaDAO.tp3.ToString();
                    }
                    catch
                    {
                        cmbTipo4.Text = "";
                    }
                }
                else
                {
                    txtN.Clear();
                    txtNome.Clear();
                    txtRs.Clear();
                    txtCidade.Clear();
                    txtUf.Clear();
                    txtRua.Clear();
                    txtFornecimento.Clear();
                    txtIm.Clear();
                    mskCel.Clear();
                    mskTel.Clear();
                    txtObs.Clear();
                    txtBairro.Clear();
                    mskCnpjPesquisa.Clear();
                    txtEmail.Clear();
                    mskCep.Clear();
                    cmbTipo1.Text = "";
                    cmbTipo2.Text = "";
                    cmbTipo3.Text = "";
                    cmbTipo4.Text = "";
                    txtCpfnj.Clear();
                    lblFisJur.Text = "";

                    txtN.Enabled = false;
                    txtNome.Enabled = false;
                    mskCep.Enabled = false;
                    txtUf.Enabled = false;
                    txtCidade.Enabled = false;
                    txtBairro.Enabled = false;
                    txtEmail.Enabled = false;
                    txtRua.Enabled = false;
                    mskCel.Enabled = false;
                    mskTel.Enabled = false;
                    txtObs.Enabled = false;
                    txtRs.Enabled = false;
                    txtFornecimento.Enabled = false;
                    txtIm.Enabled = false;
                    cmbTipo1.Enabled = false;
                    cmbTipo2.Enabled = false;
                    cmbTipo3.Enabled = false;
                    cmbTipo4.Enabled = false;
                    txtNome.Visible = false;
                    lblNome.Visible = false;
                    txtCpfnj.Visible = false;
                    lblCpfNj.Visible = false;
                    btnProx.Enabled = false;
                    btnAnt.Enabled = false;
                }
            }
            else
            {
                txtPesqNome.BackColor = Color.Empty;

                update = false;

                txtN.Clear();
                txtNome.Clear();
                txtRs.Clear();
                txtCidade.Clear();
                txtUf.Clear();
                txtRua.Clear();
                txtFornecimento.Clear();
                txtIm.Clear();
                mskCel.Clear();
                mskTel.Clear();
                txtObs.Clear();
                txtBairro.Clear();
                mskCnpjPesquisa.Clear();
                txtEmail.Clear();
                mskCep.Clear();
                cmbTipo1.Text = "";
                cmbTipo2.Text = "";
                cmbTipo3.Text = "";
                cmbTipo4.Text = "";
                txtCpfnj.Clear();
                txtCpfnj.Visible = false;
                lblCpfNj.Visible = false;
                lblFisJur.Text = "";

                txtN.Enabled = false;
                txtNome.Enabled = false;
                mskCep.Enabled = false;
                txtUf.Enabled = false;
                txtCidade.Enabled = false;
                txtBairro.Enabled = false;
                txtEmail.Enabled = false;
                txtRua.Enabled = false;
                mskCel.Enabled = false;
                mskTel.Enabled = false;
                txtObs.Enabled = false;
                txtRs.Enabled = false;
                txtFornecimento.Enabled = false;
                txtIm.Enabled = false;
                cmbTipo1.Enabled = false;
                cmbTipo2.Enabled = false;
                cmbTipo3.Enabled = false;
                cmbTipo4.Enabled = false;
                txtNome.Visible = false;
                lblNome.Visible = false;
                btnProx.Enabled = false;
                btnAnt.Enabled = false;
            }
        }
    }
}
