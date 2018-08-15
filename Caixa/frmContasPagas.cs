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
    public partial class frmContasPagas : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        PessoaDAO pesDAO = new PessoaDAO();
        Contas conta = new Contas();
        ContasDAO contaDAO = new ContasDAO();
        Contas2 conta2 = new Contas2();
        Contas3 conta3 = new Contas3();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        Valorgeral vg = new Valorgeral();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        #endregion

        #region VAR
        string codpes;
        string fornecedor;
        string nf;
        string valor;
        string valor2;
        string valor3;
        DateTime data;
        DateTime data2;
        DateTime data3;
        DateTime data4;
        DateTime dataem;

        #endregion

        public frmContasPagas()
        {
            InitializeComponent();
        }

        public void CarregarComboFornecedor()
        {
            cmbFornecedor.DataSource = pesDAO.ListarF();
            cmbFornecedor.DisplayMember = "nome";
            cmbFornecedor.ValueMember = "ID";
            codpes = cmbFornecedor.SelectedValue.ToString();

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

     
        private void frmContasPagas_Load(object sender, EventArgs e)
        {
            
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            Moeda(ref txtValorVenc1);
            Moeda(ref txtValorVenc1);
            Moeda(ref txtValorVenc2);
            Moeda(ref txtValorVenc3);
            try
            {
                CarregarComboFornecedor();
            }
            catch
            {

            }
            
 
            try
            {
                gvExibir.DataSource = contaDAO.ListarDiferenciado();
            }
            catch
            {

            }
        }

        private void frmContasPagas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorVenc1);
            txtValorVenc1.BackColor = Color.Empty;

            valor = txtValorVenc1.Text.ToString();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void chkNf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNf.Checked == true)
            {
                chkPc.Enabled = false;
                txtNf.Enabled = true;
                txtNf.Visible = true;
                
            
                    this.ProcessTabKey(true);
                     
            }
            else
            {
                chkPc.Enabled = true;
                txtNf.Enabled = false;
                txtNf.Visible = false;
                
            }
        }

        private void chkPc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPc.Checked == true)
            {
                chkNf.Enabled = false;
                txtNf.Enabled = false;
                txtNf.Visible = false;
                
            }
            else
            {
                chkNf.Enabled = true;
                txtNf.Enabled = true;
               
            }
        }

        private void txtNf_TextChanged(object sender, EventArgs e)
        {
            txtNf.BackColor = Color.Empty;
            if (txtNf.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contaDAO.ListarNF(nf);

            }
            else
            {
                try
                {
                    gvExibir.DataSource = contaDAO.ListarTudo();
                }
                catch
                {

                }
               
            }
        }

        private void txtNf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
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

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (chkNf.Checked == true || chkPc.Checked == true)
            {

                if(chkNf.Checked == true)
                {
                    if (txtNf.Text==string.Empty||mskData.MaskFull==false||txtValorVenc1.Text=="0,00")
                    {
                        if (txtNf.Text == string.Empty)
                            txtNf.BackColor = Color.Red;

                        if (mskData.MaskFull == false)
                            mskData.BackColor = Color.Red;

                        if (txtValorVenc1.Text == "0,00")
                            txtValorVenc1.BackColor = Color.Red;

                    }
                    else
                    {
                        try
                        {
                            DialogResult op;

                            op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Fornecedor : " +fornecedor+"\n N°NF : " +nf+ "\n Valor : " +valor+" R$ "+ "\n Data Vencimento : " +data.ToShortDateString(),
                                "Salvando!", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (op == DialogResult.Yes)
                            {
                                if (cmbParcela.SelectedIndex == 0)
                                {
                                    conta.Data = Convert.ToDateTime(mskData.Text);
                                    conta.Id_pessoa = Convert.ToInt32(codpes);
                                    conta.Nf = txtNf.Text.ToString();
                                    conta.Valor = txtValorVenc1.Text.ToString().Replace(".", "");
                                    conta.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta.Status = "Em aberto";
                                    contaDAO.Inserir(conta);

                                    




                                }

                                if (cmbParcela.SelectedIndex == 1)
                                {

                                    conta.Data = Convert.ToDateTime(mskData.Text);
                                    conta.Id_pessoa = Convert.ToInt32(codpes);
                                    conta.Nf = txtNf.Text.ToString();
                                    conta.Valor = txtValorVenc1.Text.ToString().Replace(".", "");
                                    conta.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta.Status = "Em aberto";
                                    contaDAO.Inserir(conta);

                                    //2
                                    conta2.Data = Convert.ToDateTime(mskData2.Text);
                                    conta2.Id_pessoa = Convert.ToInt32(codpes);
                                    conta2.Nf = txtNf.Text.ToString();
                                    conta2.Valor = txtValorVenc2.Text.ToString().Replace(".", "");
                                    conta2.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta2.Status = "Em aberto";
                                    contaDAO.Inserir2(conta2);
                                }

                                if (cmbParcela.SelectedIndex == 2)
                                {

                                    conta.Data = Convert.ToDateTime(mskData.Text);
                                    conta.Id_pessoa = Convert.ToInt32(codpes);
                                    conta.Nf = txtNf.Text.ToString();
                                    conta.Valor = txtValorVenc1.Text.ToString().Replace(".", "");
                                    conta.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta.Status = "Em aberto";
                                    contaDAO.Inserir(conta);

                                    //2
                                    conta2.Data = Convert.ToDateTime(mskData2.Text);
                                    conta2.Id_pessoa = Convert.ToInt32(codpes);
                                    conta2.Nf = txtNf.Text.ToString();
                                    conta2.Valor = txtValorVenc2.Text.ToString().Replace(".", "");
                                    conta2.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta2.Status = "Em aberto";
                                    contaDAO.Inserir2(conta2);

                                    //3
                                    conta3.Data = Convert.ToDateTime(mskData3.Text);
                                    conta3.Id_pessoa = Convert.ToInt32(codpes);
                                    conta3.Nf = txtNf.Text.ToString();
                                    conta3.Valor = txtValorVenc3.Text.ToString().Replace(".", "");
                                    conta3.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta3.Status = "Em aberto";
                                    contaDAO.Inserir3(conta3);
                                }

                                DialogResult dl;

                                dl = MessageBox.Show("Informações salvas com sucesso, deseja refazer na mesma nota?",
                                    "Atenção!", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                                if (dl == DialogResult.Yes)
                                {
                                    mskData.Clear();
                                    mskData2.Clear();
                                    mskData3.Clear();
                                    mskDataem.Clear();
                                    txtValorVenc1.Clear();
                                    txtValorVenc2.Clear();
                                    txtValorVenc3.Clear();
                                    gvExibir.DataSource = contaDAO.ListarNF(nf);
                                }
                                else
                                {
                                    txtNf.Clear();
                                    mskData.Clear();
                                    mskData2.Clear();
                                    mskData3.Clear();
                                    mskDataem.Clear();
                                    txtValorVenc1.Clear();
                                    txtValorVenc2.Clear();
                                    txtValorVenc3.Clear();
                                    chkNf.Checked = false;
                                    cmbParcela.SelectedIndex = 0;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Favor verificar as informações digitadas !!!");
                        }
                    }
                 
                }

                if(chkPc.Checked == true)
                {
                    if (mskData.MaskFull == false || txtValorVenc1.Text == "0,00")
                    {
                        if (txtValorVenc1.Text == "0,00")
                            txtValorVenc1.BackColor = Color.Red;

                        if (mskData.MaskFull == false)
                            mskData.BackColor = Color.Red;
                    }
                    else
                    {
                        try
                        {
                            DialogResult op;

                            op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Fornecedor : " + fornecedor + "\n Pedido/Cheque"+"\n Valor : " + valor + " R$ " + "\n Data de vencimento : " + data.ToShortDateString(),
                                "Salvando!", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (op == DialogResult.Yes)
                            {
                                if (cmbParcela.SelectedIndex == 0)
                                {
                                    conta.Data = Convert.ToDateTime(mskData.Text);
                                    conta.Id_pessoa = Convert.ToInt32(codpes);
                                    conta.Nf = txtNf.Text.ToString();
                                    conta.Valor = txtValorVenc1.Text.ToString().Replace(".", "");
                                    conta.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta.Status = "Em aberto";
                                    contaDAO.Inserir(conta);
                                }

                                if (cmbParcela.SelectedIndex == 1)
                                {

                                    conta.Data = Convert.ToDateTime(mskData.Text);
                                    conta.Id_pessoa = Convert.ToInt32(codpes);
                                    conta.Nf = txtNf.Text.ToString();
                                    conta.Valor = txtValorVenc1.Text.ToString().Replace(".", "");
                                    conta.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta.Status = "Em aberto";
                                    contaDAO.Inserir(conta);

                                    //2
                                    conta2.Data = Convert.ToDateTime(mskData2.Text);
                                    conta2.Id_pessoa = Convert.ToInt32(codpes);
                                    conta2.Nf = txtNf.Text.ToString();
                                    conta2.Valor = txtValorVenc2.Text.ToString().Replace(".", "");
                                    conta2.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta2.Status = "Em aberto";
                                    contaDAO.Inserir2(conta2);
                                }

                                if (cmbParcela.SelectedIndex == 2)
                                {

                                    conta.Data = Convert.ToDateTime(mskData.Text);
                                    conta.Id_pessoa = Convert.ToInt32(codpes);
                                    conta.Nf = txtNf.Text.ToString();
                                    conta.Valor = txtValorVenc1.Text.ToString().Replace(".", "");
                                    conta.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta.Status = "Em aberto";
                                    contaDAO.Inserir(conta);

                                    //2
                                    conta2.Data = Convert.ToDateTime(mskData2.Text);
                                    conta2.Id_pessoa = Convert.ToInt32(codpes);
                                    conta2.Nf = txtNf.Text.ToString();
                                    conta2.Valor = txtValorVenc2.Text.ToString().Replace(".", "");
                                    conta2.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta2.Status = "Em aberto";
                                    contaDAO.Inserir2(conta2);

                                    //3
                                    conta3.Data = Convert.ToDateTime(mskData3.Text);
                                    conta3.Id_pessoa = Convert.ToInt32(codpes);
                                    conta3.Nf = txtNf.Text.ToString();
                                    conta3.Valor = txtValorVenc3.Text.ToString().Replace(".", "");
                                    conta3.Data_em = Convert.ToDateTime(mskDataem.Text);
                                    conta3.Status = "Em aberto";
                                    contaDAO.Inserir3(conta3);
                                }
                            }

                        }
                        catch
                        {
                            MessageBox.Show("Favor verificar as informações digitadas !!!");
                        }
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Favor escolher ou N°NF ou Pedido/Cheque !!!");
            }
        }

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            mskData.BackColor = Color.Empty;

            if (mskData.MaskFull == true)
            {
                try
                {
                    data = Convert.ToDateTime(mskData.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskData.Clear();
                }



                if (txtValorVenc1.Enabled == true)
                {
                    this.ProcessTabKey(true);
                }
            }
        }

        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fornecedor = cmbFornecedor.Text.ToString();
                codpes = cmbFornecedor.SelectedValue.ToString();
            }
            catch
            {

            }
         
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatContas rc = new frmRelatContas();
            rc.Owner = this;
            rc.ShowDialog();
        }

        private void cmbParcela_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            if (cmbParcela.SelectedIndex == 0)
            {
                txtValorVenc1.Enabled = true;
                mskData2.Enabled = false;
                mskData3.Enabled = false;
                txtValorVenc2.Enabled = false;
                txtValorVenc3.Enabled = false;

                this.ProcessTabKey(true);

            }

            if (cmbParcela.SelectedIndex == 1)
            {
                txtValorVenc1.Enabled = true;
                txtValorVenc2.Enabled = true;
                mskData2.Enabled = true;
                txtValorVenc3.Enabled = false;
                mskData3.Enabled = false;

                this.ProcessTabKey(true);
            }

            if (cmbParcela.SelectedIndex == 2)
            {
                txtValorVenc1.Enabled = true;
                txtValorVenc2.Enabled = true;
                txtValorVenc3.Enabled = true;
                mskData3.Enabled = true;
                mskData2.Enabled = true;

                this.ProcessTabKey(true);
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
           
        }

        private void cmbParcela_TextChanged(object sender, EventArgs e)
        {
            if (cmbParcela.Text == string.Empty)
            {
                txtValorVenc1.Enabled = false;
                txtValorVenc2.Enabled = false;
                txtValorVenc3.Enabled = false;
                mskData3.Enabled = false;
                mskData2.Enabled = false;
            }
        }

        private void txtValorVenc1_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorVenc1);
            if (txtValorVenc1.Text != string.Empty)
            {
                valor = txtValorVenc1.Text;
            }
           
        }

        private void txtValorVenc2_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorVenc2);
            if (txtValorVenc2.Text != string.Empty)
            {
                valor2 = txtValorVenc2.Text;
            }


        }

        private void txtValorVenc3_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorVenc3);
            if (txtValorVenc3.Text != string.Empty)
            {
                valor3=txtValorVenc3.Text;
            }
        }

        private void txtValorVenc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
  

            }
        }

        private void txtValorVenc2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void txtValorVenc3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
         
            }
        }

        private void mskDataem_TextChanged(object sender, EventArgs e)
        {
            mskDataem.BackColor = Color.Empty;

            if (mskDataem.MaskFull == true)
            {
                try
                {
                    data2 = Convert.ToDateTime(mskDataem.Text);
                    this.ProcessTabKey(true);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDataem.Clear();
                }

            }
        }

        private void mskData2_TextChanged(object sender, EventArgs e)
        {
           mskData2.BackColor = Color.Empty;

            if (mskData2.MaskFull == true)
            {
                try
                {
                    data3 = Convert.ToDateTime(mskData2.Text);
                    this.ProcessTabKey(true);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDataem.Clear();
                }

            }
        }

        private void mskData3_TextChanged(object sender, EventArgs e)
        {
            mskData3.BackColor = Color.Empty;

            if (mskData3.MaskFull == true)
            {
                try
                {
                    data4 = Convert.ToDateTime(mskData3.Text);
                    this.ProcessTabKey(true);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDataem.Clear();
                }

            }
        }

        private void txtValorVenc1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtValorVenc2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtValorVenc3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void gvExibir_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Contains("Atrasado"))
            {
                e.CellStyle.ForeColor = Color.Red;

            }

            if (e.Value != null && e.Value.ToString().Contains("Pago"))
            {
                e.CellStyle.ForeColor = Color.Green;

            }

            if (e.Value != null && e.Value.ToString().Contains("Em aberto"))
            {
                e.CellStyle.ForeColor = Color.Goldenrod;

            }
        }

        private void btnDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(121))
            {
                frmDespesa desp = new frmDespesa();
                desp.Owner = this;
                desp.ShowDialog();
            }
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            frmDespesa desp = new frmDespesa();
            desp.Owner = this;
            desp.ShowDialog();
        }
    }
}
