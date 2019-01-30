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
    public partial class frmPesquisaRecarga : Form
    {
        RecargaDAO recDAO = new RecargaDAO();
        DateTime de;
        DateTime at;
        int j;
        DateTime data;

        string operadora;
        public frmPesquisaRecarga()
        {
            InitializeComponent();
        }

        private void frmPesquisaRecarga_Load(object sender, EventArgs e)
        {
            try
            {
                //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;



                string datatela = DateTime.Now.ToShortDateString();
                mskAt.Text = datatela;
                mskData.Text = datatela;
                if (mskData.MaskFull == true && mskAt.MaskFull == true)
                {
                    try
                    {
                        de = Convert.ToDateTime(mskData.Text);
                        at = Convert.ToDateTime(mskAt.Text);

                        gvExibir.DataSource = recDAO.ListarB(de, at);

                        #region AJUSTE GRID
                        foreach (DataGridViewColumn column in gvExibir.Columns)
                        {
                            if (column.DataPropertyName == "VALOR")
                                column.Width = 70; //tamanho fixo da coluna VALOR
                            else if (column.DataPropertyName == "HORA")
                                column.Width = 60; //tamanho fixo da coluna HORA
                            else if (column.DataPropertyName == "DATA")
                                column.Width = 70; //tamanho fixo da coluna DATA

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




                    this.gvExibir.Columns["valor_rec"].DefaultCellStyle
        .Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                else
                {
                    if (mskData.MaskFull == false || mskAt.MaskFull == false)
                    {
                        try
                        {
                            gvExibir.DataSource = recDAO.Listartudo();
                        }
                        catch
                        {

                        }



                        this.gvExibir.Columns["valor_rec"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;

                    }
                }
            }
            catch
            {
    
            }
            
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

                    if (cell.ColumnIndex == 5)
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
            #endregion
        }

        private void txtOperadora_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "VALOR")
                    column.Width = 70; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "DATA")
                    column.Width = 70; //tamanho fixo da coluna DATA

                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

            #region DATA INCIAL
            if (mskData.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskData.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskData.Clear();
                }

            }
            #endregion

            #region DATA FINAL
            if (mskAt.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAt.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAt.Clear();
                }

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E OPERADORA
            if (txtOperadora.Text!=string.Empty && mskData.MaskFull==true)
            {
                operadora = txtOperadora.Text;
                gvExibir.DataSource = recDAO.Listarfiltro(de, operadora);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskData.MaskFull==true && txtOperadora.Text == string.Empty && mskAt.MaskFull==false)
            {
                    gvExibir.DataSource = recDAO.ListarData(de);
            }
            #endregion

            #region SOMENTE OPERADORA PREECHIDA
            if (txtOperadora.Text!=string.Empty && mskData.MaskFull == false && mskAt.MaskFull==false)
            {
                    operadora = txtOperadora.Text;
                    gvExibir.DataSource = recDAO.ListarOperadora(operadora);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskData.MaskFull == false && txtOperadora.Text == string.Empty && mskAt.MaskFull==false)
            {
                gvExibir.DataSource = recDAO.Listartudo();
            }
            #endregion

            if (mskData.MaskFull == true && mskAt.MaskFull == true && txtOperadora.Text==string.Empty)
            {
                de = Convert.ToDateTime(mskData.Text);
                at = Convert.ToDateTime(mskAt.Text);

                gvExibir.DataSource = recDAO.ListarB(de, at);
            }

            if (mskData.MaskFull == true && mskAt.MaskFull == true && txtOperadora.Text != string.Empty)
            {
                operadora = txtOperadora.Text;
                de = Convert.ToDateTime(mskData.Text);
                at = Convert.ToDateTime(mskAt.Text);

                gvExibir.DataSource = recDAO.ListarBO(de, at, operadora);
            }

        }

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "VALOR")
                    column.Width = 70; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "DATA")
                    column.Width = 70; //tamanho fixo da coluna DATA

                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

            #region DATA INCIAL
            if (mskData.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskData.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskData.Clear();
                }
         
            }
            #endregion

            #region DATA FINAL
            if (mskAt.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAt.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAt.Clear();
                }
     
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E OPERADORA
            if (txtOperadora.Text != string.Empty && mskData.MaskFull == true)
            {
                operadora = txtOperadora.Text;
                gvExibir.DataSource = recDAO.Listarfiltro(de, operadora);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskData.MaskFull == true && txtOperadora.Text == string.Empty)
            {
                gvExibir.DataSource = recDAO.ListarData(de);
            }
            #endregion

            #region SOMENTE OPERADORA PREENCHIDA
            if (txtOperadora.Text != string.Empty && mskData.MaskFull == false)
            {
                    operadora = txtOperadora.Text;
                    gvExibir.DataSource = recDAO.ListarOperadora(operadora);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskData.MaskFull == false && txtOperadora.Text == string.Empty)
            {
                gvExibir.DataSource = recDAO.Listartudo();
            }
            #endregion

            if (mskData.MaskFull == true && mskAt.MaskFull == true && txtOperadora.Text==string.Empty)
            {
                de = Convert.ToDateTime(mskData.Text);
                at = Convert.ToDateTime(mskAt.Text);

                gvExibir.DataSource = recDAO.ListarB(de, at);
            }

            if (mskData.MaskFull == true && mskAt.MaskFull == true && txtOperadora.Text != string.Empty)
            {
                operadora = txtOperadora.Text;
                de = Convert.ToDateTime(mskData.Text);
                at = Convert.ToDateTime(mskAt.Text);

                gvExibir.DataSource = recDAO.ListarBO(de, at, operadora);
            }
        }

        private void frmPesquisaRecarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
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

        private void txtOperadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void mskAt_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "VALOR")
                    column.Width = 70; //tamanho fixo da coluna VALOR
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "DATA")
                    column.Width = 70; //tamanho fixo da coluna DATA

                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

            #region DATA INCIAL
            if (mskData.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskData.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskData.Clear();
                }

            }
            #endregion

            #region DATA FINAL
            if (mskAt.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAt.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAt.Clear();
                }

            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E OPERADORA
            if (txtOperadora.Text != string.Empty && mskData.MaskFull == true)
            {
                operadora = txtOperadora.Text;
                gvExibir.DataSource = recDAO.Listarfiltro(de, operadora);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA
            if (mskData.MaskFull == true && txtOperadora.Text == string.Empty)
            {
                gvExibir.DataSource = recDAO.ListarData(de);
            }
            #endregion

            #region SOMENTE OPERADORA PREENCHIDA
            if (txtOperadora.Text != string.Empty && mskData.MaskFull == false)
            {
                operadora = txtOperadora.Text;
                gvExibir.DataSource = recDAO.ListarOperadora(operadora);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskData.MaskFull == false && txtOperadora.Text == string.Empty)
            {
                gvExibir.DataSource = recDAO.Listartudo();
            }
            #endregion

            if (mskData.MaskFull == true && mskAt.MaskFull == true && txtOperadora.Text==string.Empty)
            {
                de = Convert.ToDateTime(mskData.Text);
                at = Convert.ToDateTime(mskAt.Text);

                gvExibir.DataSource = recDAO.ListarB(de, at);
            }

            if (mskData.MaskFull == true && mskAt.MaskFull == true && txtOperadora.Text != string.Empty)
            {
                operadora = txtOperadora.Text;
                de = Convert.ToDateTime(mskData.Text);
                at = Convert.ToDateTime(mskAt.Text);

                gvExibir.DataSource = recDAO.ListarBO(de, at,operadora);
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
                    if (j == 5)
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
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("B2:C300");

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
    }
}
