using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class Login : Form
    {
        UsuarioDAO usuDAO = new UsuarioDAO();
        Fechamento fec = new Fechamento();
        FechamentoDAO fecDAO = new FechamentoDAO();
     
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            InicialCaixa i = new InicialCaixa();
            i.ShowDialog();
        }
    
        private void Login_Load(object sender, EventArgs e)
        {
           Conexao.criar_Conexao();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            if (usuDAO.VerificaAdm(login, senha) == true)
            {
                UsuarioDAO.login = usuDAO.Usu.Login_usu;
                login = usuDAO.Usu.Login_usu;

                if (fecDAO.VerificaCaixa(login) == true)
                {
                        fec.Responsavel = login;
                        FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                        fecDAO.Pesquisacart(fec);
                        FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                        DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                        FechamentoDAO.data = fecDAO.Fec.Data;
                        FechamentoDAO.valor = fecDAO.Fec.Valor;
                        
                        this.Hide();
                        InicialCaixa i = new InicialCaixa();
                        i.ShowDialog();                  
                }
                else
                {
                    this.Hide();
                    Abertura a = new Abertura();
                    a.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Usuário incorreto ou senha incorreta!");
                txtSenha.Clear();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                Application.Exit();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                string login = txtLogin.Text;
                string senha = txtSenha.Text;
                if (usuDAO.VerificaAdm(login, senha) == true)
                {
                    UsuarioDAO.login = usuDAO.Usu.Login_usu;
                    login = usuDAO.Usu.Login_usu;

                    if (fecDAO.VerificaCaixa(login) == true)
                    {
                        fec.Responsavel = login;
                        FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                        fecDAO.Pesquisacart(fec);
                        FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                        DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                        FechamentoDAO.data = fecDAO.Fec.Data;
                        FechamentoDAO.valor = fecDAO.Fec.Valor;

                        this.Hide();
                        InicialCaixa i = new InicialCaixa();
                        i.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        Abertura a = new Abertura();
                        a.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Usuário incorreto ou senha incorreta!");
                    txtSenha.Clear();
                }
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
