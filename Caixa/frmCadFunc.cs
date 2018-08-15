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
    public partial class frmCadFunc : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        Pessoa pes = new Pessoa();
        PessoaDAO pesDAO = new PessoaDAO();
        TipoDAO tpDAO = new TipoDAO();
        #endregion

        string codtp;
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
            txtNome.BackColor = Color.Empty;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text==string.Empty)
            {
                MessageBox.Show("Favor preencher o nome da pessoa !!!");
                txtNome.BackColor = Color.Red;
            }
            else
            {
                try
                {
             
                    pes.Nome = txtNome.Text.ToString();
                    pes.Id_tp = Convert.ToInt32(codtp);
                    pesDAO.Inserir(pes);
                    txtNome.Clear();
                    cmbTipo.SelectedIndex = 0;
                    gvExibir.DataSource = pesDAO.ListarNT();
                    MessageBox.Show("Informações salvas com sucesso !!!");
                }
                catch
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
            }
            
           
        }

        public void CarregarComboTipo()
        {
            try
            {
                cmbTipo.DataSource = tpDAO.Listartudo();
                cmbTipo.DisplayMember = "tipo";
                cmbTipo.ValueMember = "ID";
                codtp = cmbTipo.SelectedValue.ToString();
            }
            catch
            {

            }
     
        }

        public void AtualizaDados()
        {
            CarregarComboTipo();
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                gvExibir.DataSource = pesDAO.ListarNT();
            }
            catch
            {

            }
        }


        private void frmCadFunc_Load(object sender, EventArgs e)
        {
            CarregarComboTipo();
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                gvExibir.DataSource = pesDAO.ListarNT();
            }
            catch
            {

            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsSeparator(e.KeyChar)))
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
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            frmTipo tp = new frmTipo();
            tp.Owner = this;
            tp.ShowDialog();

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            codtp = cmbTipo.SelectedValue.ToString();
        }
    }
}
