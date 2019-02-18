using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmTaxa : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        Taxas tx = new Taxas();
        TaxasDAO txDAO = new TaxasDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        #endregion

        public frmTaxa()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txDAO.VerificaExiste() == true)
            {
                #region SODEXO
                tx.Id_cartao = 10;
                tx.Taxa = txtSodexo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaSodexo.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 11;
                tx.Taxa = txtSodexo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaSodexo.Value.ToString();
                txDAO.Update(tx);
                #endregion

                #region VR
                tx.Id_cartao = 15;
                tx.Taxa = txtVr.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaVr.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 16;
                tx.Taxa = txtVr.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaVr.Value.ToString();
                txDAO.Update(tx);
                #endregion

                #region TICKET
                tx.Id_cartao = 12;
                tx.Taxa = txtTicket.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaTicket.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 17;
                tx.Taxa = txtTicket.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaTicket.Value.ToString();
                txDAO.Update(tx);
                #endregion

                #region ALELO
                tx.Id_cartao = 8;
                tx.Taxa = txtAlelo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaAlelo.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 9;
                tx.Taxa = txtAlelo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaAlelo.Value.ToString();
                txDAO.Update(tx);
                #endregion

                #region PCARD
                tx.Id_cartao = 18;
                tx.Taxa = txtPcard.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaPcard.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 19;
                tx.Taxa = txtPcard.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaPcard.Value.ToString();
                txDAO.Update(tx);
                #endregion

                #region CREDITO
                tx.Id_cartao = 1;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 3;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 6;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 7;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 14;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Update(tx);
                #endregion

                #region DEBITO
                tx.Id_cartao = 2;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 4;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 5;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Update(tx);

                tx.Id_cartao = 13;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Update(tx);
                #endregion

                MessageBox.Show("Informações atualizadas com sucesso !!!");

                aud.Acao = "ATUALIZADO VALOR TAXA";
                aud.Data = FechamentoDAO.data;
                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                aud.Responsavel = UsuarioDAO.login;
                audDAO.Inserir(aud);
            }
            else
            {
                #region SODEXO
                tx.Id_cartao = 10;
                tx.Taxa = txtSodexo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaSodexo.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 11;
                tx.Taxa = txtSodexo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaSodexo.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                #region VR
                tx.Id_cartao = 15;
                tx.Taxa = txtVr.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaVr.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 16;
                tx.Taxa = txtVr.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaVr.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                #region TICKET
                tx.Id_cartao = 12;
                tx.Taxa = txtTicket.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaTicket.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 17;
                tx.Taxa = txtTicket.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaTicket.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                #region ALELO
                tx.Id_cartao = 8;
                tx.Taxa = txtAlelo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaAlelo.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 9;
                tx.Taxa = txtAlelo.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaAlelo.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                #region PCARD
                tx.Id_cartao = 18;
                tx.Taxa = txtPcard.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaPcard.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 19;
                tx.Taxa = txtPcard.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaPcard.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                #region CREDITO
                tx.Id_cartao = 1;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 3;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 6;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 7;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 14;
                tx.Taxa = txtCredito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaCredito.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                #region DEBITO
                tx.Id_cartao = 2;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 4;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 5;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Inserir(tx);

                tx.Id_cartao = 13;
                tx.Taxa = txtDebito.Text.ToString().Replace(".", "");
                tx.Dias = txtDiaDebito.Value.ToString();
                txDAO.Inserir(tx);
                #endregion

                MessageBox.Show("Informações salvas com sucesso !!!");

                aud.Acao = "INSERIDO VALOR TAXA";
                aud.Data = FechamentoDAO.data;
                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                aud.Responsavel = UsuarioDAO.login;
                audDAO.Inserir(aud);
            }
        }

        public static void Moeda(ref TextBox txt)
        {
            #region MOEDA
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
            #endregion
        }

        private void frmTaxa_Load(object sender, EventArgs e)
        {
            #region MOEDA
            Moeda(ref txtAlelo);
            Moeda(ref txtSodexo);
            Moeda(ref txtTicket);
            Moeda(ref txtVr);
            Moeda(ref txtCredito);
            Moeda(ref txtDebito);
            Moeda(ref txtPcard);
            #endregion

            #region NUMERICBOX
            txtDiaSodexo.ResetText();
            txtDiaVr.ResetText();
            txtDiaTicket.ResetText();
            txtDiaDebito.ResetText();
            txtDiaCredito.ResetText();
            txtDiaAlelo.ResetText();
            txtDiaPcard.ResetText();
            #endregion

            txDAO.PesquisaSodexo();
            txtSodexo.Text = txDAO.Taxas.Taxa;
            txtDiaSodexo.Value = Convert.ToDecimal(txDAO.Taxas.Dias);

            txDAO.PesquisaVr();
            txtVr.Text = txDAO.Taxas.Taxa;
            txtDiaVr.Value = Convert.ToDecimal(txDAO.Taxas.Dias);

            txDAO.PesquisaT();
            txtTicket.Text = txDAO.Taxas.Taxa;
            txtDiaTicket.Value = Convert.ToDecimal(txDAO.Taxas.Dias);

            txDAO.PesquisaElo();
            txtAlelo.Text = txDAO.Taxas.Taxa;
            txtDiaAlelo.Value = Convert.ToDecimal(txDAO.Taxas.Dias);

            txDAO.PesquisaSoft();
            txtPcard.Text = txDAO.Taxas.Taxa;
            txtDiaPcard.Value = Convert.ToDecimal(txDAO.Taxas.Dias);

            txDAO.PesquisaCred();
            txtCredito.Text = txDAO.Taxas.Taxa;
            txtDiaCredito.Value = Convert.ToDecimal(txDAO.Taxas.Dias);

            txDAO.PesquisaDEB();
            txtDebito.Text = txDAO.Taxas.Taxa;
            txtDiaDebito.Value = Convert.ToDecimal(txDAO.Taxas.Dias);
        }

        #region TEXTCHANGED
        private void txtSodexo_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtSodexo);
        }

        private void txtVr_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtVr);
        }

        private void txtTicket_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtTicket);
        }

        private void txtAlelo_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtAlelo);
        }

        private void txtCredito_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtCredito);
        }

        private void txtDebito_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtDebito);
        }
        #endregion

        #region KEY DOWN
        private void txtSodexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtVr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtAlelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDebito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDiaSodexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDiaVr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDiaTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDiaAlelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDiaCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtDiaDebito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
        #endregion

        #region KEY PRESS
        private void txtSodexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtVr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtAlelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }
        #endregion

        private void txtPcard_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPcard);
        }

        private void txtPcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtPcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtDiaPcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void frmTaxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
}
