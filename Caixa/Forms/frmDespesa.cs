using System;
using System.Drawing;

using System.Windows.Forms;

namespace Caixa
{
    public partial class frmDespesa : Form
    {
        #region INSTANCIAMENTO CLASSES
        Despesa desp = new Despesa();
        DespesaDAO despDAO = new DespesaDAO();
        PessoaDAO pesDAO = new PessoaDAO();
        Tipodespesa tpdes = new Tipodespesa();
        TipodespesaDAO tpdesDAO = new TipodespesaDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        string codpes;
        string codtp;
        string tipo;
        string pessoa;
        string valor;
        string desc;
        DateTime data;
        int numparc;
        #endregion

        public frmDespesa()
        {
            InitializeComponent();
        }

        private void frmDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
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

        public void CarregarComboFunc()
        {
            cmbOp.DataSource = pesDAO.ListarFU();
            cmbOp.DisplayMember = "nome";
            cmbOp.ValueMember = "ID";
            codpes = cmbOp.SelectedValue.ToString();
            pessoa = cmbOp.Text;
        }

        public void CarregarComboForn()
        {
            cmbOp.DataSource = pesDAO.ListarF();
            cmbOp.DisplayMember = "nome";
            cmbOp.ValueMember = "ID";
            codpes = cmbOp.SelectedValue.ToString();
            pessoa = cmbOp.Text;
        }

        public void CarregarComboTipo()
        {
            cmbOp.DataSource = tpdesDAO.ListarTipoDespesa();
            cmbOp.DisplayMember = "nome";
            cmbOp.ValueMember = "ID";
            codtp = cmbOp.SelectedValue.ToString();
            tipo = cmbOp.Text;
        }

        private void chkF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForn.Checked == true)
            {
                chkFunc.Enabled = false;
                chkDespesa.Enabled = false;
                try
                {
                    CarregarComboForn();
                    pessoa = cmbOp.Text;
                }
                catch
                {

                }
                           
            }
            else
            {
                chkFunc.Enabled = true;
                chkDespesa.Enabled = true;
                try
                {
                    cmbOp.DataSource = null;
                }
                catch
                {

                }              
            }
        }

        private void chkFunc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFunc.Checked == true)
            {
                chkForn.Enabled = false;
                chkDespesa.Enabled = false;
                try
                {
                    CarregarComboFunc();
                    pessoa = cmbOp.Text;
                }
                catch
                {

                }               
            }
            else
            {
                chkForn.Enabled = true;
                chkDespesa.Enabled = true;
                try
                {
                    cmbOp.DataSource = null;
                }
                catch
                {

                }
                
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (mskData.MaskFull==false || txtValor.Text=="0,00" || cmbOp.Text == string.Empty)
            {            
                if (mskData.MaskFull == false)
                    mskData.BackColor = Color.Red;

                if (cmbOp.Text == string.Empty)
                    mskData.BackColor = Color.Red;

                if (txtValor.Text == "0,00")
                    txtValor.BackColor = Color.Red;

                    MessageBox.Show("Favor preencher todas as informações !!!");
            }
            else
            {
                try
                {
                    DialogResult op;

                    op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$" + "\n Descrição : " + desc + "\n Data : " + data.ToShortDateString() + "\n Pessoa : " + pessoa,
                        "Salvando!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        for(int i = 0; i < numparc; i++)
                        {                       
                                DateTime datavenc = data.AddMonths(i);
                                desp.Descr = txtDesc.Text;
                                desp.Data = datavenc;
                                desp.Valor = txtValor.Text.ToString().Replace(".", "");
                                desp.Status = "Em aberto";

                            if (chkForn.Checked == true || chkFunc.Checked == true)
                            {
                                desp.Id_pessoa = Convert.ToInt32(codpes);
                                despDAO.Inserir(desp);
                            }
                            else
                            {
                                desp.Id_tipodespesa = Convert.ToInt32(codtp);
                                despDAO.Inserir2(desp);                                
                            }                            
                        }
                        MessageBox.Show("Informações salvas com sucesso !!!");
                        Limpar();

                        aud.Acao = "INSERIU DESPESA FIXA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }                        
                }
                catch
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
            }
        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            txtDesc.BackColor = Color.Empty;
            if (txtDesc.Text != string.Empty)
            {
                desc = txtDesc.Text;
            }
        }
        private void cmbOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOp.BackColor = Color.Empty;
            if (chkFunc.Checked == true || chkForn.Checked == true)
            {               
                pessoa = cmbOp.Text;
                try
                {
                    codpes = cmbOp.SelectedValue.ToString();
                }
                catch
                {

                }
            }
            else
            {
                tipo = cmbOp.Text;
                try
                {
                    codtp = cmbOp.SelectedValue.ToString();
                }
                catch
                {

                }
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
            }
        }
        private void frmDespesa_Load(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            string datatela = DateTime.Now.ToShortDateString();
            mskData.Text = datatela;
        }
        public void AtualizaDados()
        {
            if (chkDespesa.Checked == true)
            {
                chkFunc.Enabled = false;
                chkForn.Enabled = false;
                try
                {
                    CarregarComboTipo();
                    tipo = cmbOp.Text;
                }
                catch
                {
                }
            }
            else
            {
                chkForn.Enabled = true;
                chkFunc.Enabled = true;
                try
                {
                    cmbOp.DataSource = null;
                }
                catch
                {
                }
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            txtValor.BackColor = Color.Empty;
            Moeda(ref txtValor);
            if (txtValor.Text != string.Empty)
            {
                valor = txtValor.Text;
            }         
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public void Limpar()
        {
            try
            {
                txtDesc.Clear();
                txtValor.Clear();
                string datatela = DateTime.Now.ToShortDateString();
                mskData.Text = datatela;
                cmbOp.DataSource = null;
                chkForn.Checked = false;
                chkFunc.Checked = false;
                cmbParcela.SelectedIndex = 0;
            }
            catch
            {
            }  
        }          


        private void btnRelat_Click(object sender, EventArgs e)
        {
            frmRelatDespesa rd = new frmRelatDespesa();
            rd.Owner = this;
            rd.ShowDialog();
        }

        private void cmbParcela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParcela.Text != string.Empty)
            {
                numparc = Convert.ToInt32(cmbParcela.Text);
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

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void btnTipoDespesa_Click(object sender, EventArgs e)
        {
            frmCadtipodespesa cadtp = new frmCadtipodespesa();
            cadtp.Owner = this;
            cadtp.ShowDialog();
        }

        private void chkDespesa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDespesa.Checked == true)
            {
                chkFunc.Enabled = false;
                chkForn.Enabled = false;
                try
                {
                    CarregarComboTipo();
                    tipo = cmbOp.Text;
                }
                catch
                {
                }
            }
            else
            {
                chkForn.Enabled = true;
                chkFunc.Enabled = true;
                try
                {
                    cmbOp.DataSource = null;
                }
                catch
                {
                }
            }
        }
    }
}
