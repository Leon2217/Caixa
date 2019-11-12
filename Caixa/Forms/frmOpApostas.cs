using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixa.Forms
{
    public partial class frmOpApostas : Form
    {
        public frmOpApostas()
        {
            InitializeComponent();
        }

        private void btnValeCAP_Click(object sender, EventArgs e)
        {
            frmOpValeCap vc = new frmOpValeCap();
            vc.ShowDialog();
        }

        private void btnGiroDaSorte_Click(object sender, EventArgs e)
        {
            frmOpSantaSorte gds = new frmOpSantaSorte();
            gds.ShowDialog();
        }

        private void frmOpApostas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyValue.Equals(112))
            {
                frmOpValeCap vc = new frmOpValeCap();
                vc.Owner = this;
                vc.ShowDialog();
            }

            if (e.KeyValue.Equals(113))
            {
                frmOpSantaSorte gds = new frmOpSantaSorte ();
                gds.Owner = this;
                gds.ShowDialog();
            }

        }
    }
}
