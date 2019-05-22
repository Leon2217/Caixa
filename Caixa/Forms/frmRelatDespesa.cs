using System;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmRelatDespesa : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        DespesaDAO despDAO = new DespesaDAO();
        PessoaDAO pesDAO = new PessoaDAO();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        #endregion

        #region VAR
        DateTime de, at;
        string pes;
        string status;
        string st;
        string id;
        DateTime data;
        int atrasado, emaberto;
        int j;
        #endregion

        public frmRelatDespesa()
        {
            InitializeComponent();
        }

        private void frmRelatDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        public void CarregarComboPessoa()
        {
            cmbPessoa.DataSource = pesDAO.ListarTDP();
            cmbPessoa.DisplayMember = "NOME";
            cmbPessoa.ValueMember = "ID";
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

        private void frmRelatDespesa_Load(object sender, EventArgs e)
        {
            try
            {
                Moeda(ref txtValor);
                despDAO.UpdateAtrasado();
                gvExibir.DataSource = despDAO.ListarTudo();
                CarregarComboPessoa();
                cmbPessoa.SelectedIndex = -1;
                cmbS.SelectedIndex = -1;

                despDAO.VerificaAtrasado();
                atrasado = Convert.ToInt32(despDAO.Desp.N.ToString());
                lblCountatrasado.Text = atrasado.ToString();

                despDAO.VerificaEmAberto();
                emaberto = Convert.ToInt32(despDAO.Desp.N.ToString());
                lblCountEmaberto.Text = emaberto.ToString();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "ID")
                        column.Width = 40; //tamanho fixo da coluna VALOR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA


                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            catch
            {
            }
        }

        private void cmbPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPessoa.Text != string.Empty)
            {
                ChkFr.Enabled = false;
            }
            else
            {
                ChkFr.Enabled = true;
            }

            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

                this.ProcessTabKey(true);

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

                this.ProcessTabKey(true);

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
        }

        private void cmbStatus_TextChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

                this.ProcessTabKey(true);

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE
(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
        }

        private void mskAté_TextChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }



            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE
(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
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


        public void AtualizaDados()
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

                this.ProcessTabKey(true);

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
        }

        private void btnAt_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Favor que preencher o ID !!!");
                txtID.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    //PEGA AS INFO'S DO ID
                    despDAO.Verificavalor(id);
                    DialogResult op;

                    op = MessageBox.Show("Você tem certeza dessas informações?",
                        "Alterando!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        if (txtValor.Text == "0,00")
                        {
                            if (st == "Pago")
                            {
                                string valor = despDAO.Desp.Valor.ToString();
                                DateTime data = despDAO.Desp.Data;
                                despDAO.UpdateStatus(st, id);

                                aud.Acao = "PAGOU DESPESA FIXA";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = data;
                                    ger.Desc_g = "DESPESA FIXA";
                                    ger.Deb_g = valor;
                                    ger.Cred_g = "0,00";
                                    ger.Forn = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                else
                                {
                                    string zero = "0.00";
                                    vgDAO.Inserir(zero);
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();

                                    #region GERAL
                                    ger.Data = data;
                                    ger.Desc_g = "DESPESA FIXA";
                                    ger.Deb_g = valor;
                                    ger.Cred_g = "0,00";
                                    ger.Forn = "0,00";
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                despDAO.UpdateStatus(st, id);
                            }
                        }
                        else
                        {
                            string valor = txtValor.Text;
                            despDAO.UpdateValorDespesa(valor, id);
                        }
                    }
                    
                    MessageBox.Show("Atualizado com sucesso !!!");
                    txtID.Clear();
                    txtValor.Clear();
                    cmbS.SelectedIndex = -1;
                    AtualizaDados();

                    despDAO.VerificaAtrasado();
                    atrasado = Convert.ToInt32(despDAO.Desp.N.ToString());
                    lblCountatrasado.Text = atrasado.ToString();

                    despDAO.VerificaEmAberto();
                    emaberto = Convert.ToInt32(despDAO.Desp.N.ToString());
                    lblCountEmaberto.Text = emaberto.ToString();
                }
                catch
                {
                    MessageBox.Show("Erro ;)");
                }
            }
        }

        private void cmbS_SelectedIndexChanged(object sender, EventArgs e)
        {
            st = cmbS.Text.ToString();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty)
            {
                id = txtID.Text.ToString();
            }
        }

        public void ExportarPDF(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(new float[] { 1, 1, 2, 1, 1, 1 });
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Cabeçalho
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            //Linha

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 1)
                    {
                        DateTime d;
                        d = Convert.ToDateTime(cell.Value.ToString());

                        pdftable.AddCell(new Phrase(d.ToShortDateString(), text));
                    }
                    else
                    {
                        pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            #region EXCEL
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.Sheets["Sheet1"];
            }
            catch
            {

            }
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "CustomerDetail";

            for (int i = 1; i < gvExibir.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = gvExibir.Columns[i - 1].HeaderText;
                worksheet.StandardWidth = 17;
            }

            for (int i = 0; i < gvExibir.Rows.Count; i++)
            {
                for (j = 0; j < gvExibir.Columns.Count; j++)
                {
                    if (j == 1)
                    {
                        try
                        {
                            data = Convert.ToDateTime(gvExibir.Rows[i].Cells[j].Value);


                            worksheet.Cells[i + 2, j + 1] = data.ToString("MM/dd/yyyy");
                        }
                        catch
                        {

                        }
                    }


                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = gvExibir.Rows[i].Cells[j].Value.ToString();
                    }

                }
            }
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("E2:E300");
            foreach (Microsoft.Office.Interop.Excel.Range range in rng)
            {
                if (range.Value != null)
                {
                    int number;
                    bool isNumber = int.TryParse(range.Value.ToString().Trim(), out number);
                    if (isNumber)
                    {

                        range.NumberFormat = "#,###.00 €";
                        range.Value = number;

                    }
                    else
                    {
                        string temp = "R$ " + range.Value.ToString();
                        temp = temp.Replace(",", ".");
                        range.Value = temp;
                    }
                }
            }


            Microsoft.Office.Interop.Excel.Range foda;
            foda = worksheet.UsedRange;
            foda.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            Microsoft.Office.Interop.Excel.Range cells = foda.Cells;
            Microsoft.Office.Interop.Excel.Borders bd = cells.Borders;
            bd.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            bd.Weight = 2d;

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Planilha";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
            #endregion
        }

        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "planilha");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFr.Checked == true)
            {
                gvExibir.DataSource = despDAO.ListarTudoSemForn();
                cmbPessoa.Enabled = false;
            }
            else
            {
                gvExibir.DataSource = despDAO.ListarTudo();
                cmbPessoa.Enabled = true;
            }
        }

        private void cmbPessoa_TextChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

                this.ProcessTabKey(true);

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                txtID.BackColor = Color.Red;
                MessageBox.Show("Favor preencher o ID da despesa");
            }
            else
            {
                DialogResult op;

                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    despDAO.Excluir(id);
                    MessageBox.Show("Excluído com sucesso !!!");
                    txtID.Text = string.Empty;

                    despDAO.VerificaAtrasado();
                    atrasado = Convert.ToInt32(despDAO.Desp.N.ToString());
                    lblCountatrasado.Text = atrasado.ToString();

                    despDAO.VerificaEmAberto();
                    emaberto = Convert.ToInt32(despDAO.Desp.N.ToString());
                    lblCountEmaberto.Text = emaberto.ToString();

                    gvExibir.DataSource = despDAO.ListarTudo();

                    aud.Acao = "EXCLUIU DESPESA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);

                }
                else
                {
                    MessageBox.Show("Cancelado");
                }
            }
        }

        private void TxtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
        }

        private void gvExibir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gvExibir.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void mskDe_TextChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);

                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

                this.ProcessTabKey(true);

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudo();
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR TUDO SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarTudoSemForn();
                }
                catch
                {

                }

            }
            #endregion

            #region DE STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusDE(status, de);
            }
            #endregion

            #region STATUS SEM FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatus(status);
            }
            #endregion

            #region BTN STATUS SEM FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == true)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSemFornStatusBTN(de, at, status);
            }
            #endregion

            #region LISTAR SEM FORN BTN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornBTN(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region LISTAR SEM FORN DE  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == true)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarSemFornDE(de);
                }
                catch
                {

                }

            }
            #endregion

            #region PESSOA LIKE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarP(pes);
                }
                catch
                {

                }
            }
            #endregion

            #region PESSOA LIKE E DE
            if (cmbPessoa.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                pes = cmbPessoa.Text;
                try
                {
                    gvExibir.DataSource = despDAO.ListarPD(pes, de);
                }
                catch
                {

                }
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarS(status);
            }
            #endregion

            #region DE STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text == string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDS(de, status);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    gvExibir.DataSource = despDAO.ListarB(de, at);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text == string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBP(de, at, pes);
                }
                catch
                {

                }

            }
            #endregion

            #region BETWEEN E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text == string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBS(de, at, status);
                }
                catch
                {

                }

            }
            #endregion

            #region STATUS E PESSOA
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarSP(status, pes);
            }
            #endregion

            #region DE STATUS E PESSOA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbStatus.Text != string.Empty && cmbPessoa.Text != string.Empty && ChkFr.Checked == false)
            {
                status = cmbStatus.Text.ToString();
                pes = cmbPessoa.Text.ToString();
                gvExibir.DataSource = despDAO.ListarDSP(de, status, pes);
            }
            #endregion

            #region BETWEEN E PESSOA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbPessoa.Text != string.Empty && cmbStatus.Text != string.Empty && ChkFr.Checked == false)
            {
                try
                {
                    pes = cmbPessoa.Text.ToString();
                    status = cmbStatus.Text.ToString();
                    gvExibir.DataSource = despDAO.ListarBPS(de, at, pes, status);
                }
                catch
                {

                }

            }
            #endregion
        }
    }
}
