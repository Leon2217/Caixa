﻿using System;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmGeral : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        GeralDAO gerDAO = new GeralDAO();
        Geral ger = new Geral();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        #endregion

        #region VAR
        DateTime de, at;
        string desc, valor;
        double cred, deb, forn, func;
        int j;
        DateTime data;
        #endregion

        public frmGeral()
        {
            InitializeComponent();
        }

        private void frmGeral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void frmGeral_Load(object sender, EventArgs e)
        {
            Moeda(ref txtAjuste);

            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    
                }
                #endregion
                try
                {
                   #region SOMA TUDO
                    gerDAO.VerificaSoma();
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""))+ forn + func;
                   
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");
                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                    #endregion 
                }
                catch
                {
                }
            }
            catch
            {
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

        private void cmbDescricao_TextChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true || chkFuncionario.Checked == true)
            {
                #region AJUSTE GRID FORN FUNC
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "DESCR")
                        column.Width = 250; //tamanho fixo da coluna DESCR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 100; //tamanho fixo da coluna DESCR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            else
            {
                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }


                }
                #endregion
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region DESC E DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                lblDeb.Text = deb.ToString("C2");
                lblCred.Text = cred.ToString("C2");
                lblTotal.Text = (cred - deb).ToString("c2");

                if (lblTotal.Text.Contains("-"))
                {
                    lblTotal.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblTotal.ForeColor = Color.ForestGreen;
                }
                #endregion
            }
            #endregion

            #region FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarForn();

                #region SOMA FORN
                gerDAO.VerificaSomaForn();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region FUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFunc();

                #region SOMA FUNC
                gerDAO.VerificaSomaFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEForn(de);

                #region SOMA DE FORN
                gerDAO.VerificaSDForn(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DE FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFunc(de);

                #region SOMA DE FUNC
                gerDAO.VerificaSDFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarBForn(de, at);

                #region SOMA BFORN
                try
                {
                    gerDAO.VerificaSBForn(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBFunc(de, at);

                #region SOMA BFUNC
                try
                {
                    gerDAO.VerificaSBFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region FORNFUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFornFunc();

                #region SOMA FORNFUNC
                gerDAO.VerificaSomaFornFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFornFunc(de);

                #region SOMA DE FORNFUNC
                gerDAO.VerificaSDFornFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBTNFornFunc(de, at);

                #region SOMA BFORNFUNC
                try
                {
                    gerDAO.VerificaSBFornFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion
        }

        private void cmbDescricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true || chkFuncionario.Checked == true)
            {
                #region AJUSTE GRID FORN FUNC
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "DESCR")
                        column.Width = 250; //tamanho fixo da coluna DESCR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 100; //tamanho fixo da coluna DESCR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            else
            {
                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }


                }
                #endregion
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region DESC E DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                lblDeb.Text = deb.ToString("C2");
                lblCred.Text = cred.ToString("C2");
                lblTotal.Text = (cred - deb).ToString("c2");

                if (lblTotal.Text.Contains("-"))
                {
                    lblTotal.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblTotal.ForeColor = Color.ForestGreen;
                }
                #endregion
            }
            #endregion

            #region FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarForn();

                #region SOMA FORN
                gerDAO.VerificaSomaForn();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region FUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFunc();

                #region SOMA FUNC
                gerDAO.VerificaSomaFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEForn(de);

                #region SOMA DE FORN
                gerDAO.VerificaSDForn(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DE FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFunc(de);

                #region SOMA DE FUNC
                gerDAO.VerificaSDFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarBForn(de, at);

                #region SOMA BFORN
                try
                {
                    gerDAO.VerificaSBForn(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBFunc(de, at);

                #region SOMA BFUNC
                try
                {
                    gerDAO.VerificaSBFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region FORNFUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFornFunc();

                #region SOMA FORNFUNC
                gerDAO.VerificaSomaFornFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFornFunc(de);

                #region SOMA DE FORNFUNC
                gerDAO.VerificaSDFornFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBTNFornFunc(de, at);

                #region SOMA BFORNFUNC
                try
                {
                    gerDAO.VerificaSBFornFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion
        }

        public void ExportarPDF(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(new float[] { 1, 2, 1, 1, 1, 1, 1});
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
                    if (cell.ColumnIndex == 0)
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

        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "planilha");
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
                    if (j == 0)
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

            Microsoft.Office.Interop.Excel.Range rng4 = worksheet.get_Range("C2:E300");
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

        private void chkFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true || chkFuncionario.Checked == true)
            {
                gvExibir.Columns.Clear();

                gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                #region AJUSTE GRID FORN FUNC
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "DESCR")
                        column.Width = 250; //tamanho fixo da coluna DESCR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DESCR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            else
            {
                gvExibir.Columns.Clear();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region DESC E DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                lblDeb.Text = deb.ToString("C2");
                lblCred.Text = cred.ToString("C2");
                lblTotal.Text = (cred - deb).ToString("c2");

                if (lblTotal.Text.Contains("-"))
                {
                    lblTotal.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblTotal.ForeColor = Color.ForestGreen;
                }
                #endregion
            }
            #endregion

            #region FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarForn();

                #region SOMA FORN
                gerDAO.VerificaSomaForn();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region FUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFunc();

                #region SOMA FUNC
                gerDAO.VerificaSomaFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEForn(de);

                #region SOMA DE FORN
                gerDAO.VerificaSDForn(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DE FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFunc(de);

                #region SOMA DE FUNC
                gerDAO.VerificaSDFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarBForn(de, at);

                #region SOMA BFORN
                try
                {
                    gerDAO.VerificaSBForn(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBFunc(de, at);

                #region SOMA BFUNC
                try
                {
                    gerDAO.VerificaSBFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region FORNFUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFornFunc();

                #region SOMA FORNFUNC
                gerDAO.VerificaSomaFornFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFornFunc(de);

                #region SOMA DE FORNFUNC
                gerDAO.VerificaSDFornFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBTNFornFunc(de, at);

                #region SOMA BFORNFUNC
                try
                {
                    gerDAO.VerificaSBFornFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion
        }

        private void chkFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true || chkFuncionario.Checked == true)
            {
                gvExibir.Columns.Clear();

                gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                #region AJUSTE GRID FORN FUNC
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "DESCR")
                        column.Width = 250; //tamanho fixo da coluna DESCR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 100; //tamanho fixo da coluna DESCR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            else
            {
                gvExibir.Columns.Clear();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }


                }
                #endregion
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region DESC E DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                lblDeb.Text = deb.ToString("C2");
                lblCred.Text = cred.ToString("C2");
                lblTotal.Text = (cred - deb).ToString("c2");

                if (lblTotal.Text.Contains("-"))
                {
                    lblTotal.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblTotal.ForeColor = Color.ForestGreen;
                }
                #endregion
            }
            #endregion

            #region FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarForn();

                #region SOMA FORN
                gerDAO.VerificaSomaForn();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region FUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFunc();

                #region SOMA FUNC
                gerDAO.VerificaSomaFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEForn(de);

                #region SOMA DE FORN
                gerDAO.VerificaSDForn(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DE FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFunc(de);

                #region SOMA DE FUNC
                gerDAO.VerificaSDFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarBForn(de, at);

                #region SOMA BFORN
                try
                {
                    gerDAO.VerificaSBForn(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBFunc(de, at);

                #region SOMA BFUNC
                try
                {
                    gerDAO.VerificaSBFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region FORNFUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFornFunc();

                #region SOMA FORNFUNC
                gerDAO.VerificaSomaFornFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFornFunc(de);

                #region SOMA DE FORNFUNC
                gerDAO.VerificaSDFornFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBTNFornFunc(de, at);

                #region SOMA BFORNFUNC
                try
                {
                    gerDAO.VerificaSBFornFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion
        }

        private void FrmGeral_Resize(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            if (this.WindowState == FormWindowState.Maximized)
            {
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 130; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 90; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 130; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 130; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 130; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 140; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            else
            {
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            #endregion
        }

        private void txtAjuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtAjuste_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtAjuste);
            if (txtAjuste.Text!=string.Empty)
            {
                valor = txtAjuste.Text.ToString().Replace(".", "");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbAjustes.Text=="CRÉDITO")
            {
                //GERAL
                if (vgDAO.Verificavalor() == true)
                {
                    vgDAO.Update(valor);
                    vgDAO.Verificavalor();
                    #region GERAL
                    ger.Data = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    ger.Desc_g = "AJUSTE";
                    ger.Cred_g = txtAjuste.Text.ToString().Replace(".", "");
                    ger.Deb_g = "0,00";
                    ger.Forn = "0,00";
                    ger.Func = "0,00";
                    ger.Total = vgDAO.Vg.Valor;
                    gerDAO.Inserir(ger);
                    gvExibir.DataSource = gerDAO.ListarTudo();
                    txtAjuste.Text = "";
                    #endregion
                }
                else
                {
                    string zero = "0.00";
                    vgDAO.Inserir(zero);
                    vgDAO.Update(valor);
                    vgDAO.Verificavalor();

                    #region GERAL
                    ger.Data = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    ger.Desc_g = "AJUSTE";
                    ger.Cred_g = txtAjuste.Text.ToString().Replace(".", "");
                    ger.Deb_g = "0,00";
                    ger.Forn = "0,00";
                    ger.Func = "0,00";
                    ger.Total = vgDAO.Vg.Valor;
                    gerDAO.Inserir(ger);
                    gvExibir.DataSource = gerDAO.ListarTudo();
                    txtAjuste.Text = "";
                    #endregion
                }
            }
            else
            {
                if (cmbAjustes.Text == "DÉBITO")
                {
                    if (vgDAO.Verificavalor() == true)
                    {
                        vgDAO.Update2(valor);
                        vgDAO.Verificavalor();
                        #region GERAL
                        ger.Data = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                        ger.Desc_g = "AJUSTE";
                        ger.Deb_g = txtAjuste.Text.ToString().Replace(".", "");
                        ger.Cred_g = "0,00";
                        ger.Forn = "0,00";
                        ger.Func = "0,00";
                        ger.Total = vgDAO.Vg.Valor;
                        gerDAO.Inserir(ger);
                        gvExibir.DataSource = gerDAO.ListarTudo();
                        txtAjuste.Text = "";
                        #endregion
                    }
                    else
                    {
                        string zero = "0.00";
                        vgDAO.Inserir(zero);
                        vgDAO.Update2(valor);
                        vgDAO.Verificavalor();

                        #region GERAL
                        ger.Data = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                        ger.Desc_g = "AJUSTE";
                        ger.Deb_g = txtAjuste.Text.ToString().Replace(".", "");
                        ger.Cred_g = "0,00";
                        ger.Forn = "0,00";
                        ger.Func = "0,00";
                        ger.Total = vgDAO.Vg.Valor;
                        gerDAO.Inserir(ger);
                        gvExibir.DataSource = gerDAO.ListarTudo();
                        txtAjuste.Text = "";
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("Escolha se é débito ou crédito!!!");
                }                   
            }
        }

        private void mskAté_TextChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true || chkFuncionario.Checked == true)
            {
                #region AJUSTE GRID FORN FUNC
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "DESCR")
                        column.Width = 250; //tamanho fixo da coluna DESCR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 100; //tamanho fixo da coluna DESCR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            else
            {
                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }


                }
                #endregion
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region DESC E DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                lblDeb.Text = deb.ToString("C2");
                lblCred.Text = cred.ToString("C2");
                lblTotal.Text = (cred - deb).ToString("c2");

                if (lblTotal.Text.Contains("-"))
                {
                    lblTotal.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblTotal.ForeColor = Color.ForestGreen;
                }
                #endregion
            }
            #endregion

            #region FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarForn();

                #region SOMA FORN
                gerDAO.VerificaSomaForn();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region FUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFunc();

                #region SOMA FUNC
                gerDAO.VerificaSomaFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEForn(de);

                #region SOMA DE FORN
                gerDAO.VerificaSDForn(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DE FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFunc(de);

                #region SOMA DE FUNC
                gerDAO.VerificaSDFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarBForn(de, at);

                #region SOMA BFORN
                try
                {
                    gerDAO.VerificaSBForn(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBFunc(de, at);

                #region SOMA BFUNC
                try
                {
                    gerDAO.VerificaSBFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region FORNFUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFornFunc();

                #region SOMA FORNFUNC
                gerDAO.VerificaSomaFornFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFornFunc(de);

                #region SOMA DE FORNFUNC
                gerDAO.VerificaSDFornFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBTNFornFunc(de, at);

                #region SOMA BFORNFUNC
                try
                {
                    gerDAO.VerificaSBFornFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion
        }

        private void mskDe_TextChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true || chkFuncionario.Checked == true)
            {
                #region AJUSTE GRID FORN FUNC
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "DESCR")
                        column.Width = 250; //tamanho fixo da coluna DESCR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 100; //tamanho fixo da coluna DESCR
                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion
            }
            else
            {
                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "CREDITO")
                        column.Width = 85; //tamanho fixo da coluna CREDITO
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "DEBITO")
                        column.Width = 80; //tamanho fixo da coluna DEBITO
                    else if (column.DataPropertyName == "FORN")
                        column.Width = 80; //tamanho fixo da coluna FORN
                    else if (column.DataPropertyName == "FUNC")
                        column.Width = 80; //tamanho fixo da coluna FUNC
                    else if (column.DataPropertyName == "TOTAL")
                        column.Width = 90; //tamanho fixo da coluna FUNC

                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }


                }
                #endregion
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region DESC E DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region LISTAR TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                lblDeb.Text = deb.ToString("C2");
                lblCred.Text = cred.ToString("C2");
                lblTotal.Text = (cred - deb).ToString("c2");

                if (lblTotal.Text.Contains("-"))
                {
                    lblTotal.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblTotal.ForeColor = Color.ForestGreen;
                }
                #endregion
            }
            #endregion

            #region FORN
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarForn();

                #region SOMA FORN
                gerDAO.VerificaSomaForn();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region FUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFunc();

                #region SOMA FUNC
                gerDAO.VerificaSomaFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEForn(de);

                #region SOMA DE FORN
                gerDAO.VerificaSDForn(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region DE FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFunc(de);

                #region SOMA DE FUNC
                gerDAO.VerificaSDFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == false)
            {
                gvExibir.DataSource = gerDAO.ListarBForn(de, at);

                #region SOMA BFORN
                try
                {
                    gerDAO.VerificaSBForn(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == false && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBFunc(de, at);

                #region SOMA BFUNC
                try
                {
                    gerDAO.VerificaSBFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region FORNFUNC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarFornFunc();

                #region SOMA FORNFUNC
                gerDAO.VerificaSomaFornFunc();
                try
                {
                    try
                    {
                        func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    }
                    catch
                    {

                    }

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }
                #endregion
            }
            #endregion                                              

            #region DE FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDEFornFunc(de);

                #region SOMA DE FORNFUNC
                gerDAO.VerificaSDFornFunc(de);
                try
                {
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;

                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("c2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN FORNFUNC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty && chkFornecedor.Checked == true && chkFuncionario.Checked == true)
            {
                gvExibir.DataSource = gerDAO.ListarBTNFornFunc(de, at);

                #region SOMA BFORNFUNC
                try
                {
                    gerDAO.VerificaSBFornFunc(de, at);
                    func = Convert.ToDouble(gerDAO.Ger.Func.ToString().Replace(".", ""));
                    forn = Convert.ToDouble(gerDAO.Ger.Forn.ToString().Replace(".", ""));
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", "")) + forn + func;
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");

                    if (lblTotal.Text.Contains("-"))
                    {
                        lblTotal.ForeColor = Color.Firebrick;
                    }
                    else
                    {
                        lblTotal.ForeColor = Color.ForestGreen;
                    }
                }
                catch
                {

                }

                #endregion
            }
            #endregion
        }
    }
}
