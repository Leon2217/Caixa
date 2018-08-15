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


    
    public partial class Abertura : Form
    {
        FechamentoDAO fecDAO = new FechamentoDAO();
        Fechamento fec = new Fechamento();
        UsuarioDAO usuDao = new UsuarioDAO();

        Verificas ver = new Verificas();
        VerificaDAO verDAO = new VerificaDAO();
        string tipo;

        DateTime data;
        
        
        string codper;
        string login;

        DateTime data_hora;

      
        public Abertura()
        {
            InitializeComponent();
        }

        private void Abertura_Load(object sender, EventArgs e)
        {
            txtUsu.Text = UsuarioDAO.login;

           login = txtUsu.Text;

            string datatela = DateTime.Now.ToShortDateString();

            mskData.Text = datatela;


            data = Convert.ToDateTime(mskData.Text);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (cmbTurno.SelectedIndex ==0)
            {
                codper = "1";
            }else
            {
                codper = "2";
            }

            if (fecDAO.Verifica(codper, data) == true)
            {
                MessageBox.Show("Esse caixa já foi aberto por : "+fecDAO.Fec.Responsavel);
            }
            else
            {

                if (fecDAO.VerificaCaixa2(codper, data) == true)
                {

                    DialogResult op;

                    op = MessageBox.Show("Deseja reabri-lo?",
                        "Este já caixa foi fechado!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        login = UsuarioDAO.login;

                        usuDao.VerificaCargo(login);
                        tipo = usuDao.Usu.Tipo.ToString();

                        if (tipo == "Administrador")
                        {
                            fec.Responsavel = UsuarioDAO.login;
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
                            MessageBox.Show("Você não possui privilégios para reabrir caixa");
                        }

                       


                    }

                }
                else
                {
                    try
                    {

                        verDAO.Verifica();

                        if (verDAO.Ver.Verifica == "NAO")
                        {
                            MessageBox.Show("O valor de retirada PDV não foi enviado no caixa anterior !!!");
                        }
                        else
                        {
                            data_hora = DateTime.Now;

                            fec.Data = Convert.ToDateTime(mskData.Text);
                            fec.Status = "Aberto";
                            fec.Responsavel = login;
                            fec.Hrinicio = Convert.ToDateTime(data_hora.ToLongTimeString());
                            fec.Id_turno = Convert.ToInt32(codper);
                            fec.Valor = "0.00";
                            fecDAO.inserir(fec);
                            fecDAO.Pesquisacart(fec);


                            if (verDAO.Verifica() == true)
                            {

                                ver.Verifica = "NAO";
                                verDAO.Update(ver);
                            }
                            else
                            {
                                ver.Verifica = "NAO";
                                verDAO.Inserir(ver);

                            }

                            FechamentoDAO.valor = fecDAO.Fec.Valor.ToString();
                            FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                            DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                            CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                            assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                            suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                            FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                            FechamentoDAO.data = fecDAO.Fec.Data;
                            this.Hide();
                            InicialCaixa i = new InicialCaixa();
                            i.ShowDialog();
                        }


                    }
                    catch
                    {

                    }
                }
            }





        }

        private void mskData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cmbTurno_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (mskData.MaskFull == true)
                {
                    data = Convert.ToDateTime(mskData.Text);
                }
            }
            catch
            {
                MessageBox.Show("A data inserida é inválida !!!");
                mskData.Clear();
                string datatela = DateTime.Now.ToShortDateString();
                mskData.Text = datatela;
            }
         
          
        }

        private void Abertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza?",
                    "Saindo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    this.Hide();
                    Login l = new Login();
                    l.ShowDialog();
                }
            }
        }
    }
}
