using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmDinheiro : Form
    {
        Dinheiro din = new Dinheiro();
        DinheiroDAO dinDAO = new DinheiroDAO();
        UsuarioDAO usuDao = new UsuarioDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        int qtd1;
        int qtd2;
        int qtd3;
        int qtd4;
        int qtd5;
        int qtd6;
        int qtd7;
        int qtd8;
        int qtd9;
        int qtd10;
        int qtd11;
        double total;
        double totalnota;
        double totalmoeda;
        double total2r;
        double total5r;
        double total10r;
        double total20r;
        double total50r;
        double total100r;
        double total5c;
        double total10c;
        double total25c;
        double total50c;
        double total1r;
        string login;
        string tipo;
        Boolean update;
        public frmDinheiro()
        {
            InitializeComponent();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        public void Calcular()
        {
            total = (qtd1 * 0.05) + (qtd2 * 0.1) + (qtd3 * 0.25) + (qtd4 * 0.5) + (qtd5 * 1) + (qtd6 * 2) + (qtd7 * 5) + (qtd8 * 10) + (qtd9 * 20) + (qtd10 * 50) + (qtd11 * 100);
            lblTotal.Text = "Total : " + total.ToString("C2");
            total2r = (qtd6 * 2);
            lbl2.Text = "= " + total2r.ToString("C2");
            total5r = (qtd7 * 5);
            lbl5.Text = "= " + total5r.ToString("C2");
            total10r = (qtd8 * 10);
            lbl10.Text = "= " + total10r.ToString("C2");
            total20r = (qtd9 * 20);
            lbl20.Text = "= " + total20r.ToString("C2");
            total50r = (qtd10 * 50);
            lbl50.Text = "= " + total50r.ToString("C2");
            total100r = (qtd11 * 100);
            lbl100.Text = "= " + total100r.ToString("C2");

            total5c = (qtd1 * 0.05);
            lbl5c.Text = "= " + total5c.ToString("C2");

            total10c = (qtd2 * 0.1);
            lbl10c.Text = "= " + total10c.ToString("C2");

            total25c = (qtd3 * 0.25);
            lbl25c.Text = "= " + total25c.ToString("C2");

            total50c = (qtd4 * 0.5);
            lbl50c.Text = "= " + total50c.ToString("C2");

            total1r = (qtd5 * 1);
            lbl1r.Text = "= " + total1r.ToString("C2");

            totalnota = total2r + total5r + total10r + total20r + total50r + total100r;
            lblNota.Text = "= " + totalnota.ToString("C2");

            totalmoeda = total5c + total10c + total25c + total50c + total1r;
            lblMoeda.Text = "= " + totalmoeda.ToString("C2");
        }

        private void frmDinheiro_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
            Calcular();
            string codcaixa = DinheiroDAO.codcaixa;

            if (DinheiroDAO.abre == "DR")
            {
                if (dinDAO.Verificadinheiro(codcaixa) == true)
                {
                    login = UsuarioDAO.login;

                    usuDao.VerificaCargo(login);
                    tipo = usuDao.Usu.Tipo.ToString();
                    update = true;
                    txt2Reais.Text = dinDAO.Dinh.Nota_2.ToString();
                    txt5Reais.Text = dinDAO.Dinh.Nota_5.ToString();
                    txt10Reais.Text = dinDAO.Dinh.Nota_10.ToString();
                    txt20Reais.Text = dinDAO.Dinh.Nota_20.ToString();
                    txt50Reais.Text = dinDAO.Dinh.Nota_50.ToString();
                    txt100Reais.Text = dinDAO.Dinh.Nota_100.ToString();
                    txt1Real.Text = dinDAO.Dinh.Moeda_1.ToString();
                    txt5Centavos.Text = dinDAO.Dinh.Moeda_5.ToString();
                    txt10Centavos.Text = dinDAO.Dinh.Moeda_10.ToString();
                    txt25Centavos.Text = dinDAO.Dinh.Moeda_25.ToString();
                    txt50Centavos.Text = dinDAO.Dinh.Moeda_50.ToString();
                    Calcular();
                }
            }
            else
            {
                if (dinDAO.Verificagaveta(codcaixa) == true)
                {
                    login = UsuarioDAO.login;

                    usuDao.VerificaCargo(login);
                    tipo = usuDao.Usu.Tipo.ToString();
                    update = true;
                    txt2Reais.Text = dinDAO.Dinh.Nota_2.ToString();
                    txt5Reais.Text = dinDAO.Dinh.Nota_5.ToString();
                    txt10Reais.Text = dinDAO.Dinh.Nota_10.ToString();
                    txt20Reais.Text = dinDAO.Dinh.Nota_20.ToString();
                    txt50Reais.Text = dinDAO.Dinh.Nota_50.ToString();
                    txt100Reais.Text = dinDAO.Dinh.Nota_100.ToString();
                    txt1Real.Text = dinDAO.Dinh.Moeda_1.ToString();
                    txt5Centavos.Text = dinDAO.Dinh.Moeda_5.ToString();
                    txt10Centavos.Text = dinDAO.Dinh.Moeda_10.ToString();
                    txt25Centavos.Text = dinDAO.Dinh.Moeda_25.ToString();
                    txt50Centavos.Text = dinDAO.Dinh.Moeda_50.ToString();
                    Calcular();
                }
            }
        }

        private void txt5Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt5Centavos.Text != string.Empty)
            {
                qtd1 = Convert.ToInt32(txt5Centavos.Text);
                Calcular();
            }
            else
            {
                qtd1 = 0;
                Calcular();
            }
        }

        private void txt10Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt10Centavos.Text != string.Empty)
            {
                qtd2 = Convert.ToInt32(txt10Centavos.Text);
                Calcular();
            }
            else
            {
                qtd2 = 0;
                Calcular();
            }
        }

        private void txt25Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt25Centavos.Text != string.Empty)
            {
                qtd3 = Convert.ToInt32(txt25Centavos.Text);
                Calcular();
            }
            else
            {
                qtd3 = 0;
                Calcular();
            }
        }

        private void txt50Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt50Centavos.Text != string.Empty)
            {
                qtd4 = Convert.ToInt32(txt50Centavos.Text);
                Calcular();
            }
            else
            {
                qtd4 = 0;
                Calcular();
            }
        }

        private void txt1Real_TextChanged(object sender, EventArgs e)
        {
            if (txt1Real.Text != string.Empty)
            {
                qtd5 = Convert.ToInt32(txt1Real.Text);
                Calcular();
            }
            else
            {
                qtd5 = 0;
                Calcular();
            }
        }

        private void txt2Reais_TextChanged(object sender, EventArgs e)
        {
            if (txt2Reais.Text != string.Empty)
            {
                qtd6 = Convert.ToInt32(txt2Reais.Text);
                Calcular();
            }
            else
            {
                qtd6 = 0;
                Calcular();
            }
        }

        private void txt5Reais_TextChanged(object sender, EventArgs e)
        {
            if (txt5Reais.Text != string.Empty)
            {
                qtd7 = Convert.ToInt32(txt5Reais.Text);
                Calcular();
            }
            else
            {
                qtd7 = 0;
                Calcular();
            }
        }

        private void txt10Reais_TextChanged(object sender, EventArgs e)
        {
            if (txt10Reais.Text != string.Empty)
            {
                qtd8 = Convert.ToInt32(txt10Reais.Text);
                Calcular();
            }
            else
            {
                qtd8 = 0;
                Calcular();
            }
        }

        private void txt25Reais_TextChanged(object sender, EventArgs e)
        {
            if (txt20Reais.Text != string.Empty)
            {
                qtd9 = Convert.ToInt32(txt20Reais.Text);
                Calcular();
            }
            else
            {
                qtd9 = 0;
                Calcular();
            }
        }

        private void txt50Reais_TextChanged(object sender, EventArgs e)
        {
            if (txt50Reais.Text != string.Empty)
            {
                qtd10 = Convert.ToInt32(txt50Reais.Text);
                Calcular();
            }
            else
            {
                qtd10 = 0;
                Calcular();
            }
        }

        private void txt100Reais_TextChanged(object sender, EventArgs e)
        {
            if (txt100Reais.Text != string.Empty)
            {
                qtd11 = Convert.ToInt32(txt100Reais.Text);
                Calcular();
            }
            else
            {
                qtd11 = 0;
                Calcular();
            }
        }

        private void txt5Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt10Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt25Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt50Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt1Real_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt2Reais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt5Reais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt10Reais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt20Reais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt50Reais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt100Reais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza?",
                "Salvando e saindo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                if (update == true)
                {
                    if (tipo == "Administrador")
                    {
                        if (DinheiroDAO.abre == "DR")
                        {
                            if (txt5Centavos.Text == string.Empty)
                            {
                                din.Moeda_5 = 0;
                            }
                            else
                            {
                                din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                din.Moeda_10 = 0;
                            }
                            else
                            {
                                din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                din.Moeda_25 = 0;
                            }
                            else
                            {
                                din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                din.Moeda_50 = 0;
                            }
                            else
                            {
                                din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                din.Moeda_1 = 0;
                            }
                            else
                            {
                                din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }

                            if (txt2Reais.Text == string.Empty)
                            {
                                din.Nota_2 = 0;
                            }
                            else
                            {
                                din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                            }

                            if (txt5Reais.Text == string.Empty)
                            {
                                din.Nota_5 = 0;
                            }
                            else
                            {
                                din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                            }

                            if (txt10Reais.Text == string.Empty)
                            {
                                din.Nota_10 = 0;
                            }
                            else
                            {
                                din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                            }
                            if (txt20Reais.Text == string.Empty)
                            {
                                din.Nota_20 = 0;
                            }
                            else
                            {
                                din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                            }
                            if (txt50Reais.Text == string.Empty)
                            {
                                din.Nota_50 = 0;
                            }
                            else
                            {
                                din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                            }
                            if (txt100Reais.Text == string.Empty)
                            {
                                din.Nota_100 = 0;
                            }
                            else
                            {
                                din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                            }
                            din.Id_caixa = dinDAO.Dinh.Id_caixa;
                            dinDAO.update(din);
                            string codcaixa = DinheiroDAO.codcaixa;
                            dinDAO.Verificaqtd(codcaixa);
                            string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                            dinDAO.updatetotal(codqtd);

                            aud.Acao = "ALTEROU DINHEIRO";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);

                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            this.Close();
                        }
                        else
                        {
                            if (txt5Centavos.Text == string.Empty)
                            {
                                din.Moeda_5 = 0;
                            }
                            else
                            {
                                din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                din.Moeda_10 = 0;
                            }
                            else
                            {
                                din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                din.Moeda_25 = 0;
                            }
                            else
                            {
                                din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                din.Moeda_50 = 0;
                            }
                            else
                            {
                                din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                din.Moeda_1 = 0;
                            }
                            else
                            {
                                din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }

                            if (txt2Reais.Text == string.Empty)
                            {
                                din.Nota_2 = 0;
                            }
                            else
                            {
                                din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                            }

                            if (txt5Reais.Text == string.Empty)
                            {
                                din.Nota_5 = 0;
                            }
                            else
                            {
                                din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                            }

                            if (txt10Reais.Text == string.Empty)
                            {
                                din.Nota_10 = 0;
                            }
                            else
                            {
                                din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                            }
                            if (txt20Reais.Text == string.Empty)
                            {
                                din.Nota_20 = 0;
                            }
                            else
                            {
                                din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                            }
                            if (txt50Reais.Text == string.Empty)
                            {
                                din.Nota_50 = 0;
                            }
                            else
                            {
                                din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                            }
                            if (txt100Reais.Text == string.Empty)
                            {
                                din.Nota_100 = 0;
                            }
                            else
                            {
                                din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                            }
                            din.Id_caixa = dinDAO.Dinh.Id_caixa;
                            dinDAO.Updategaveta(din);
                            string codcaixa = DinheiroDAO.codcaixa;
                            dinDAO.Verificaqtdgaveta(codcaixa);
                            string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                            dinDAO.Updatetotalgaveta(codqtd);

                            aud.Acao = "ALTEROU DINHEIRO GAVETA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);

                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Você não possui privilégios suficientes para alterar !!!");
                    }
                }
                else
                {
                    if (DinheiroDAO.abre == "DR")
                    {
                        try
                        {
                            if (txt5Centavos.Text == string.Empty)
                            {
                                din.Moeda_5 = 0;
                            }
                            else
                            {
                                din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                din.Moeda_10 = 0;
                            }
                            else
                            {
                                din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                din.Moeda_25 = 0;
                            }
                            else
                            {
                                din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                din.Moeda_50 = 0;
                            }
                            else
                            {
                                din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                din.Moeda_1 = 0;
                            }
                            else
                            {
                                din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }

                            if (txt2Reais.Text == string.Empty)
                            {
                                din.Nota_2 = 0;
                            }
                            else
                            {
                                din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                            }

                            if (txt5Reais.Text == string.Empty)
                            {
                                din.Nota_5 = 0;
                            }
                            else
                            {
                                din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                            }

                            if (txt10Reais.Text == string.Empty)
                            {
                                din.Nota_10 = 0;
                            }
                            else
                            {
                                din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                            }
                            if (txt20Reais.Text == string.Empty)
                            {
                                din.Nota_20 = 0;
                            }
                            else
                            {
                                din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                            }
                            if (txt50Reais.Text == string.Empty)
                            {
                                din.Nota_50 = 0;
                            }
                            else
                            {
                                din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                            }
                            if (txt100Reais.Text == string.Empty)
                            {
                                din.Nota_100 = 0;
                            }
                            else
                            {
                                din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                            }
                            din.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);

                            dinDAO.inserir(din);
                            string codcaixa = DinheiroDAO.codcaixa;
                            dinDAO.Verificaqtd(codcaixa);
                            string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                            dinDAO.updatetotal(codqtd);

                            aud.Acao = "INSERIU DINHEIRO";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);

                            MessageBox.Show("Informações salvas com sucesso!!!");
                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            this.Close();
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            if (txt5Centavos.Text == string.Empty)
                            {
                                din.Moeda_5 = 0;
                            }
                            else
                            {
                                din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                din.Moeda_10 = 0;
                            }
                            else
                            {
                                din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                din.Moeda_25 = 0;
                            }
                            else
                            {
                                din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                din.Moeda_50 = 0;
                            }
                            else
                            {
                                din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                din.Moeda_1 = 0;
                            }
                            else
                            {
                                din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }

                            if (txt2Reais.Text == string.Empty)
                            {
                                din.Nota_2 = 0;
                            }
                            else
                            {
                                din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                            }

                            if (txt5Reais.Text == string.Empty)
                            {
                                din.Nota_5 = 0;
                            }
                            else
                            {
                                din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                            }

                            if (txt10Reais.Text == string.Empty)
                            {
                                din.Nota_10 = 0;
                            }
                            else
                            {
                                din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                            }
                            if (txt20Reais.Text == string.Empty)
                            {
                                din.Nota_20 = 0;
                            }
                            else
                            {
                                din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                            }
                            if (txt50Reais.Text == string.Empty)
                            {
                                din.Nota_50 = 0;
                            }
                            else
                            {
                                din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                            }
                            if (txt100Reais.Text == string.Empty)
                            {
                                din.Nota_100 = 0;
                            }
                            else
                            {
                                din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                            }
                            din.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);

                            dinDAO.Inserirgaveta(din);
                            string codcaixa = DinheiroDAO.codcaixa;
                            dinDAO.Verificaqtdgaveta(codcaixa);
                            string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                            dinDAO.Updatetotalgaveta(codqtd);


                            aud.Acao = "INSERIU DINHEIRO GAVETA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);



                            MessageBox.Show("Informações salvas com sucesso!!!");
                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            this.Close();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza?",
                    "Saindo sem salvar!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (e.KeyValue.Equals(121))
            {

                DialogResult op;

                op = MessageBox.Show("Você tem certeza?",
                    "Salvando e saindo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    if (update == true)
                    {
                        if (tipo == "Administrador")
                        {
                            if (DinheiroDAO.abre == "DR")
                            {
                                if (txt5Centavos.Text == string.Empty)
                                {
                                    din.Moeda_5 = 0;
                                }
                                else
                                {
                                    din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                                }

                                if (txt10Centavos.Text == string.Empty)
                                {
                                    din.Moeda_10 = 0;
                                }
                                else
                                {
                                    din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                                }
                                if (txt25Centavos.Text == string.Empty)
                                {
                                    din.Moeda_25 = 0;
                                }
                                else
                                {
                                    din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                                }
                                if (txt50Centavos.Text == string.Empty)
                                {
                                    din.Moeda_50 = 0;
                                }
                                else
                                {
                                    din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                                }

                                if (txt1Real.Text == string.Empty)
                                {
                                    din.Moeda_1 = 0;
                                }
                                else
                                {
                                    din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                                }

                                if (txt2Reais.Text == string.Empty)
                                {
                                    din.Nota_2 = 0;
                                }
                                else
                                {
                                    din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                                }

                                if (txt5Reais.Text == string.Empty)
                                {
                                    din.Nota_5 = 0;
                                }
                                else
                                {
                                    din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                                }

                                if (txt10Reais.Text == string.Empty)
                                {
                                    din.Nota_10 = 0;
                                }
                                else
                                {
                                    din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                                }
                                if (txt20Reais.Text == string.Empty)
                                {
                                    din.Nota_20 = 0;
                                }
                                else
                                {
                                    din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                                }
                                if (txt50Reais.Text == string.Empty)
                                {
                                    din.Nota_50 = 0;
                                }
                                else
                                {
                                    din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                                }
                                if (txt100Reais.Text == string.Empty)
                                {
                                    din.Nota_100 = 0;
                                }
                                else
                                {
                                    din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                                }
                                din.Id_caixa = dinDAO.Dinh.Id_caixa;
                                dinDAO.update(din);
                                string codcaixa = DinheiroDAO.codcaixa;
                                dinDAO.Verificaqtd(codcaixa);
                                string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                                dinDAO.updatetotal(codqtd);

                                aud.Acao = "ALTEROU DINHEIRO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                ((frmOpcaoFecha)this.Owner).AtualizaDados();
                                this.Close();
                            }
                            else
                            {
                                if (txt5Centavos.Text == string.Empty)
                                {
                                    din.Moeda_5 = 0;
                                }
                                else
                                {
                                    din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                                }

                                if (txt10Centavos.Text == string.Empty)
                                {
                                    din.Moeda_10 = 0;
                                }
                                else
                                {
                                    din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                                }
                                if (txt25Centavos.Text == string.Empty)
                                {
                                    din.Moeda_25 = 0;
                                }
                                else
                                {
                                    din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                                }
                                if (txt50Centavos.Text == string.Empty)
                                {
                                    din.Moeda_50 = 0;
                                }
                                else
                                {
                                    din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                                }

                                if (txt1Real.Text == string.Empty)
                                {
                                    din.Moeda_1 = 0;
                                }
                                else
                                {
                                    din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                                }

                                if (txt2Reais.Text == string.Empty)
                                {
                                    din.Nota_2 = 0;
                                }
                                else
                                {
                                    din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                                }

                                if (txt5Reais.Text == string.Empty)
                                {
                                    din.Nota_5 = 0;
                                }
                                else
                                {
                                    din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                                }

                                if (txt10Reais.Text == string.Empty)
                                {
                                    din.Nota_10 = 0;
                                }
                                else
                                {
                                    din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                                }
                                if (txt20Reais.Text == string.Empty)
                                {
                                    din.Nota_20 = 0;
                                }
                                else
                                {
                                    din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                                }
                                if (txt50Reais.Text == string.Empty)
                                {
                                    din.Nota_50 = 0;
                                }
                                else
                                {
                                    din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                                }
                                if (txt100Reais.Text == string.Empty)
                                {
                                    din.Nota_100 = 0;
                                }
                                else
                                {
                                    din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                                }
                                din.Id_caixa = dinDAO.Dinh.Id_caixa;
                                dinDAO.Updategaveta(din);
                                string codcaixa = DinheiroDAO.codcaixa;
                                dinDAO.Verificaqtdgaveta(codcaixa);
                                string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                                dinDAO.Updatetotalgaveta(codqtd);

                                aud.Acao = "ALTEROU DINHEIRO GAVETA";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                ((frmOpcaoFecha)this.Owner).AtualizaDados();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não possui privilégios suficientes para alterar !!!");
                        }
                    }
                    else
                    {
                        if (DinheiroDAO.abre == "DR")
                        {
                            try
                            {
                                if (txt5Centavos.Text == string.Empty)
                                {
                                    din.Moeda_5 = 0;
                                }
                                else
                                {
                                    din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                                }

                                if (txt10Centavos.Text == string.Empty)
                                {
                                    din.Moeda_10 = 0;
                                }
                                else
                                {
                                    din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                                }
                                if (txt25Centavos.Text == string.Empty)
                                {
                                    din.Moeda_25 = 0;
                                }
                                else
                                {
                                    din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                                }
                                if (txt50Centavos.Text == string.Empty)
                                {
                                    din.Moeda_50 = 0;
                                }
                                else
                                {
                                    din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                                }

                                if (txt1Real.Text == string.Empty)
                                {
                                    din.Moeda_1 = 0;
                                }
                                else
                                {
                                    din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                                }

                                if (txt2Reais.Text == string.Empty)
                                {
                                    din.Nota_2 = 0;
                                }
                                else
                                {
                                    din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                                }

                                if (txt5Reais.Text == string.Empty)
                                {
                                    din.Nota_5 = 0;
                                }
                                else
                                {
                                    din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                                }

                                if (txt10Reais.Text == string.Empty)
                                {
                                    din.Nota_10 = 0;
                                }
                                else
                                {
                                    din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                                }
                                if (txt20Reais.Text == string.Empty)
                                {
                                    din.Nota_20 = 0;
                                }
                                else
                                {
                                    din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                                }
                                if (txt50Reais.Text == string.Empty)
                                {
                                    din.Nota_50 = 0;
                                }
                                else
                                {
                                    din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                                }
                                if (txt100Reais.Text == string.Empty)
                                {
                                    din.Nota_100 = 0;
                                }
                                else
                                {
                                    din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                                }
                                din.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);

                                dinDAO.inserir(din);
                                string codcaixa = DinheiroDAO.codcaixa;
                                dinDAO.Verificaqtd(codcaixa);
                                string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                                dinDAO.updatetotal(codqtd);

                                aud.Acao = "INSERIU DINHEIRO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                MessageBox.Show("Informações salvas com sucesso!!!");
                                ((frmOpcaoFecha)this.Owner).AtualizaDados();
                                this.Close();
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (txt5Centavos.Text == string.Empty)
                                {
                                    din.Moeda_5 = 0;
                                }
                                else
                                {
                                    din.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                                }

                                if (txt10Centavos.Text == string.Empty)
                                {
                                    din.Moeda_10 = 0;
                                }
                                else
                                {
                                    din.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                                }
                                if (txt25Centavos.Text == string.Empty)
                                {
                                    din.Moeda_25 = 0;
                                }
                                else
                                {
                                    din.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                                }
                                if (txt50Centavos.Text == string.Empty)
                                {
                                    din.Moeda_50 = 0;
                                }
                                else
                                {
                                    din.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                                }

                                if (txt1Real.Text == string.Empty)
                                {
                                    din.Moeda_1 = 0;
                                }
                                else
                                {
                                    din.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                                }

                                if (txt2Reais.Text == string.Empty)
                                {
                                    din.Nota_2 = 0;
                                }
                                else
                                {
                                    din.Nota_2 = Convert.ToInt32(txt2Reais.Text);
                                }

                                if (txt5Reais.Text == string.Empty)
                                {
                                    din.Nota_5 = 0;
                                }
                                else
                                {
                                    din.Nota_5 = Convert.ToInt32(txt5Reais.Text);
                                }

                                if (txt10Reais.Text == string.Empty)
                                {
                                    din.Nota_10 = 0;
                                }
                                else
                                {
                                    din.Nota_10 = Convert.ToInt32(txt10Reais.Text);
                                }
                                if (txt20Reais.Text == string.Empty)
                                {
                                    din.Nota_20 = 0;
                                }
                                else
                                {
                                    din.Nota_20 = Convert.ToInt32(txt20Reais.Text);
                                }
                                if (txt50Reais.Text == string.Empty)
                                {
                                    din.Nota_50 = 0;
                                }
                                else
                                {
                                    din.Nota_50 = Convert.ToInt32(txt50Reais.Text);
                                }
                                if (txt100Reais.Text == string.Empty)
                                {
                                    din.Nota_100 = 0;
                                }
                                else
                                {
                                    din.Nota_100 = Convert.ToInt32(txt100Reais.Text);
                                }
                                din.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);

                                dinDAO.Inserirgaveta(din);
                                string codcaixa = DinheiroDAO.codcaixa;
                                dinDAO.Verificaqtdgaveta(codcaixa);
                                string codqtd = dinDAO.Dinh.Id_qtd.ToString();
                                dinDAO.Updatetotalgaveta(codqtd);

                                aud.Acao = "INSERIU DINHEIRO GAVETA";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                MessageBox.Show("Informações salvas com sucesso!!!");
                                ((frmOpcaoFecha)this.Owner).AtualizaDados();
                                this.Close();
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }

        private void txt2Reais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt5Reais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt10Reais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt20Reais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt50Reais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt100Reais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt5Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt10Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt25Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt50Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt1Real_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOpcaoFecha f = new frmOpcaoFecha();
            f.ShowDialog();
        }
    }
}
