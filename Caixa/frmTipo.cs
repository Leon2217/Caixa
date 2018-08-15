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
        TipoPessoa tp = new TipoPessoa();
        TipoDAO tpDAO = new TipoDAO();
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
            if (txtTipo.Text==string.Empty)
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
                        MessageBox.Show("O tipo "+nome+" já foi cadastrada no sistema !!!");
                        txtTipo.Clear();
                    }
                    else
                    {
                    tp.Tipo = txtTipo.Text.ToString();
                    tpDAO.Inserir(tp);
                    MessageBox.Show("Tipo cadastrado com sucesso !!!");
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
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
    }
}
