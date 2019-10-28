using System;
using System.Windows.Forms;
using Caixa.Classes;
using Caixa.ClassesDAO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;

namespace Caixa.Forms
{
    public partial class frmRelatConsumo : Form
    {
        RelatConsumo rlc = new RelatConsumo();
        relatconsumoDAO rlcDAO = new relatconsumoDAO();

        DateTime de;
        DateTime at;
        string nome;
        DateTime data;
        int j;
        public frmRelatConsumo()
        {
            InitializeComponent();
        }

        private void FrmRelatConsumo_Load(object sender, EventArgs e)
        {
            try
            {
                #region DATA INCIAL
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

                #region DATA FINAL
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

                mskAté.Text = DateTime.Now.ToShortDateString();
                mskDe.Text = DateTime.Now.ToShortDateString();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "VALOR")
                        column.Width = 50; //tamanho fixo da coluna VALOR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "NOME")
                        column.Width = 130; //tamanho fixo da coluna DESCRICAO


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

                    if (cell.ColumnIndex == 3)
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

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            #region DATA INCIAL
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

            #region DATA FINAL
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

            #region SOMENTE NOME PREENCHIDO
            if (txtNome.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarNome(nome);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E NOME
            if (txtNome.Text != string.Empty && mskDe.MaskFull == true)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarDeNome(nome, de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskDe.MaskFull == true && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarDe(de);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTN(de, at);
            }
            #endregion

            #region TODOS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text != string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTNNOME(nome, de, at);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarTudo();
            }
            #endregion

            #region GridView da soma do mês
            if (txtNome.Text != string.Empty)
            {
                gvMostrarTotal.DataSource = rlcDAO.ListarMes(nome);
            }
            else
            {
                gvMostrarTotal.DataSource = null;
            }
            #endregion
        }

        private void MskAté_TextChanged(object sender, EventArgs e)
        {
            #region DATA INCIAL
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

            #region DATA FINAL
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

            #region SOMENTE NOME PREENCHIDO
            if (txtNome.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarNome(nome);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E NOME
            if (txtNome.Text != string.Empty && mskDe.MaskFull == true)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarDeNome(nome, de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskDe.MaskFull == true && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarDe(de);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTN(de, at);
            }
            #endregion

            #region TODOS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text != string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTNNOME(nome, de, at);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarTudo();
            }
            #endregion
        }

        private void MskDe_TextChanged(object sender, EventArgs e)
        {
            #region DATA INCIAL
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

            #region DATA FINAL
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

            #region SOMENTE NOME PREENCHIDO
            if (txtNome.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarNome(nome);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E NOME
            if (txtNome.Text != string.Empty && mskDe.MaskFull == true)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarDeNome(nome, de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskDe.MaskFull == true && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarDe(de);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTN(de, at);
            }
            #endregion

            #region TODOS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text != string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTNNOME(nome, de, at);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarTudo();
            }
            #endregion
        }

        private void FrmRelatConsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "CONSUMO");
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
                worksheet.StandardWidth = 17;
            }

            for (int i = 0; i < gvExibir.Rows.Count; i++)
            {
                for (j = 0; j < gvExibir.Columns.Count; j++)
                {
                    if (j == 3)
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
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("C2", "C300");
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

        private void prnFormConsumo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        Bitmap bmp;

        private void btnImprimirForm_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
    }
}
