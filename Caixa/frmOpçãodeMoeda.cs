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
    public partial class frmOpçãodeMoeda : Form
    {
        public frmOpçãodeMoeda()
        {
            InitializeComponent();
        }

        private void frmOpçãodeMoeda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
            if (e.KeyValue.Equals(112))
            {
                frmEntradaMoeda en = new frmEntradaMoeda();
                en.Owner = this;
                en.ShowDialog();
            }
            if (e.KeyValue.Equals(113))
            {
                frmDevoluçãodeMoeda d = new frmDevoluçãodeMoeda();
                d.Owner = this;
                d.ShowDialog();
            }
            if (e.KeyValue.Equals(114))
            {
                frmESM esm = new frmESM();
                esm.Owner = this;
                esm.ShowDialog();
            }




        }

        private void frmOpçãodeMoeda_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            frmEntradaMoeda en = new frmEntradaMoeda();
            en.Owner = this;
            en.ShowDialog();
        }

        private void btnDev_Click(object sender, EventArgs e)
        {
            frmDevoluçãodeMoeda d = new frmDevoluçãodeMoeda();
            d.Owner = this;
            d.ShowDialog();
        }

        private void btnMovimento_Click(object sender, EventArgs e)
        {
            frmESM es = new frmESM();
            es.Owner = this;
            es.ShowDialog();
        }
    }
}
