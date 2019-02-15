using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmVendavc : Form
    {
        Inventario inv = new Inventario();
        InventarioDAO invDAO = new InventarioDAO();
        VendaVC vc = new VendaVC();
        VendaVCDAO vcDAO = new VendaVCDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        InicialCaixa form1;
        int qtd;
        double valor;
        double totalvc;
        int totalvenda;
        int qtd_estoque;
        int venda;
        public frmVendavc()
        {
            InitializeComponent();
        }

        private void frmVendavc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void frmVendavc_Load(object sender, EventArgs e)
        {
            txtQtd.ResetText();
            Conexao.criar_Conexao();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //update de qtd de estoque 
            if (invDAO.VerificaInventário() == true)
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Qtd : " + venda,
                    "Salvando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    qtd = Convert.ToInt32(txtQtd.Value);
                    if (invDAO.Inv.Qtd_est < qtd)
                    {
                        MessageBox.Show("A quantidade digitada é maior que o estoque !!!");
                    }
                    else
                    {
                        invDAO.UpdateEstoque(qtd);

                        //fim

                        //buscar valor
                        invDAO.VerificaInventário();
                        valor = Convert.ToDouble(invDAO.Inv.Valor_vc.Replace('.', ','));
                        //fim

                        //valor pago pelo valecap
                        totalvc = valor * qtd;
                        //fim

                        //qtd vendida
                        invDAO.VerificaInventário();


                        vcDAO.VerificaVenda();

                        totalvenda = (qtd + vcDAO.Vvc.Total_vendas);
                        //fim

                        //puxar o novo valor de estoque
                        qtd_estoque = invDAO.Inv.Qtd_est;

                        vc.Id_caixa = FechamentoDAO.codcaixa;
                        vc.Qtd_vc = qtd;
                        vc.Valor_vc = valor.ToString();
                        vc.Total_vc = totalvc.ToString().Replace(".", "");
                        vc.Qtd_estoque = qtd_estoque;
                        vc.Total_vendas = totalvenda;
                        vc.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        vc.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        vc.Descr = "Venda";

                        vcDAO.Inserir(vc);
                        this.Close();

                        aud.Acao = "INSERIU VENDA VALECAP";
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
