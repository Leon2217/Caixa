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
    public partial class relatSangria : Form
    {
        #region VAR
        DateTime de, at, data; 
        int j;
        #endregion

        Sangria san = new Sangria();
        SangriaDAO sanDAO = new SangriaDAO();
        public relatSangria()
        {
            InitializeComponent();
        }

        private void relatSangria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
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

            #region SOMENTE TURNO MANHA
            if (cmbTurno.Text == "Manhã" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManha();
            }
            #endregion

            #region SOMENTE TURNO TARDE
            if (cmbTurno.Text == "Tarde" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTarde();
            }
            #endregion           

            #region LISTAR SANGRIA DE
            if (mskDe.MaskFull == true && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaDe(de);
            }
            #endregion

            #region LISTAR SANGRIA TARDE DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Tarde" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeDe(de);
            }
            #endregion

            #region LISTAR SANGRIA MANHÃ DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Manhã" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaDe(de);
            }
            #endregion

            #region BTN 
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == string.Empty)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaBtn(de, at);
            }
            #endregion

            #region BTN MANHA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Manhã")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaBtn(de, at);
            }
            #endregion

            #region BTN TARDE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Tarde")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeBtn(de, at);
            }
            #endregion

            #region TODOS VAZIO
            if (mskDe.MaskFull == false && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarTudoSangria();
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
          
            #region SOMENTE TURNO TARDE
            if (cmbTurno.Text == "Tarde" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTarde();
            }
            #endregion

            #region SOMENTE TURNO MANHÃ
            if (cmbTurno.Text == "Manhã" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManha();
            }
            #endregion

            #region LISTAR SANGRIA DE
            if (mskDe.MaskFull == true && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaDe(de);
            }
            #endregion

            #region LISTAR SANGRIA TARDE DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Tarde" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeDe(de);
            }
            #endregion

            #region LISTAR SANGRIA MANHÃ DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Manhã" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaDe(de);
            }
            #endregion

            #region BTN 
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == string.Empty)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaBtn(de, at);
            }
            #endregion

            #region BTN MANHA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Manhã")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaBtn(de, at);
            }
            #endregion

            #region BTN TARDE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Tarde")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeBtn(de, at);
            }
            #endregion

            #region TODOS VAZIO
            if (mskDe.MaskFull == false && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarTudoSangria();
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

            #region SOMENTE TURNO MANHA
            if (cmbTurno.Text == "Manhã" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManha();
            }
            #endregion

            #region SOMENTE TURNO TARDE
            if (cmbTurno.Text == "Tarde" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTarde();
            }
            #endregion

            #region LISTAR SANGRIA DE
            if (mskDe.MaskFull == true && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaDe(de);
            }
            #endregion

            #region LISTAR SANGRIA TARDE DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Tarde" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeDe(de);
            }
            #endregion

            #region LISTAR SANGRIA MANHÃ DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Manhã" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaDe(de);
            }
            #endregion

            #region BTN 
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == string.Empty)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaBtn(de, at);
            }
            #endregion

            #region BTN MANHA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Manhã")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaBtn(de, at);
            }
            #endregion

            #region BTN TARDE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Tarde")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeBtn(de, at);
            }
            #endregion

            #region TODOS VAZIO
            if (mskDe.MaskFull == false && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarTudoSangria();
            }
            #endregion
        }

        private void cmbTurno_TextChanged(object sender, EventArgs e)
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

            #region SOMENTE TURNO MANHA
            if (cmbTurno.Text == "Manhã" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManha();
            }
            #endregion

            #region SOMENTE TURNO TARDE
            if (cmbTurno.Text == "Tarde" && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTarde();
            }
            #endregion

            #region LISTAR SANGRIA DE
            if (mskDe.MaskFull == true && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaDe(de);
            }
            #endregion

            #region LISTAR SANGRIA TARDE DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Tarde" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeDe(de);
            }
            #endregion

            #region LISTAR SANGRIA MANHÃ DE
            if (mskDe.MaskFull == true && cmbTurno.Text == "Manhã" && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaDe(de);
            }
            #endregion

            #region BTN 
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == string.Empty)
            {
                gvExibir.DataSource = sanDAO.ListarSangriaBtn(de, at);
            }
            #endregion

            #region BTN MANHA
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Manhã")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaManhaBtn(de, at);
            }
            #endregion

            #region BTN TARDE
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && cmbTurno.Text == "Tarde")
            {
                gvExibir.DataSource = sanDAO.ListarSangriaTardeBtn(de, at);
            }
            #endregion

            #region TODOS VAZIO
            if (mskDe.MaskFull == false && cmbTurno.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = sanDAO.ListarTudoSangria();
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
            #endregion
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
                        data = Convert.ToDateTime(gvExibir.Rows[i].Cells[j].Value);


                        worksheet.Cells[i + 2, j + 1] = data.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = gvExibir.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            Microsoft.Office.Interop.Excel.Range rng = worksheet.get_Range("A2", "C300");

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

        private void relatSangria_Load(object sender, EventArgs e)
        {
            #region DATAS
            string datatela = DateTime.Now.ToShortDateString();
            mskAté.Text = datatela;
            mskDe.Text = datatela;
            #endregion            
        }
    }
}
