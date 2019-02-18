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
    public partial class frmExcluirFunc : Form
    {
        #region INSTANCIAMENTO CLASSES
        PessoaDAO pesDAO = new PessoaDAO();
        TipoDAO tpDAO = new TipoDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        string nome;
#pragma warning disable CS0169 // O campo "frmExcluirFunc.id" nunca é usado
        string id;
#pragma warning restore CS0169 // O campo "frmExcluirFunc.id" nunca é usado
        string tipo;
        #endregion

        public frmExcluirFunc()
        {
            InitializeComponent();
        }

        private void frmExcluirFunc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }


        public void CarregarComboTipo()
        {
            try
            {
                cmbTipo.DataSource = tpDAO.Listartudo();
                cmbTipo.DisplayMember = "tipo";
                cmbTipo.ValueMember = "ID";
                tipo = cmbTipo.Text.ToString();
            }
            catch
            {

            }

        }

        private void frmExcluirFunc_Load(object sender, EventArgs e)
        {
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            CarregarComboTipo();
            cmbTipo.SelectedIndex = -1;
            try
            {
                gvExibir.DataSource = pesDAO.ListarT();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "ID")
                        column.Width = 45; //tamanho fixo da coluna ID
                    else if(column.DataPropertyName =="TIPO")
                        column.Width = 80; //tamanho fixo da coluna FISJUR
                    else if (column.DataPropertyName == "CPFNJ")
                        column.Width = 160; //tamanho fixo da coluna FISJUR
                    else if (column.DataPropertyName == "CATEGORIA")
                        column.Width = 100; //tamanho fixo da coluna FISJUR

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            catch
            {

            }
            
        }

       

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            #region FILTRA POR NOME E TIPO
            if (txtNome.Text != string.Empty && cmbTipo.Text != string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNome(nome, tipo);
            }
            #endregion

            #region FILTRA POR TIPO
            if (txtNome.Text == string.Empty && cmbTipo.Text != string.Empty)
            {
                gvExibir.DataSource = pesDAO.ListarID(tipo);
            }
            #endregion

            #region FILTRA POR NOME
            if (txtNome.Text != string.Empty && cmbTipo.Text == string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNM(nome);
            }
            #endregion

            if (txtNome.Text == string.Empty && cmbTipo.Text == string.Empty)
            {

                gvExibir.DataSource = pesDAO.ListarT();
            }

            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "TIPO")
                    column.Width = 80; //tamanho fixo da coluna FISJUR
                else if (column.DataPropertyName == "CPFNJ")
                    column.Width = 160; //tamanho fixo da coluna FISJUR
                else if (column.DataPropertyName == "CATEGORIA")
                    column.Width = 100; //tamanho fixo da coluna FISJUR

                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

        }

        //private void txtId_TextChanged(object sender, EventArgs e)
        //{
        //    txtId.BackColor = Color.Empty;
        //    if (txtId.Text != string.Empty)
        //    {
        //      id = txtId.Text.ToString();
        //    }


        //}

        //private void btnExcluir_Click(object sender, EventArgs e)
        //{
        //    if (txtId.Text == string.Empty)
        //    {
        //        txtId.BackColor = Color.Red;
        //        MessageBox.Show("Favor preencher o ID da pessoa");
        //    }
        //    else
        //    {
        //        DialogResult op;

        //        op = MessageBox.Show("Deseja realmente excluir?",
        //            "Excluir?", MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);

        //        if (op == DialogResult.Yes)
        //        {
        //            pesDAO.Excluir(id);
        //            MessageBox.Show("Excluído com sucesso !!!");
        //            txtId.Text = string.Empty;
        //            cmbTipo.SelectedIndex = 0;
        //            txtNome.Clear();
        //            gvExibir.DataSource = pesDAO.ListarID(tipo);

        //            aud.Acao = "EXCLUIU PESSOA";
        //            aud.Data = FechamentoDAO.data;
        //            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
        //            aud.Responsavel = UsuarioDAO.login;
        //            audDAO.Inserir(aud);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cancelado");
        //        }
        //    }
        //}

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
               e.Handled = true;

            }
        }

        private void chkFunc_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkFunc.Checked == true)
            //{
            //    chkFornecedor.Enabled = false;
              
            //}
            //else
            //{
            //    chkFornecedor.Enabled = true;
            //}

            //#region SOMENTE FUNCIONARIO
            //if (txtNome.Text == string.Empty && chkFunc.Checked == true && chkFornecedor.Checked == false)
            //{
            //    tipo = "Func";
            //    gvExibir.DataSource = pesDAO.ListarTipo(tipo);
            //}
            //#endregion

            //#region TODOS VAZIOS
            //if (txtNome.Text == string.Empty && chkFornecedor.Checked == false && chkFunc.Checked == false)
            //{
            //    gvExibir.DataSource = pesDAO.ListarExcluir();
            //}
            //#endregion

            //#region SOMENTE FUNCIONARIO E NOME
            //if (txtNome.Text != string.Empty && chkFunc.Checked == true && chkFornecedor.Checked == false)
            //{
            //    nome = txtNome.Text;
            //    tipo = "Func";
            //    gvExibir.DataSource = pesDAO.ListarTN(tipo, nome);
            //}
            //#endregion

            //#region SOMENTE FORNECEDOR E NOME
            //if (txtNome.Text != string.Empty && chkFunc.Checked == false && chkFornecedor.Checked == true)
            //{
            //    nome = txtNome.Text;
            //    tipo = "Fornecedor";
            //    gvExibir.DataSource = pesDAO.ListarTN(tipo, nome);
            //}
            //#endregion

        }

        private void chkFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkFornecedor.Checked == true)
            //{
            //    chkFunc.Enabled = false;
              
            //}
            //else
            //{
            //    chkFunc.Enabled = true;
            //}

            //#region SOMENTE FORNECEDOR
            //if (txtNome.Text == string.Empty && chkFunc.Checked == false && chkFornecedor.Checked == true)
            //{
            //    tipo = "Fornecedor";
            //    gvExibir.DataSource = pesDAO.ListarTipo(tipo);
            //}
            //#endregion

            //#region TODOS VAZIOS
            //if (txtNome.Text == string.Empty && chkFornecedor.Checked == false && chkFunc.Checked == false)
            //{
            //    gvExibir.DataSource = pesDAO.ListarExcluir();
            //}
            //#endregion

            //#region SOMENTE FUNCIONARIO E NOME
            //if (txtNome.Text != string.Empty && chkFunc.Checked == true && chkFornecedor.Checked == false)
            //{
            //    nome = txtNome.Text;
            //    tipo = "Func";
            //    gvExibir.DataSource = pesDAO.ListarTN(tipo, nome);
            //}
            //#endregion

            //#region SOMENTE FORNECEDOR E NOME
            //if (txtNome.Text != string.Empty && chkFunc.Checked == false && chkFornecedor.Checked == true)
            //{
            //    nome = txtNome.Text;
            //    tipo = "Fornecedor";
            //    gvExibir.DataSource = pesDAO.ListarTN(tipo, nome);
            //}
            //#endregion



        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo = cmbTipo.Text.ToString();
            #region FILTRA POR NOME E TIPO
            if (txtNome.Text != string.Empty && cmbTipo.Text != string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNome(nome, tipo);
            }
            #endregion

            #region FILTRA POR TIPO
            if (txtNome.Text == string.Empty && cmbTipo.Text != string.Empty)
            {
                gvExibir.DataSource = pesDAO.ListarID(tipo);
            }
            #endregion

            #region FILTRA POR NOME
            if (txtNome.Text != string.Empty && cmbTipo.Text == string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNM(nome);
            }
            #endregion

            if (txtNome.Text == string.Empty && cmbTipo.Text == string.Empty)
            {
                
                gvExibir.DataSource = pesDAO.ListarT();
            }


        }

        private void cmbTipo_TextChanged(object sender, EventArgs e)
        {
            #region FILTRA POR NOME
            if (txtNome.Text != string.Empty && cmbTipo.Text != string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNome(nome, tipo);
            }
            #endregion

            #region SOMENTE NOME VAZIO
            if (txtNome.Text == string.Empty && cmbTipo.Text == string.Empty)
            {
                gvExibir.DataSource = pesDAO.ListarID(tipo);
            }
            #endregion

            if (txtNome.Text == string.Empty && cmbTipo.Text == string.Empty)
            {
                gvExibir.DataSource = pesDAO.ListarT();
            }

            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "TIPO")
                    column.Width = 80; //tamanho fixo da coluna FISJUR
                else if (column.DataPropertyName == "CPFNJ")
                    column.Width = 160; //tamanho fixo da coluna FISJUR
                else if (column.DataPropertyName == "CATEGORIA")
                    column.Width = 100; //tamanho fixo da coluna FISJUR

                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

        }

        private void gvExibir_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nomec;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gvExibir.Rows[e.RowIndex];
                nomec = row.Cells["NOME"].Value.ToString();

                var qrForm = from frm in Application.OpenForms.Cast<Form>()
                             where frm is frmPesquisaPessoa
                             select frm;

                if (qrForm != null && qrForm.Count() > 0)
                {
                    ((frmPesquisaPessoa)qrForm.First()).AtualizaNome(nomec);
                }
            }
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

