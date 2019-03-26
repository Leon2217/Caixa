using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmRelatVendavc : Form
    {
        VendaVCDAO vcDAO = new VendaVCDAO();
        VendaVC vc = new VendaVC();
        DateTime data;
        DateTime dt;
        double total;
        int j;
        public frmRelatVendavc()
        {
            InitializeComponent();
        }

        private void frmRelatVendavc_Load(object sender, EventArgs e)
        {
            try
            {
                gvExibir.DataSource = vcDAO.ListarTudo();

                this.gvExibir.Columns["VALOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.gvExibir.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                string datatela = DateTime.Now.ToShortDateString();
                mskData.Text = datatela;
            }
            catch
            {
            }
        }

        public void ExportarPDF(DataGridView dgw, string filename)
        {
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
                    if (cell.ColumnIndex == 6)
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

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            if (mskData.MaskFull == false)
            {
                gvExibir.DataSource = vcDAO.ListarTudo();

                try
                {
                    vcDAO.VerificaTotalLabelTudo();
                    total = Convert.ToDouble(vcDAO.Vvc.Total_vc.ToString().Replace(".", ""));
                    lblTotalV.Text = total.ToString("C2");
                }
                catch
                {

                }
            }
            else
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

                gvExibir.DataSource = vcDAO.ListarData(data);
                try
                {
                    vcDAO.VerificaTotalLabel(data);
                    total = Convert.ToDouble(vcDAO.Vvc.Total_vc.ToString().Replace(".", ""));
                    lblTotalV.Text = total.ToString("C2");
                }
                catch
                {

                }
             
            }          
        }

        private void frmRelatVendavc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "planilha");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
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
            }

            for (int i = 0; i < gvExibir.Rows.Count; i++)
            {
                for ( j = 0; j < gvExibir.Columns.Count; j++)
                {
                    if (j == 6)
                    {
                        data = Convert.ToDateTime(gvExibir.Rows[i].Cells[j].Value);

                        worksheet.Cells[i + 2, j + 1] = data.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = gvExibir.Rows[i].Cells[j].Value.ToString();
                    }
                }

            }

            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("C2", "D300");
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
                        //the percent values were decimals with commas in the string       
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
        }
    }
}
