using System;
using System.Windows.Forms;
using System.Diagnostics;

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
        GeralDAO gerDAO = new GeralDAO();
        Geral ger = new Geral();
        RelattxDAO rlxDAO = new RelattxDAO();
        Relattx rlx = new Relattx();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        assinadaDAO assDAO = new assinadaDAO();
        Process myProcess = new Process();
        AcessoEmail email = new AcessoEmail();
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
        double totalnoitevale;
        double totalvale;
        double totalnoiterec;
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
            f.Owner = this;
            f.ShowDialog();
        }

        public void Atualizadados()
        {
            codcaixa = DinheiroDAO.codcaixa;
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
            }

            if (recDAO.Verificarecarga2(data) == true)
            {
                try
                {
                    totaltarderec = Convert.ToDouble(RecargaDAO.totalrecarga2.ToString().Replace('.', ','));
                    totalrec = (totaltarderec + totalmanharec);
                    if (FechamentoDAO.codturno == "2")
                    {
                        TotalRec();
                    }

                }
                catch
                {

                }

            }

            if (recDAO.Verificarecarga3(data) == true)
            {

                try
                {
                    totalnoiterec = Convert.ToDouble(RecargaDAO.totalrecarga3.ToString().Replace('.', ','));
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totrec).ToString("C2");
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "3")
                {
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totalnoiterec).ToString("C2");
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
            }

            if (vvcDAO.VerificaVenda2(data) == true)
            {
                try
                {
                    totaltardevale = Convert.ToDouble(VendaVCDAO.tarde.ToString().Replace('.', ','));
                    totalvale = (totaltardevale + totalmanhavale);
                    if (FechamentoDAO.codturno == "2")
                    {
                        TotalVale();
                    }
                }
                catch
                {

                }
            }

            if (vvcDAO.VerificaVenda3(data) == true)
            {

                try
                {
                    totalnoitevale = Convert.ToDouble(VendaVCDAO.noite.ToString().Replace('.', ','));

                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "3")
                {
                    btnValecap.Text = "F3 - Vale Cap" + "\n Total : " + (totalnoitevale).ToString("C2");
                }
            }



            #endregion
        }

        private void InicialCaixa_Load(object sender, EventArgs e)
        {
            //DateTime dataatual = DateTime.Now;
            //DateTime endlicense = Convert.ToDateTime("21/03/2019");

            //if (endlicense > dataatual)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Licensa expirada! Contate o Desenvolvedor.");
            //    Application.Exit();
            //}


            #region SODEXO
            if (rlxDAO.SDX(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloSD() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));

                        Double tot = (sd - 4.99);



                        if (vgDAO.Verificavalor() == false)
                        {
                            string zero = "0,00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "SODEXO";
                            ger.Deb_g = "";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }
                        else
                        {
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "SODEXO";
                            ger.Deb_g = "";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }

                        }



                    }
                    catch
                    {

                    }

                }
            }
            #endregion
            #region TICKET
            if (rlxDAO.TIC(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloTic() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));
                        Double tot = (sd - 5.68);


                        if (vgDAO.Verificavalor() == false)
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "TICKET";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Deb_g = "";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }
                        else
                        {
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "TICKET";
                            ger.Deb_g = "";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }

                        }


                    }
                    catch
                    {

                    }

                }
            }
            #endregion
            #region VR
            if (rlxDAO.VR(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloVR() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));
                        Double tot = (sd - 5.14);


                        if (vgDAO.Verificavalor() == false)
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "VR";
                            ger.Deb_g = "";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }
                        else
                        {
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "VR";
                            ger.Deb_g = "";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }

                        }

                    }
                    catch
                    {

                    }

                }
            }
            #endregion
            #region ALELO
            if (rlxDAO.ALELO(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloAlelo() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));
                        Double tot = (sd - 0.67);

                        if (vgDAO.Verificavalor() == false)
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "ALELO";
                            ger.Deb_g = "";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }
                        else
                        {
                            vgDAO.Update(tot.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = tot.ToString().Replace(".", "");
                            ger.Desc_g = "ALELO";
                            ger.Deb_g = "";
                            ger.Total = vgDAO.Vg.Valor;
                            if (tot > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }





                    }
                    catch
                    {

                    }

                }
            }
            #endregion
            #region CRÉDITO
            if (rlxDAO.CRED(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloC() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));

                        if (vgDAO.Verificavalor() == false)
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(sd.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = sd.ToString().Replace(".", "");
                            ger.Desc_g = "CARTÃO CRÉDITO";
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Deb_g = "";
                            ger.Total = vgDAO.Vg.Valor;
                            if (sd > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }
                        else
                        {
                            vgDAO.Update(sd.ToString());
                            vgDAO.Verificavalor();
                            ger.Data = FechamentoDAO.data;
                            ger.Cred_g = sd.ToString().Replace(".", "");
                            ger.Desc_g = "CARTÃO CRÉDITO";
                            ger.Deb_g = "";
                            ger.Total = vgDAO.Vg.Valor;
                            if (sd > 0)
                            {
                                gerDAO.Inserir(ger);
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }
            #endregion
            #region DÉBITO
            if (rlxDAO.DEB(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloD() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));


                        vgDAO.Update(sd.ToString());
                        vgDAO.Verificavalor();
                        ger.Data = FechamentoDAO.data;
                        ger.Cred_g = sd.ToString().Replace(".", "");
                        ger.Desc_g = "CARTÃO DÉBITO";
                        ger.Deb_g = "";
                        ger.Forn = "0,00";
                        ger.Func = "0,00";
                        ger.Total = vgDAO.Vg.Valor;
                        if (sd > 0)
                        {
                            gerDAO.Inserir(ger);
                        }
                    }
                    catch
                    {

                    }

                }
            }
            #endregion
            #region PLCARD
            if (rlxDAO.PLCARD(FechamentoDAO.data) == false)
            {
                if (rlxDAO.IntervaloPlcard() == true)
                {
                    try
                    {
                        Double sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace('.', ','));
                        Double tot = (sd - 7.80);

                        vgDAO.Update(tot.ToString());
                        vgDAO.Verificavalor();
                        ger.Data = FechamentoDAO.data;
                        ger.Cred_g = tot.ToString().Replace(".", "");
                        ger.Desc_g = "PLCARD";
                        ger.Forn = "0,00";
                        ger.Func = "0,00";
                        ger.Deb_g = "";
                        ger.Total = vgDAO.Vg.Valor;
                        if (tot > 0)
                        {
                            gerDAO.Inserir(ger);
                        }

                    }
                    catch
                    {

                    }

                }
            }
            #endregion

            Conexao.criar_Conexao();
            codcaixa = DinheiroDAO.codcaixa;
            DateTime data = FechamentoDAO.data;

            lblOperador.Text = "Bem vindo, " + UsuarioDAO.login + ".";
            if (FechamentoDAO.codturno == "1")
            {
                lblTurno.Text = "Turno: Manhã";
            }

            if (FechamentoDAO.codturno == "2")
            {
                lblTurno.Text = "Turno: Tarde";
            }

            if (FechamentoDAO.codturno == "3")
            {
                lblTurno.Text = "Turno: Noite";
            }

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
            }

            if (recDAO.Verificarecarga2(data) == true)
            {
                try
                {
                    totaltarderec = Convert.ToDouble(RecargaDAO.totalrecarga2.ToString().Replace('.', ','));
                    totalrec = (totaltarderec + totalmanharec);
                    if (FechamentoDAO.codturno == "2")
                    {
                        TotalRec();
                    }

                }
                catch
                {

                }

            }

            if (recDAO.Verificarecarga3(data) == true)
            {

                try
                {
                    totalnoiterec = Convert.ToDouble(RecargaDAO.totalrecarga3.ToString().Replace('.', ','));
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totrec).ToString("C2");
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "3")
                {
                    btnRecarga.Text = "F2 - Recarga" + "\n Total : " + (totalnoiterec).ToString("C2");
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
            }

            if (vvcDAO.VerificaVenda2(data) == true)
            {
                try
                {
                    totaltardevale = Convert.ToDouble(VendaVCDAO.tarde.ToString().Replace('.', ','));
                    totalvale = (totaltardevale + totalmanhavale);
                    if (FechamentoDAO.codturno == "2")
                    {
                        TotalVale();
                    }
                }
                catch
                {

                }
            }

            if (vvcDAO.VerificaVenda3(data) == true)
            {

                try
                {
                    totalnoitevale = Convert.ToDouble(VendaVCDAO.noite.ToString().Replace('.', ','));

                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "3")
                {
                    btnValecap.Text = "F3 - Vale Cap" + "\n Total : " + (totalnoitevale).ToString("C2");
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
                taxasToolStripMenuItem.Enabled = false;
                backupToolStripMenuItem.Enabled = false;

                btnRecebimento.Visible = false;
            }
        }

        public void TotalRec()
        {
            btnRecarga.Text = "F2 - Recarga" + "\n Manhã : " + totalmanharec.ToString("C2") + "\n Tarde : " + totaltarderec.ToString("C2") + "\n Total : " + totalrec.ToString("C2");
        }

        public void TotalVale()
        {
            btnValecap.Text = "F3 - Vale Cap" + "\n Manhã : " + totalmanhavale.ToString("C2") + "\n Tarde : " + totaltardevale.ToString("C2") + "\n Total : " + totalvale.ToString("C2");
        }

        private void InicialCaixa_KeyDown(object sender, KeyEventArgs e)
        {
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
                    aud.Acao = "FECHOU CAIXA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);
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
        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaxa t = new frmTaxa();
            t.Owner = this;
            t.ShowDialog();
        }
        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFunc cf = new frmCadFunc();
            cf.Owner = this;
            cf.ShowDialog();
        }
        private void fiadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiado ass = new frmFiado();
            ass.Owner = this;
            ass.ShowDialog();
        }
        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipo tipo = new frmTipo();
            tipo.Owner = this;
            tipo.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region senha e enviar email
            #region geradordeSenha

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);

            string senhagerada = finalString;
            #endregion
            assDAO.DeletaT();
            assDAO.InserirT(senhagerada);
            String mensagemEmail = senhagerada;

            frmTelaSplash sp = new frmTelaSplash();
            sp.Owner = this;
            sp.ShowDialog();

            try
            {
                email.enviarEmail(mensagemEmail, "leogz120100@gmail.com");
                //email.enviarEmail(mensagemEmail, "helder@microstation.com.br");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("erro:  {0}", ex.Message));
            }
            #endregion           
        }
    }
}
