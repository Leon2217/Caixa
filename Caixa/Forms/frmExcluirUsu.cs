using System;
using System.Drawing;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmExcluirUsu : Form
    {
        Usuario usu = new Usuario();
        UsuarioDAO usuDAO = new UsuarioDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string id;

        public frmExcluirUsu()
        {
            InitializeComponent();
        }

        private void frmExcluirUsu_Load(object sender, EventArgs e)
        {
            try
            {
            gvExibir.DataSource = usuDAO.ListarTudo();
            }
            catch
            {
            }
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
                    usuDAO.Excluir(id);
                    MessageBox.Show("Excluído com sucesso !!!");
                    txtId.Text = string.Empty;
                    gvExibir.DataSource = usuDAO.ListarTudo();

                    aud.Acao = "EXCLUIU USUARIO";
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
            if (txtId.Text != string.Empty)
            {
                  id = txtId.Text.ToString();
            }          
        }

        private void frmExcluirUsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void gvExibir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = gvExibir.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
