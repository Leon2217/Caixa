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
    public partial class frmSuprimento : Form
    {
        suprimentos supri = new suprimentos();
        suprimentoDAO supriDAO = new suprimentoDAO();
        UsuarioDAO usuDao = new UsuarioDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        string valor;
        string login, tipo;
        Boolean update;
        public frmSuprimento()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza dessas informações?" +"\n Valor : " + valor + " R$",
                "Salvando!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                if (update == true)
                {
                    if (tipo == "Administrador")
                    {
                        supri.Id_caixa = Convert.ToInt32(suprimentoDAO.codcaixa);
                        supri.Valor = txtValor.Text.ToString().Replace(".","");
                        supriDAO.update(supri);
                        MessageBox.Show("Dados alterados com sucesso !!!");
                        ((frmOpcaoFecha)this.Owner).AtualizaDados();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Você não possui privilégios para alterar valores !!!");
                    }
                }
                else
                {
                    try
                    {
                        supri.Id_caixa = Convert.ToInt32(suprimentoDAO.codcaixa);
                        supri.Valor = txtValor.Text.ToString().Replace(".","");
                        supriDAO.inserir(supri);
                        MessageBox.Show("Informações salvas com sucesso !!!");

                        aud.Acao = "INSERIU SUPRIMENTO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        ((frmOpcaoFecha)this.Owner).AtualizaDados();

                        this.Close();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                }
                
    
            }
        }

        private void frmSuprimento_Load(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            string codcaixa = DinheiroDAO.codcaixa;
            if (supriDAO.Verificasupri(codcaixa) == true)
            {
                login = UsuarioDAO.login;
                usuDao.VerificaCargo(login);
                tipo = usuDao.Usu.Tipo.ToString();
                update = true;
                txtValor.Text =supriDAO.Supri.Valor.ToString();
            }


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


        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            valor = txtValor.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void frmSuprimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnAdicionar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }
    }
}
