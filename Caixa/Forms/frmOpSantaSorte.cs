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
    public partial class frmOpSantaSorte : Form
    {
        public frmOpSantaSorte()
        {
            InitializeComponent();
        }

        private void frmOpGirodaSorte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyValue.Equals(112))
            {
                frmVendaSS gds = new frmVendaSS();
                gds.Owner = this;
                gds.ShowDialog();
            }

            if (e.KeyValue.Equals(113))
            {
                frmInventarioSS gds = new frmInventarioSS();
                gds.Owner = this;
                gds.ShowDialog();
            }

            if (e.KeyValue.Equals(114))
            {
                frmRelatSS rgds = new frmRelatSS();
                rgds.Owner = this;
                rgds.ShowDialog();
            }
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            frmVendaSS gds = new frmVendaSS();
            gds.Owner = this;
            gds.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmInventarioSS gds = new frmInventarioSS();
            gds.Owner = this;
            gds.ShowDialog();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatSS rgds = new frmRelatSS();
            rgds.Owner = this;
            rgds.ShowDialog();  
        }

        private void frmOpGirodaSorte_Load(object sender, EventArgs e)
        {

        }
    }
}
