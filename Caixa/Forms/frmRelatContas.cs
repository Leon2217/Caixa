﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmRelatContas : Form
    {

        #region INSTANCIAMENTO CLASSES
        ContasDAO contasDAO = new ContasDAO();
        PessoaDAO pesDAO = new PessoaDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Valorgeral vg = new Valorgeral();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        DateTime de, at;
        string codpes;
        string fornecedor;
        string status;
        string nf;
        string pc;
        string id;
        string st;
        string n;
        int j;
        DateTime data;
        DateTime data2;
#pragma warning disable CS0169 // O campo "frmRelatContas.data3" nunca é usado
        DateTime data3;
#pragma warning restore CS0169 // O campo "frmRelatContas.data3" nunca é usado
#pragma warning disable CS0169 // O campo "frmRelatContas.data4" nunca é usado
        DateTime data4;
#pragma warning restore CS0169 // O campo "frmRelatContas.data4" nunca é usado

        #endregion

        public frmRelatContas()
        {
            InitializeComponent();
        }

        public void CarregarComboStatus()
        {           
            //cmbS.DataSource = contasDAO.ListarStatus(id);
            //cmbS.DisplayMember = "STATUS";
            //cmbS.ValueMember = "STATUS";
  
        }


        private void frmRelatContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        public void CarregarComboFornecedor()
        {
            cmbFornecedor.DataSource = pesDAO.ListarF();
            cmbFornecedor.DisplayMember = "nome";
            cmbFornecedor.ValueMember = "ID";
            codpes = cmbFornecedor.SelectedValue.ToString();

        }

        private void frmRelatContas_Load(object sender, EventArgs e)
        {
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            try
            {
                CarregarComboFornecedor();
                cmbFornecedor.SelectedIndex = -1;
                contasDAO.UpdateAtrasado();
            }
            catch
            {

            }
      


            try
            {

                gvExibir.DataSource = contasDAO.ListarTudo();

                DataTable table = new DataTable();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "ID")
                        column.Width = 45; //tamanho fixo da coluna ID
                    else if (column.DataPropertyName == "STATUS")
                        column.Width = 90; //tamanho fixo da coluna STATUS               
                    else if (column.DataPropertyName == "VENC")
                        column.Width = 90; //tamanho fixo da coluna VENC
                    else if (column.DataPropertyName == "EMISSAO")
                        column.Width = 90; //tamanho fixo da coluna EMISSAO
                    else if (column.DataPropertyName == "NF")
                        column.Width = 140; //tamanho fixo da coluna NF
                    else if (column.DataPropertyName == "VALOR")
                        column.Width = 90; //tamanho fixo da coluna VALOR
                    else if (column.DataPropertyName == "FORNECEDOR")
                        column.Width = 250; //tamanho fixo da coluna FORNECEDOR


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


        private void gvExibir_CellClick(object sender, DataGridViewCellEventArgs  e)
        {
            if (gvExibir.CurrentCell.Value.ToString() != "")
            {
                //ContasDAO.codfudeu = Convert.ToInt32(gvExibir.CurrentCell.Tag);
                //frmPesqAgen k = new frmPesqAgen();
                //k.ShowDialog();


                string msg = String.Format("Row: {0}, Column: {1}",
           gvExibir.CurrentCell.RowIndex,
           gvExibir.CurrentCell.ColumnIndex);
                MessageBox.Show(msg, "Current Cell");








            }
        }

        private void chkPc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPc.Checked == true)
            {
                chkNf.Enabled = false;
            }
            else
            {
                chkNf.Enabled = true;
            }

            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "STATUS")
                    column.Width = 90; //tamanho fixo da coluna STATUS               
                else if (column.DataPropertyName == "VENC")
                    column.Width = 90; //tamanho fixo da coluna VENC
                else if (column.DataPropertyName == "EMISSAO")
                    column.Width = 90; //tamanho fixo da coluna EMISSAO
                else if (column.DataPropertyName == "NF")
                    column.Width = 140; //tamanho fixo da coluna NF
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 90; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "FORNECEDOR")
                    column.Width = 250; //tamanho fixo da coluna FORNECEDOR


                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion



        }

        private void chkNf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNf.Checked == true)
            {
                cmbFornecedor.Enabled = false;
                chkPc.Enabled = false;
                txtNf.Visible = true;
                this.ProcessTabKey(true);
            }
            else
            {
                cmbFornecedor.Enabled = true;
                txtNf.Visible = false;
                chkPc.Enabled = true;
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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion
        }

        private void mskDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskAté_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskAté_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "STATUS")
                    column.Width = 90; //tamanho fixo da coluna STATUS               
                else if (column.DataPropertyName == "VENC")
                    column.Width = 90; //tamanho fixo da coluna VENC
                else if (column.DataPropertyName == "EMISSAO")
                    column.Width = 90; //tamanho fixo da coluna EMISSAO
                else if (column.DataPropertyName == "NF")
                    column.Width = 140; //tamanho fixo da coluna NF
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 90; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "FORNECEDOR")
                    column.Width = 250; //tamanho fixo da coluna FORNECEDOR


                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion
        }

        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion
        }

        private void cmbFornecedor_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "STATUS")
                    column.Width = 90; //tamanho fixo da coluna STATUS               
                else if (column.DataPropertyName == "VENC")
                    column.Width = 90; //tamanho fixo da coluna VENC
                else if (column.DataPropertyName == "EMISSAO")
                    column.Width = 90; //tamanho fixo da coluna EMISSAO
                else if (column.DataPropertyName == "NF")
                    column.Width = 140; //tamanho fixo da coluna NF
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 90; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "FORNECEDOR")
                    column.Width = 250; //tamanho fixo da coluna FORNECEDOR


                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion
        }

        private void cmbStatus_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "STATUS")
                    column.Width = 90; //tamanho fixo da coluna STATUS               
                else if (column.DataPropertyName == "VENC")
                    column.Width = 90; //tamanho fixo da coluna VENC
                else if (column.DataPropertyName == "EMISSAO")
                    column.Width = 90; //tamanho fixo da coluna EMISSAO
                else if (column.DataPropertyName == "NF")
                    column.Width = 140; //tamanho fixo da coluna NF
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 90; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "FORNECEDOR")
                    column.Width = 250; //tamanho fixo da coluna FORNECEDOR


                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion
        }

        private void txtNf_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "STATUS")
                    column.Width = 90; //tamanho fixo da coluna STATUS               
                else if (column.DataPropertyName == "VENC")
                    column.Width = 90; //tamanho fixo da coluna VENC
                else if (column.DataPropertyName == "EMISSAO")
                    column.Width = 90; //tamanho fixo da coluna EMISSAO
                else if (column.DataPropertyName == "NF")
                    column.Width = 140; //tamanho fixo da coluna NF
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 90; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "FORNECEDOR")
                    column.Width = 250; //tamanho fixo da coluna FORNECEDOR


                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion

            #region DATA E NF
            if (txtNf.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false)
            {
                #region BLOQ

                cmbFornecedor.Enabled = false;
                chkPc.Enabled = false;
                #endregion

                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNF(de, nf);
            }
            else
            {
                #region DESBLOQ
                //cmbFornecedor.Enabled = true;
                chkPc.Enabled = true;
                #endregion
            }
            #endregion
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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion

            #region DATA E NF
            if (txtNf.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false)
            {
                #region BLOQ

                cmbFornecedor.Enabled = false;
                chkPc.Enabled = false;
                #endregion

                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNF(de, nf);
            }
            else
            {
                #region DESBLOQ
                //cmbFornecedor.Enabled = true;
                chkPc.Enabled = true;
                #endregion
            }
            #endregion
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty)
            {
                id = txtID.Text.ToString();
                txtn.Enabled = false;
                CarregarComboStatus();
            }
            else
            {
                txtn.Enabled = true;
            }

        }

        private void btnAt_Click(object sender, EventArgs e)
        {
            if (txtID.Enabled == true)
            {

                if (cmbS.Text == string.Empty || txtID.Text == string.Empty)
                {
                    MessageBox.Show("Favor preencher ou NF ou ID !!!");


                }
                else
                {
                    try
                    {

                        DialogResult op;

                        op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Status : " + st,
                            "Alterando!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (op == DialogResult.Yes)
                        {
                            if (st == "Pago")
                            {
                                //PEGA AS INFO'S DO ID

                                contasDAO.Verificavalor(id);
                                string valor = contasDAO.Con.Valor.ToString();
                                DateTime data = contasDAO.Con.Data;
                                contasDAO.UpdateStatus(st, id);

                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = data;
                                    ger.Desc_g = "NF";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Forn = valor;
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
                                    ger.Desc_g = "NF";
                                    ger.Deb_g = "0,00";
                                    ger.Forn = valor;
                                    ger.Func = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion


                            }
                            else
                            {
                                contasDAO.UpdateStatus(st, id);
                            }

                            MessageBox.Show("Atualizado com sucesso !!!");

                            aud.Acao = "PAGOU CONTA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                            AtualizaDados();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro ;)");
                    }
                }
            }
            else
            {

                if (cmbS.Text == string.Empty || txtn.Text == string.Empty)
                {
                    MessageBox.Show("Favor preencher ou NF ou ID !!!");


                }
                else
                {
                    try
                    {

                        DialogResult op;

                        op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Status : " + st,
                            "Alterando!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (op == DialogResult.Yes)
                        {
                            if (st == "Pago")
                            {
                                //PEGA AS INFO'S DO ID

                                contasDAO.Verificavalor(id);
                                string valor = contasDAO.Con.Valor.ToString();
                                DateTime data = contasDAO.Con.Data;
                                contasDAO.UpdateStatus(st, id);

                                #region GERAL
                                if (vgDAO.Verificavalor() == true)
                                {
                                    vgDAO.Update2(valor);
                                    vgDAO.Verificavalor();
                                    #region GERAL
                                    ger.Data = data;
                                    ger.Desc_g = "NF";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Forn = valor;
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
                                    ger.Desc_g = "NF";
                                    ger.Deb_g = "0,00";
                                    ger.Cred_g = "0,00";
                                    ger.Forn = valor;
                                    ger.Func = "0,00";
                                    ger.Total = vgDAO.Vg.Valor;
                                    gerDAO.Inserir(ger);

                                    #endregion
                                }
                                #endregion


                            }
                            else
                            {
                                contasDAO.UpdateStatus(st, id);
                            }
                            MessageBox.Show("Atualizado com sucesso !!!");
                            AtualizaDados();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro ;)");
                    }
                }
            }
        }

        private void cmbS_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbS.Text != string.Empty)
            {
                st = cmbS.Text.ToString();
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

        private void txtn_TextChanged(object sender, EventArgs e)
        {
           
            if (txtn.Text != string.Empty)
            {
                txtID.Enabled = false;
                n = txtn.Text.ToString();
            }
            else
            {
                txtID.Enabled = true;
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
                    if (j == 3)
                    {
                        try
                        {
                            data2 = Convert.ToDateTime(gvExibir.Rows[i].Cells[j].Value);


                            worksheet.Cells[i + 2, j + 1] = data2.ToString("MM/dd/yyyy");
                        }
                        catch
                        {

                        }
                    }

                    if (j == 4)
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
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("F2:F300");
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

            Microsoft.Office.Interop.Excel.Range rng2 = worksheet.get_Range("H2:H300");
            foreach (Microsoft.Office.Interop.Excel.Range range in rng2)
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

            Microsoft.Office.Interop.Excel.Range rng3 = worksheet.get_Range("J2:J300");
            foreach (Microsoft.Office.Interop.Excel.Range range in rng3)
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

            Microsoft.Office.Interop.Excel.Range rng4 = worksheet.get_Range("L2:L300");
            foreach (Microsoft.Office.Interop.Excel.Range range in rng4)
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

        public void ExportarPDF(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(new float[] { 1, 1, 3, 1 , 1 ,1 , 1 });
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
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
                    if (cell.ColumnIndex == 3 || cell.ColumnIndex==4)
                    {
                        try
                        {
                            DateTime d;
                            d = Convert.ToDateTime(cell.Value.ToString());
                            pdftable.AddCell(new Phrase(d.ToShortDateString(), text));
                        }
                        catch
                        {

                        }
                        
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





        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "planilha");
        }


        private void gvExibir_CellErrorTextNeeded(object sender, DataGridViewCellErrorTextNeededEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty && txtn.Text == string.Empty)
            {
                txtID.BackColor = Color.Red;
                MessageBox.Show("Favor preencher o ID ou NF da conta");
            }
            else
            {
                DialogResult op;

                op = MessageBox.Show("Deseja realmente excluir?",
                    "Excluir?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    contasDAO.Excluir(id, n);
                    MessageBox.Show("Excluído com sucesso !!!");
                    txtID.Text = string.Empty;
                    txtn.Text = string.Empty;
                    gvExibir.DataSource = contasDAO.ListarTudo();

                    aud.Acao = "EXCLUIU CONTA";
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

        private void gvExibir_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gvExibir.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void mskDe_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 45; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "STATUS")
                    column.Width = 90; //tamanho fixo da coluna STATUS               
                else if (column.DataPropertyName == "VENC")
                    column.Width = 90; //tamanho fixo da coluna VENC
                else if (column.DataPropertyName == "EMISSAO")
                    column.Width = 90; //tamanho fixo da coluna EMISSAO
                else if (column.DataPropertyName == "NF")
                    column.Width = 140; //tamanho fixo da coluna NF
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 90; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "FORNECEDOR")
                    column.Width = 250; //tamanho fixo da coluna FORNECEDOR


                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

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

            #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarPFS(fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDPFS(de, fornecedor, status, nf);
            }
            #endregion

            #region DE,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNS(de, nf, status);
            }
            #endregion

            #region DE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDFS(de, fornecedor, status);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBPFS(de, at, fornecedor, status, nf);
            }
            #endregion

            #region BETWEEN,PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,NF E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBNS(de, at, nf, status);
            }
            #endregion

            #region BETWEEN,FORNECEDOR E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBFS(de, at, fornecedor, status);
            }
            #endregion

            #region FORNECEDOR E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarFS(fornecedor, status);
            }
            #endregion

            #region PEDIDO/CHEQUE E FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarPF(nf, fornecedor);
            }
            #endregion

            #region AS DUAS DATAS E PEDIDO/CHEQUE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region AS DUAS DATAS E NOTA FISCAL
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBN(de, at, nf);
            }
            #endregion

            #region PEDIDO/CHEQUE E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                nf = "Pedido/cheque";
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region NOTA FISCAL E STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text != string.Empty)
            {
                nf = txtNf.Text.ToString();
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNS(nf, status);
            }
            #endregion

            #region AS DUAS DATAS E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBS(de, at, status);
            }
            #endregion

            #region AS DUAS DATAS E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarBF(de, at, fornecedor);
            }
            #endregion

            #region PEDIDO/CHEQUE
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                nf = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region NOTA FISCAL
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarNF(nf);
            }
            #endregion

            #region STATUS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarS(status);
            }
            #endregion

            #region FORNECEDOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarF(fornecedor);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKNF
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == true && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarD(de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E CHKPC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == true && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                pc = "Pedido/cheque";
                gvExibir.DataSource = contasDAO.ListarDNF(de, pc);
            }
            #endregion

            #region AS DUAS DATAS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarB(de, at);
            }
            #endregion

            #region PRIMEIRA DATA E FORNECEDOR
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text != string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                fornecedor = cmbFornecedor.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDF(de, fornecedor);
            }
            #endregion

            #region PRIMEIRA DATA E STATUS
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text != string.Empty)
            {
                status = cmbStatus.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDS(de, status);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbFornecedor.Text == string.Empty
                && chkPc.Checked == false && chkNf.Checked == false && cmbStatus.Text == string.Empty)
            {
                gvExibir.DataSource = contasDAO.ListarTudo();
            }
            #endregion

            #region DATA E NF
            if (txtNf.Text != string.Empty && mskDe.MaskFull == true && mskAté.MaskFull == false)
            {
                #region BLOQ

                cmbFornecedor.Enabled = false;
                chkPc.Enabled = false;
                #endregion

                nf = txtNf.Text.ToString();
                gvExibir.DataSource = contasDAO.ListarDNF(de, nf);
            }
            else
            {
                #region DESBLOQ
                cmbFornecedor.Enabled = true;
                chkPc.Enabled = true;
                #endregion
            }
            #endregion


        }
    }
}