using System;
using System.Drawing;
using System.Windows.Forms;
using Caixa.Classes;
using Caixa.ClassesDAO;

namespace Caixa.Forms
{
    public partial class frmConsumo : Form
    {
        PessoaDAO pesDAO = new PessoaDAO();
        Pessoa pessoa = new Pessoa();
        Consumo cons = new Consumo();
        ConsumoDAO consDAO = new ConsumoDAO();
        RelatConsumo rlc = new RelatConsumo();
        relatconsumoDAO rlcDAO = new relatconsumoDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string codpes;

        public frmConsumo()
        {
            InitializeComponent();
        }

        private void FrmConsumo_Load(object sender, EventArgs e)
        {
            try
            {            
                gvExibir.DataSource = consDAO.ListarMes();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "ID")
                        column.Width = 40; //tamanho fixo da coluna ID
                    else if (column.DataPropertyName == "VALOR")
                        column.Width = 75; //tamanho fixo da coluna VALOR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion

                Moeda(ref txtValor);
                CarregarComboFunc();
                cmbFuncionario.SelectedIndex = -1;
            }
            catch
            {

            }

        }

        public void CarregarComboFunc()
        {
            cmbFuncionario.DataSource = pesDAO.ListarFU();
            cmbFuncionario.DisplayMember = "nome";
            cmbFuncionario.ValueMember = "ID";
            codpes = cmbFuncionario.SelectedValue.ToString();
            //pessoa = cmbFornecedor.Text;
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

        private void FrmConsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (consDAO.Verificaconsumo(codpes) == true)
            {
                if (cmbFuncionario.Text == string.Empty || txtValor.Text == "0,00" || txtDesc.Text == string.Empty)
                {
                    if (cmbFuncionario.Text == string.Empty)
                        cmbFuncionario.BackColor = Color.Red;

                    if (txtValor.Text == "0.00")
                        txtValor.BackColor = Color.Red;

                    if (txtDesc.Text == string.Empty)
                        txtDesc.BackColor = Color.Red;

                        MessageBox.Show("Informações inválidas!!!");
                }
                else
                {
                    try
                    {
                        cons.Valor = txtValor.Text.ToString().Replace(".", "");
                        cons.Id_pessoa = Convert.ToInt32(codpes);
                        consDAO.Update(cons);

                        rlc.Id_pessoa = Convert.ToInt32(codpes);
                        rlc.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        rlc.Valor = txtValor.Text.ToString().Replace(".", "");
                        rlc.Descr = txtDesc.Text;
                        rlcDAO.Inserir(rlc);
                        MessageBox.Show("Informações cadastradas com sucesso!!!");

                        aud.Acao = "INSERIU CONSUMO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        txtValor.Clear();
                        cmbFuncionario.Text = "";
                        txtDesc.Clear();
                        if (chkTodos.Checked == true)
                        {
                            gvExibir.DataSource = consDAO.ListarTudo();
                        }
                        else
                        {
                            gvExibir.DataSource = consDAO.ListarMes();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas!!!");
                    }
                }
            }
            else
            {
                if (cmbFuncionario.Text == string.Empty || txtValor.Text == "0,00")
                {
                    if (cmbFuncionario.Text == string.Empty)
                        cmbFuncionario.BackColor = Color.Red;

                    if (txtValor.Text == "0.00")
                        txtValor.BackColor = Color.Red;

                    MessageBox.Show("Informações inválidas!!!");
                }
                else
                {
                    try
                    {
                        cons.Valor = txtValor.Text.ToString().Replace(".", "");
                        cons.Id_pessoa = Convert.ToInt32(codpes);
                        consDAO.Inserir(cons);


                        rlc.Id_pessoa = Convert.ToInt32(codpes);
                        rlc.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        rlc.Valor = txtValor.Text.ToString().Replace(".", "");
                        rlc.Descr = txtDesc.Text;
                        rlcDAO.Inserir(rlc);
                        MessageBox.Show("Informações cadastradas com sucesso!!!");

                        aud.Acao = "INSERIU FIADO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        txtValor.Clear();
                        cmbFuncionario.Text = "";
                        txtDesc.Clear();
                        gvExibir.DataSource = consDAO.ListarTudo();
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas!!!");
                    }
                }
            }
        }

        private void TxtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
        }

        private void CmbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            codpes = cmbFuncionario.SelectedValue.ToString();
        }

        private void BtnRelatConsumo_Click(object sender, EventArgs e)
        {
            frmRelatConsumo c = new frmRelatConsumo();
            c.Owner = this;
            c.ShowDialog();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                gvExibir.DataSource = consDAO.ListarTudo();
            }
            else
            {
                gvExibir.DataSource = consDAO.ListarMes();
            }
        }
    }
}
