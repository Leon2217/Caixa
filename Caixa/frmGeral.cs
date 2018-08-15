using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        #endregion

        #region VAR
        DateTime de, at;
        string desc;
        double cred, deb;
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
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            try
            {
                gvExibir.DataSource = gerDAO.ListarTudo();
                try
                {
                    #region SOMA TUDO
                    gerDAO.VerificaSoma();
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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

        private void cmbDescricao_TextChanged(object sender, EventArgs e)
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);

                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
                    lblDeb.Text = deb.ToString("C2");
                    lblCred.Text = cred.ToString("C2");
                    lblTotal.Text = (cred - deb).ToString("C2");
                }
                catch
                {

                }

                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at,desc);
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();
                #region SOMA TUDO
                gerDAO.VerificaSoma();
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
        }

        private void cmbDescricao_SelectedIndexChanged(object sender, EventArgs e)
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);

                #region SOMA B
                gerDAO.VerificaSB(de, at);
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();
                #region SOMA TUDO
                gerDAO.VerificaSoma();
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
        }

        private void mskDe_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        public void ExportarPDF(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(new float[] { 1, 2, 1, 1, 1});
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de, desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);

                #region SOMA B
                gerDAO.VerificaSB(de, at);
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
                #endregion
            }
            #endregion

            #region BETWEEN E DESC
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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

            #region DE
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                this.ProcessTabKey(true);
                gvExibir.DataSource = gerDAO.ListarDE(de);

                #region SOMA DE
                gerDAO.VerificaSD(de);
                try
                {
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDS(desc);

                #region SOMA DESC
                gerDAO.VerificaSDC(desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == false && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarDD(desc, de);

                #region SOMA DESC DE
                gerDAO.VerificaSDD(de,desc);
                try
                {
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarB(de, at);
                #region SOMA B
                try
                {
                    gerDAO.VerificaSB(de, at);
                    cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbDescricao.Text != string.Empty)
            {
                desc = cmbDescricao.Text.ToString();
                gvExibir.DataSource = gerDAO.ListarBD(de, at, desc);

                #region SOMA B E DESC
                try
                {
                    gerDAO.VerificaSBD(de, at, desc);
                    try
                    {
                        cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                    }
                    catch
                    {

                    }
                    try
                    {
                        deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && cmbDescricao.Text == string.Empty)
            {
                gvExibir.DataSource = gerDAO.ListarTudo();

                #region SOMA TUDO
                gerDAO.VerificaSoma();
                cred = Convert.ToDouble(gerDAO.Ger.Cred_g.ToString().Replace(".", ""));
                deb = Convert.ToDouble(gerDAO.Ger.Deb_g.ToString().Replace(".", ""));
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




        }
    }
}
