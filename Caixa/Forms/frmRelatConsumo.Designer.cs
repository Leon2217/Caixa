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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatConsumo));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
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
            this.gvExibir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExibir.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvExibir.Location = new System.Drawing.Point(11, 40);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(753, 496);
            this.gvExibir.TabIndex = 28;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImprimir.FlatAppearance.BorderSize = 2;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Image = global::Caixa.Properties.Resources.apps_printer_15747;
            this.btnImprimir.Location = new System.Drawing.Point(830, 499);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(35, 37);
            this.btnImprimir.TabIndex = 29;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnExport.Location = new System.Drawing.Point(771, 6);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 101);
            this.btnExport.TabIndex = 30;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
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
            this.btnPDF.Location = new System.Drawing.Point(771, 117);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(94, 101);
            this.btnPDF.TabIndex = 31;
            this.btnPDF.Text = "Gerar .PDF";
            this.btnPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // frmRelatConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(871, 548);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImprimir);
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
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPDF;
    }
}