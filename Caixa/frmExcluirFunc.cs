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
        #endregion

        #region VAR
        string nome;
        string id;
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
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            CarregarComboTipo();
            try
            {
                gvExibir.DataSource = pesDAO.ListarID(tipo);
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
            #region FILTRA POR NOME
            if (txtNome.Text != string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNome(nome,tipo);
            }
            #endregion

            #region SOMENTE NOME VAZIO
            if (txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = pesDAO.ListarID(tipo);
            }
            #endregion

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            txtId.BackColor = Color.Empty;
            if (txtId.Text != string.Empty)
            {
              id = txtId.Text.ToString();
            }
            
          
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                txtId.BackColor = Color.Red;
                MessageBox.Show("Favor preencher o ID da pessoa");
            }
            else
            {
                DialogResult op;

                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    pesDAO.Excluir(id);
                    MessageBox.Show("Excluído com sucesso !!!");
                    txtId.Text = string.Empty;
                    cmbTipo.SelectedIndex = 0;
                    txtNome.Clear();
                    gvExibir.DataSource = pesDAO.ListarID(tipo);
                }
                else
                {
                    MessageBox.Show("Cancelado");
                }
            }
        }

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
            #region FILTRA POR NOME
            if (txtNome.Text != string.Empty)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = pesDAO.ListarNome(nome, tipo);
            }
            #endregion

            #region SOMENTE NOME VAZIO
            if (txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = pesDAO.ListarID(tipo);
            }
            #endregion
        }
    }
}
