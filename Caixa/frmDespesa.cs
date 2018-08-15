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
    public partial class frmDespesa : Form
    {

        #region INSTANCIAMENTO CLASSES
        Despesa desp = new Despesa();
        DespesaDAO despDAO = new DespesaDAO();
        #endregion


        public frmDespesa()
        {
            InitializeComponent();
        }

        private void frmDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void chkF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForn.Checked == true)
            {
                chkFunc.Enabled = false;
            }
            else
            {
                chkFunc.Enabled = true;
            }
        }

        private void chkFunc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFunc.Checked == true)
            {
                chkForn.Enabled = false;
            }
            else
            {
                chkForn.Enabled = true;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if ()
            {

            }
            else
            {
                try
                {

                }
                catch
                {

                }
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            txtDesc.BackColor = Color.Empty;
        }

        private void cmbOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOp.BackColor = Color.Empty;
        }

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            mskData.BackColor = Color.Empty;
        }
    }
}
