using System;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Caixa
{
    public partial class frmFiado : Form
    {
        fiado ass = new fiado();
        fiadoDAO assDAO = new fiadoDAO();
        CredDeb cd = new CredDeb();
        credDebDAO cdDAO = new credDebDAO();
        UsuarioDAO usuDAO = new UsuarioDAO();
        PessoaDAO pesDAO = new PessoaDAO();
        Geral ger = new Geral();
        GeralDAO gerDAO = new GeralDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Valorcaixa vc = new Valorcaixa();
        ValorcaixaDAO vcDAO = new ValorcaixaDAO();
        Relatfiado rlf = new Relatfiado();
        relatfiadoDAO rlfDAO = new relatfiadoDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string nome;
        string codcaixa;
        string tipo;
        string login;
        string codpes;
        string id;
        Boolean update;
        DateTime de;       
        int j;

        public frmFiado()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza dessas informações?",
                "Salvando!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                try
                {
                    if (update == true)
                    {

                        if (tipo == "Administrador")
                        {                         
                            assDAO.Alterar(ass);
                            MessageBox.Show("Dados alterados com sucesso !!!");
                           
                            ((frmOpcaoFecha)this.Owner).AtualizaDados();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Você não possui privilégios o suficiente para alterar !!!");
                        }
                    }
                    else
                    {                      
                        assDAO.Inserir(ass);
                        MessageBox.Show("Informações salvas com sucesso !!!");
                       
                        ((frmOpcaoFecha)this.Owner).AtualizaDados();
                        this.Close();
                    }                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }        
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public void CarregarComboNome()
        {
            cmbCliente.DataSource = pesDAO.ListarClientes();
            cmbCliente.DisplayMember = "NOME";
            cmbCliente.ValueMember = "ID";            
        }

        public void CarregarComboID()
        {
            cmbCliente.DataSource = pesDAO.ListarIDC(id);
            cmbCliente.DisplayMember = "NOME";
            cmbCliente.ValueMember = "ID";
            try
            {
                codpes = cmbCliente.SelectedValue.ToString();
            }
            catch
            {
            }         
        }

        private void frmAssinadas_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarComboNome();
                cmbCliente.SelectedIndex = -1;
            }
            catch
            {
            }
          
            string datatela = DateTime.Now.ToShortDateString();
            gvExibir.DataSource = assDAO.ListarTudo();

            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 40; //tamanho fixo da coluna ID
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 75; //tamanho fixo da coluna VALOR
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion

            Moeda(ref txtValor);
            Moeda(ref txtValorPago);
            codcaixa = assinadaDAO.codcaixa;
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

        private void frmAssinadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                   this.Close();
            }
        }

        private void cmbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
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

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtIdAtualizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtValor_TextChanged_1(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCliente.BackColor = Color.Empty;
            try
            {
                codpes = cmbCliente.SelectedValue.ToString();
                nome = cmbCliente.Text;
            }
            catch
            {
            }

            if (cmbCliente.Text != string.Empty)
            {
                gvExibir.DataSource = assDAO.ListarNome(nome);
            }

            if (cmbCliente.Text == string.Empty)
            {
                gvExibir.DataSource = assDAO.ListarTudo();
            }

        }

        private void cmbCliente_TextChanged(object sender, EventArgs e)
        {
            cmbCliente.BackColor = Color.Empty;
            try
            {
                codpes = cmbCliente.SelectedValue.ToString();
                nome = cmbCliente.Text;
            }
            catch
            {
            }
            
            if (cmbCliente.Text != string.Empty)
            {
                gvExibir.DataSource = assDAO.ListarNome(nome);
            }


            if (cmbCliente.Text == string.Empty)
            {
                gvExibir.DataSource = assDAO.ListarTudo();
            }

            #region AJUSTE GRID
            foreach (DataGridViewColumn column in gvExibir.Columns)
            {
                if (column.DataPropertyName == "ID")
                    column.Width = 30; //tamanho fixo da coluna CODP
                else if (column.DataPropertyName == "VALOR")
                    column.Width = 75; //tamanho fixo da coluna CODP

                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            #endregion
        }

        private void btnSalvarc_Click(object sender, EventArgs e)
        {
            if (assDAO.Verificafiado(codpes) == true)
            {
                if (cmbCliente.Text == string.Empty || txtValor.Text == "0,00")
                {
                    if (cmbCliente.Text == string.Empty)
                        cmbCliente.BackColor = Color.Red;

                    if (txtValor.Text == "0.00")
                        txtValor.BackColor = Color.Red;

                    MessageBox.Show("Informações inválidas!!!");
                }
                else
                {
                    try
                    {
                        ass.Valor = txtValor.Text.ToString().Replace(".", "");
                        ass.Id_pessoa = Convert.ToInt32(codpes);         
                        assDAO.Update(ass);

                        rlf.Id_pessoa = Convert.ToInt32(codpes);
                        rlf.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        rlf.Valor = txtValor.Text.ToString().Replace(".", "");
                        rlf.Descr = txtDesc.Text;
                        rlfDAO.Inserir(rlf);
                        MessageBox.Show("Informações cadastradas com sucesso!!!");

                        aud.Acao = "INSERIU FIADO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        txtValor.Clear();
                        txtId.Clear();
                        cmbCliente.Text = "";
                        txtDesc.Clear();
                        gvExibir.DataSource = assDAO.ListarTudo();
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas!!!");
                    }
                }
            }
            else
            {
                if (cmbCliente.Text == string.Empty || txtValor.Text == "0,00")
                {
                    if (cmbCliente.Text == string.Empty)
                        cmbCliente.BackColor = Color.Red;

                    if (txtValor.Text == "0.00")
                        txtValor.BackColor = Color.Red;

                    MessageBox.Show("Informações inválidas!!!");
                }
                else
                {
                    try
                    {
                        ass.Valor = txtValor.Text.ToString().Replace(".", "");
                        ass.Id_pessoa = Convert.ToInt32(codpes);                     
                        assDAO.Inserir(ass);


                        rlf.Id_pessoa = Convert.ToInt32(codpes);
                        rlf.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        rlf.Valor = txtValor.Text.ToString().Replace(".", "");
                        rlf.Descr = txtDesc.Text;
                        rlfDAO.Inserir(rlf);
                        MessageBox.Show("Informações cadastradas com sucesso!!!");

                        aud.Acao = "INSERIU FIADO";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        txtValor.Clear();
                        txtId.Clear();
                        cmbCliente.Text = "";
                        txtDesc.Clear();
                        gvExibir.DataSource = assDAO.ListarTudo();
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas!!!");
                    }
                }
            }
           
        }
        private void txtValor_TextChanged_2(object sender, EventArgs e)
        {
            txtValor.BackColor = Color.Empty;
            Moeda(ref txtValor);
        }

        private void btnAt_Click(object sender, EventArgs e)
        {
            if (txtIdAtualizar.Text == string.Empty || txtValorPago.Text == "0,00")
            {
                if (txtIdAtualizar.Text == string.Empty)
                    txtIdAtualizar.BackColor = Color.Red;

                if (txtValorPago.Text == "0,00")
                    txtValorPago.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    ass.Id_pessoa = Convert.ToInt32(txtIdAtualizar.Text);
                    ass.Valor = txtValorPago.Text.ToString().Replace(".", "");
                    assDAO.Update2(ass);
                    assDAO.VerificaNome(ass);

                    gvExibir.DataSource = assDAO.ListarTudo();

                    if (vcDAO.Verificavalor() == true)
                    {
                        vcDAO.Update(txtValorPago.Text.ToString().Replace(".", ""));
                        vcDAO.Verificavalor();

                        #region CREDITO DEBITO
                        string datatela = DateTime.Now.ToShortDateString();
                        string hrtela = DateTime.Now.ToShortTimeString();
                        cd.Data = Convert.ToDateTime(datatela);
                        cd.Hora = Convert.ToDateTime(hrtela);
                        cd.Desc_db = "Pagamento Fiado de "+ fiadoDAO.nome;
                        cd.Cred_db = txtValorPago.Text.ToString().Replace(".", "");
                        cd.Deb_db = "0,00";
                        cd.Responsa_db = UsuarioDAO.login;
                        cd.Total = vcDAO.Vc.Valor;
                        cd.C = null;
                        cdDAO.Inserir(cd);
                    }

                        #endregion

                        #region GERAL
                        if (vgDAO.Verificavalor() == true)
                        {



                            vgDAO.Update(txtValorPago.Text.ToString().Replace(".", ""));
                            vgDAO.Verificavalor();
                            #region GERAL
                            ger.Data = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                            ger.Desc_g = "FIADO";
                            ger.Deb_g = "";
                            ger.Cred_g = txtValorPago.Text.ToString().Replace(".", "");
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }
                        else
                        {
                            string zero = "0.00";
                            vgDAO.Inserir(zero);
                            vgDAO.Update(txtValorPago.Text.ToString().Replace(".", ""));
                            vgDAO.Verificavalor();

                            #region GERAL
                            ger.Data = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                            ger.Desc_g = "FIADO";
                            ger.Deb_g = "";
                            ger.Cred_g = txtValorPago.Text.ToString().Replace(".", "");
                            ger.Forn = "0,00";
                            ger.Func = "0,00";
                            ger.Total = vgDAO.Vg.Valor;
                            gerDAO.Inserir(ger);

                            #endregion
                        }
                        #endregion

                        txtValorPago.Text = string.Empty;
                        txtIdAtualizar.Text = string.Empty;
                    }
                
                catch
                {
                    MessageBox.Show("Favor verificar as informações digitadas!!!");
                }
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
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                id = txtId.Text;
                CarregarComboID();
            }
            else
            {
                CarregarComboNome();
                cmbCliente.Text = "";
            }
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
                    worksheet.Cells[i + 2, j + 1] = gvExibir.Rows[i].Cells[j].Value.ToString();                 
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

        private void btnPaideFamilia_Click(object sender, EventArgs e)
        {
            ExportarPDF(gvExibir, "planilha");
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorPago);
        }

        private void txtIdAtualizar_TextChanged(object sender, EventArgs e)
        {
            txtIdAtualizar.BackColor = Color.Empty;
            id = txtIdAtualizar.Text;
        }

        private void btnFiado_Click(object sender, EventArgs e)
        {
            frmRelatFiado v = new frmRelatFiado();
            v.Owner = this;
            v.ShowDialog();
        }

        private void gvExibir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdAtualizar.Text = gvExibir.SelectedRows[0].Cells[0].Value.ToString();
        }
    }   
}