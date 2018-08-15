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
    public partial class frmCadOperadora : Form
    {
        OperadoraDAO opDAO = new OperadoraDAO();
        Operadoras op = new Operadoras();
        string nome;
        public frmCadOperadora()
        {
            InitializeComponent();
        }

        private void frmCadOperadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text==string.Empty)
            {
                txtNome.BackColor = Color.Red;
                MessageBox.Show("Favor preencher o nome da operadora !!!");
            }
            else
            {
                nome = txtNome.Text;
                try
                {
                    if (opDAO.Verificaexiste(nome)==true)
                    {
                        MessageBox.Show("A operadora "+nome+" já foi cadastrada no sistema !!!");
                        txtNome.Clear();
                    }
                    else
                    {
                        op.Operadora = txtNome.Text.ToString();
                        opDAO.Inserir(op);
                        MessageBox.Show("Operadora cadastrada com sucesso");
                        txtNome.Clear();
                       
                    }



                }
                catch
                {
                    MessageBox.Show("Favor verificar as informções digitadas !!!");
                }
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsSeparator(e.KeyChar)))
            {
               e.Handled = true;

            }
        }
    }
}
