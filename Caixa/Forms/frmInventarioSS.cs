using System;
using System.Windows.Forms;
using Caixa.Classes;
using Caixa.ClassesDAO;

namespace Caixa.Forms
{
    public partial class frmInventarioSS : Form
    {
        InventarioSS invGDS = new InventarioSS();
        InventarioSSDAO invGdsDAO = new InventarioSSDAO();
        VendaSS vgds = new VendaSS();
        VendaSSDAO vgdsDAO = new VendaSSDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();


        string valor;
        int qtd;

        public frmInventarioSS()
        {
            InitializeComponent();
        }

        #region VoidMoeda
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
        #endregion

        public void Limpar()
        {
            txtQtd.ResetText();
            txtValor.Clear();
        }

        private void frmInventarioGDS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (invGdsDAO.VerificaInventário() == true)
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$" + "\n Qtd : " + qtd,
                    "Alterando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    try
                    {
                        vgds.Id_caixa = FechamentoDAO.codcaixa;
                        vgds.Qtd_gds = 0;
                        vgds.Valor_gds = txtValor.Text.ToString().Replace(".", "");
                        vgds.Total_gds = "0";
                        vgds.Qtd_estoque = Convert.ToInt32(txtQtd.Text);
                        vgds.Total_vendas = 0;
                        vgds.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        vgds.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        vgds.Descr = "Inventário";

                        vgdsDAO.Inserir(vgds);

                        invGDS.Qtd_est = Convert.ToInt32(txtQtd.Text);
                        invGDS.Valor_gds = txtValor.Text.ToString().Replace(".", "");
                        invGdsDAO.Update(invGDS);

                        MessageBox.Show("Dados alterados com sucesso !!!");
                        Limpar();

                        aud.Acao = "ATUALIZOU INVENTARIO VALECAP";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                }
            }
            else
            {
                try
                {
                    vgds.Id_caixa = FechamentoDAO.codcaixa;
                    vgds.Qtd_gds = 0;
                    vgds.Valor_gds = txtValor.Text.ToString().Replace(".", "");
                    vgds.Total_gds = "0";
                    vgds.Qtd_estoque = Convert.ToInt32(txtQtd.Text);
                    vgds.Total_vendas = 0;
                    vgds.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    vgds.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                    vgds.Descr = "Inventário";

                    vgdsDAO.Inserir(vgds);

                    invGDS.Qtd_est = Convert.ToInt32(txtQtd.Text);
                    invGDS.Valor_gds = txtValor.Text.ToString().Replace(".", "");
                    invGdsDAO.Inserir(invGDS);
                    MessageBox.Show("Dados salvos com sucesso !!!");
                    Limpar();

                    aud.Acao = "INSERIU INVENTARIO SANTA SORTE";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
            }
        }

        private void frmInventarioGDS_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
            Moeda(ref txtValor);
            txtQtd.ResetText();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            valor = txtValor.Text;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtQtd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtQtd_ValueChanged(object sender, EventArgs e)
        {
            qtd = Convert.ToInt32(txtQtd.Value);
        }
    }
}
