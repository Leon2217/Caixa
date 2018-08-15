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
    public partial class frmInventario : Form
    {
        Inventario inv = new Inventario();
        InventarioDAO invDAO = new InventarioDAO();
        VendaVC vc = new VendaVC();
        VendaVCDAO vcDAO = new VendaVCDAO();
        string valor;
        int qtd;

        public frmInventario()
        {
            InitializeComponent();
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

        private void frmInventario_Load(object sender, EventArgs e)
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

        public void Limpar()
        {
            txtQtd.ResetText();
            txtValor.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (invDAO.VerificaInventário() == true)
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$"+"\n Qtd : "+qtd,
                    "Alterando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    try
                    {
                        vc.Id_caixa = FechamentoDAO.codcaixa;
                        vc.Qtd_vc =0;
                        vc.Valor_vc = txtValor.Text.ToString().Replace(".","");
                        vc.Total_vc ="0";
                        vc.Qtd_estoque = Convert.ToInt32(txtQtd.Text);
                        vc.Total_vendas =0;
                        vc.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        vc.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        vc.Descr = "Inventário";

                        vcDAO.Inserir(vc);

                        inv.Qtd_est = Convert.ToInt32(txtQtd.Text);
                        inv.Valor_vc = txtValor.Text.ToString().Replace(".","");
                        invDAO.Update(inv);

                        MessageBox.Show("Dados alterados com sucesso !!!");
                        Limpar();
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
                    vc.Id_caixa = FechamentoDAO.codcaixa;
                    vc.Qtd_vc = 0;
                    vc.Valor_vc = txtValor.Text.ToString().Replace(".", "");
                    vc.Total_vc = "0";
                    vc.Qtd_estoque = Convert.ToInt32(txtQtd.Text);
                    vc.Total_vendas = 0;
                    vc.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    vc.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                    vc.Descr = "Inventário";

                    vcDAO.Inserir(vc);

                    inv.Qtd_est = Convert.ToInt32(txtQtd.Text);
                    inv.Valor_vc = txtValor.Text.ToString().Replace(".","");
                    invDAO.Inserir(inv);
                    //((InicialCaixa)this.Owner).Atualizadados();
                    MessageBox.Show("Dados salvos com sucesso !!!");
                    Limpar();
                }
                catch(FormatException)
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
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
            qtd =Convert.ToInt32(txtQtd.Value);
        }

        private void frmInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
}
