﻿using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmRelatCartao : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        MarcaDAO marDAO = new MarcaDAO();
        MaquinasDAO maqDAO = new MaquinasDAO();
        CartaocaixaDAO ccDAO = new CartaocaixaDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        #endregion

        #region VAR
        DateTime de, at;
        string codmarca;
        string codmarca2;
        string codturno;
        string codmaq;
        int j;
        string tipo;
        double cred, deb, vr, tk, sd, el, sn;
        string login;
        #endregion
        public frmRelatCartao()
        {
            InitializeComponent();
        }

        public void CarregarComboMarca()
        {
            cmbBandeira.DataSource = marDAO.ListarTudo();
            cmbBandeira.DisplayMember = "MARCA";
            cmbBandeira.ValueMember = "ID";
            codmarca = cmbBandeira.SelectedValue.ToString();
        }

        public void CarregarComboCartao()
        {
            cmbCartao.DataSource = marDAO.ListarCartao(codmarca);
            cmbCartao.DisplayMember = "CART";
            cmbCartao.ValueMember = "ID";
            cmbCartao.Text = "";
        }

        public void CarregarComboMaq()
        {
            cmbMaquina.DataSource = maqDAO.ListarTudo();
            cmbMaquina.DisplayMember = "maquina";
            cmbMaquina.ValueMember = "id_maquina";
            cmbMaquina.Text = "";
        }

        private void frmRelatCartao_Load(object sender, EventArgs e)
        {
            #region LOGIN
            login = UsuarioDAO.login;
            usuDAO.VerificaCargo(login);
            tipo = usuDAO.Usu.Tipo.ToString();
            #endregion


            if (tipo == "Operador" || tipo == "Operador\t")
            {
                btnTaxa.Visible = false;
            }

            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            CarregarComboMarca();
            CarregarComboMaq();
            cmbBandeira.Text = "";
            cmbCartao.Text = "";
            cmbMaquina.Text = "";
            gvExibir.DataSource = ccDAO.ListarTudo();

            #region VERIFICA SE (VAZIOS)
            try
            {
                ccDAO.VerificaSC();
                cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");
            }
            catch
            {
            }

            try
            {
                ccDAO.VerificaSD();
                deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");
            }
            catch
            {
            }

            try
            {
                ccDAO.VerificaSDX();
                sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");
            }
            catch
            {
            }

            try
            {
                ccDAO.VerificaSVR();
                vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");
            }
            catch
            {
            }

            try
            {
                ccDAO.VerificaT();
                tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");
            }
            catch
            {
            }

            try
            {
                ccDAO.VerificaSe();
                el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");
            }
            catch
            {
            }

            try
            {
                ccDAO.VerificaSFN();
                sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                lblSoft.Text = sn.ToString("C2");
            }
            catch
            {
            }

            try
            {
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            catch
            {
            }
            #endregion
        }

        private void cmbBandeira_SelectedIndexChanged(object sender, EventArgs e)
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            CarregarComboCartao();
        }

        private void frmRelatCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyValue.Equals(121))
            {
                #region LOGIN
                login = UsuarioDAO.login;
                usuDAO.VerificaCargo(login);
                tipo = usuDAO.Usu.Tipo.ToString();
                #endregion

                if (tipo != "Operador")
                {
                    frmRelatTaxa rlt = new frmRelatTaxa();
                    rlt.Owner = this;
                    rlt.ShowDialog();
                }
            }
        }

        private void cmbBandeira_TextChanged(object sender, EventArgs e)
        {
            CarregarComboCartao();

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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }

        private void cmbCartao_SelectedIndexChanged(object sender, EventArgs e)
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }

        private void cmbCartao_TextChanged(object sender, EventArgs e)
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }

        private void cmbMaquina_SelectedIndexChanged(object sender, EventArgs e)
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }

        private void cmbMaquina_TextChanged(object sender, EventArgs e)
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }

        public void ExportarPDF(DataGridView dgw, string filename)
        {
            #region PDF
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
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
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
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
            #endregion
        }

        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "planilha");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            #region Excel
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
                    worksheet.Cells[i + 2, j + 1] = gvExibir.Rows[i].Cells[j].Value.ToString();
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

        private void btnTaxa_Click(object sender, EventArgs e)
        {
            frmRelatTaxa rlt = new frmRelatTaxa();
            rlt.Owner = this;
            rlt.ShowDialog();

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

            #region PEGA ID DA MARCA
            try
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO TURNO
            try
            {
                if (cmbTurno.SelectedIndex == 0)
                {
                    codturno = "1";
                }
                else
                {
                    codturno = "2";
                }


            }
            catch
            {

            }
            #endregion

            #region PEGA ID DA MAQUINA
            try
            {
                codmaq = cmbMaquina.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region PEGA ID DO CARTAO
            try
            {
                codmarca2 = cmbCartao.SelectedValue.ToString();
            }
            catch
            {

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDe(de);

                    #region Label (DE) Crédito
                    ccDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    ccDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    ccDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    ccDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    ccDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    ccDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    ccDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region DE E BANDEIRA/MARCA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarTudo();


                    #region Label Crédito
                    ccDAO.VerificaSC();
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region Label Débito
                    ccDAO.VerificaSD();
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region Label Sodexo
                    ccDAO.VerificaSDX();
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region Label VR
                    ccDAO.VerificaSVR();
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region Label Ticket
                    ccDAO.VerificaT();
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region Label ELO
                    ccDAO.VerificaSe();
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region Label Softnex
                    ccDAO.VerificaSFN();
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDT(de, codturno);
            }
            #endregion

            #region DE E MÁQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarDM(de, codmaq);

                    #region CRED (DE) MAQUINA
                    ccDAO.VerificaDCM(codmaq, de);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (DE) MAQUINA
                    ccDAO.VerificaDDM(codmaq, de);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (DE) MAQUINA
                    ccDAO.VerificaDVRM(codmaq, de);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (DE) MAQUINA
                    ccDAO.VerificaDSDXM(codmaq, de);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (DE) MAQUINA
                    ccDAO.VerificaDELOM(codmaq, de);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (DE) MAQUINA
                    ccDAO.VerificaDTM(codmaq, de);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (DE) MAQUINA
                    ccDAO.VerificaDSFTM(codmaq, de);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region BANDEIRA/MARCA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarB(codmarca);
            }
            #endregion

            #region MÁQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarM(codmaq);

                    #region CRED MAQUINA
                    ccDAO.VerificaCM(codmaq);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB MAQUINA
                    ccDAO.VerificaDM(codmaq);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR MAQUINA
                    ccDAO.VerificaVRM(codmaq);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SDX MAQUINA
                    ccDAO.VerificaSDXM(codmaq);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO MAQUINA
                    ccDAO.VerificaELOM(codmaq);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET MAQUINA
                    ccDAO.VerificaTM(codmaq);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX MAQUINA
                    ccDAO.VerificaSFTM(codmaq);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }


                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");

            }
            #endregion

            #region TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarT(codturno);
            }
            #endregion

            #region BANDEIRA E CART
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBC(codmarca2, codmarca);
            }
            #endregion

            #region BANDEIRA E TURNO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBT(codturno, codmarca);
            }
            #endregion

            #region BANDEIRA E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBM(codmarca, codmaq);
            }
            #endregion

            #region TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarTM(codturno, codmaq);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarB(de, at);


                    #region Label (BTW) Crédito
                    ccDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    ccDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    ccDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    ccDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    ccDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    ccDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Soft
                    ccDAO.VerificaSOFT(de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }
                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region BETWEEN E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTU(de, at, codturno);
            }
            #endregion

            #region BETWEEN E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty)
            {
                try
                {
                    gvExibir.DataSource = ccDAO.ListarBTM(de, at, codmaq);


                    #region CRED (BTN) MAQUINA
                    ccDAO.VerificaBCM(codmaq, de, at);
                    cred = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                    #endregion

                    #region DEB (BTN) MAQUINA
                    ccDAO.VerificaBDM(codmaq, de, at);
                    deb = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    #endregion

                    #region VR (BTN) MAQUINA
                    ccDAO.VerificaBVRM(codmaq, de, at);
                    vr = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                    #endregion

                    #region SODEXO (BTN) MAQUINA
                    ccDAO.VerificaBSDXM(codmaq, de, at);
                    sd = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                    #endregion

                    #region ELO (BTN) MAQUINA
                    ccDAO.VerificaBELOM(codmaq, de, at);
                    el = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                    #endregion

                    #region TICKET (BTN) MAQUINA
                    ccDAO.VerificaBTM(codmaq, de, at);
                    tk = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                    #endregion

                    #region SOFTNEX (BTN) MAQUINA
                    ccDAO.VerificaBSFTM(codmaq, de, at);
                    sn = Convert.ToDouble(ccDAO.Carcai.Valor.ToString().Replace(".", ""));
                    lblSoft.Text = sn.ToString("C2");
                    #endregion
                }
                catch
                {

                }

                lblTotal.Text = (cred + deb + sd + vr + tk + el + sn).ToString("C2");
            }
            #endregion

            #region DE,BANDEIRA E TURNO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBT(de, codmarca, codturno);
            }
            #endregion

            #region DE,BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBM(de, codmarca, codmaq);
            }
            #endregion

            #region DE,TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDTM(de, codturno, codmaq);
            }
            #endregion

            #region BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTM(codmarca, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBT(de, at, codmarca, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBM(de, at, codmarca, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA E CART
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text == string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBC(de, at, codmarca, codmarca2);
            }
            #endregion

            #region BETWEEN, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBTM(de, at, codturno, codmaq);
            }
            #endregion

            #region BETWEEN, BANDEIRA, CART E TURNO
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text != string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text == string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBCT(de, at, codmarca, codmarca2, codturno);
            }
            #endregion

            #region BETWEEN, BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty &&
                cmbCartao.Text == string.Empty && cmbTurno.Text != string.Empty && cmbMaquina.Text != string.Empty
                )
            {
                gvExibir.DataSource = ccDAO.ListarBBTM(de, at, codmarca, codturno, codmaq);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text == string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBTC(de, codmarca, codturno, codmarca2);
            }
            #endregion

            #region DE, BANDEIRA, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMC(de, codmarca, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO E MAQUINA
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text == string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMT(de, codmarca, codmaq, codturno);
            }
            #endregion

            #region BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarBTMC(codmarca, codturno, codmaq, codmarca2);
            }
            #endregion

            #region DE,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = ccDAO.ListarDBMTC(de, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion

            #region BETWEEN,BANDEIRA, TURNO, MAQUINA E CARTAO
            if (mskDe.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCartao.Text != string.Empty && cmbMaquina.Text != string.Empty && cmbTurno.Text != string.Empty && mskAté.MaskFull == true)
            {
                gvExibir.DataSource = ccDAO.ListarBBMTC(de, at, codmarca, codmaq, codturno, codmarca2);
            }
            #endregion
        }
    }
}
