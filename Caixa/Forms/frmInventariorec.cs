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
    public partial class frmInventariorec : Form
    {
        Inventariorec ir = new Inventariorec();
        InventariorecDAO irDAO = new InventariorecDAO();
        Recarga rec = new Recarga();
        RecargaDAO recDAO = new RecargaDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
       


        string valor;

        public frmInventariorec()
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

        public void Limpar()
        {
            Moeda(ref txtValor);
            txtValor.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            if (irDAO.VerificaInventário() == true)
            {

                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$",
                    "Alterando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {



                    try
                    {
                        ir.Total = txtValor.Text.ToString().Replace(".", "");
                        irDAO.Update(ir);

                        aud.Acao = "ATUALIZADO INVENTARIO RECARGA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);


                        rec.Id_caixa = FechamentoDAO.codcaixa;
                        rec.Operadora = "-";
                        rec.Valor_rec = "0.00";

                   
                        rec.N_telefone = "-";
                        rec.Descricao = "Inventário";
                        rec.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        rec.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        rec.Total = txtValor.Text.ToString().Replace(".", "");

                        recDAO.Inserir(rec);

                       





                        Limpar();
                        MessageBox.Show("Informações salvas com sucesso !!!");

      
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                }
            }

            else
            {
                DialogResult ip;

                ip = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$",
                    "Salvando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (ip == DialogResult.Yes)
                {
                    try
                    {
                        ir.Total = txtValor.Text.ToString().Replace(".", "");
                        irDAO.Inserir(ir);
                        Limpar();
                        MessageBox.Show("Informações salvas com sucesso !!!");

                        aud.Acao = "INSERIDO INVENTARIO RECARGA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                }
            }         
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            valor = txtValor.Text;
            Moeda(ref txtValor);
        }

        private void frmInventariorec_Load(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
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

        private void frmInventariorec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
}
