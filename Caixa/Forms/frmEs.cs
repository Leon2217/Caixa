using System;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmEs : Form
    {
        credDebDAO cdDAO = new credDebDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        DateTime de, at;
        DateTime data;

        string descr;
        string credito;
        string debito;
        int j;
        public frmEs()
        {
            InitializeComponent();
        }

        private void mskDe_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "DESCR")
                    column.Width = 330; //tamanho fixo da coluna DESCR
                else if (column.DataPropertyName == "DATA")
                    column.Width = 80; //tamanho fixo da coluna DATA
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "CRED")
                    column.Width = 100; //tamanho fixo da coluna CRED
                else if (column.DataPropertyName == "DEB")
                    column.Width = 100; //tamanho fixo da coluna DEB
                else if (column.DataPropertyName == "C")
                    column.Visible = false;
                else if (column.DataPropertyName == "ID")
                    column.Visible = false;

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

            #region DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarD(de);
            }
            #endregion

            #region BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarB(de, at);
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDesc(descr);


            }
            #endregion

            #region DESC DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDD(de, descr);


            }
            #endregion

            #region DESC BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESC(de, at, descr);


            }
            #endregion

            #region TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarTudo();
            }
            #endregion

            #region VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarValor(credito, debito);
            }
            #endregion

            #region DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarDV(de,credito, debito);
            }
            #endregion

            #region BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarBVALOR(de, at, credito, debito);
            }
            #endregion

            #region DESC VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDescValor(descr, credito, debito);
            }
            #endregion

            #region DESC DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                descr = txtDesc.Text.ToString();
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                gvExibir.DataSource = cdDAO.ListarDDV(de, descr, credito, debito);                   
            }
            #endregion

            #region DESC BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESCVALOR(de, at, descr, credito, debito);


            }
            #endregion
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
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "DESCR")
                    column.Width = 330; //tamanho fixo da coluna DESCR
                else if (column.DataPropertyName == "DATA")
                    column.Width = 80; //tamanho fixo da coluna DATA
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "CRED")
                    column.Width = 100; //tamanho fixo da coluna CRED
                else if (column.DataPropertyName == "DEB")
                    column.Width = 100; //tamanho fixo da coluna DEB
                else if (column.DataPropertyName == "C")
                    column.Visible = false;
                else if (column.DataPropertyName == "ID")
                    column.Visible = false;

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

            #region DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarD(de);
            }
            #endregion

            #region BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarB(de, at);
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDesc(descr);


            }
            #endregion

            #region DESC DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDD(de, descr);


            }
            #endregion

            #region DESC BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESC(de, at, descr);


            }
            #endregion

            #region TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarTudo();
            }
            #endregion

            #region VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarValor(credito, debito);
            }
            #endregion

            #region DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarDV(de, credito, debito);
            }
            #endregion

            #region BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarBVALOR(de, at, credito, debito);
            }
            #endregion

            #region DESC VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDescValor(descr, credito, debito);
            }
            #endregion

            #region DESC DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                descr = txtDesc.Text.ToString();
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                gvExibir.DataSource = cdDAO.ListarDDV(de, descr, credito, debito);
            }
            #endregion

            #region DESC BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESCVALOR(de, at, descr, credito, debito);


            }
            #endregion

        }

        private void frmEs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
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
                worksheet.StandardWidth = 17;
            }

            for (int i = 0; i < gvExibir.Rows.Count; i++)
            {
                for (j = 0; j < gvExibir.Columns.Count; j++)
                {
                    if (j == 1)
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
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("E2", "G300");
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
            foreach (DataGridViewRow row in gvExibir.Rows)
            {
                if (Convert.ToString(row.Cells[8].Value) == "C")
                    row.Cells["DEB"].Style.ForeColor = Color.Red;
                if (Convert.ToString(row.Cells[2].Value) == "Fechamento PDV")
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                if (Convert.ToString(row.Cells[2].Value) == "Saída p/ caixa moeda")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                if (Convert.ToString(row.Cells[2].Value) == "Entrada moeda PDV")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                if (Convert.ToString(row.Cells[2].Value) == "Entrada caixa moeda")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                if (Convert.ToString(row.Cells[2].Value) == "Entrada sangria PDV")
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "DESCR")
                    column.Width = 330; //tamanho fixo da coluna DESCR
                else if (column.DataPropertyName == "DATA")
                    column.Width = 80; //tamanho fixo da coluna DATA
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "CRED")
                    column.Width = 100; //tamanho fixo da coluna CRED
                else if (column.DataPropertyName == "DEB")
                    column.Width = 100; //tamanho fixo da coluna DEB
                else if (column.DataPropertyName == "C")
                    column.Visible = false;
                else if (column.DataPropertyName == "ID")
                    column.Visible = false;

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

            #region DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarD(de);
            }
            #endregion

            #region BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarB(de, at);
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDesc(descr);
            }
            #endregion

            #region DESC DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDD(de, descr);


            }
            #endregion

            #region DESC BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESC(de, at, descr);


            }
            #endregion

            #region TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarTudo();
            }
            #endregion

            #region VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarValor(credito, debito);
            }
            #endregion

            #region DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarDV(de, credito, debito);
            }
            #endregion

            #region BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarBVALOR(de, at, credito, debito);
            }
            #endregion

            #region DESC VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDescValor(descr, credito, debito);
            }
            #endregion

            #region DESC DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                descr = txtDesc.Text.ToString();
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                gvExibir.DataSource = cdDAO.ListarDDV(de, descr, credito, debito);
            }
            #endregion

            #region DESC BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESCVALOR(de, at, descr, credito, debito);


            }
            #endregion
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "DESCR")
                    column.Width = 330; //tamanho fixo da coluna DESCR
                else if (column.DataPropertyName == "DATA")
                    column.Width = 80; //tamanho fixo da coluna DATA
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "CRED")
                    column.Width = 100; //tamanho fixo da coluna CRED
                else if (column.DataPropertyName == "DEB")
                    column.Width = 100; //tamanho fixo da coluna DEB
                else if (column.DataPropertyName == "C")
                    column.Visible = false;
                else if (column.DataPropertyName == "ID")
                    column.Visible = false;

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

            #region DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarD(de);
            }
            #endregion

            #region BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarB(de, at);
            }
            #endregion

            #region DESC
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDesc(descr);


            }
            #endregion

            #region DESC DE
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDD(de, descr);


            }
            #endregion

            #region DESC BTN
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text == string.Empty)
            {
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESC(de, at, descr);


            }
            #endregion

            #region TUDO
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text == string.Empty)
            {
                gvExibir.DataSource = cdDAO.ListarTudo();
            }
            #endregion

            #region VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarValor(credito, debito);
            }
            #endregion

            #region DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarDV(de, credito, debito);
            }
            #endregion

            #region BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text == string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                gvExibir.DataSource = cdDAO.ListarBVALOR(de, at, credito, debito);
            }
            #endregion

            #region DESC VALOR
            if (mskDe.MaskFull == false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarDescValor(descr, credito, debito);
            }
            #endregion

            #region DESC DE VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull == false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                descr = txtDesc.Text.ToString();
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");
                gvExibir.DataSource = cdDAO.ListarDDV(de, descr, credito, debito);
            }
            #endregion

            #region DESC BTN VALOR
            if (mskDe.MaskFull != false && mskAté.MaskFull != false && txtDesc.Text != string.Empty && txtValor.Text != string.Empty)
            {
                credito = txtValor.Text.ToString().Replace(".", "");
                debito = txtValor.Text.ToString().Replace(".", "");

                descr = txtDesc.Text.ToString();
                gvExibir.DataSource = cdDAO.ListarBDESCVALOR(de, at, descr, credito, debito);


            }
            #endregion
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

        private void btImprimir_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(gvExibir);
        }

        private void btnConferido_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            cdDAO.UpdateConferido(id);

            try
            {
                gvExibir.SelectedRows[0].Cells["DEB"].Style.ForeColor = Color.Red;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Não há linha selecionada");
            }                                
        }     

        private void gvExibir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = gvExibir.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            cdDAO.UpdateConferido2(id);

            try
            {
                gvExibir.SelectedRows[0].Cells["DEB"].Style.ForeColor = Color.Black;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Não há linha selecionada");
            }             
        }

        private void frmEs_Load(object sender, EventArgs e)
        {
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            string login = UsuarioDAO.login;
            usuDAO.VerificaCargo(login);
            if (usuDAO.Usu.Tipo == "Administrador")
            {
                btnConferido.Visible = true;
                btnVoltar.Visible = true;
            }
            else
            {
                btnConferido.Visible = false;
                btnVoltar.Visible = false;
            }

            string datatela = DateTime.Now.ToShortDateString();
            mskAté.Text = datatela;
            mskDe.Text = datatela;
            
            if (mskDe.MaskFull == true && mskAté.MaskFull == true)
            {
                de = Convert.ToDateTime(mskDe.Text);
                at = Convert.ToDateTime(mskAté.Text);
           
                gvExibir.DataSource = cdDAO.ListarB(de, at);

                this.gvExibir.Columns["CRED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.gvExibir.Columns["DEB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.gvExibir.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                if (mskDe.MaskFull == false || mskAté.MaskFull == false)
                {                  
                    gvExibir.DataSource = cdDAO.ListarTudo();

                    this.gvExibir.Columns["CRED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.gvExibir.Columns["DEB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.gvExibir.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "DESCR")
                    column.Width = 330; //tamanho fixo da coluna DESCR                
                else if (column.DataPropertyName == "DATA")
                    column.Width = 80; //tamanho fixo da coluna DATA
                else if (column.DataPropertyName == "HORA")
                    column.Width = 60; //tamanho fixo da coluna HORA
                else if (column.DataPropertyName == "CRED")
                    column.Width = 100; //tamanho fixo da coluna CRED
                else if (column.DataPropertyName == "DEB")
                    column.Width = 100; //tamanho fixo da coluna DEB
                else if (column.DataPropertyName == "C")
                    column.Visible = false;
                else if (column.DataPropertyName == "ID")
                    column.Visible = false;
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion
        }
    }
}
