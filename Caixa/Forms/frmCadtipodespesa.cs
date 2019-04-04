using System;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace Caixa
{
    public partial class frmCadtipodespesa : Form
    {
        #region INSTANCIAMENTO CLASSES
        Tipodespesa tpdes = new Tipodespesa();
        TipodespesaDAO tpdesDAO = new TipodespesaDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion
        string nome;

        public frmCadtipodespesa()
        {
            InitializeComponent();
        }

        private void frmCadtipodespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty)
            {
                txtNome.BackColor = Color.Red;
                MessageBox.Show("Favor preencher o nome do tipo !!!");
            }
            else
            {
                nome = txtNome.Text;
                try
                {
                    if (tpdesDAO.Verificaexiste(nome) == true)
                    {
                        MessageBox.Show("O tipo " + nome + " já foi cadastrada no sistema !!!");
                        txtNome.Clear();
                    }
                    else
                    {
                        tpdes.Nome = txtNome.Text.ToString();
                        tpdesDAO.Inserir(tpdes);
                        MessageBox.Show("Tipo cadastrado com sucesso");
                        txtNome.Clear();

                        aud.Acao = "CADASTROU TIPO DESPESA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                     where frm is frmDespesa
                                     select frm;

                        if (qrForm != null && qrForm.Count() > 0)
                        {
                            ((frmDespesa)qrForm.First()).AtualizaDados();
                        }
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
    }
}
