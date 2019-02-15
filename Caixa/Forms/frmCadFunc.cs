using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmCadFunc : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        Pessoa pes = new Pessoa();
        PessoaDAO pesDAO = new PessoaDAO();
        TipoDAO tpDAO = new TipoDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        Contato contato = new Contato();
        ContatoDAO contatoDAO = new ContatoDAO();
        EnderecoDAO endDAO = new EnderecoDAO();
        Endereco end = new Endereco();
      
        TipopessoaDAO tpsDAO = new TipopessoaDAO();
        Tipopessoa tp = new Tipopessoa();
     
        #endregion

        #region VAR
        string codtp;
        string codtp2;
        string codtp3;
        string codtp4;
        string codtp5;
        string codtp6;
        string codnome;
        string codnome2;



#pragma warning disable CS0414 // O campo "frmCadFunc.update" é atribuído, mas seu valor nunca é usado
        Boolean update;
#pragma warning restore CS0414 // O campo "frmCadFunc.update" é atribuído, mas seu valor nunca é usado
        Boolean updatec;
#pragma warning disable CS0414 // O campo "frmCadFunc.Pesquisa" é atribuído, mas seu valor nunca é usado
        Boolean Pesquisa;
#pragma warning restore CS0414 // O campo "frmCadFunc.Pesquisa" é atribuído, mas seu valor nunca é usado
        Boolean PesquisaEnd;
        string id_con;

        #endregion
        public frmCadFunc()
        {
            InitializeComponent();
        }

        private void frmCadFunc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtRs.BackColor = Color.Empty;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            #region FÍSICO
            if (rdbFis.Checked == true)
            {                
                    if (mskCpf.MaskFull == false || txtNome.Text == string.Empty)
                    {
                   
                        if (mskCpf.MaskFull == false)
                            mskCpf.BackColor = Color.Red;                                   

                        if (txtNome.Text == string.Empty)
                            txtNome.BackColor = Color.Red;
                 


                        MessageBox.Show("Favor preencher os campos em vermelho!!!");

                    }
                    else
                    {
                       
                            try
                            {
                                pes.Nome = txtNome.Text;
                                pes.Tipo = "Física";
                                pes.Cpfnj = mskCpf.Text;
                                pes.Im = txtIm.Text;
                                pes.Ie = txtIe.Text;
                                pes.Fornecimento = txtFornecimento.Text;
                                pes.Rs = txtRs.Text;

                                pes.Email = txtEmail.Text;
                                pes.Cel = mskCel.Text;
                                pes.Tel = mskTel.Text;
                                pes.Obs = txtObs.Text;

                                pesDAO.Inserir(pes);
                                pesDAO.VerificaID();

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
                                endDAO.Inserir(end);

                            if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text != string.Empty)
                            {

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                                tpsDAO.Inserir(tp);

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                tpsDAO.Inserir(tp);

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                                tpsDAO.Inserir(tp);

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo4.SelectedValue);
                                tpsDAO.Inserir(tp);
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
                                tpsDAO.Inserir(tp);

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                tpsDAO.Inserir(tp);

                                tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                                tpsDAO.Inserir(tp);
                            }
      
                                MessageBox.Show("Informações cadastradas com sucesso!");

                                Bloq();


                                aud.Acao = "INSERIU PESSOA FÍSICA";
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
                if (rdbJur.Checked == true)
                {                  
                        if (mskCnpj.MaskFull == false || txtNome.Text == string.Empty)
                    {
                            if (mskCnpj.MaskFull == false)
                                mskCnpj.BackColor = Color.Red;

                            if (txtNome.Text == string.Empty)
                                txtNome.BackColor = Color.Red;
                          

                            MessageBox.Show("Favor preencher os campos em vermelho!!!");

                        }
                        else
                        {                          
                                try
                                {


                                    pes.Nome = txtNome.Text;
                                    pes.Tipo = "Jurídica";
                                    pes.Cpfnj = mskCnpj.Text;
                                    pes.Im = txtIm.Text;
                                    pes.Ie = txtIe.Text;
                                    pes.Rs = txtRs.Text;
                                    pes.Fornecimento = txtFornecimento.Text;



                                    pes.Email = txtEmail.Text;
                                    pes.Cel = mskCel.Text;
                                    pes.Tel = mskTel.Text;
                                    pes.Obs = txtObs.Text;

                                    pesDAO.Inserir(pes);
                                    pesDAO.VerificaID();

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
                                    endDAO.Inserir(end);

                                if (cmbTipo1.Text != string.Empty && cmbTipo3.Text != string.Empty && cmbTipo2.Text != string.Empty && cmbTipo4.Text != string.Empty)
                                {

                                    tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                    tp.Id_tipo = Convert.ToInt32(cmbTipo1.SelectedValue);
                                    tpsDAO.Inserir(tp);

                                    tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                    tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                    tpsDAO.Inserir(tp);

                                    tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                    tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                                    tpsDAO.Inserir(tp);

                                    tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                    tp.Id_tipo = Convert.ToInt32(cmbTipo4.SelectedValue);
                                    tpsDAO.Inserir(tp);
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
                                    tpsDAO.Inserir(tp);

                                    tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                    tp.Id_tipo = Convert.ToInt32(cmbTipo3.SelectedValue);
                                    tpsDAO.Inserir(tp);

                                    tp.Id_pessoa = pesDAO.Pes.Id_pessoa;
                                    tp.Id_tipo = Convert.ToInt32(cmbTipo2.SelectedValue);
                                    tpsDAO.Inserir(tp);
                                }

                                MessageBox.Show("Informações cadastradas com sucesso!");

                                    Bloq();

                                    aud.Acao = "INSERIU PESSOA JURÍDICA";
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
        }

        public void AtualizaDados()
        {
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                //gvExibir.DataSource = pesDAO.ListarNT();
            }
            catch
            {

            }
        }
        private void frmCadFunc_Load(object sender, EventArgs e)
        {        
            CarregarComboTipo5();
            CarregarComboTipo6();
          
            cmbNome.Text = "";

            tipExp.InitialDelay = 500;
            tipExp.AutoPopDelay = 3000;
            tipExp.SetToolTip(this.btnCadastrar, "Salvar Informações");
            tipExp.SetToolTip(this.btnLimpar, "Cancelar");
            tipExp.SetToolTip(this.btnPesq, "Pesquisar/Alterar");

            cmbTipo5.Text = "";
            cmbTipo6.Text = "";

        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            frmTipo tp = new frmTipo();
            tp.Owner = this;
            tp.ShowDialog();

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //codtp = cmbTipo.SelectedValue.ToString();
        }

        private void rdbFis_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFis.Checked == true)
            {
                lblCpf.Visible = true;
                mskCpf.Visible = true;
                lblCnpj.Visible = false;
                mskCnpj.Visible = false;
                chkIe.Enabled = true;
                chkIe.Checked = false;
                mskCnpj.Clear();
                mskCpf.Enabled = true;

                CarregarComboTipo();
                CarregarComboTipo2();
                CarregarComboTipo3();
                CarregarComboTipo4();
                

                cmbTipo3.Text = "";
                cmbTipo2.Text = "";
                cmbTipo4.Text = "";
         
                txtNome.Enabled = true;
                txtNome.Visible = true;
                lblNome.Visible = true;
                txtRua.Enabled = true;
                txtNome.Visible = true;
                txtObs.Enabled = true;
                txtUf.Enabled = true;
                txtEmail.Enabled = true;
                txtCidade.Enabled = true;
                txtBairro.Enabled = true;
                cmbTipo1.Enabled = true;
                mskCel.Enabled = true;
                txtFornecimento.Enabled = true;
                txtIm.Enabled = true;
                txtN.Enabled = true;
                mskTel.Enabled = true;
                txtRs.Enabled = true;
                mskCep.Enabled = true;
                lblFantasia.Visible = false;
                this.ProcessTabKey(true);
            }
            else
            {
                lblCpf.Visible = false;
                mskCpf.Visible = false;
                chkIe.Enabled = false;
                txtNome.Enabled = false;
                lblNome.Visible = false;
                txtNome.Visible = false;
                lblCnpj.Visible = false;
                mskCnpj.Visible = false;
            }
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

        public void CarregarComboTipo5()
        {
            cmbTipo5.DataSource = tpDAO.ListarTipo();
            cmbTipo5.DisplayMember = "tipo";
            cmbTipo5.ValueMember = "ID";
        }

        public void CarregarComboTipo6()
        {
            cmbTipo6.DataSource = tpDAO.ListarTipo();
            cmbTipo6.DisplayMember = "tipo";
            cmbTipo6.ValueMember = "ID";
        }

        public void CarregarComboNome()
        {
            cmbNome.DataSource = pesDAO.ListarIDT(codtp5);
            cmbNome.DisplayMember = "NOME";
            cmbNome.ValueMember = "ID";
            try
            {
                codnome = cmbNome.SelectedValue.ToString();
                gvExibir.DataSource = contatoDAO.ListarID(codnome);
            }
            catch
            {

            }
        }

        public void CarregarComboNome2()
        {
            cmbNome2.DataSource = pesDAO.ListarIDT(codtp6);
            cmbNome2.DisplayMember = "NOME";
            cmbNome2.ValueMember = "ID";

        }

        private void rdbJur_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbJur.Checked == true)
            {

                lblCpf.Visible = false;
                mskCpf.Visible = false;
                lblCnpj.Visible = true;
                mskCnpj.Visible = true;
                chkIe.Enabled = true;
                chkIe.Checked = false;
                mskCpf.Clear();
                mskCnpj.Enabled = true;

                CarregarComboTipo();
                CarregarComboTipo2();
                CarregarComboTipo3();
                CarregarComboTipo4();

                cmbTipo3.Text = "";
                cmbTipo2.Text = "";
                cmbTipo4.Text = "";

                lblFantasia.Visible = true;
                txtRua.Enabled = true;
                txtNome.Visible = true;
                txtNome.Enabled = true;
                txtObs.Enabled = true;
                txtUf.Enabled = true;
                txtEmail.Enabled = true;
                txtCidade.Enabled = true;
                txtBairro.Enabled = true;
                cmbTipo1.Enabled = true;
                mskCel.Enabled = true;
                txtFornecimento.Enabled = true;
                txtIe.Enabled = false;
                txtIm.Enabled = true;
                txtN.Enabled = true;
                mskTel.Enabled = true;
                txtRs.Enabled = true;
                mskCep.Enabled = true;                 

                this.ProcessTabKey(true);             
            }
            else
            {
                lblCnpj.Visible = false;
                mskCnpj.Visible = false;
                txtIe.Enabled = false;
                txtIm.Enabled = false;
            }
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

        private void mskCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbFornecimento_KeyDown(object sender, KeyEventArgs e)
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

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBairro_KeyDown(object sender, KeyEventArgs e)
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

        private void mskCpf_Leave(object sender, EventArgs e)
        {

        }

        private void mskCpf_TextChanged(object sender, EventArgs e)
        {
            if (mskCpf.MaskFull == true)
            {
                if (pesDAO.VerificaCPF(mskCpf.Text) == true)
                {
                    MessageBox.Show("CPF já cadastrado no sistema");
                    mskCpf.Text = "";
                }
                else
                {
                    validacpf validar = new validacpf();
                    if (validar.VerificarCpf(mskCpf.Text) == true)
                    {

                        if (pesDAO.VerificaCPF(mskCpf.Text) == true)
                        {
                            mskCpf.Clear();
                            MessageBox.Show("Este CPF já foi cadastrado !!!");
                        }
                        else
                        {
                            pctCerto.Visible = true;
                            this.ProcessTabKey(true);
                            string CpfSenha = mskCpf.Text.Substring(0, 3);
                            btnCadastrar.Enabled = true;
                        }                 
                    }
                    else
                    {
                        pctCerto.Visible = false;
                        pctErrado.Visible = true;
                        btnCadastrar.Enabled = false;
                    }
                }
            }
            else
            {
                gvExibir.DataSource = null;

                btnCadastrar.Enabled = true;
                mskCpf.BackColor = Color.Empty;
                pctCerto.Visible = false;
                pctErrado.Visible = false;
                update = false;
                rdbJur.Enabled = true;

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
                mskCnpj.Clear();
                txtEmail.Clear();
                mskCep.Clear();
            }
        }

        private void mskCnpj_TextChanged(object sender, EventArgs e)
        {
            if (mskCnpj.MaskFull == true)
            {
                if (pesDAO.VerificaCPF(mskCnpj.Text) == true)
                {                 
                    MessageBox.Show("CNPJ já cadastrado no sistema");
                    mskCnpj.Text = "";
                }
                else
                {
                    validacnpj valida = new validacnpj();
                    if (valida.VerificaCnpj(mskCnpj.Text))
                    {
                        if (pesDAO.VerificaCPF(mskCpf.Text) == true)
                        {
                            mskCpf.Clear();
                            MessageBox.Show("Este CPF já foi cadastrado !!!");
                        }
                        else
                        {
                            pctCerto.Visible = true;
                            this.ProcessTabKey(true);
                            string CpfSenha = mskCpf.Text.Substring(0, 3);
                            btnCadastrar.Enabled = true;
                        }

                    }
                    else
                    {
                        pctCerto.Visible = false;
                        pctErrado.Visible = true;
                        btnCadastrar.Enabled = false;
                       

                    }
                }
            }
            else
            {
                gvExibir.DataSource = null;
                //lblEmpresa.Text = "";

                mskCnpj.BackColor = Color.Empty;
                pctCerto.Visible = false;
                pctErrado.Visible = false;
                update = false;
                rdbFis.Enabled = true;
                btnCadastrar.Enabled = true;
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
                txtEmail.Clear();
                mskCep.Clear();                
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Limpar();

            Pesquisa = false;
            //chkCli.Checked = false;
            //chkFornecedor.Checked = false;
            //chkFunc.Checked = false;
            rdbFis.Checked = false;
            rdbJur.Checked = false;
            txtN.Enabled = false;
            //chkCli.Enabled = false;
            //chkFornecedor.Enabled = false;
            //chkFunc.Enabled = false;
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
            txtIe.Enabled = false;
            txtIm.Enabled = false;
            txtIe.Visible = true;
            txtIm.Visible = true;
            chkIe.Enabled = false;
            chkIe.Checked = false;
            lblFantasia.Visible = false;
       
            cmbTipo1.Enabled = false;

            //chkFunc2.Visible = false;
            //chkFunc2.Checked = false;
            //chkFornecedor2.Checked = false;
            //chkFornecedor2.Visible = false;
            //chkCli2.Checked = false;
            //chkCli2.Visible = false;
            txtEmailc.Enabled = false;
            txtEmailc.Clear();
            txtNomeec.Clear();
            txtNomeec.Enabled = false;
            txtDepartamento.Enabled = false;
            txtDepartamento.Clear();
            mskTelc.Enabled = false;
            mskTelc.Clear();
            btnNovoc.Enabled = true;
            
        }
        public void Bloq()
        {
            Limpar();


            rdbFis.Checked = false;
            rdbJur.Checked = false;
            mskCpf.Enabled = false;
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
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (updatec == true)
            {
                #region UPDATE
                if (txtNomeec.Text == string.Empty || mskTelc.MaskFull == false
               || txtEmailc.Text == string.Empty || txtDepartamento.Text == string.Empty)
                {
                    if (txtNomeec.Text == string.Empty)
                        txtNomeec.BackColor = Color.Red;

                    if (mskTelc.MaskFull == false)
                        mskTelc.BackColor = Color.Red;

                    if (txtEmailc.Text == string.Empty)
                        txtEmailc.BackColor = Color.Red;

                    if (txtDepartamento.Text == string.Empty)
                        txtDepartamento.BackColor = Color.Red;

                    MessageBox.Show("Favor preencher os campos em vermelho !!!");


                }
                else
                {
                    try
                    {
                        if (txtEmailc.Text.Contains("@") == true && txtEmailc.Text.Contains("."))
                        {
                            try
                            {

                                contato.Id_contato = Convert.ToInt32(id_con);
                                contato.Nome = txtNomeec.Text;
                                contato.Telefone = mskTelc.Text;
                                contato.Dep = txtDepartamento.Text;
                                contato.Email = txtEmailc.Text;
                                

                                contatoDAO.Update(contato);

                                MessageBox.Show("Informações atualizadas com sucesso!!!");
                                gvExibir.DataSource = contatoDAO.ListarID(pesDAO.Pes.Id_pessoa.ToString());
                                LimparContato();


                                aud.Acao = "ATUALIZOU INFORMAÇÕES DE CONTATO";
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
                        else
                        {
                            MessageBox.Show("E-mail inválido!!!");
                            txtEmail.BackColor = Color.Red;
                        }
                    }
                    catch
                    {

                    }
                }
                #endregion
            }
            else
            {
                #region INSERIR
                if (txtNomeec.Text == string.Empty || mskTelc.MaskFull == false
               || txtEmailc.Text == string.Empty || txtDepartamento.Text == string.Empty)
                {
                    if (txtNomeec.Text == string.Empty)
                        txtNomeec.BackColor = Color.Red;

                    if (mskTelc.MaskFull == false)
                        mskTelc.BackColor = Color.Red;

                    if (txtEmailc.Text == string.Empty)
                        txtEmailc.BackColor = Color.Red;

                    if (txtDepartamento.Text == string.Empty)
                        txtDepartamento.BackColor = Color.Red;

                    MessageBox.Show("Favor preencher os campos em vermelho !!!");


                }
                else
                {
                    try
                    {
                        if (txtEmailc.Text.Contains("@") == true && txtEmailc.Text.Contains("."))
                        {
                            try
                            {
                                contato.Id_pessoa = Convert.ToInt32(codnome);
                                contato.Nome = txtNomeec.Text;
                                contato.Telefone = mskTelc.Text;
                                contato.Dep = txtDepartamento.Text;
                                contato.Email = txtEmailc.Text;
                                
                                contatoDAO.Inserir(contato);

                                MessageBox.Show("Informações salvas com sucesso!!!");
                                gvExibir.DataSource = contatoDAO.ListarID(pesDAO.Pes.Id_pessoa.ToString());
                                LimparContato();


                                aud.Acao = "INSERIU CONTATO";
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
                        else
                        {
                            MessageBox.Show("E-mail inválido!!!");
                            txtEmail.BackColor = Color.Red;
                        }
                    }
                    catch
                    {

                    }
                }
                #endregion
            }

        }

        private void txtUf_TextChanged(object sender, EventArgs e)
        {
            txtUf.BackColor = Color.Empty;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            rdbFis.Enabled = true;
            rdbJur.Enabled = true;
            mskCep.Enabled = true;
            //txtUf.Enabled = true;
            txtCidade.Enabled = true;
            txtBairro.Enabled = true;
            txtEmail.Enabled = true;
            //txtRua.Enabled = true;
            mskCel.Enabled = true;
            mskTel.Enabled = true;
            txtObs.Enabled = true;
            //txtN.Enabled = true;
        }

        private void txtIm_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtFornecimento_TextChanged(object sender, EventArgs e)
        {
            txtFornecimento.BackColor = Color.Empty;
        }

        private void txtRs_TextChanged(object sender, EventArgs e)
        {
            txtRs.BackColor = Color.Empty;
        }

        private void mskCep_TextChanged(object sender, EventArgs e)
        {
            mskCep.BackColor = Color.Empty;
            if(mskCep.MaskFull == true)
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

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.Empty;
        }

        private void txtRua_TextChanged(object sender, EventArgs e)
        {
            txtRua.BackColor = Color.Empty;       
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
           
        }

        private void mskCel_TextChanged(object sender, EventArgs e)
        {
            mskCel.BackColor = Color.Empty;
            if (mskCel.MaskFull == true)
            {
                this.ProcessTabKey(true);
            }
        }

        private void mskTel_TextChanged(object sender, EventArgs e)
        {
            mskTel.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }

        private void txtCidade_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNomec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtNomeec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskTelc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEmailc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtIe_TextChanged(object sender, EventArgs e)
        {
            txtIe.BackColor = Color.Empty;
        }

        public void Limpar()
        {
            txtN.Clear();
            txtNome.Clear();
            txtRs.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            txtRua.Clear();
            txtFornecimento.Clear();
            txtIe.Text = "Isento";
            txtIm.Clear();
            mskCel.Clear();
            mskCpf.Clear();
            mskTel.Clear();
            txtObs.Clear();
            txtBairro.Clear();
            mskCnpj.Clear();
            txtEmail.Clear();
            mskCep.Clear();
            cmbTipo1.Text = "";
            cmbTipo2.Text = "";
            cmbTipo3.Text = "";
            cmbTipo4.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult op;

            if (mskCpf.MaskFull == false && mskCnpj.MaskFull == false)
            {
                MessageBox.Show("Impossível excluir nada né amigão!!!!");
            }
            else
            {
                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {

                    if (rdbFis.Checked == true)
                    {
                        pesDAO.ExcluirCpfnj(mskCpf.Text);
                        MessageBox.Show("Excluído com sucesso !!!");
                        Limpar();

                        aud.Acao = "EXCLUIU PESSOA FÍSICA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    else
                    {
                        if (rdbJur.Checked == true)
                        {
                            pesDAO.ExcluirCpfnj(mskCnpj.Text);
                            MessageBox.Show("Excluído com sucesso !!!");
                            Limpar();

                            aud.Acao = "EXCLUIU PESSOA JURÍDICA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                        }

                    }
                }
                else
                {
                }
            }

        }

        private void btnNovoc_Click(object sender, EventArgs e)
        {
            updatec = false;
            txtNomeec.Enabled = true;
            txtEmailc.Enabled = true;
            mskTelc.Enabled = true;
            txtDepartamento.Enabled = true;
        }

        private void btnCancelarc_Click(object sender, EventArgs e)
        {
            txtNomeec.Enabled = false;
            txtEmailc.Enabled = false;
            mskTelc.Enabled = false;
            txtDepartamento.Enabled = false;
            LimparContato();
            btnNovoc.Enabled = true;
            cmbTipo5.Text = "";
            cmbNome.Text = "";
            gvExibir.DataSource = null;
        }

        private void txtNomeec_TextChanged(object sender, EventArgs e)
        {
            txtNomeec.BackColor = Color.Empty;
        }

        private void mskTelc_TextChanged(object sender, EventArgs e)
        {
            mskTelc.BackColor = Color.Empty;
            if (mskTelc.MaskFull == true)
            {
                this.ProcessTabKey(true);
            }
        }

        private void txtEmailc_TextChanged(object sender, EventArgs e)
        {
            txtEmailc.BackColor = Color.Empty;
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            txtDepartamento.BackColor = Color.Empty;
        }

        public void LimparContato()
        {
            txtEmailc.Clear();
            txtNomeec.Clear();
            txtDepartamento.Clear();
            mskTelc.Clear();
            txtEmailc.Enabled = false;
            txtNomeec.Enabled = false;
            txtDepartamento.Enabled = false;
            mskTelc.Enabled = false;
        }

        private void gvExibir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gvExibir.Rows[e.RowIndex];
                txtEmailc.Text = row.Cells["email"].Value.ToString();
                mskTelc.Text = row.Cells["TEL"].Value.ToString();
                txtNomeec.Text = row.Cells["NOME"].Value.ToString();
                txtDepartamento.Text = row.Cells["DEPARTAMENTO"].Value.ToString();

                id_con = row.Cells["ID"].Value.ToString();
                btnNovoc.Enabled = false;
                txtEmailc.Enabled = true;
                mskTelc.Enabled = true;
                txtNomeec.Enabled = true;
                txtDepartamento.Enabled = true;
                updatec = true;

            }
        }

        private void btnExcluirc_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Deseja realmente excluir?",
                "Excluir?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                pesDAO.ExcluirContato(id_con);
                MessageBox.Show("Excluído com sucesso !!!");
                LimparContato();

                gvExibir.DataSource = contatoDAO.ListarID(pesDAO.Pes.Id_pessoa.ToString());
                gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                btnNovoc.Enabled = true;


                aud.Acao = "EXCLUIU CONTATO";
                aud.Data = FechamentoDAO.data;
                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                aud.Responsavel = UsuarioDAO.login;
                audDAO.Inserir(aud);

            }
            else
            {

            }
        }
        

        private void txtN_TextChanged(object sender, EventArgs e)
        {
            txtN.BackColor = Color.Empty;
        }

        private void txtN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            Pesquisa = true;
            rdbFis.Enabled = true;
            rdbJur.Enabled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void mskCpf_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            mskCepC.Enabled = true;
            txtBairroC.Enabled = true;
            txtCompC.Enabled = true;
            txtUfC.Enabled = true;
            txtCidadeC.Enabled = true;
            txtNc.Enabled = true;
            txtRuaC.Enabled = true;

            mskCepE.Enabled = true;
            txtBairroee.Enabled = true;
            txtComplementoE.Enabled = true;
            txtUfE.Enabled = true;
            txtCidadeE.Enabled = true;
            txtNe.Enabled = true;
            txtRuaE.Enabled = true;
        }

        private void btnCancelarEnd_Click(object sender, EventArgs e)
        {
            mskCepC.Enabled = false;
            txtBairroC.Enabled = false;
            txtCompC.Enabled = false;
            txtUfC.Enabled = false;
            txtCidadeC.Enabled = false;
            txtNc.Enabled = false;
            txtRuaC.Enabled = false;

            mskCepE.Enabled = false;
            txtBairroee.Enabled = false;
            txtComplementoE.Enabled = false;
            txtUfE.Enabled = false;
            txtCidadeE.Enabled = false;
            txtNe.Enabled = false;
            txtRuaE.Enabled = false;


            mskCepC.Clear();
            txtBairroC.Clear();
            txtCompC.Clear();
            txtUfC.Clear();
            txtCidadeC.Clear();
            txtNc.Clear();
            txtRuaC.Clear();

            mskCepE.Clear();
            txtBairroee.Clear();
            txtComplementoE.Clear();
            txtUfE.Clear();
            txtCidadeE.Clear();
            txtNe.Clear();
            txtRuaE.Clear();           

            cmbNome2.Text = "";
            cmbTipo6.Text = "";          
        }

        private void btnSalvarEnd_Click(object sender, EventArgs e)
        {

            if(PesquisaEnd == true)
            {
                try
                {
                    end.Bairro = txtBairroC.Text;
                    end.Cep = mskCepC.Text;
                    end.Cidade = txtCidadeC.Text;
                    end.Id_pessoa = Convert.ToInt32(codnome2);
                    end.N_casa = Convert.ToInt32(txtNc.Text);
                    end.Rua = txtRuaC.Text;
                    end.Tipo = "cobranca";
                    end.Uf = txtUfC.Text;
                    end.Complemento = txtCompC.Text;
                    endDAO.Update(end);
                }
                catch
                {

                }


                try
                {
                    end.Bairro = txtBairroee.Text;
                    end.Cep = mskCepE.Text;
                    end.Cidade = txtCidadeE.Text;
                    end.Id_pessoa = Convert.ToInt32(codnome2);
                    end.N_casa = Convert.ToInt32(txtNe.Text);
                    end.Rua = txtRuaE.Text;
                    end.Tipo = "Entrega";
                    end.Uf = txtUfE.Text;
                    end.Complemento = txtComplementoE.Text;
                    endDAO.Update2(end);
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    end.Bairro = txtBairroC.Text;
                    end.Cep = mskCepC.Text;
                    end.Cidade = txtCidadeC.Text;
                    end.Id_pessoa = Convert.ToInt32(codnome2);
                    end.N_casa = Convert.ToInt32(txtNc.Text);
                    end.Rua = txtRuaC.Text;
                    end.Tipo = "Cobranca";
                    end.Uf = txtUfC.Text;
                    end.Complemento = txtCompC.Text;
                    endDAO.Inserir(end);                   
                }
                catch
                {
                }

                try
                {
                    end.Bairro = txtBairroee.Text;
                    end.Cep = mskCepE.Text;
                    end.Cidade = txtCidadeE.Text;
                    end.Id_pessoa = Convert.ToInt32(codnome2);
                    end.N_casa = Convert.ToInt32(txtNe.Text);
                    end.Rua = txtRuaE.Text;
                    end.Tipo = "Entrega";
                    end.Uf = txtUfE.Text;
                    end.Complemento = txtComplementoE.Text;
                    endDAO.Inserir(end);
                    

                    MessageBox.Show("Cadastrado com sucesso!!!");
                }
                catch
                {

                }
            }   
        }

        private void mskCepC_TextChanged(object sender, EventArgs e)
        {
            mskCepC.BackColor = Color.Empty;
            if (mskCepC.MaskFull == true)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCepC.Text);

                    ds.ReadXml(xml);

                    txtRuaC.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                    txtBairroC.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                    txtCidadeC.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                    txtUfC.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "O CEP digitado é invalido");
                }
            }
            else
            {
                txtBairroC.Clear();
                txtUfC.Clear();
                txtRuaC.Clear();
                txtCidadeC.Clear();
            }
        }



        public void limparend()
        {
            mskCepC.Clear();
            txtBairroC.Clear();
            txtCidadeC.Clear();
            txtCompC.Clear();
            txtRuaC.Clear();
            txtNc.Clear();
            txtUfC.Clear();

            txtBairroee.Clear();
            mskCepE.Clear();
            txtCidadeE.Clear();
            txtComplementoE.Clear();
            txtRuaE.Clear();
            txtNe.Clear();
            txtUfE.Clear();           
        }

        private void mskCepE_TextChanged(object sender, EventArgs e)
        {
            mskCepE.BackColor = Color.Empty;
            if (mskCepE.MaskFull == true)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCepE.Text);

                    ds.ReadXml(xml);

                    txtRuaE.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                    txtBairroee.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                    txtCidadeE.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                    txtUfE.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "O CEP digitado é invalido");
                }
            }
            else
            {
                txtBairroee.Clear();
                txtUfE.Clear();
                txtRuaE.Clear();
                txtCidadeE.Clear();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Deseja realmente excluir?",
                "Excluir?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                endDAO.ExcluirEndereco(pesDAO.Pes.Id_pessoa.ToString());
                MessageBox.Show("Excluído com sucesso !!!");

                limparend();

                mskCepC.Enabled = false;
                txtBairroC.Enabled = false;
                txtCompC.Enabled = false;
                txtUfC.Enabled = false;
                txtCidadeC.Enabled = false;
                txtNc.Enabled = false;
                txtRuaC.Enabled = false;
                btnIncluir.Enabled = true;

                mskCepE.Enabled = false;
                txtBairroee.Enabled = false;
                txtComplementoE.Enabled = false;
                txtUfE.Enabled = false;
                txtCidadeE.Enabled = false;
                txtNe.Enabled = false;
                txtRuaE.Enabled = false;

                aud.Acao = "EXCLUIU ENDERECO";
                aud.Data = FechamentoDAO.data;
                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                aud.Responsavel = UsuarioDAO.login;
                audDAO.Inserir(aud);

            }
            else
            {

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

        private void tabPage2_Click(object sender, EventArgs e)
        {
            cmbTipo5.Text = "";
            cmbNome.Text = "";
        }

        private void cmbTipo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            codtp5 = cmbTipo5.SelectedValue.ToString();
            CarregarComboNome();
        }

        private void cmbTipo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                codtp6 = cmbTipo6.SelectedValue.ToString();
                CarregarComboNome2();
            }
            catch
            {
            }          
        }

        private void cmbNome2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mskCepC.Enabled = false;
            txtBairroC.Enabled = false;
            txtCompC.Enabled = false;
            txtUfC.Enabled = false;
            txtCidadeC.Enabled = false;
            txtNc.Enabled = false;
            txtRuaC.Enabled = false;

            mskCepE.Enabled = false;
            txtBairroee.Enabled = false;
            txtComplementoE.Enabled = false;
            txtUfE.Enabled = false;
            txtCidadeE.Enabled = false;
            txtNe.Enabled = false;
            txtRuaE.Enabled = false;


            mskCepC.Clear();
            txtBairroC.Clear();
            txtCompC.Clear();
            txtUfC.Clear();
            txtCidadeC.Clear();
            txtNc.Clear();
            txtRuaC.Clear();

            mskCepE.Clear();
            txtBairroee.Clear();
            txtComplementoE.Clear();
            txtUfE.Clear();
            txtCidadeE.Clear();
            txtNe.Clear();
            txtRuaE.Clear();
            btnIncluir.Enabled = true;

            try
            {
                codnome2 = cmbNome2.SelectedValue.ToString();
            }
            catch
            {
            }

            if (endDAO.VerificaID(codnome2)==true )
            {
                txtBairroC.Text = endDAO.End.Bairro;
                mskCepC.Text = endDAO.End.Cep;
                txtCidadeC.Text = endDAO.End.Cidade;
                txtCompC.Text = endDAO.End.Complemento;
                txtNc.Text = endDAO.End.N_casa.ToString();
                txtRuaC.Text = endDAO.End.Rua;
                PesquisaEnd = true;

                txtRuaE.Enabled = true;
                txtUfE.Enabled = true;
                txtNe.Enabled = true;
                txtComplementoE.Enabled = true;
                txtCidadeE.Enabled = true;
                mskCepE.Enabled = true;
                txtBairroee.Enabled = true;

                txtRuaC.Enabled = true;
                txtNc.Enabled = true;
                txtCompC.Enabled = true;
                txtUfC.Enabled = true;
                txtCidadeC.Enabled = true;
                mskCepC.Enabled = true;
                txtBairroC.Enabled = true;

                btnIncluir.Enabled = false;
            }
            else
            {
                PesquisaEnd = false;
            }

            if (endDAO.VerificaID2(codnome2)==true)
            {
                txtBairroee.Text = endDAO.End.Bairro;
                mskCepE.Text = endDAO.End.Cep;
                txtCidadeE.Text = endDAO.End.Cidade;
                txtComplementoE.Text = endDAO.End.Complemento;
                txtNe.Text = endDAO.End.N_casa.ToString();
                txtRuaE.Text = endDAO.End.Rua;
                PesquisaEnd = true;

                txtRuaE.Enabled = true;
                txtUfE.Enabled = true;
                txtNe.Enabled = true;
                txtComplementoE.Enabled = true;
                txtCidadeE.Enabled = true;
                mskCepE.Enabled = true;
                txtBairroee.Enabled = true;

                txtRuaC.Enabled = true;
                txtNc.Enabled = true;
                txtCompC.Enabled = true;
                txtUfC.Enabled = true;
                txtCidadeC.Enabled = true;
                mskCepC.Enabled = true;
                txtBairroC.Enabled = true;

                btnIncluir.Enabled = false;
            }
            else
            {
                PesquisaEnd = false;
            }
        }

        private void cmbNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            codnome = cmbNome.SelectedValue.ToString();
            try
            {
                gvExibir.DataSource = contatoDAO.ListarID(codnome);
            }
            catch
            {

            }
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            cmbTipo5.Text = "";
            cmbNome.Text = "";
            cmbNome2.Text = "";
            cmbTipo6.Text = "";

            gvExibir.DataSource = null;

            mskCepC.Enabled = false;
            txtBairroC.Enabled = false;
            txtCompC.Enabled = false;
            txtUfC.Enabled = false;
            txtCidadeC.Enabled = false;
            txtNc.Enabled = false;
            txtRuaC.Enabled = false;
            mskCepE.Enabled = false;
            txtBairroee.Enabled = false;
            txtComplementoE.Enabled = false;
            txtUfE.Enabled = false;
            txtCidadeE.Enabled = false;
            txtNe.Enabled = false;
            txtRuaE.Enabled = false;


            mskCepC.Clear();
            txtBairroC.Clear();
            txtCompC.Clear();
            txtUfC.Clear();
            txtCidadeC.Clear();
            txtNc.Clear();
            txtRuaC.Clear();
            mskCepE.Clear();
            txtBairroee.Clear();
            txtComplementoE.Clear();
            txtUfE.Clear();
            txtCidadeE.Clear();
            txtNe.Clear();
            txtRuaE.Clear();
        }

        private void btnPesq_Click_1(object sender, EventArgs e)
        {
            frmPesquisaPessoa pesqp = new frmPesquisaPessoa();
            pesqp.Owner = this;
            pesqp.ShowDialog();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            cmbTipo6.Text = "";
            cmbNome2.Text = "";
        }

        private void txtNe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void txtNc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
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

        private void mskCepC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtCompC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtUfC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtCidadeC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtBairroC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtNc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtRuaC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskCepE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtComplementoE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtUfE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtCidadeE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtNe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtBairroee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtRuaE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void cmbNome2_TextChanged(object sender, EventArgs e)
        {
            if (cmbNome2.Text == string.Empty)
            {
                mskCepC.Enabled = false;
                txtBairroC.Enabled = false;
                txtCompC.Enabled = false;
                txtUfC.Enabled = false;
                txtCidadeC.Enabled = false;
                txtNc.Enabled = false;
                txtRuaC.Enabled = false;

                mskCepE.Enabled = false;
                txtBairroee.Enabled = false;
                txtComplementoE.Enabled = false;
                txtUfE.Enabled = false;
                txtCidadeE.Enabled = false;
                txtNe.Enabled = false;
                txtRuaE.Enabled = false;

                mskCepC.Clear();
                txtBairroC.Clear();
                txtCompC.Clear();
                txtUfC.Clear();
                txtCidadeC.Clear();
                txtNc.Clear();
                txtRuaC.Clear();

                mskCepE.Clear();
                txtBairroee.Clear();
                txtComplementoE.Clear();
                txtUfE.Clear();
                txtCidadeE.Clear();
                txtNe.Clear();
                txtRuaE.Clear();
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

        private void mskTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void mskCel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void mskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
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

        private void cmbTipo2_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbTipo5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void cmbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
