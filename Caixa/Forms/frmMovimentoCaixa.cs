using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmMovimentoCaixa : Form
    {
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        Valorcaixa vc = new Valorcaixa();
        public frmMovimentoCaixa()
        {
            InitializeComponent();
        }

        private void frmMovimentoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
            if (e.KeyValue.Equals(112))
            {
                frmCredito v = new frmCredito();
                v.Owner = this;
                v.ShowDialog();
            }
            if (e.KeyValue.Equals(113))
            {
                frmDebito v = new frmDebito();
                v.Owner = this;
                v.ShowDialog();
            }
            if (e.KeyValue.Equals(114))
            {
                frmEs v = new frmEs();
                v.Owner = this;
                v.ShowDialog();
            }
        }

        private void btnCrédito_Click(object sender, EventArgs e)
        {
            frmCredito v = new frmCredito();
            v.Owner = this;
            v.ShowDialog();
        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            frmDebito v = new frmDebito();
            v.Owner = this;
            v.ShowDialog();
        }

        private void frmMovimentoCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                vcDAO.Verificavalor();
                double valor = Convert.ToDouble(vcDAO.Vc.Valor.ToString().Replace('.', ','));             
            }
            catch
            {
            }           
        }

        public void AtualizaDados()
        {
            vcDAO.Verificavalor();
            double valor = Convert.ToDouble(vcDAO.Vc.Valor.ToString().Replace('.',','));           
        }

        private void btnMovimento_Click(object sender, EventArgs e)
        {
            frmEs v = new frmEs();
            v.Owner = this;
            v.ShowDialog();
        }
    }
}
