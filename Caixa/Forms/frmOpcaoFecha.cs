using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmOpcaoFecha : Form
    {
        #region INSTANCIAMENTO CLASSES
        Valorcaixa vc = new Valorcaixa();
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        CredDeb cd = new CredDeb();
        credDebDAO cdDAO = new credDebDAO();
#pragma warning disable CS0169 // O campo "frmOpcaoFecha.data_hora" nunca é usado
        DateTime data_hora;
#pragma warning restore CS0169 // O campo "frmOpcaoFecha.data_hora" nunca é usado
        Dinheiro din = new Dinheiro();
        DinheiroDAO dinDAO = new DinheiroDAO();
        suprimentoDAO supriDAO = new suprimentoDAO();
        assinadaDAO assDAO = new assinadaDAO();
        CartaocaixaDAO carcai = new CartaocaixaDAO();
        SangriaDAO sanDAO = new SangriaDAO();
        FechamentoDAO fecDAO = new FechamentoDAO();
        Fechamento fec = new Fechamento();
        Verificas ver = new Verificas();
        VerificaDAO verDAO = new VerificaDAO();
        Diferenca difr = new Diferenca();
        diferencaDAO difDAO = new diferencaDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        Valorgeral vg = new Valorgeral();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        suprimentos supri = new suprimentos();
        #endregion

        #region VAR
#pragma warning disable CS0169 // O campo "frmOpcaoFecha.update" nunca é usado
        Boolean update;
#pragma warning restore CS0169 // O campo "frmOpcaoFecha.update" nunca é usado
        string codcaixa;
        double total;
        double totalgaveta;
        double totalsupri;
        string dinheiro;
        double classm;
        double assinadas;
        double julio;
        double totalmanhacart;
        double totalcart;
        double totaltarde;
        double dif;
        double totsang;
        string valor;
        string v;
        double valorrelat;
#pragma warning disable CS0169 // O campo "frmOpcaoFecha.codturno" nunca é usado
        string codturno;
#pragma warning restore CS0169 // O campo "frmOpcaoFecha.codturno" nunca é usado
        string tipo;
        string login;
        double noite;
        #endregion
        public frmOpcaoFecha()
        {
            InitializeComponent();
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            DinheiroDAO.abre = "DR";
            frmDinheiro d = new frmDinheiro();
            d.Owner = this;
            d.ShowDialog();
        }

        public void AtualizaDados()
        {
            Moeda(ref txtValorRelat);
            codcaixa = DinheiroDAO.codcaixa;
            DateTime data = FechamentoDAO.data;
            #region SANGRIA
            if (sanDAO.Verificasangria(codcaixa) == true)
            {
                try
                {
                    totsang = Convert.ToDouble(SangriaDAO.totalsangria.ToString().Replace('.', ','));
                }
                catch
                {

                }
            }
            #endregion

            #region GAVETA
            if (dinDAO.Verificatotalgaveta(codcaixa) == true)
            {
                try
                {
                    totalgaveta = Convert.ToDouble(DinheiroDAO.totalgaveta.ToString().Replace('.', ','));
                    btnGaveta.Text = "2 - Dinheiro Gaveta" + "\n Total : " + (totalgaveta).ToString("C2");
                }
                catch
                {

                }



            }
            #endregion

            #region DINHEIRO
            if (dinDAO.Verificatotal(codcaixa) == true)
            {
                try
                {
                    total = Convert.ToDouble(DinheiroDAO.Totalmanha.ToString().Replace('.', ','));
                    btnDinheiro.Text = "F1 - Dinheiro" + "\n Total : " + (total).ToString("C2");
                }
                catch
                {

                }

            }

            #endregion

            #region SUPRIMENTO
            if (supriDAO.Verificatotalsupri(codcaixa) == true)
            {
                try
                {
                    totalsupri = Convert.ToDouble(suprimentoDAO.totalsuprimento.ToString().Replace('.', ','));
                    btnSuprimento.Text = "F5 - Suprimento" + "\n Total : " + (totalsupri).ToString("C2");
                }
                catch
                {

                }

            }
            #endregion

            #region ASSINADAS
            if (assDAO.Buscar(codcaixa) == true)
            {
                try
                {
                    classm = Convert.ToDouble(assinadaDAO.classm.ToString().Replace('.', ','));
                    julio = Convert.ToDouble(assinadaDAO.julio.ToString().Replace('.', ','));
                    assinadas = Convert.ToDouble(assinadaDAO.assinada.ToString().Replace('.', ','));
                    Caclularass();
                }
                catch
                {

                }


            }
            #endregion

            #region CARTÕES


            if (carcai.testa(data) == true)
            {
                try
                {
                    totalmanhacart = Convert.ToDouble(CartaocaixaDAO.total.ToString().Replace('.', ','));
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "1")
                {
                    btnCartão.Text = "F3 - Cartão" + "\n Total : " + totalmanhacart.ToString("C2");
                }

            }



            if (carcai.testa2(data) == true)
            {
                try
                {
                    totalcart = Convert.ToDouble(CartaocaixaDAO.total2.ToString().Replace('.', ','));
                    totaltarde = (totalcart - totalmanhacart);
                    if (FechamentoDAO.codturno == "2")
                    {
                        TotalCart();
                    }
                }

                catch
                {

                }

            }

            if (carcai.testa3(data) == true)
            {
                try
                {
                    noite = Convert.ToDouble(CartaocaixaDAO.noite.ToString().Replace('.', ','));
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "3")
                {
                    btnCartão.Text = "F3 - Cartão" + "\n Total : " + noite.ToString("C2");
                }

            }
            Calcdif();
            #endregion
        }

        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {
            }
        }
        public void frmOpcaoFecha_Load(object sender, EventArgs e)
        {
            Moeda(ref txtValorRelat);
            codcaixa = DinheiroDAO.codcaixa;
            DateTime data = FechamentoDAO.data;
            fec.Id_caixa = Convert.ToInt32(codcaixa);

            try
            {
                valorrelat = Convert.ToDouble(FechamentoDAO.valor);
                txtValorRelat.Text = valorrelat.ToString();

                if (txtValorRelat.Text == "0,00")
                {
                    txtValorRelat.Enabled = true;
                    lblDif.Visible = false;
                }
                else
                {
                    lblDif.Visible = true;
                }


                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();

                fecDAO.VerificaRelat(codcaixa);

                if (fecDAO.Fec.Valor != "0.00")
                {
                    if (tipo == "Operador" || tipo == "Operador\t")
                    {
                        txtValorRelat.Enabled = false;
                    }
                }
            }
            catch
            {
            }

            #region SANGRIA
            if (sanDAO.Verificasangria(codcaixa) == true)
            {
                try
                {
                    totsang = Convert.ToDouble(SangriaDAO.totalsangria.ToString().Replace('.', ','));
                }
                catch
                {
                }
            }
            #endregion
            #region GAVETA
            if (dinDAO.Verificatotalgaveta(codcaixa) == true)
            {
                try
                {
                    totalgaveta = Convert.ToDouble(DinheiroDAO.totalgaveta.ToString().Replace('.', ','));
                    btnGaveta.Text = "2 - Dinheiro Gaveta" + "\n Total : " + (totalgaveta).ToString("C2");
                }
                catch
                {
                }
            }
            #endregion
            #region DINHEIRO
            if (dinDAO.Verificatotal(codcaixa) == true)
            {
                try
                {
                    total = Convert.ToDouble(DinheiroDAO.Totalmanha.ToString().Replace('.', ','));
                    btnDinheiro.Text = "F1 - Dinheiro retirada" + "\n Total : " + (total).ToString("C2");
                }
                catch
                {
                }
            }

            #endregion
            #region SUPRIMENTO
            if (supriDAO.Verificatotalsupri(codcaixa) == true)
            {
                try
                {
                    totalsupri = Convert.ToDouble(suprimentoDAO.Totalsuprimento.ToString().Replace('.', ','));
                    btnSuprimento.Text = "F5 - Suprimento" + "\n Total : " + (totalsupri).ToString("C2");
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    if (FechamentoDAO.codturno == "1")
                    {
                        dinDAO.PegaUltimoIdTurno1();
                        string cod = dinDAO.Dinh.Id_qtd.ToString();
                        dinDAO.PegaTotalUltimoIdTurno1(cod);
                    }
                    else if(FechamentoDAO.codturno == "2")
                    {
                        dinDAO.PegaUltimoIdTurno2();
                        string cod = dinDAO.Dinh.Id_qtd.ToString();
                        dinDAO.PegaTotalUltimoIdTurno2(cod);
                    }
                    double supr = Convert.ToDouble(dinDAO.Dinh.Total.ToString().Replace('.', ','));
                    btnSuprimento.Text = "F5 - Suprimento" + "\n Total : " + (supr).ToString("C2");

                    supri.Id_caixa = Convert.ToInt32(suprimentoDAO.codcaixa);
                    supri.Valor = supr.ToString().Replace(".", "");
                    supriDAO.inserir(supri);
                }
                catch
                {
                }               
            }
            #endregion
            #region ASSINADAS
            if (assDAO.Buscar(codcaixa) == true)
            {
                classm = Convert.ToDouble(assinadaDAO.classm.ToString().Replace('.', ','));
                julio = Convert.ToDouble(assinadaDAO.julio.ToString().Replace('.', ','));
                assinadas = Convert.ToDouble(assinadaDAO.assinada.ToString().Replace('.', ','));
                Caclularass();
            }
            #endregion
            #region CARTÕES
            if (carcai.testa(data) == true)
            {
                try
                {
                    totalmanhacart = Convert.ToDouble(CartaocaixaDAO.total.ToString().Replace('.', ','));
                }
                catch
                {
                }
                if (FechamentoDAO.codturno == "1")
                {
                    btnCartão.Text = "F3 - Cartão" + "\n Total : " + totalmanhacart.ToString("C2");
                }
            }



            if (carcai.testa2(data) == true)
            {
                try
                {
                    totalcart = Convert.ToDouble(CartaocaixaDAO.total2.ToString().Replace('.', ','));
                    totaltarde = (totalcart - totalmanhacart);
                    if (FechamentoDAO.codturno == "2")
                    {
                        TotalCart();
                    }
                }

                catch
                {

                }

            }

            if (carcai.testa3(data) == true)
            {
                try
                {
                    noite = Convert.ToDouble(CartaocaixaDAO.noite.ToString().Replace('.', ','));
                }
                catch
                {

                }
                if (FechamentoDAO.codturno == "3")
                {
                    btnCartão.Text = "F3 - Cartão" + "\n Total : " + noite.ToString("C2");
                }

            }







            Calcdif();
            #endregion
        }

        public void TotalCart()
        {
            //Esse void irá servir somente no caso do id_período=2
            btnCartão.Text = "F3 - Cartão" + "\n Manhã : " + totalmanhacart.ToString("C2") + "\n Tarde : " + totaltarde.ToString("C2") + "\n Total : " + totalcart.ToString("C2");
        }
        public void Caclularass()
        {
            btnFiado.Text = "F4 - Assinadas" + "\n Total: " + (classm + julio + assinadas).ToString("C2");
        }
        private void btnCartão_Click(object sender, EventArgs e)
        {
            totalcartao t = new totalcartao();
            t.Owner = this;
            t.ShowDialog();
        }

        private void btnFiado_Click(object sender, EventArgs e)
        {
            frmAssinadas a = new frmAssinadas();
            a.Owner = this;
            a.ShowDialog();
        }

        private void btnSuprimento_Click(object sender, EventArgs e)
        {
            frmSuprimento s = new frmSuprimento();
            s.Owner = this;
            s.ShowDialog();
        }

        private void txtValorRelat_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorRelat);
            v = txtValorRelat.Text;
            if (txtValorRelat.Text == string.Empty)
            {
                lblDif.Text = string.Empty;
            }
            else
            {
                Calcdif();
            }
        }
        public void Calcdif()
        {
            double valor;

            valor = Convert.ToDouble(txtValorRelat.Text);
            if (FechamentoDAO.codturno == "1")
            {
                dif = ((totalgaveta + total + classm + julio + assinadas + totalmanhacart) - (valor));
                lblDif.Text = "Diferença : " + dif.ToString("C2");
            }
            else
            {
                dif = ((totalgaveta + total + classm + julio + assinadas + totaltarde) - (valor));
                lblDif.Text = "Diferença : " + dif.ToString("C2");
            }
        }

        private void txtValorRelat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmRelatDif rd = new frmRelatDif();
            rd.Owner = this;
            rd.ShowDialog();
        }

        private void btnGaveta_Click(object sender, EventArgs e)
        {
            DinheiroDAO.abre = "DG";
            frmDinheiro d = new frmDinheiro();
            d.Owner = this;
            d.ShowDialog();
        }

        private void frmOpcaoFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(112))
            {
                DinheiroDAO.abre = "DR";
                frmDinheiro d = new frmDinheiro();
                d.Owner = this;
                d.ShowDialog();
            }
            if (e.KeyValue.Equals(113))
            {
                DinheiroDAO.abre = "DG";
                frmDinheiro d = new frmDinheiro();
                d.Owner = this;
                d.ShowDialog();
            }
            if (e.KeyValue.Equals(114))
            {
                totalcartao t = new totalcartao();
                t.Owner = this;
                t.ShowDialog();
            }
            if (e.KeyValue.Equals(115))
            {
                frmFiado a = new frmFiado();
                a.Owner = this;
                a.ShowDialog();
            }
            if (e.KeyValue.Equals(116))
            {         
                frmSuprimento s = new frmSuprimento();
                s.Owner = this;
                s.ShowDialog();
            }

            if (e.KeyValue.Equals(117))
            {
                frmRelatDif rd = new frmRelatDif();
                rd.Owner = this;
                rd.ShowDialog();

            }
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyValue.Equals(121))
            {
                if (txtValorRelat.Text == "0,00")
                {
                    MessageBox.Show("Valor inválido");
                }
                else
                {
                    try
                    {
                        DialogResult op;

                        op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + v + " R$",
                            "Salvando!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (op == DialogResult.Yes)
                        {
                            codcaixa = DinheiroDAO.codcaixa;
                            valor = txtValorRelat.Text.ToString().Replace(".", "");
                            fecDAO.Updatevalor(valor, codcaixa);
                            FechamentoDAO.valor = valor.ToString().Replace(",", ".");
                            //txtValorRelat.Enabled = false;
                            lblDif.Visible = true;
                            //btnSalvar.Enabled = false;
                            //((frmOpcaoFecha)this.Owner).AtualizaDados();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro !!!");
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region LOGIN
            login = UsuarioDAO.login;
            usuDAO.VerificaCargo(login);
            tipo = usuDAO.Usu.Tipo.ToString();
            #endregion

            string codcaixa = FechamentoDAO.codcaixa.ToString();

            if (txtValorRelat.Text == "0,00")
            {
                MessageBox.Show("Valor inválido");
            }
            else
            {
                try
                {
                    DialogResult op;

                    op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + v + " R$",
                        "Salvando!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (op == DialogResult.Yes)
                    {
                        fecDAO.VerificaRelat(codcaixa);
                        if (fecDAO.Fec.Valor != "0.00")
                        {
                            if (tipo == "Administrador")
                            {
                                codcaixa = DinheiroDAO.codcaixa;
                                valor = txtValorRelat.Text.ToString().Replace(".", "");
                                fecDAO.Updatevalor(valor, codcaixa);
                                FechamentoDAO.valor = valor.ToString().Replace(",", ".");
                                lblDif.Visible = true;
                                btnValor.Enabled = true;                                 
                            }
                            else
                            {
                                MessageBox.Show("Você não possui privilégios o suficiente para alterar");
                            }
                        }
                        else
                        {
                            codcaixa = DinheiroDAO.codcaixa;
                            valor = txtValorRelat.Text.ToString().Replace(".", "");
                            fecDAO.Updatevalor(valor, codcaixa);
                            FechamentoDAO.valor = valor.ToString().Replace(",", ".");
                            lblDif.Visible = true;
                            btnValor.Enabled = true;                           

                            if (tipo == "Administrador")
                            {
                                txtValorRelat.Enabled = true;
                            }
                            else
                            {
                                txtValorRelat.Enabled = false;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Erro !!!");
                }
            }
        }
        private void btnValor_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza dessas informações?",
                "Salvando!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (op == DialogResult.Yes)
            {
                if (vcDAO.Verificavalor() == true)
                {
                    dinheiro = DinheiroDAO.totalmanha;
                    if (dinheiro != null)
                    {
                        verDAO.Verifica();
                        #region CREDITO DEBITO
                        if (verDAO.Ver.Verifica == "SIM")
                        {
                            MessageBox.Show("Já foi enviado a retirada.");
                        }
                        else
                        {
                            vcDAO.Update(dinheiro);
                            vcDAO.Verificavalor();
                         
                            string datatela = DateTime.Now.ToShortDateString();
                            string hrtela = DateTime.Now.ToShortTimeString();
                            cd.Data = Convert.ToDateTime(datatela);
                            cd.Hora = Convert.ToDateTime(hrtela);
                            cd.Desc_db = "Fechamento PDV";
                            cd.Cred_db = total.ToString().Replace(".", "");
                            cd.Deb_db = "0,00";
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcDAO.Vc.Valor;
                            cd.C = null;

                            cdDAO.Inserir(cd);

                            #region GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update(total.ToString());
                                vgDAO.Verificavalor();

                                #region GERAL
                                string datatela1 = DateTime.Now.ToShortDateString();
                                ger.Data = Convert.ToDateTime(datatela1);
                                ger.Desc_g = "";
                                ger.Cred_g = total.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                #endregion
                            }
                            else
                            {
                                string zero1 = "0.00";
                                string datatela2 = DateTime.Now.ToShortDateString();
                                vgDAO.Inserir(zero1);
                                vgDAO.Update(total.ToString());
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(datatela2);
                                ger.Desc_g = "";
                                ger.Cred_g = total.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);


                                #endregion
                            }
                            #endregion

                            if (verDAO.Verifica() == true)
                            {
                                //update 
                                ver.Verifica = "SIM";
                                verDAO.Update(ver);
                            }
                            else
                            {
                                ver.Verifica = "SIM";
                                verDAO.Inserir(ver);
                                //inserir
                            }

                            if (FechamentoDAO.codturno == "1")
                            {
                                try
                                {
                                    difr.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                                    difr.Manha = dif.ToString().Replace(".", "");
                                    difr.Tarde = "";
                                    difDAO.Inserir(difr);
                                }
                                catch
                                {
                                    MessageBox.Show("Favor salvar o valor do dinheiro primeiro !!!");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (FechamentoDAO.codturno == "2")
                                    {
                                        if (difDAO.Verifica() == true)
                                        {
                                            string valor = dif.ToString().Replace(".", "");
                                            DateTime data = FechamentoDAO.data;
                                            difDAO.Update(valor, data);
                                        }
                                        else
                                        {
                                            difr.Id_caixa = Convert.ToInt32(FechamentoDAO.codcaixa);
                                            difr.Tarde = dif.ToString().Replace(".", "");
                                            difr.Manha = "";
                                            difDAO.Inserir(difr);
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            MessageBox.Show("Informações cadastradas com sucesso !!!");

                            aud.Acao = "ENVIOU RETIRADA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                        }
                        #endregion                        
                    }
                    else
                    {
                        if (FechamentoDAO.codturno =="3")
                        {
                            dinheiro = "0.00";
                            
                            verDAO.Verifica();
                            #region CREDITO DEBITO
                            if (verDAO.Ver.Verifica == "SIM")
                            {
                                MessageBox.Show("Já foi enviado a retirada.");
                            }
                            else
                            {
                                vcDAO.Update(dinheiro);
                                vcDAO.Verificavalor();

                                string datatela = DateTime.Now.ToShortDateString();
                                string hrtela = DateTime.Now.ToShortTimeString();
                                cd.Data = Convert.ToDateTime(datatela);
                                cd.Hora = Convert.ToDateTime(hrtela);
                                cd.Desc_db = "Fechamento PDV";
                                cd.Cred_db = total.ToString().Replace(".", "");
                                cd.Deb_db = "0,00";
                                cd.Responsa_db = UsuarioDAO.login;
                                cd.Total = vcDAO.Vc.Valor;
                                cd.C = null;

                                cdDAO.Inserir(cd);
                                if (verDAO.Verifica() == true)
                                {
                                    //update 
                                    ver.Verifica = "SIM";
                                    verDAO.Update(ver);
                                }
                                else
                                {
                                    ver.Verifica = "SIM";
                                    verDAO.Inserir(ver);
                                    //inserir
                                }

                                if (FechamentoDAO.codturno == "1")
                                {
                                    try
                                    {
                                        difr.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                                        difr.Manha = dif.ToString().Replace(".", "");
                                        difr.Tarde = "";
                                        difDAO.Inserir(difr);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Favor salvar o valor do relatório primeiro !!!");
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        if (difDAO.Verifica() == true)
                                        {
                                            string valor = dif.ToString().Replace(".", "");
                                            DateTime data = FechamentoDAO.data;
                                            difDAO.Update(valor, data);
                                        }
                                        else
                                        {
                                            difr.Id_caixa = Convert.ToInt32(FechamentoDAO.codcaixa);
                                            difr.Tarde = dif.ToString().Replace(".", "");
                                            difr.Manha = "";
                                            difDAO.Inserir(difr);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                MessageBox.Show("Informações cadastradas com sucesso !!!");

                                aud.Acao = "ENVIOU RETIRADA";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);
                            }
                            #endregion

                            #region GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update(total.ToString());
                                vgDAO.Verificavalor();


                                #region GERAL
                                string datatela1 = DateTime.Now.ToShortDateString();
                                ger.Data = Convert.ToDateTime(datatela1);
                                ger.Desc_g = "";
                                ger.Cred_g = total.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                #endregion
                            }
                            else
                            {
                                string zero1 = "0.00";
                                string datatela2 = DateTime.Now.ToShortDateString();
                                vgDAO.Inserir(zero1);
                                vgDAO.Update(total.ToString());
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(datatela2);
                                ger.Desc_g = "";
                                ger.Cred_g = total.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                #endregion
                            }

                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("Não existe valor de retirada");
                        }                      
                    }
                }
                else
                {
                    string zero = "0.00";
                    vcDAO.Inserir(zero);
                    dinheiro = DinheiroDAO.totalmanha;
                    if (dinheiro != null)
                    {
                        verDAO.Verifica();

                        #region CREDITO DEBITO
                        if (verDAO.Ver.Verifica == "SIM")
                        {
                            MessageBox.Show("Já foi enviado a retirada.");
                        }
                        else
                        {
                            vcDAO.Update(dinheiro);
                            vcDAO.Verificavalor();
                         
                            string datatela = DateTime.Now.ToShortDateString();
                            string hrtela = DateTime.Now.ToShortTimeString();
                            cd.Data = Convert.ToDateTime(datatela);
                            cd.Hora = Convert.ToDateTime(hrtela);
                            cd.Desc_db = "Fechamento PDV";
                            cd.Cred_db = total.ToString().Replace(".", "");
                            cd.Deb_db = "0,00";
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcDAO.Vc.Valor;
                            cd.C = null;

                            cdDAO.Inserir(cd);

                            if (verDAO.Verifica() == true)
                            {
                                //update 
                                ver.Verifica = "SIM";
                                verDAO.Update(ver);
                            }
                            else
                            {
                                ver.Verifica = "SIM";
                                verDAO.Inserir(ver);
                                //inserir
                            }

                            if (FechamentoDAO.codturno == "1")
                            {
                                try
                                {
                                    difr.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                                    difr.Manha = dif.ToString().Replace(".", "");
                                    difr.Tarde = "";
                                    difDAO.Inserir(difr);
                                }
                                catch
                                {
                                    MessageBox.Show("Favor salvar o valor do relatório primeiro !!!");
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (difDAO.Verifica() == true)
                                    {
                                        string valor = dif.ToString().Replace(".", "");
                                        DateTime data = FechamentoDAO.data;
                                        difDAO.Update(valor, data);
                                    }
                                    else if (FechamentoDAO.codturno == "2")
                                    {
                                        difr.Id_caixa = Convert.ToInt32(FechamentoDAO.codcaixa);
                                        difr.Tarde = dif.ToString().Replace(".", "");
                                        difr.Manha = "";
                                        difDAO.Inserir(difr);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            MessageBox.Show("Informações cadastradas com sucesso !!!");

                            aud.Acao = "ENVIOU RETIRADA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                            #endregion
                            
                           #region GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                vgDAO.Update(total.ToString());
                                vgDAO.Verificavalor();


                                #region GERAL
                                string datatela3 = DateTime.Now.ToShortDateString();
                                ger.Data = Convert.ToDateTime(datatela3);
                                ger.Desc_g = "";
                                ger.Cred_g = total.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                #endregion
                            }
                            else
                            {
                                string zero2 = "0.00";
                                string datatela4 = DateTime.Now.ToShortDateString();
                                vgDAO.Inserir(zero2);
                                vgDAO.Update(total.ToString());
                                vgDAO.Verificavalor();

                                #region GERAL
                                ger.Data = Convert.ToDateTime(datatela4);
                                ger.Desc_g = "";
                                ger.Cred_g = total.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);
                                #endregion
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não existe valor de retirada");
                    }
                }
            }
        }
    }
}
