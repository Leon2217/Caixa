using System;
using System.Drawing;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmExcluirValores : Form
    {
        OperadoraDAO opDAO = new OperadoraDAO();
        ValoroperadoraDAO vopDAO = new ValoroperadoraDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string codop;
        string operadora;
        string id;

        public frmExcluirValores()
        {
            InitializeComponent();
        }

        public void CarregarComboOperadora()
        { 
            cmbOperadora.DataSource = opDAO.Listartudo();
            cmbOperadora.DisplayMember = "operadora";
            cmbOperadora.ValueMember = "id_operadora";
            codop = cmbOperadora.SelectedValue.ToString();
        }

        private void frmExcluirValores_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarComboOperadora();
            }
            catch
            {
            }
        }

        private void cmbOperadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            codop = cmbOperadora.SelectedValue.ToString();
            operadora = cmbOperadora.Text.ToString();
            gvExibir.DataSource = vopDAO.Listarvalores2(operadora);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                txtId.BackColor = Color.Red;
                MessageBox.Show("Favor preencher o ID da operadora");
            }
            else
            {
                DialogResult op;

                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    vopDAO.Excluir(id);             
                    MessageBox.Show("Excluído com sucesso !!!");
                    txtId.Text = string.Empty;              
                    gvExibir.DataSource = vopDAO.Listarvalores2(operadora);

                    aud.Acao = "EXCLUIU VALOR OPERADORA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);
                }
                else
                {
                    MessageBox.Show("Cancelado");
                }
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            txtId.BackColor = Color.Empty;
            id = txtId.Text.ToString();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void frmExcluirValores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void gvExibir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = gvExibir.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
