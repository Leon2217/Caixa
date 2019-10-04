using System;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmAssinadas : Form
    {
        assinada ass = new assinada();
        assinadaDAO assDAO = new assinadaDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        string  valor;
        string valor2;
        string valor3;
        string valor4;
        string codcaixa;
        string tipo;
        string login;
        Boolean update;
        public frmAssinadas()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza dessas informações?"+"\n Assinadas : " +valor+" R$"+"\n Class : "+valor2+ " R$"+ "\n Julio Simões : " + valor3 + " R$" + "\n Fiado cartão : " + valor4 + "R$",
                "Salvando!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                try
                {
                    if (update == true)
                    {

                        if (tipo == "Administrador")
                        {
                            ass.Id_caixa = Convert.ToInt32(assinadaDAO.codcaixa);
                            ass.Classm = txtClass.Text.ToString().Replace(".", "");
                            ass.Assinadas = txtAssinada.Text.ToString().Replace(".", "");
                            ass.Julio = txtJulio.Text.ToString().Replace(".", "");
                            ass.Fiado = txtFiado.Text.ToString().Replace(".", "");
                            assDAO.Alterar(ass);
                            MessageBox.Show("Dados alterados com sucesso !!!");
                            txtAssinada.Clear();
                            txtClass.Clear();
                            txtJulio.Clear();
                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Você não possui privilégios o suficiente para alterar !!!");
                        }                           
                    }
                    else
                    {
                        ass.Id_caixa = Convert.ToInt32(FechamentoDAO.codcaixa);
                        ass.Classm = txtClass.Text.ToString().Replace(".", "");
                        ass.Assinadas = txtAssinada.Text.ToString().Replace(".", "");
                        ass.Julio = txtJulio.Text.ToString().Replace(".", "");
                        ass.Fiado = txtFiado.Text.ToString().Replace(".", "");
                        assDAO.Inserir(ass);
                        MessageBox.Show("Informações salvas com sucesso !!!");
                        txtAssinada.Clear();
                        txtClass.Clear();
                        txtJulio.Clear();
                        ((frmOpcaoFecha)this.Owner).AtualizaDados();
                        this.Close();
                    }                   
                }
                catch (FormatException)
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }        
            }
        }
        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtClass);
            valor2 = txtClass.Text;
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
      {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void frmAssinadas_Load(object sender, EventArgs e)
        {
            Moeda(ref txtClass);
            Moeda(ref txtJulio);
            Moeda(ref txtAssinada);
            Moeda(ref txtFiado);
            codcaixa = assinadaDAO.codcaixa;
            if (assDAO.Buscar(codcaixa)==true)
            {
                txtAssinada.Text =assinadaDAO.assinada.ToString();
                txtClass.Text = assinadaDAO.classm.ToString();
                txtJulio.Text = assinadaDAO.julio.ToString();
                txtFiado.Text = assinadaDAO.fiado.ToString();
                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();
                update = true;
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

        private void txtJulio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void txtJulio_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtJulio);
            valor3 = txtJulio.Text;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

            Moeda(ref txtAssinada);
            valor = txtAssinada.Text;

        }

        private void txtAssinada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtJulio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void frmAssinadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                   this.Close();
            }
        }

        private void txtFiado_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtFiado);
            valor4 = txtFiado.Text;
        }

        private void txtFiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
