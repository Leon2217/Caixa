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
    public partial class frmExcluirOperadora : Form
    {
        OperadoraDAO opDAO = new OperadoraDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string operadora;
        string id;
        public frmExcluirOperadora()
        {
            InitializeComponent();
        }

        private void frmExcluirOperadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtOperadora_TextChanged(object sender, EventArgs e)
        {

            if (txtOperadora.Text != string.Empty)
            {
                operadora = txtOperadora.Text;
                gvExibir.DataSource = opDAO.Listarfiltro(operadora);
            }
            else
            {
                gvExibir.DataSource = opDAO.Listartudo();
            }
            
        }

        private void frmExcluirOperadora_Load(object sender, EventArgs e)
        {
            gvExibir.DataSource = opDAO.Listartudo();
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text==string.Empty)
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
                    opDAO.excluir(id);
                    MessageBox.Show("Excluído com sucesso !!!");
                    txtId.Text = string.Empty;
                    txtOperadora.Text = string.Empty;
                    gvExibir.DataSource = opDAO.Listartudo();

                    aud.Acao = "EXCLUIU OPERADORA";
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

        private void txtOperadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
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
