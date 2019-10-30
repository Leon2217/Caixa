namespace Caixa.Forms
{
    partial class frmRelatConsumo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatConsumo));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.gvMostrarTotal = new System.Windows.Forms.DataGridView();
            this.prnFormConsumo = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnImprimirForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMostrarTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(423, 6);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(341, 26);
            this.txtNome.TabIndex = 24;
            this.txtNome.TextChanged += new System.EventHandler(this.TxtNome_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nome:";
            // 
            // mskAté
            // 
            this.mskAté.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAté.Location = new System.Drawing.Point(198, 6);
            this.mskAté.Mask = "00/00/0000";
            this.mskAté.Name = "mskAté";
            this.mskAté.Size = new System.Drawing.Size(100, 26);
            this.mskAté.TabIndex = 23;
            this.mskAté.TextChanged += new System.EventHandler(this.MskAté_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Até:";
            // 
            // mskDe
            // 
            this.mskDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDe.Location = new System.Drawing.Point(47, 6);
            this.mskDe.Mask = "00/00/0000";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(100, 26);
            this.mskDe.TabIndex = 22;
            this.mskDe.TextChanged += new System.EventHandler(this.MskDe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "De:";
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            this.gvExibir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvExibir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExibir.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvExibir.Location = new System.Drawing.Point(11, 40);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gvExibir.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvExibir.Size = new System.Drawing.Size(753, 464);
            this.gvExibir.TabIndex = 28;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.Location = new System.Drawing.Point(798, 6);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(102, 101);
            this.btnExport.TabIndex = 30;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPDF.BackColor = System.Drawing.Color.White;
            this.btnPDF.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnPDF.FlatAppearance.BorderSize = 2;
            this.btnPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPDF.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPDF.Location = new System.Drawing.Point(798, 117);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(102, 101);
            this.btnPDF.TabIndex = 31;
            this.btnPDF.Text = "Gerar  .PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // gvMostrarTotal
            // 
            this.gvMostrarTotal.AllowUserToAddRows = false;
            this.gvMostrarTotal.AllowUserToDeleteRows = false;
            this.gvMostrarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gvMostrarTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvMostrarTotal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvMostrarTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMostrarTotal.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvMostrarTotal.Location = new System.Drawing.Point(11, 510);
            this.gvMostrarTotal.Name = "gvMostrarTotal";
            this.gvMostrarTotal.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.gvMostrarTotal.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvMostrarTotal.Size = new System.Drawing.Size(753, 51);
            this.gvMostrarTotal.TabIndex = 32;
            // 
            // prnFormConsumo
            // 
            this.prnFormConsumo.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prnFormConsumo_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.prnFormConsumo;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnImprimirForm
            // 
            this.btnImprimirForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirForm.BackColor = System.Drawing.Color.White;
            this.btnImprimirForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImprimirForm.FlatAppearance.BorderSize = 2;
            this.btnImprimirForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImprimirForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImprimirForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirForm.Image = global::Caixa.Properties.Resources.apps_printer_15747;
            this.btnImprimirForm.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirForm.Location = new System.Drawing.Point(798, 226);
            this.btnImprimirForm.Name = "btnImprimirForm";
            this.btnImprimirForm.Size = new System.Drawing.Size(102, 101);
            this.btnImprimirForm.TabIndex = 33;
            this.btnImprimirForm.Text = "Imprimir Formulário";
            this.btnImprimirForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimirForm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnImprimirForm.UseVisualStyleBackColor = false;
            this.btnImprimirForm.Click += new System.EventHandler(this.btnImprimirForm_Click);
            // 
            // frmRelatConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(906, 567);
            this.Controls.Add(this.btnImprimirForm);
            this.Controls.Add(this.gvMostrarTotal);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRelatConsumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatório de Consumo";
            this.Load += new System.EventHandler(this.FrmRelatConsumo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelatConsumo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMostrarTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskAté;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.DataGridView gvMostrarTotal;
        private System.Drawing.Printing.PrintDocument prnFormConsumo;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnImprimirForm;
    }
}