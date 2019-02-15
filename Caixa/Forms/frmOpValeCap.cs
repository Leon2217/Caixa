using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmOpValeCap : Form
    {
        public frmOpValeCap()
        {
            InitializeComponent();
        }

        public void btnVenda_Click(object sender, EventArgs e)
        {         
            frmVendavc vc = new frmVendavc();                  
            vc.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmInventario inv = new frmInventario();
            inv.ShowDialog();
        }

        private void frmOpValeCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyValue.Equals(112))
            {
                frmVendavc vc = new frmVendavc();
                vc.Owner = this;
                vc.ShowDialog();
            }

            if (e.KeyValue.Equals(113))
            {
                frmInventario inv = new frmInventario();
                inv.Owner = this;
                inv.ShowDialog();
            }

            if (e.KeyValue.Equals(114))
            {
                frmRelatVendavc rel = new frmRelatVendavc();
                rel.Owner = this;
                rel.ShowDialog();
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatVendavc r = new frmRelatVendavc();
            r.Owner = this;
            r.ShowDialog();
        }
    }
}
