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
    public partial class frmRelatTaxa : Form
    {
        #region INSTANCIAMENTO DE CLASSES
        RelattxDAO rlxDAO = new RelattxDAO();
        #endregion

        #region VAR
        DateTime de, at;
        MarcaDAO marDAO = new MarcaDAO();
        string codmarca;
        string codcart;
        double cred, deb, vr, tk, sd, el, sn;
        int j;
        DateTime data;
        #endregion
        public frmRelatTaxa()
        {
            InitializeComponent();
        }

        private void frmRelatTaxa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
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
            cmbCart.DataSource = marDAO.ListarCartao(codmarca);
            cmbCart.DisplayMember = "CART";
            cmbCart.ValueMember = "ID";
            cmbCart.Text = "";


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


            Microsoft.Office.Interop.Excel.Range rng4 = worksheet.get_Range("D2:E300");
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

        private void frmRelatTaxa_Load(object sender, EventArgs e)
        {          
            try
            {
                CarregarComboMarca();
            }
            catch
            {

            }
   
            cmbBandeira.Text = "";
            cmbCart.Text = "";
            try
            {
                gvExibir.DataSource = rlxDAO.ListarTudo();
            }
            catch
            {

            }

            try
            {
                rlxDAO.VerificaSC();
                cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");
            }
            catch
            {

            }


            try
            {
                rlxDAO.VerificaSD();
                deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");
            }
            catch
            {

            }


            try
            {
                rlxDAO.VerificaSDX();
                sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");
            }
            catch
            {

            }


            try
            {
                rlxDAO.VerificaSVR();
                vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");
            }
            catch
            {

            }


            try
            {
                rlxDAO.VerificaT();
                tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");
            }
            catch
            {

            }

            try
            {
                rlxDAO.VerificaSe();
                el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");
            }
            catch
            {

            }

            try
            {
                rlxDAO.VerificaSFN();
                sn = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSoft.Text = sn.ToString("C2");
            }
            catch
            {

            }



            try
            {
                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            catch
            {

            }
            
        }

        private void cmbBandeira_SelectedIndexChanged(object sender, EventArgs e)
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

            #region SOMENTE UMA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = rlxDAO.ListarDE(de);

                    #region Label (DE) Crédito
                    rlxDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    rlxDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    rlxDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    rlxDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    rlxDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    rlxDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    rlxDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {
                    Limpar();
                }



                    lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
             
                  
            
            }
            #endregion

            #region DE E BANDEIRA  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDB(de,codmarca);
            }
            #endregion

            #region BANDEIRA  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarB(codmarca);
            }
            #endregion

            #region BANDEIRA E CARTAO  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBC(codmarca, codcart);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {

           
                    gvExibir.DataSource = rlxDAO.ListarBT(de, at);

                    #region Label (BTW) Crédito
                    rlxDAO.VerificaBC(de, at);
                    try
                    {
                        cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (BTW) Débito
                    rlxDAO.VerificaBDD(de, at);
                    try
                    {
                        deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Vr
                    rlxDAO.VerificaBVR(de, at);
                    try
                    {
                        vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Sodexo
                    rlxDAO.VerificaBSDX(de, at);
                    try
                    {
                        sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Alelo
                    rlxDAO.VerificaBELO(de, at);
                    try
                    {
                        el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(BTW) Ticket
                    rlxDAO.VerificaBTK(de, at);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
              
    
                
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region DE,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDBC(de,codmarca, codcart);
            }
            #endregion

            #region BETWEEN,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBBC(de,at, codmarca, codcart);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarTudo();

                rlxDAO.VerificaSC();
                cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");


                rlxDAO.VerificaSD();
                deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");


                rlxDAO.VerificaSDX();
                sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");


                rlxDAO.VerificaSVR();
                vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");


                rlxDAO.VerificaT();
                tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");

                rlxDAO.VerificaSe();
                el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");

            }
            #endregion
        }

        private void cmbBandeira_TextChanged(object sender, EventArgs e)
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

            #region SOMENTE UMA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = rlxDAO.ListarDE(de);

                    #region Label (DE) Crédito
                    rlxDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    rlxDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    rlxDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    rlxDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    rlxDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    rlxDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    rlxDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {
                    Limpar();
                }



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            #endregion

            #region DE E BANDEIRA  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region BANDEIRA  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarB(codmarca);
            }
            #endregion

            #region BANDEIRA E CARTAO  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBC(codmarca, codcart);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarBT(de, at);

                #region Label (BTW) Crédito
                rlxDAO.VerificaBC(de, at);
                try
                {
                    cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label (BTW) Débito
                rlxDAO.VerificaBDD(de, at);
                try
                {
                    deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Vr
                rlxDAO.VerificaBVR(de, at);
                try
                {
                    vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Sodexo
                rlxDAO.VerificaBSDX(de, at);
                try
                {
                    sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Alelo
                rlxDAO.VerificaBELO(de, at);
                try
                {
                    el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Ticket
                rlxDAO.VerificaBTK(de, at);
                try
                {
                    tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                }
                catch
                {

                }
                #endregion

                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region DE,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDBC(de, codmarca, codcart);
            }
            #endregion

            #region BETWEEN,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBBC(de, at, codmarca, codcart);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarTudo();

                rlxDAO.VerificaSC();
                cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");


                rlxDAO.VerificaSD();
                deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");


                rlxDAO.VerificaSDX();
                sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");


                rlxDAO.VerificaSVR();
                vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");


                rlxDAO.VerificaT();
                tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");

                rlxDAO.VerificaSe();
                el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");

            }
            #endregion

            CarregarComboCartao();
        }

        private void cmbCart_SelectedIndexChanged(object sender, EventArgs e)
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

            #region SOMENTE UMA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = rlxDAO.ListarDE(de);

                    #region Label (DE) Crédito
                    rlxDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    rlxDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    rlxDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    rlxDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    rlxDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    rlxDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    rlxDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {
                    Limpar();
                }



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            #endregion

            #region DE E BANDEIRA  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region BANDEIRA  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarB(codmarca);
            }
            #endregion

            #region BANDEIRA E CARTAO  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBC(codmarca,codcart);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarBT(de,at);

                #region Label (BTW) Crédito
                rlxDAO.VerificaBC(de, at);
                try
                {
                    cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label (BTW) Débito
                rlxDAO.VerificaBDD(de, at);
                try
                {
                    deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Vr
                rlxDAO.VerificaBVR(de, at);
                try
                {
                    vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Sodexo
                rlxDAO.VerificaBSDX(de, at);
                try
                {
                    sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Alelo
                rlxDAO.VerificaBELO(de, at);
                try
                {
                    el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Ticket
                rlxDAO.VerificaBTK(de, at);
                try
                {
                    tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                }
                catch
                {

                }
                #endregion

                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region DE,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDBC(de, codmarca, codcart);
            }
            #endregion

            #region BETWEEN,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBBC(de, at, codmarca, codcart);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarTudo();

                rlxDAO.VerificaSC();
                cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");


                rlxDAO.VerificaSD();
                deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");


                rlxDAO.VerificaSDX();
                sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");


                rlxDAO.VerificaSVR();
                vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");


                rlxDAO.VerificaT();
                tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");

                rlxDAO.VerificaSe();
                el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");

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

            #region SOMENTE UMA DATA
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = rlxDAO.ListarDE(de);

                    #region Label (DE) Crédito
                    rlxDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    rlxDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    rlxDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    rlxDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    rlxDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    rlxDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    rlxDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion
                }
                catch
                {
                    Limpar();
                }



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            #endregion

            #region DE E BANDEIRA  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDB(de, codmarca);
            }
            #endregion

            #region BANDEIRA  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarB(codmarca);
            }
            #endregion

            #region BANDEIRA E CARTAO  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBC(codmarca, codcart);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarBT(de, at);

                #region Label (BTW) Crédito
                rlxDAO.VerificaBC(de, at);
                try
                {
                    cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label (BTW) Débito
                rlxDAO.VerificaBDD(de, at);
                try
                {
                    deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Vr
                rlxDAO.VerificaBVR(de, at);
                try
                {
                    vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Sodexo
                rlxDAO.VerificaBSDX(de, at);
                try
                {
                    sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Alelo
                rlxDAO.VerificaBELO(de, at);
                try
                {
                    el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Ticket
                rlxDAO.VerificaBTK(de, at);
                try
                {
                    tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                }
                catch
                {

                }
                #endregion

                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");
            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBB(de, at, codmarca);
            }
            #endregion

            #region DE,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDBC(de, codmarca, codcart);
            }
            #endregion

            #region BETWEEN,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBBC(de, at, codmarca, codcart);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarTudo();

                rlxDAO.VerificaSC();
                cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");


                rlxDAO.VerificaSD();
                deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");


                rlxDAO.VerificaSDX();
                sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");


                rlxDAO.VerificaSVR();
                vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");


                rlxDAO.VerificaT();
                tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");

                rlxDAO.VerificaSe();
                el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");

            }
            #endregion
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

            #region SOMENTE UMA DATA
            if (mskDe.MaskFull==true && mskAté.MaskFull==false && cmbBandeira.Text==string.Empty && cmbCart.Text == string.Empty)
            {
                try
                {
                    gvExibir.DataSource = rlxDAO.ListarDE(de);

                    #region Label (DE) Crédito
                    rlxDAO.VerificaDC(de);
                    try
                    {
                        cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblCred.Text = cred.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label (DE) Débito
                    rlxDAO.VerificaDD(de);
                    try
                    {
                        deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblDeb.Text = deb.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Vr
                    rlxDAO.VerificaDVR(de);
                    try
                    {
                        vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblV.Text = vr.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Sodexo
                    rlxDAO.VerificaDSDX(de);
                    try
                    {
                        sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSod.Text = sd.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Alelo
                    rlxDAO.VerificaDELO(de);
                    try
                    {
                        el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblAle.Text = el.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    rlxDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Ticket
                    rlxDAO.VerificaDT(de);
                    try
                    {
                        tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblTic.Text = tk.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Label(DE) Softnex
                    rlxDAO.VerificaDSOFT(de);
                    try
                    {
                        sn = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                        lblSoft.Text = sn.ToString("C2");
                    }
                    catch
                    {

                    }
                    #endregion


                }
                catch
                {
                    Limpar();
                }




                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");


            }
            #endregion

            #region DE E BANDEIRA  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDB(de, codmarca);

            }
            #endregion

            #region BANDEIRA  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarB(codmarca);
            }
            #endregion

            #region BANDEIRA E CARTAO  
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBC(codmarca, codcart);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarBT(de, at);

                #region Label (BTW) Crédito
                rlxDAO.VerificaBC(de,at);
                try
                {
                    cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblCred.Text = cred.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label (BTW) Débito
                rlxDAO.VerificaBDD(de,at);
                try
                {
                    deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Vr
                rlxDAO.VerificaBVR(de,at);
                try
                {
                    vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblV.Text = vr.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Sodexo
                rlxDAO.VerificaBSDX(de,at);
                try
                {
                    sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblSod.Text = sd.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Alelo
                rlxDAO.VerificaBELO(de,at);
                try
                {
                    el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblAle.Text = el.ToString("C2");
                }
                catch
                {

                }
                #endregion

                #region Label(BTW) Ticket
                rlxDAO.VerificaBTK(de,at);
                try
                {
                    tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                    lblTic.Text = tk.ToString("C2");
                }
                catch
                {

                }
                #endregion

                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");


            }
            #endregion

            #region BETWEEN E BANDEIRA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text == string.Empty)
            {
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBB(de, at, codmarca);

                
            }
            #endregion

            #region DE,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarDBC(de, codmarca, codcart);
            }
            #endregion

            #region BETWEEN,BANDEIRA E CARTAO  
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbBandeira.Text != string.Empty && cmbCart.Text != string.Empty)
            {
                codcart = cmbCart.SelectedValue.ToString();
                codmarca = cmbBandeira.SelectedValue.ToString();
                gvExibir.DataSource = rlxDAO.ListarBBC(de, at, codmarca, codcart);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbBandeira.Text == string.Empty && cmbCart.Text == string.Empty)
            {
                gvExibir.DataSource = rlxDAO.ListarTudo();

                rlxDAO.VerificaSC();
                cred = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblCred.Text = cred.ToString("C2");


                rlxDAO.VerificaSD();
                deb = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblDeb.Text = deb.ToString("C2");


                rlxDAO.VerificaSDX();
                sd = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblSod.Text = sd.ToString("C2");


                rlxDAO.VerificaSVR();
                vr = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblV.Text = vr.ToString("C2");


                rlxDAO.VerificaT();
                tk = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblTic.Text = tk.ToString("C2");

                rlxDAO.VerificaSe();
                el = Convert.ToDouble(rlxDAO.Rlx.Valor_ct.ToString().Replace(".", ""));
                lblAle.Text = el.ToString("C2");



                lblTotal.Text = (cred + deb + sd + vr + tk + el).ToString("C2");

            }
            #endregion





        }
        public void Limpar()
        {
            lblAle.Text = "";
            lblCred.Text = "";
            lblDeb.Text = "";
            lblSod.Text = "";
            lblTic.Text = "";
            lblV.Text = "";           
        }
    }
}
