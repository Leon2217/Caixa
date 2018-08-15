namespace Caixa
{
    partial class frmRelatVendavc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatVendavc));
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.Location = new System.Drawing.Point(16, 56);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(658, 386);
            this.gvExibir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data:";
            // 
            // mskData
            // 
            this.mskData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mskData.Location = new System.Drawing.Point(66, 16);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(108, 26);
            this.mskData.TabIndex = 1;
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            // 
            // btnPaideFamilia
            // 
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(250, 9);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(210, 41);
            this.btnPaideFamilia.TabIndex = 2;
            this.btnPaideFamilia.Text = "Gerar .PDF";
            this.btnPaideFamilia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPaideFamilia.UseVisualStyleBackColor = false;
            this.btnPaideFamilia.Click += new System.EventHandler(this.btnPaideFamilia_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Location = new System.Drawing.Point(466, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(210, 41);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmRelatVendavc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(682, 448);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvExibir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmRelatVendavc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatório Vale Cap";
            this.Load += new System.EventHandler(this.frmRelatVendavc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelatVendavc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
    }
}