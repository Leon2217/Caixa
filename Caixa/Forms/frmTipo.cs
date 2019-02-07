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
    public partial class frmTipo : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        Tipos tp = new Tipos();
        TipoDAO tpDAO = new TipoDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        string nome;
        #endregion

        public frmTipo()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtTipo.Text == string.Empty)
            {
                MessageBox.Show("Favor inserir um tipo !!!");
                txtTipo.BackColor = Color.Red;
            }
            else
            {
                nome = txtTipo.Text;
                try
                {
                    if (tpDAO.Verificaexiste(nome) == true)
                    {
                        MessageBox.Show("O tipo " + nome + " já foi cadastrada no sistema !!!");
                        txtTipo.Clear();
                    }
                    else
                    {
                        tp.Tipo = txtTipo.Text.ToString();
                        tpDAO.Inserir(tp);
                        MessageBox.Show("Tipo cadastrado com sucesso !!!");

                        aud.Acao = "INSERIU TIPO PESSOA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        txtTipo.Clear();
                        gvExibir.DataSource = tpDAO.Listartudo();
                        var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                     where frm is frmCadFunc
                                     select frm;

                        if (qrForm != null && qrForm.Count() > 0)
                        {
                            ((frmCadFunc)qrForm.First()).AtualizaDados();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
            }
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            txtTipo.BackColor = Color.Empty;
        }

        private void frmTipo_Load(object sender, EventArgs e)
        {
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                gvExibir.DataSource = tpDAO.Listartudo();
            }
            catch
            {

            }
        }

        private void frmTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
