using System;
using System.Windows.Forms;


namespace Caixa
{
    public partial class frmTelaSplash : Form
    {
        public frmTelaSplash()
        {
            InitializeComponent();

            //Inicializa o timer
            tmrTelaSplash.Start();
            //Coloca o intervalo de tempo
            tmrTelaSplash.Interval = 1000;

            //Diz a minima e a máxima do progressBar
            pgbtime.Minimum = 0;
            pgbtime.Maximum = 500;
        }

        private void tmrTelaSplash_Tick(object sender, EventArgs e)
        {
            //Se o valor da progressBar for menor que a maxima estipulada
            if (pgbtime.Value < pgbtime.Maximum)
            {
                //É adicionado a mesma o valor atual mais algum número multiplo da maxima
                pgbtime.Value = pgbtime.Value + 500;
            }
            else if (pgbtime.Value == pgbtime.Maximum)
            {
                //Parando o timer
                tmrTelaSplash.Stop();
                //Indo para frmBackup
                Visible = false;
                frmBackup bkp = new frmBackup();
                bkp.ShowDialog();
                Close();
            }
        }
    }
}
