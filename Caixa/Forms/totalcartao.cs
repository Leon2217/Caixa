using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class totalcartao : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        CartaomaquinaDAO carMaquinaDAO = new CartaomaquinaDAO();
        Cartaomaquina carMaq = new Cartaomaquina();
        Cartaocaixa carcai = new Cartaocaixa();
        CartaocaixaDAO carcaiDAO = new CartaocaixaDAO();
        MaquinasDAO maqDAO = new MaquinasDAO();
        Fechamento fecha = new Fechamento();
        FechamentoDAO fechaDAO = new FechamentoDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        TaxasDAO txDAO = new TaxasDAO();
        Relattx rtx = new Relattx();
        RelattxDAO rtxDAO = new RelattxDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        String login, tipo;
        Boolean update;
        string codmaq;
        double valor1;
        double valor2;
        double valor3;
        double valor4;
        double valor5;
        double valor6;
        double valor7;
        double valor8;
        double valor9;
        double valor10;
        double valor11;
        double valor12;
        double valor13;
        double valor14;
        double valor15;
        double valor16;
        double valor17;
        double valor18;
        double vl;
        double por;
        string codcart;
        double total;
        double totalcred;
        double totalref;
        double taxa;
        double totaltx;
        #endregion
        public totalcartao()
        {
            InitializeComponent();
        }
        public void Calcular()
        {
            total = valor1 + valor2 + valor3 + valor4 + valor5 + valor6 + valor7 + valor8 + valor9 + valor10 + valor11 + valor12 + valor13 + valor14 + valor15 + valor16 + valor17 + valor18;
            totalcred = valor1 + valor2 + valor3 + valor4 + valor5 + valor6 + valor7 + valor8;
            totalref = valor9 + valor10 + valor11 + valor12 + valor13 + valor14 + valor15 + valor16 + valor17 + valor18;
            lblCart.Text = "= " + totalcred.ToString("C2");
            lblTotal.Text = "Total : " + total.ToString("C2");
            lblRef.Text = "= " + totalref.ToString("C2");
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

        public void CarregarComboMaquina()
        {
            cmbMaquina.DataSource = maqDAO.ListarTudo();
            cmbMaquina.DisplayMember = "maquina";
            cmbMaquina.ValueMember = "id_maquina";
            codmaq = cmbMaquina.SelectedValue.ToString();
            string codcart1 = "1";
            string codcart2 = "2";
            string codcart3 = "3";
            string codcart4 = "4";
            string codcart5 = "5";
            string codcart6 = "6";
            string codcart7 = "7";
            string codcart8 = "8";
            string codcart9 = "9";
            string codcart10 = "10";
            string codcart11 = "11";
            string codcart12 = "12";
            string codcart13 = "14";
            string codcart14 = "15";
            string codcart15 = "16";
            string codcart16 = "17";
            string codcart17 = "18";
            string codcart18 = "19";
            if (carMaquinaDAO.Pesquisacart(codcart1, codmaq) == true)
            {
                txtVsCred.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart2, codmaq) == true)
            {
                txtVsDeb.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart3, codmaq) == true)
            {
                txtMsCred.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart4, codmaq) == true)
            {
                txtMsDeb.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart5, codmaq) == true)
            {
                txtEdebito.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart6, codmaq) == true)
            {
                txtEcredito.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart7, codmaq) == true)
            {
                txtHcredito.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart8, codmaq) == true)
            {
                txtEali.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart9, codmaq) == true)
            {
                txtEref.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart10, codmaq) == true)
            {
                txtSali.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart11, codmaq) == true)
            {
                txtSref.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart12, codmaq) == true)
            {
                txtTref.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart13, codmaq) == true)
            {
                txtEldebito.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart14, codmaq) == true)
            {
                txtVrali.Enabled = true;
            }

            if (carMaquinaDAO.Pesquisacart(codcart15, codmaq) == true)
            {
                txtVrref.Enabled = true;
            }
            if (carMaquinaDAO.Pesquisacart(codcart16, codmaq) == true)
            {
                txtTicketali.Enabled = true;
            }
            if (carMaquinaDAO.Pesquisacart(codcart17, codmaq) == true)
            {
                txtAlisoft.Enabled = true;
            }
            else
            {
                txtAlisoft.Enabled = false;
            }
            if (carMaquinaDAO.Pesquisacart(codcart18, codmaq) == true)
            {
                txtRefsoft.Enabled = true;
            }
            else
            {
                txtRefsoft.Enabled = false;
            }

        }
        private void cmbmaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            codmaq = cmbMaquina.SelectedValue.ToString();
            string codcart1 = "1";
            string codcart2 = "2";
            string codcart3 = "3";
            string codcart4 = "4";
            string codcart5 = "5";
            string codcart6 = "6";
            string codcart7 = "7";
            string codcart8 = "8";
            string codcart9 = "9";
            string codcart10 = "10";
            string codcart11 = "11";
            string codcart12 = "12";
            string codcart13 = "14";
            string codcart14 = "15";
            string codcart15 = "16";
            string codcart16 = "17";
            string codcart17 = "18";
            string codcart18 = "19";
            if (carMaquinaDAO.Pesquisacart(codcart1, codmaq) == true)
            {
                txtVsCred.Enabled = true;
            }
            else
            {
                txtVsCred.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart2, codmaq) == true)
            {
                txtVsDeb.Enabled = true;
            }
            else
            {
                txtVsDeb.Enabled = false;
            }


            if (carMaquinaDAO.Pesquisacart(codcart3, codmaq) == true)
            {
                txtMsCred.Enabled = true;
            }
            else
            {
                txtMsCred.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart4, codmaq) == true)
            {
                txtMsDeb.Enabled = true;
            }
            else
            {
                txtMsDeb.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart5, codmaq) == true)
            {
                txtEdebito.Enabled = true;
            }
            else
            {
                txtEdebito.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart6, codmaq) == true)
            {
                txtEcredito.Enabled = true;
            }
            else
            {
                txtEcredito.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart7, codmaq) == true)
            {
                txtHcredito.Enabled = true;
            }
            else
            {
                txtHcredito.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart8, codmaq) == true)
            {
                txtEali.Enabled = true;
            }
            else
            {
                txtEali.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart9, codmaq) == true)
            {
                txtEref.Enabled = true;
            }
            else
            {
                txtEref.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart10, codmaq) == true)
            {
                txtSali.Enabled = true;
            }
            else
            {
                txtSali.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart11, codmaq) == true)
            {
                txtSref.Enabled = true;
            }
            else
            {
                txtSref.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart12, codmaq) == true)
            {
                txtTref.Enabled = true;
            }
            else
            {
                txtTref.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart13, codmaq) == true)
            {
                txtEldebito.Enabled = true;
            }
            else
            {
                txtEldebito.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart14, codmaq) == true)
            {
                txtVrali.Enabled = true;
            }
            else
            {
                txtVrali.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart15, codmaq) == true)
            {
                txtVrref.Enabled = true;
            }
            else
            {
                txtVrref.Enabled = false;
            }
            if (carMaquinaDAO.Pesquisacart(codcart16, codmaq) == true)
            {
                txtTicketali.Enabled = true;
            }
            else
            {
                txtTicketali.Enabled = false;
            }

            if (carMaquinaDAO.Pesquisacart(codcart17, codmaq) == true)
            {
                txtAlisoft.Enabled = true;
            }
            else
            {
                txtAlisoft.Enabled = false;
            }
            if (carMaquinaDAO.Pesquisacart(codcart18, codmaq) == true)
            {
                txtRefsoft.Enabled = true;
            }
            else
            {
                txtRefsoft.Enabled = false;
            }

            string codcaixa = CartaocaixaDAO.codcaixa;
            if (carcaiDAO.vercarcai(codcaixa, codmaq) == true)
            {
                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();
                update = true;

                try
                {
                    txtVsCred.Text = CartaocaixaDAO.vscred.ToString();
                }
                catch
                {
                }
                try
                {
                    txtVsDeb.Text = CartaocaixaDAO.vsdeb.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEcredito.Text = CartaocaixaDAO.elocred.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEdebito.Text = CartaocaixaDAO.elodeb.ToString();
                }
                catch
                {
                }
                try
                {
                    txtMsCred.Text = CartaocaixaDAO.mscred.ToString();
                }
                catch
                {
                }
                try
                {
                    txtMsDeb.Text = CartaocaixaDAO.msdeb.ToString();
                }
                catch
                {
                }
                try
                {
                    txtHcredito.Text = CartaocaixaDAO.hipercard.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEldebito.Text = CartaocaixaDAO.electron.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEali.Text = CartaocaixaDAO.eloali.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEref.Text = CartaocaixaDAO.eloref.ToString();
                }
                catch
                {
                }
                try
                {
                    txtSali.Text = CartaocaixaDAO.sodexoali.ToString();
                }
                catch
                {
                }
                try
                {
                    txtSref.Text = CartaocaixaDAO.sodexoref.ToString();
                }
                catch
                {
                }
                try
                {
                    txtTref.Text = CartaocaixaDAO.ticket.ToString();
                }
                catch
                {
                }
                try
                {
                    txtVrali.Text = CartaocaixaDAO.vrali.ToString();
                }
                catch
                {
                }
                try
                {
                    txtVrref.Text = CartaocaixaDAO.vrrefei.ToString();
                }
                catch
                {
                }

                try
                {
                    txtTicketali.Text = CartaocaixaDAO.fakeline.ToString();
                }
                catch
                {
                }
                try
                {
                    txtAlisoft.Text = CartaocaixaDAO.alisoft.ToString();
                }
                catch
                {
                }
                try
                {
                    txtRefsoft.Text = CartaocaixaDAO.refsoft.ToString();
                }
                catch
                {
                }
            }
            else
            {
                update = false;
                Limpar();
            }
        }
        public void Atualizadados()
        {
            string codcaixa = CartaocaixaDAO.codcaixa;
            if (carcaiDAO.vercarcai(codcaixa, codmaq) == true)
            {
                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();
                update = true;

                txtVsCred.Text = CartaocaixaDAO.vscred.ToString();
                txtVsDeb.Text = CartaocaixaDAO.vsdeb.ToString();
                txtEcredito.Text = CartaocaixaDAO.elocred.ToString();
                txtEdebito.Text = CartaocaixaDAO.elodeb.ToString();
                txtMsCred.Text = CartaocaixaDAO.mscred.ToString();
                txtMsDeb.Text = CartaocaixaDAO.msdeb.ToString();
                txtHcredito.Text = CartaocaixaDAO.hipercard.ToString();
                txtEldebito.Text = CartaocaixaDAO.electron.ToString();
                txtEali.Text = CartaocaixaDAO.eloali.ToString();
                txtEref.Text = CartaocaixaDAO.eloref.ToString();
                txtSali.Text = CartaocaixaDAO.sodexoali.ToString();
                txtSref.Text = CartaocaixaDAO.sodexoref.ToString();
                txtTref.Text = CartaocaixaDAO.ticket.ToString();
                txtVrali.Text = CartaocaixaDAO.vrali.ToString();
                txtVrref.Text = CartaocaixaDAO.vrrefei.ToString();
                txtTicketali.Text = CartaocaixaDAO.fakeline.ToString();
                txtAlisoft.Text = CartaocaixaDAO.alisoft.ToString();
                txtRefsoft.Text = CartaocaixaDAO.refsoft.ToString();
            }
        }

        private void totalcartao_Load(object sender, EventArgs e)
        {
            CarregarComboMaquina();
            lblTotal.Text = "Total : " + total.ToString("C2");
            Moeda(ref txtVsCred);
            Moeda(ref txtVsDeb);
            Moeda(ref txtEcredito);
            Moeda(ref txtEdebito);
            Moeda(ref txtMsCred);
            Moeda(ref txtMsDeb);
            Moeda(ref txtHcredito);
            Moeda(ref txtEldebito);
            Moeda(ref txtEali);
            Moeda(ref txtEref);
            Moeda(ref txtSali);
            Moeda(ref txtSref);
            Moeda(ref txtTref);
            Moeda(ref txtVrali);
            Moeda(ref txtVrref);
            Moeda(ref txtTicketali);
            Moeda(ref txtAlisoft);
            Moeda(ref txtRefsoft);

            string codcaixa = CartaocaixaDAO.codcaixa;
            if (carcaiDAO.vercarcai(codcaixa, codmaq) == true)
            {
                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();
                update = true;

                try
                {
                    txtVsCred.Text = CartaocaixaDAO.vscred.ToString();
                }
                catch
                {
                }
                try
                {
                    txtVsDeb.Text = CartaocaixaDAO.vsdeb.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEcredito.Text = CartaocaixaDAO.elocred.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEdebito.Text = CartaocaixaDAO.elodeb.ToString();
                }
                catch
                {
                }
                try
                {
                    txtMsCred.Text = CartaocaixaDAO.mscred.ToString();
                }
                catch
                {
                }
                try
                {
                    txtMsDeb.Text = CartaocaixaDAO.msdeb.ToString();
                }
                catch
                {
                }
                try
                {
                    txtHcredito.Text = CartaocaixaDAO.hipercard.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEldebito.Text = CartaocaixaDAO.electron.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEali.Text = CartaocaixaDAO.eloali.ToString();
                }
                catch
                {
                }
                try
                {
                    txtEref.Text = CartaocaixaDAO.eloref.ToString();
                }
                catch
                {
                }
                try
                {
                    txtSali.Text = CartaocaixaDAO.sodexoali.ToString();
                }
                catch
                {
                }
                try
                {
                    txtSref.Text = CartaocaixaDAO.sodexoref.ToString();
                }
                catch
                {
                }
                try
                {
                    txtTref.Text = CartaocaixaDAO.ticket.ToString();
                }
                catch
                {
                }
                try
                {
                    txtVrali.Text = CartaocaixaDAO.vrali.ToString();
                }
                catch
                {
                }
                try
                {
                    txtVrref.Text = CartaocaixaDAO.vrrefei.ToString();
                }
                catch
                {
                }

                try
                {
                    txtTicketali.Text = CartaocaixaDAO.fakeline.ToString();
                }
                catch
                {
                }
                try
                {
                    txtAlisoft.Text = CartaocaixaDAO.alisoft.ToString();
                }
                catch
                {
                }
                try
                {

                    txtRefsoft.Text = CartaocaixaDAO.refsoft.ToString();
                }
                catch
                {
                }
            }
        }
        private void txtVsCred_TextChanged(object sender, EventArgs e)
        {

            Moeda(ref txtVsCred);
            if (txtVsCred.Text != string.Empty)
            {
                valor1 = Convert.ToDouble(txtVsCred.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void txtVsDeb_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtVsDeb);
            if (txtVsDeb.Text != string.Empty)
            {
                valor2 = Convert.ToDouble(txtVsDeb.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtEcredito_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEcredito);
            if (txtEcredito.Text != string.Empty)
            {
                valor3 = Convert.ToDouble(txtEcredito.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtEdebito_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEdebito);
            if (txtEdebito.Text != string.Empty)
            {
                valor4 = Convert.ToDouble(txtEdebito.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtMsCred_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtMsCred);
            if (txtMsCred.Text != string.Empty)
            {
                valor5 = Convert.ToDouble(txtMsCred.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtMsDeb_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtMsDeb);
            if (txtMsDeb.Text != string.Empty)
            {
                valor6 = Convert.ToDouble(txtMsDeb.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void txtHcredito_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtHcredito);
            if (txtHcredito.Text != string.Empty)
            {
                valor7 = Convert.ToDouble(txtHcredito.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtEali_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEali);
            if (txtEali.Text != string.Empty)
            {
                valor9 = Convert.ToDouble(txtEali.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void txtEref_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEref);
            if (txtEref.Text != string.Empty)
            {
                valor10 = Convert.ToDouble(txtEref.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtSali_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtSali);
            if (txtSali.Text != string.Empty)
            {
                valor11 = Convert.ToDouble(txtSali.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtSref_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtSref);
            if (txtSref.Text != string.Empty)
            {
                valor12 = Convert.ToDouble(txtSref.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtTref_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtTref);
            if (txtTref.Text != string.Empty)
            {
                valor13 = Convert.ToDouble(txtTref.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtEldebito_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtEldebito);
            if (txtEldebito.Text != string.Empty)
            {
                valor8 = Convert.ToDouble(txtEldebito.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtVrali_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtVrali);
            if (txtVrali.Text != string.Empty)
            {
                valor14 = Convert.ToDouble(txtVrali.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtVrref_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtVrref);
            if (txtVrref.Text != string.Empty)
            {
                valor15 = Convert.ToDouble(txtVrref.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        private void txtVsCred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void txtVsDeb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEcredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEdebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMsCred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMsDeb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtHcredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEldebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtSali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtSref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtTref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtVrali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtVrref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtVsCred_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtVsDeb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEcredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEdebito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtMsCred_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtMsDeb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtHcredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEldebito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEali_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtEref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtSali_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtSref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtTref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtVrali_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtVrref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            if (update == true)
            {
                if (tipo == "Administrador")
                {
                    if (txtVsCred.Text != string.Empty)
                    {

                        codcart = "1";
                        carcai.Valor = txtVsCred.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtVsCred.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVsCred.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtxDAO.Update(rtx);

                    }
                    else
                    {
                        codcart = "1";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtVsDeb.Text != string.Empty)
                    {
                        codcart = "2";
                        carcai.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtVsDeb.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "2";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtMsCred.Text != string.Empty)
                    {
                        codcart = "3";
                        carcai.Valor = txtMsCred.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtMsCred.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtMsCred.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "3";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtMsDeb.Text != string.Empty)
                    {
                        codcart = "4";
                        carcai.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        //vl = Convert.ToDouble(txtMsDeb.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "4";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtEdebito.Text != string.Empty)
                    {
                        codcart = "5";
                        carcai.Valor = txtEdebito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtEdebito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEdebito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "5";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtEcredito.Text != string.Empty)
                    {
                        codcart = "6";
                        carcai.Valor = txtEcredito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtEcredito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEcredito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "6";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtHcredito.Text != string.Empty)
                    {
                        codcart = "7";
                        carcai.Valor = txtHcredito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtHcredito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtHcredito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "7";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtEali.Text != string.Empty)
                    {
                        codcart = "8";
                        carcai.Valor = txtEali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtEali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "8";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtEref.Text != string.Empty)
                    {
                        codcart = "9";
                        carcai.Valor = txtEref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtEref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "9";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }
                    if (txtSali.Text != string.Empty)
                    {
                        codcart = "10";
                        carcai.Valor = txtSali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtSali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtSali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "10";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtSref.Text != string.Empty)
                    {
                        codcart = "11";
                        carcai.Valor = txtSref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtSref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtSref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "11";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtTref.Text != string.Empty)
                    {
                        codcart = "12";
                        carcai.Valor = txtTref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtTref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtTref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "12";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtEldebito.Text != string.Empty)
                    {
                        codcart = "14";
                        carcai.Valor = txtEldebito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtEldebito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEldebito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "14";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtVrref.Text != string.Empty)
                    {
                        codcart = "15";
                        carcai.Valor = txtVrref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtVrref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVrref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "15";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }

                    if (txtVrali.Text != string.Empty)
                    {
                        codcart = "16";
                        carcai.Valor = txtVrali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtVrali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVrali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "16";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }
                    if (txtTicketali.Text != string.Empty)
                    {
                        codcart = "17";
                        carcai.Valor = txtTicketali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtTicketali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtTicketali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "17";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }
                    if (txtAlisoft.Text != string.Empty)
                    {
                        codcart = "18";
                        carcai.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtAlisoft.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "18";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }
                    if (txtRefsoft.Text != string.Empty)
                    {
                        codcart = "19";
                        carcai.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);

                        vl = Convert.ToDouble(txtRefsoft.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Update(rtx);
                    }
                    else
                    {
                        codcart = "19";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.update(carcai);
                    }
                    MessageBox.Show("Dados alterados com sucesso !!!");
                    ((frmOpcaoFecha)this.Owner).AtualizaDados();

                    aud.Acao = "ALTEROU CART";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);

                }
                else
                {
                    MessageBox.Show("Você não possui requisitos o suficiente para alterar !!!");
                }
            }
            else
            {
                try
                {
                    if (txtVsCred.Text != string.Empty)
                    {
                        codcart = "1";
                        carcai.Valor = txtVsCred.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtVsCred.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));
                        
                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVsCred.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "1";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }

                    if (txtVsDeb.Text != string.Empty)
                    {
                        codcart = "2";
                        carcai.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtVsDeb.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "2";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtMsCred.Text != string.Empty)
                    {
                        codcart = "3";
                        carcai.Valor = txtMsCred.Text.Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtMsCred.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtMsCred.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "3";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtMsDeb.Text != string.Empty)
                    {
                        codcart = "4";
                        carcai.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtMsDeb.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "4";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtEdebito.Text != string.Empty)
                    {
                        codcart = "5";
                        carcai.Valor = txtEdebito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtEdebito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEdebito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);

                    }
                    else
                    {
                        codcart = "5";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }

                    if (txtEcredito.Text != string.Empty)
                    {
                        codcart = "6";
                        carcai.Valor = txtEcredito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtEcredito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEcredito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "6";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtHcredito.Text != string.Empty)
                    {
                        codcart = "7";
                        carcai.Valor = txtHcredito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtHcredito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtHcredito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "7";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }


                    if (txtEali.Text != string.Empty)
                    {
                        codcart = "8";
                        carcai.Valor = txtEali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtEali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "8";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtEref.Text != string.Empty)
                    {
                        codcart = "9";
                        carcai.Valor = txtEref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtEref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "9";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtSali.Text != string.Empty)
                    {
                        codcart = "10";
                        carcai.Valor = txtSali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtSali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtSali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "10";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtSref.Text != string.Empty)
                    {
                        codcart = "11";
                        carcai.Valor = txtSref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtSref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtSref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "11";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtTref.Text != string.Empty)
                    {
                        codcart = "12";
                        carcai.Valor = txtTref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtTref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtTref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "12";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtEldebito.Text != string.Empty)
                    {
                        codcart = "14";
                        carcai.Valor = txtEldebito.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtEldebito.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtEldebito.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "14";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }

                    if (txtVrali.Text != string.Empty)
                    {
                        codcart = "16";
                        carcai.Valor = txtVrali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtVrali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVrali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "16";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtVrref.Text != string.Empty)
                    {
                        codcart = "15";
                        carcai.Valor = txtVrref.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtVrref.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtVrref.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "15";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }

                    if (txtTicketali.Text != string.Empty)
                    {
                        codcart = "17";
                        carcai.Valor = txtTicketali.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtTicketali.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtTicketali.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "17";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtAlisoft.Text != string.Empty)
                    {
                        codcart = "18";
                        carcai.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtAlisoft.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "18";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    if (txtRefsoft.Text != string.Empty)
                    {
                        codcart = "19";
                        carcai.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);

                        vl = Convert.ToDouble(txtRefsoft.Text.ToString().Replace(".", ""));

                        txDAO.VerificaTaxa(codcart);
                        por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                        taxa = (vl * (por / 100));
                        totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                        rtx.Data = FechamentoDAO.data;
                        rtx.Id_cartao = Convert.ToInt32(codcart);
                        rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                        rtx.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                        rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                        rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        rtx.Id_maquina = Convert.ToInt32(codmaq);
                        rtxDAO.Inserir(rtx);
                    }
                    else
                    {
                        codcart = "19";
                        carcai.Valor = "0";
                        carcai.Id_cartao = Convert.ToInt32(codcart);
                        carcai.Id_maquina = Convert.ToInt32(codmaq);
                        carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                        carcaiDAO.inserir(carcai);
                    }
                    MessageBox.Show("Informações salvas com sucesso!!!");
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show($"ERRO: FOI IMPOSSÍVEL SALVAR ALGUNS VALORES, CONFIRA SE HÁ TAXAS CADASTRADAS E DEPOIS TENTE NOVAMENTE");
                }
                catch (Exception p)
                {
                    MessageBox.Show($"Erro inesperado, {p.Message}");
                }

                aud.Acao = "INSERIU CART";
                aud.Data = FechamentoDAO.data;
                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                aud.Responsavel = UsuarioDAO.login;
                audDAO.Inserir(aud);

                try
                {
                    ((frmOpcaoFecha)this.Owner).AtualizaDados();
                    Atualizadados();
                }
                catch
                {
                }
            }
        }
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtOutro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmOpcaoFecha f = new frmOpcaoFecha();
            f.ShowDialog();
        }

        private void totalcartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyValue.Equals(122))
            {
                frmRelatCartao relat = new frmRelatCartao();
                relat.Owner = this;
                relat.ShowDialog();
            }

            if (e.KeyValue.Equals(121))
            {

                DialogResult op;

                op = MessageBox.Show("Você tem certeza?",
                    "Alterando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    if (update == true)
                    {
                        if (tipo == "Administrador")
                        {
                            if (txtVsCred.Text != string.Empty)
                            {

                                codcart = "1";
                                carcai.Valor = txtVsCred.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtVsCred.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVsCred.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "1";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtVsDeb.Text != string.Empty)
                            {
                                codcart = "2";
                                carcai.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtVsDeb.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "2";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtMsCred.Text != string.Empty)
                            {
                                codcart = "3";
                                carcai.Valor = txtMsCred.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtMsCred.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtMsCred.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "3";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtMsDeb.Text != string.Empty)
                            {
                                codcart = "4";
                                carcai.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtMsDeb.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "4";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtEdebito.Text != string.Empty)
                            {
                                codcart = "5";
                                carcai.Valor = txtEdebito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtEdebito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEdebito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);

                            }
                            else
                            {
                                codcart = "5";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtEcredito.Text != string.Empty)
                            {
                                codcart = "6";
                                carcai.Valor = txtEcredito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtEcredito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEcredito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "6";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtHcredito.Text != string.Empty)
                            {
                                codcart = "7";
                                carcai.Valor = txtHcredito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtHcredito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtHcredito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "7";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtEali.Text != string.Empty)
                            {
                                codcart = "8";
                                carcai.Valor = txtEali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtEali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "8";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtEref.Text != string.Empty)
                            {
                                codcart = "9";
                                carcai.Valor = txtEref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtEref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "9";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }
                            if (txtSali.Text != string.Empty)
                            {
                                codcart = "10";
                                carcai.Valor = txtSali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtSali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtSali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "10";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtSref.Text != string.Empty)
                            {
                                codcart = "11";
                                carcai.Valor = txtSref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtSref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtSref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "11";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtTref.Text != string.Empty)
                            {
                                codcart = "12";
                                carcai.Valor = txtTref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtTref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtTref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "12";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtEldebito.Text != string.Empty)
                            {
                                codcart = "14";
                                carcai.Valor = txtEldebito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtEldebito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEldebito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "14";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);


                            }

                            if (txtVrref.Text != string.Empty)
                            {
                                codcart = "15";
                                carcai.Valor = txtVrref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtVrref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVrref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "15";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            if (txtVrali.Text != string.Empty)
                            {
                                codcart = "16";
                                carcai.Valor = txtVrali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtVrali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVrali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "16";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }
                            if (txtTicketali.Text != string.Empty)
                            {
                                codcart = "17";
                                carcai.Valor = txtTicketali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtTicketali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtTicketali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "17";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }
                            if (txtAlisoft.Text != string.Empty)
                            {
                                codcart = "18";
                                carcai.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtAlisoft.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "18";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }
                            if (txtRefsoft.Text != string.Empty)
                            {
                                codcart = "19";
                                carcai.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);

                                vl = Convert.ToDouble(txtRefsoft.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Update(rtx);
                            }
                            else
                            {
                                codcart = "19";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.update(carcai);
                            }

                            MessageBox.Show("Dados alterados com sucesso !!!");
                            aud.Acao = "ALTEROU CART";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                            ((frmOpcaoFecha)this.Owner).AtualizaDados();


                        }
                        else
                        {
                            MessageBox.Show("Você não possui requisitos o suficiente para alterar !!!");
                        }
                    }

                    else
                    {
                        try
                        {


                            if (txtVsCred.Text != string.Empty)
                            {

                                codcart = "1";
                                carcai.Valor = txtVsCred.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtVsCred.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVsCred.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "1";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }


                            if (txtVsDeb.Text != string.Empty)
                            {
                                codcart = "2";
                                carcai.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtVsDeb.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVsDeb.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "2";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }


                            if (txtMsCred.Text != string.Empty)
                            {
                                codcart = "3";
                                carcai.Valor = txtMsCred.Text.Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtMsCred.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtMsCred.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "3";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtMsDeb.Text != string.Empty)
                            {
                                codcart = "4";
                                carcai.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtMsDeb.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtMsDeb.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "4";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtEdebito.Text != string.Empty)
                            {
                                codcart = "5";
                                carcai.Valor = txtEdebito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtEdebito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEdebito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);

                            }
                            else
                            {
                                codcart = "5";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }

                            if (txtEcredito.Text != string.Empty)
                            {
                                codcart = "6";
                                carcai.Valor = txtEcredito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtEcredito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEcredito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "6";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtHcredito.Text != string.Empty)
                            {
                                codcart = "7";
                                carcai.Valor = txtHcredito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtHcredito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtHcredito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "7";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }


                            if (txtEali.Text != string.Empty)
                            {
                                codcart = "8";
                                carcai.Valor = txtEali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtEali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "8";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtEref.Text != string.Empty)
                            {
                                codcart = "9";
                                carcai.Valor = txtEref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtEref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "9";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtSali.Text != string.Empty)
                            {
                                codcart = "10";
                                carcai.Valor = txtSali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtSali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtSali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "10";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtSref.Text != string.Empty)
                            {
                                codcart = "11";
                                carcai.Valor = txtSref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtSref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtSref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "11";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtTref.Text != string.Empty)
                            {
                                codcart = "12";
                                carcai.Valor = txtTref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtTref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtTref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "12";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtEldebito.Text != string.Empty)
                            {
                                codcart = "14";
                                carcai.Valor = txtEldebito.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtEldebito.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));


                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtEldebito.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "14";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }

                            if (txtVrali.Text != string.Empty)
                            {
                                codcart = "16";
                                carcai.Valor = txtVrali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtVrali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVrali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "16";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtVrref.Text != string.Empty)
                            {
                                codcart = "15";
                                carcai.Valor = txtVrref.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtVrref.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtVrref.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "15";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtTicketali.Text != string.Empty)
                            {
                                codcart = "17";
                                carcai.Valor = txtTicketali.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtTicketali.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtTicketali.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "17";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtAlisoft.Text != string.Empty)
                            {
                                codcart = "18";
                                carcai.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtAlisoft.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtAlisoft.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "18";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);
                            }
                            if (txtRefsoft.Text != string.Empty)
                            {
                                codcart = "19";
                                carcai.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                                vl = Convert.ToDouble(txtRefsoft.Text.ToString().Replace(".", ""));

                                txDAO.VerificaTaxa(codcart);
                                por = Convert.ToDouble(txDAO.Taxas.Taxa.ToString().Replace('.', ','));
                                taxa = (vl * (por / 100));
                                totaltx = Convert.ToDouble((vl - taxa).ToString("#0.00"));

                                rtx.Data = FechamentoDAO.data;
                                rtx.Id_cartao = Convert.ToInt32(codcart);
                                rtx.Taxa = txDAO.Taxas.Taxa.ToString().Replace('.', ',');
                                rtx.Valor = txtRefsoft.Text.ToString().Replace(".", "");
                                rtx.Valor_ct = totaltx.ToString().Replace(".", "");
                                rtx.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                rtx.Id_maquina = Convert.ToInt32(codmaq);
                                rtxDAO.Inserir(rtx);
                            }
                            else
                            {
                                codcart = "19";
                                carcai.Valor = "0";
                                carcai.Id_cartao = Convert.ToInt32(codcart);
                                carcai.Id_maquina = Convert.ToInt32(codmaq);
                                carcai.Id_caixa = Convert.ToInt32(CartaocaixaDAO.codcaixa);
                                carcaiDAO.inserir(carcai);

                            }
                            MessageBox.Show("Informações salvas com sucesso!!!");
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show($"ERRO: FOI IMPOSSÍVEL SALVAR ALGUNS VALORES, CONFIRA SE HÁ TAXAS CADASTRADAS E DEPOIS TENTE NOVAMENTE");
                        }
                        catch (Exception p)
                        {
                            MessageBox.Show($"Erro inesperado, {p.Message}");
                        }

                        aud.Acao = "INSERIU CART";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                        try
                        {
                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            Atualizadados();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void txtTicketali_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtTicketali);
            if (txtTicketali.Text != string.Empty)
            {
                valor16 = Convert.ToDouble(txtTicketali.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void txtTicketali_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtTicketali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void txtAlisoft_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtAlisoft);
            if (txtAlisoft.Text != string.Empty)
            {
                valor17 = Convert.ToDouble(txtAlisoft.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void txtRefsoft_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtRefsoft);
            if (txtRefsoft.Text != string.Empty)
            {
                valor18 = Convert.ToDouble(txtRefsoft.Text);
                Calcular();
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void txtAlisoft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtRefsoft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {

                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtAlisoft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtRefsoft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnRelat_Click(object sender, EventArgs e)
        {
            frmRelatCartao rlc = new frmRelatCartao();
            rlc.Owner = this;
            rlc.ShowDialog();
        }

        public void Limpar()
        {
            txtVsCred.Clear();
            txtVsDeb.Clear();
            txtEali.Clear();
            txtEcredito.Clear();
            txtEdebito.Clear();
            txtEldebito.Clear();
            txtEref.Clear();
            txtHcredito.Clear();
            txtMsCred.Clear();
            txtMsDeb.Clear();
            txtSali.Clear();
            txtSref.Clear();
            txtTref.Clear();
            txtVrali.Clear();
            txtVrref.Clear();
            txtTicketali.Clear();
            txtAlisoft.Clear();
            txtRefsoft.Clear();
        }
    }
}
