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

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
               e.Handled = true;
            }
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

