using System;
using System.Windows.Forms;


namespace Caixa
{
    public partial class frmTelaSplash : Form
    {
        public frmTelaSplash()
        {
            InitializeComponent();

            //inicaliza o timer
            tmrTelaSplash.Start();
            //coloca o tempo de excução
            tmrTelaSplash.Interval = 1000;

            //diz a minima e a maxima do progressBar
            pgbtime.Minimum = 0;
            pgbtime.Maximum = 500;
        }

        private void tmrTelaSplash_Tick(object sender, EventArgs e)
        {
            //se o valor da progressBar for menor que a maxima estipulada
            if (pgbtime.Value < pgbtime.Maximum)
            {
                //é adiconado a mesma o valor atual mais algum número multiplo da maxima
                pgbtime.Value = pgbtime.Value + 500;
            }
            else if (pgbtime.Value == pgbtime.Maximum)
            {
                //para o timer
                tmrTelaSplash.Stop();
                //vai pra tela de backup
                Visible = false;
                frmBackup bkp = new frmBackup();
                bkp.ShowDialog();
                Close();
            }
        }
    }
}
