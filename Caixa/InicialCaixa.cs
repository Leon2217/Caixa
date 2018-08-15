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
    public partial class InicialCaixa : Form
    {
        DateTime data_hora;

        #region INSTACIAMENTO CLASSES
        Fechamento fec = new Fechamento();
        credDebDAO cdDAO = new credDebDAO();
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        CredDeb cd = new CredDeb();
        FechamentoDAO fecDAO = new FechamentoDAO();
        DinheiroDAO dinDAO = new DinheiroDAO();
        SangriaDAO sanDAO = new SangriaDAO();
        RecargaDAO recDAO = new RecargaDAO();
        Verificas ver = new Verificas();
        VerificaDAO verDAO = new VerificaDAO();
        VendaVC vcc = new VendaVC();
        VendaVCDAO vvcDAO = new VendaVCDAO();
        ContasDAO contasDAO = new ContasDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        #endregion

        #region VARIÁVEIS
        string codcaixa;
        double totsang;
        double totrec;
        double total;
        string dinheiro;
        double totalmanharec;
        double totalrec;
        double totaltarderec;
        double totalmanhavale;
        double totaltardevale;
        double totalvale;
        string tipo;
        string login;
        #endregion

 

        public InicialCaixa()
        {
            InitializeComponent();
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            frmDinheiro d = new frmDinheiro();
            d.ShowDialog();
        }

        private void btnMaquina_Click(object sender, EventArgs e)
        {
            frmOpcaoFecha f = new frmOpcaoFecha();
            f.Owner =this;
            f.ShowDialog();
        }

        public void Atualizadados()
        {
            codcaixa =DinheiroDAO.codcaixa;
            DateTime data = FechamentoDAO.data;
            #region SANGRIA
            if (sanDAO.Verificasangria(codcaixa) == true)
            {
                try
                {
                    totsang = Convert.ToDouble(SangriaDAO.totalsangria.ToString().Replace('.', ','));
                    btnSangria.Text = "F4 - Sangria" + "\n Total : " + (totsang).ToString("C2");
                }
                catch
                {

                }



            }
            #endregion
            #region RECARGA
            if (recDAO.Verificarecarga(data) == true)
            {

                try
                {
                    totalmanharec = Convert.ToDouble(RecargaDAO.totalrecarga.ToString().Replace('.', ','));
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totrec).ToString("C2");
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "1")
                {
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totalmanharec).ToString("C2");
                }
                else
                {
                    if (recDAO.Verificarecarga2(data) == true)
                    {
                        try
                        {
                            totaltarderec = Convert.ToDouble(RecargaDAO.totalrecarga2.ToString().Replace('.', ','));
                            totalrec = (totaltarderec + totalmanharec);
                            //totalrec = Convert.ToDouble(RecargaDAO.totalrecarga2.ToString().Replace('.', ','));
                            //totaltarderec = (totalrec - totalmanharec);
                            TotalRec();
                        }
                        catch
                        {

                        }

                    }
                }
            }
            #endregion
            #region DINHEIRO
            if (dinDAO.Verificatotal(codcaixa) == true)
            {
                try
                {
                    total = Convert.ToDouble(DinheiroDAO.Totalmanha.ToString().Replace('.', ','));
                  
                }
                catch
                {

                }


            }

            #endregion
            #region VALECAP
            if (vvcDAO.VerificaVenda(data) == true)
            {
                try
                {
                    totalmanhavale = Convert.ToDouble(VendaVCDAO.manha.ToString().Replace('.', ','));
                    btnValecap.Text = "F3 - Vale Cap" + "\n Total : " + (totalvale).ToString("C2");
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "1")
                {
                    btnValecap.Text = "F3 - Vale Cap" + "\n Total : " + (totalmanhavale).ToString("C2");
                }
                else
                {
                    if (vvcDAO.VerificaVenda2(data) == true)
                    {
                        try
                        {
                            totaltardevale = Convert.ToDouble(VendaVCDAO.tarde.ToString().Replace('.', ','));
                            totalvale = (totaltardevale + totalmanhavale);
                            TotalVale();
                        }
                        catch
                        {

                        }

                    }
                }
            }
            #endregion

        }

        private void InicialCaixa_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
            codcaixa = DinheiroDAO.codcaixa;
            DateTime data = FechamentoDAO.data;

            //contasDAO.UpdateAtrasado();


            #region SANGRIA
            if (sanDAO.Verificasangria(codcaixa) == true)
            {
                try
                {
                    totsang = Convert.ToDouble(SangriaDAO.totalsangria.ToString().Replace('.', ','));
                    btnSangria.Text = "F4 - Sangria" + "\n Total : " + (totsang).ToString("C2");
                }
                catch
                {

                }

            }
            #endregion
            #region RECARGA
            if (recDAO.Verificarecarga(data) == true)
            {

                try
                {
                    totalmanharec = Convert.ToDouble(RecargaDAO.totalrecarga.ToString().Replace('.', ','));
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totrec).ToString("C2");
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "1")
                {
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totalmanharec).ToString("C2");
                }
                else
                {
                    if (recDAO.Verificarecarga2(data) == true)
                    {
                        try
                        {
                            totaltarderec = Convert.ToDouble(RecargaDAO.totalrecarga2.ToString().Replace('.', ','));
                            totalrec = (totaltarderec + totalmanharec);
                            //totalrec = Convert.ToDouble(RecargaDAO.totalrecarga2.ToString().Replace('.', ','));
                            //totaltarderec = (totalrec - totalmanharec);
                            TotalRec();
                        }
                        catch
                        {

                        }

                    }
                }
            }
            #endregion
            #region DINHEIRO
            if (dinDAO.Verificatotal(codcaixa) == true)
            {
                try
                {
                    total = Convert.ToDouble(DinheiroDAO.Totalmanha.ToString().Replace('.', ','));
                  
                }
                catch
                {

                }


            }

            #endregion
            #region VALECAP
            if (vvcDAO.VerificaVenda(data) == true)
            {

                try
                {
                    totalmanhavale = Convert.ToDouble(VendaVCDAO.manha.ToString().Replace('.', ','));
                    btnValecap.Text = "F3 - Vale Cap" + "\n Total : " + (totalvale).ToString("C2");
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "1")
                {
                    btnValecap.Text = "F3 - Vale Cap" + "\n Total : " + (totalmanhavale).ToString("C2");
                }
                else
                {
                    if (vvcDAO.VerificaVenda2(data) == true)
                    {
                        try
                        {
                            totaltardevale = Convert.ToDouble(VendaVCDAO.tarde.ToString().Replace('.', ','));
                            totalvale = (totaltardevale + totalmanhavale);
                            TotalVale();
                        }
                        catch
                        {

                        }

                    }
                }
            }
            #endregion

            #region LOGIN
            login = UsuarioDAO.login;
            usuDAO.VerificaCargo(login);
            tipo = usuDAO.Usu.Tipo.ToString();
            #endregion


            if (tipo == "Operador" || tipo == "Operador\t")
            {
                usuárioToolStripMenuItem.Enabled = false;
                usuárioToolStripMenuItem1.Enabled = false;
                btnRecebimento.Visible = false;
            }
        }

        public void TotalRec()
        {
          
            btnRecarga.Text = "F2 - Recarga" + "\n Manhã : " + totalmanharec.ToString("C2") + "\n Tarde : " + totaltarderec.ToString("C2") + "\n Total : " + totalrec.ToString("C2");
        }

        public void TotalVale()
        {
           btnValecap.Text = "F3 - Vale Cap" + "\n Manhã : " + totalmanhavale.ToString("C2") + "\n Tarde : " + totaltardevale.ToString("C2") + "\n Total : " +totalvale.ToString("C2");
        }

        private void InicialCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {

                //DialogResult op;

                //op = MessageBox.Show("Você tem certeza?",
                //    "Saindo", MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question);

                //if (op == DialogResult.Yes)
                //{
                //    this.Hide();
                //    Login l = new Login();
                //    l.ShowDialog();
                //}
            }


            if (e.KeyValue.Equals(116))
            {
            

                #region LOGIN
                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();
                #endregion


                if (tipo != "Operador")
                {
                    frmGeral g = new frmGeral();
                    g.Owner = this;
                    g.ShowDialog();
                }
  



            }

          

            if (e.KeyValue.Equals(122))
            {

                DialogResult op;

                op = MessageBox.Show("Você tem certeza?",
                    "Saindo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    

                   
                      data_hora = DateTime.Now;
                        fec.Hrfinal = Convert.ToDateTime(data_hora.ToLongTimeString());
                        fec.Datafinal = Convert.ToDateTime(data_hora.ToShortDateString());
                        fec.Status = "Fechado";
                        fec.Responsavel = UsuarioDAO.login;
                        fec.Id_caixa = FechamentoDAO.codcaixa;
                        fecDAO.fechar(fec);
                       
                        Application.Restart();
                   
                   

            
                }
            }
            if (e.KeyValue.Equals(119))
            {
                frmFalta f = new frmFalta();
                f.Owner = this;
                f.ShowDialog();
            }

            if (e.KeyValue.Equals(120))
            {
                frmContasPagas cop = new frmContasPagas();
                cop.Owner = this;
                cop.ShowDialog();
            }


            if (e.KeyValue.Equals(118))
            {
                frmOpçãodeMoeda om = new frmOpçãodeMoeda();
                om.Owner = this;
                om.ShowDialog();
            }


            if (e.KeyValue.Equals(117))
            {

                frmOpcaoFecha f = new frmOpcaoFecha();
                f.ShowDialog();
            }
            if (e.KeyValue.Equals(113))
            {
                frmRecarga r = new frmRecarga();
                r.Owner = this;
                r.ShowDialog();
            }

            if (e.KeyValue.Equals(114))
            {
                frmOpValeCap op = new frmOpValeCap();
                op.Owner = this;
                op.ShowDialog();
            }

            if (e.KeyValue.Equals(115))
            {
                frmSangria san = new frmSangria();
                san.Owner = this;
                san.ShowDialog();
            }

            if (e.KeyValue.Equals(112))
            {
                frmMovimentoCaixa v = new frmMovimentoCaixa();
                v.Owner = this;
                v.ShowDialog();
            }
        }

        private void btnSangria_Click(object sender, EventArgs e)
        {
            frmSangria san = new frmSangria();
            san.Owner = this;
            san.ShowDialog();
        }

        private void InicialCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

      

        private void operadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadOperadora r = new frmCadOperadora();
            r.Owner = this;
            r.ShowDialog();
        }

        private void operadoraToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmExcluirOperadora r = new frmExcluirOperadora();
            r.Owner = this;
            r.ShowDialog();
        }

        private void operadoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmAlterarOperadora r = new frmAlterarOperadora();
            //r.Owner = this;
            //r.ShowDialog();
        }

        private void valoresDaOperadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmValorOperadora r = new frmValorOperadora();
            r.Owner = this;
            r.ShowDialog();
        }

        private void valoresOperadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcluirValores v = new frmExcluirValores();
            v.Owner = this;
            v.ShowDialog();
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            frmMovimentoCaixa v = new frmMovimentoCaixa();
            v.Owner = this;
            v.ShowDialog();
        }

        private void btnRecarga_Click(object sender, EventArgs e)
        {
            frmRecarga r = new frmRecarga();
            r.Owner = this;
            r.ShowDialog();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadusu u = new frmCadusu();
            u.Owner = this;
            u.ShowDialog();
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExcluirUsu eu = new frmExcluirUsu();
            eu.Owner = this;
            eu.ShowDialog();
        }

        private void btnMoeda_Click(object sender, EventArgs e)
        {
            frmOpçãodeMoeda om = new frmOpçãodeMoeda();
            om.Owner = this;
            om.ShowDialog();
        }

        private void btnValecap_Click(object sender, EventArgs e)
        {
            frmOpValeCap ovc = new frmOpValeCap();
            ovc.Owner = this;
            ovc.ShowDialog();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFunc cf = new frmCadFunc();
            cf.Owner = this;
            cf.ShowDialog();
        }

        private void btnFaltas_Click(object sender, EventArgs e)
        {
            frmFalta fta = new frmFalta();
            fta.Owner = this;
            fta.ShowDialog();
        }

        private void funcionárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExcluirFunc ef = new frmExcluirFunc();
            ef.Owner = this;
            ef.ShowDialog();
        }

        private void btnContas_Click(object sender, EventArgs e)
        {
            frmContasPagas cp = new frmContasPagas();
            cp.Owner = this;
            cp.ShowDialog();
        }

        private void btnRecebimento_Click(object sender, EventArgs e)
        {
            frmGeral g = new frmGeral();
            g.Owner = this;
            g.ShowDialog();
        }
    }
}
