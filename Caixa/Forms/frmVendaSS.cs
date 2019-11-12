using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using Caixa.Classes;
using Caixa.ClassesDAO;

namespace Caixa.Forms
{
    public partial class frmVendaSS : Form
    {
        InventarioSS invGDS = new InventarioSS();
        InventarioSSDAO invGdsDAO = new InventarioSSDAO();
        VendaSS vgds = new VendaSS();
        VendaSSDAO vgdsDAO = new VendaSSDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        int qtd;
        double valor;
        double totalinv;
        int totalvenda;
        int qtd_estoque;
        int venda;

        public frmVendaSS()
        {
            InitializeComponent();
        }

        private void frmVendaGDS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //update de qtd de estoque 
            if (invGdsDAO.VerificaInventário() == true)
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?" +   "\n Qtd : " + venda,
                    "Salvando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    qtd = Convert.ToInt32(txtQtd.Value);
                    if (invGdsDAO.InvGDS.Qtd_est < qtd)
                    {
                        MessageBox.Show("A quantidade digitada é maior que o estoque !!!");
                    }
                    else
                    {
                        invGdsDAO.UpdateEstoque(qtd);

                        //fim

                        //buscar valor
                        invGdsDAO.VerificaInventário();
                        valor = Convert.ToDouble(invGdsDAO.InvGDS.Valor_gds.Replace('.', ','));
                        //fim

                        //valor pago pelo giro da sorte
                        totalinv = valor * qtd;
                        //fim

                        //qtd vendida
                        invGdsDAO.VerificaInventário();


                        vgdsDAO.VerificaVenda();

                        totalvenda = (qtd + vgdsDAO.Vgds.Total_vendas);
                        //fim

                        //puxar o novo valor de estoque
                        qtd_estoque = invGdsDAO.InvGDS.Qtd_est;

                        vgds.Id_caixa = FechamentoDAO.codcaixa;
                        vgds.Qtd_gds = qtd;
                        vgds.Valor_gds = valor.ToString();
                        vgds.Total_gds = totalinv.ToString().Replace(".", "");
                        vgds.Qtd_estoque = qtd_estoque;
                        vgds.Total_vendas = totalvenda;
                        vgds.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        vgds.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        vgds.Descr = "Venda";

                        vgdsDAO.Inserir(vgds);
                        this.Close();

                        aud.Acao = "INSERIU VENDA GIRO DA SORTE";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);


                        var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                     where frm is InicialCaixa
                                     select frm;

                        if (qrForm != null && qrForm.Count() > 0)
                        {
                            ((InicialCaixa)qrForm.First()).Atualizadados();
                        }
                        MessageBox.Show("Dados salvos com sucesso");
                    }
                }
            }
            else
            {
                MessageBox.Show("Para realizar uma venda, é necessário atualizar o estoque primeiro !!!");
            }
        }

        private void txtQtd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                venda = Convert.ToInt32(txtQtd.Text);
            }
            catch
            {
            }
        }

        private void frmVendaGDS_Load(object sender, EventArgs e)
        {
            txtQtd.ResetText();
            Conexao.criar_Conexao();
        }

        private void txtQtd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
