using System;
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
    public partial class frmEs : Form
    {
        credDebDAO cdDAO = new credDebDAO();

        DateTime de, at;
        DateTime data;
#pragma warning disable CS0169 // O campo "frmEs.cred" nunca é usado
        string cred;
#pragma warning restore CS0169 // O campo "frmEs.cred" nunca é usado

        int j;
        public frmEs()
        {
            InitializeComponent();
        }

        private void mskDe_TextChanged(object sender, EventArgs e)
        {
            if (mskDe.MaskFull == true && mskAté.MaskFull==true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("A data inserida é inválida !!!");
                    mskDe.Clear();
                    string datatela = DateTime.Now.ToShortDateString();
                    mskDe.Text = datatela;
                }
              
                gvExibir.DataSource = cdDAO.ListarB(de, at);
            }
            else
            {
                if(mskDe.MaskFull==false || mskAté.MaskFull == false)
                {
                    gvExibir.DataSource = cdDAO.ListarTudo();
                }
            }          
        }

        public void ExportarPDF(DataGridView dgw,string filename)
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
                foreach(DataGridViewCell cell in row.Cells)
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
                using (FileStream stream=new FileStream(savefiledialoge.FileName,FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4,10f,10f,10f,0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }

            }
        }

        private void mskAté_TextChanged(object sender, EventArgs e)
        {
            if (mskDe.MaskFull == true && mskAté.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("A data inserida é inválida !!!");
                    mskAté.Clear();
                    string datatela = DateTime.Now.ToShortDateString();
                    mskAté.Text = datatela;

                }
              
                gvExibir.DataSource = cdDAO.ListarB(de, at);
            }
            else
            {
                if (mskDe.MaskFull == false || mskAté.MaskFull == false)
                {
                    gvExibir.DataSource = cdDAO.ListarTudo();
                }
            }
    
        }

        private void frmEs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }


        }

    

        private void frmEs_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                foreach (DataGridViewColumn c in gvExibir.Columns)
                {
#pragma warning disable CS0104 // "Font" é uma referência ambígua entre "System.Drawing.Font" e "iTextSharp.text.Font"
                    c.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, GraphicsUnit.Pixel);
#pragma warning restore CS0104 // "Font" é uma referência ambígua entre "System.Drawing.Font" e "iTextSharp.text.Font"
                }
            }
        }

     

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            Microsoft.Office.Interop.Excel._Application app =new Microsoft.Office.Interop.Excel.Application();
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

            for(int i = 1; i < gvExibir.Columns.Count+1; i++)
            {
                worksheet.Cells[1,i] = gvExibir.Columns[i - 1].HeaderText;
                worksheet.StandardWidth =17;

   
                

            }

            for (int i = 0; i < gvExibir.Rows.Count; i++)
            {
                for (j = 0; j < gvExibir.Columns.Count; j++)
                {
                    if (j == 0)
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
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("D2", "F300");
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
                        string temp = "R$ "+range.Value.ToString();
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
            saveFileDialoge.FileName ="Planilha";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir,"planilha");
        }

        private void gvExibir_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        



            if (e.Value != null && e.Value.Equals("Retirada de dinheiro")|| e.Value != null && e.Value.Equals("Fechamento PDV"))
            {
                if (e.RowIndex == 0)
                {
                    try
                    {
                        gvExibir.CurrentRow.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    catch
                    {

                    }

                }
                else 
                {
                    gvExibir.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                }



                
            }
            


            if (e.Value != null && e.Value.Equals("Entrada de moeda") || e.Value != null && e.Value.Equals("Sangria de moeda")|| e.Value != null && e.Value.Equals("Troca de Moeda")|| e.Value != null && e.Value.Equals("Devolução moeda")|| e.Value != null && e.Value.Equals("Devolução")|| e.Value != null && e.Value.Equals("Entrada moeda PDV")|| e.Value != null && e.Value.Equals("Saída p/ caixa moeda") || e.Value != null && e.Value.Equals("Entrada caixa moeda"))
            {

                if (e.RowIndex == 0)
                {
                    try
                    {
                        
                        gvExibir.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    catch
                    {

                    }
                   
                }
                else
                {

                    
                    gvExibir.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }


                
            }


            if (e.Value != null && e.Value.Equals("Entrada sangria PDV"))
            {



                if (e.RowIndex == 0)
                {
                    try
                    {

                        gvExibir.CurrentRow.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                    catch
                    {

                    }

                }
                else
                {


                    gvExibir.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                }



            }











        }

 

        private void frmEs_Load(object sender, EventArgs e)
        {
           
            gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            string datatela = DateTime.Now.ToShortDateString();
            mskDe.Text = datatela;
            mskAté.Text = datatela;
           
            if (mskDe.MaskFull == true && mskAté.MaskFull == true)
            {
                de = Convert.ToDateTime(mskDe.Text);
                at = Convert.ToDateTime(mskAté.Text);
           
                    gvExibir.DataSource = cdDAO.ListarB(de, at);

                this.gvExibir.Columns["CRED"].DefaultCellStyle
    .Alignment = DataGridViewContentAlignment.MiddleRight;


                this.gvExibir.Columns["DEB"].DefaultCellStyle
.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.gvExibir.Columns["TOTAL"].DefaultCellStyle
.Alignment = DataGridViewContentAlignment.MiddleRight;


               
            }
            else
            {
                if (mskDe.MaskFull == false || mskAté.MaskFull == false)
                {
                   
                        gvExibir.DataSource = cdDAO.ListarTudo();

                    this.gvExibir.Columns["CRED"].DefaultCellStyle
.Alignment = DataGridViewContentAlignment.MiddleRight;
                 
                    this.gvExibir.Columns["DEB"].DefaultCellStyle
.Alignment = DataGridViewContentAlignment.MiddleRight;

                    this.gvExibir.Columns["TOTAL"].DefaultCellStyle
.Alignment = DataGridViewContentAlignment.MiddleRight;



                }
            }
        }
    }
}
