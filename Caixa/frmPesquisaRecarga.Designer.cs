namespace Caixa
{
    partial class frmPesquisaRecarga
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOperadora = new System.Windows.Forms.TextBox();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mskAt = new System.Windows.Forms.MaskedTextBox();
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operadora:";
            // 
            // txtOperadora
            // 
            this.txtOperadora.Location = new System.Drawing.Point(489, 10);
            this.txtOperadora.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOperadora.Name = "txtOperadora";
            this.txtOperadora.Size = new System.Drawing.Size(137, 26);
            this.txtOperadora.TabIndex = 2;
            this.txtOperadora.TextChanged += new System.EventHandler(this.txtOperadora_TextChanged);
            this.txtOperadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOperadora_KeyDown);
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.Location = new System.Drawing.Point(18, 48);
            this.gvExibir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(620, 390);
            this.gvExibir.TabIndex = 4;
            // 
            // mskData
            // 
            this.mskData.Location = new System.Drawing.Point(55, 10);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(102, 26);
            this.mskData.TabIndex = 1;
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            this.mskData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskData_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Até:";
            // 
            // mskAt
            // 
            this.mskAt.Location = new System.Drawing.Point(207, 10);
            this.mskAt.Mask = "00/00/0000";
            this.mskAt.Name = "mskAt";
            this.mskAt.Size = new System.Drawing.Size(100, 26);
            this.mskAt.TabIndex = 6;
            this.mskAt.TextChanged += new System.EventHandler(this.mskAt_TextChanged);
            // 
            // btnPaideFamilia
            // 
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(645, 48);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(97, 92);
            this.btnPaideFamilia.TabIndex = 7;
            this.btnPaideFamilia.Text = "Gerar .PDF";
            this.btnPaideFamilia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPaideFamilia.UseVisualStyleBackColor = false;
            this.btnPaideFamilia.Click += new System.EventHandler(this.btnPaideFamilia_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Location = new System.Drawing.Point(645, 146);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 92);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmPesquisaRecarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(748, 452);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.mskAt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.txtOperadora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmPesquisaRecarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Consulta de Recarga";
            this.Load += new System.EventHandler(this.frmPesquisaRecarga_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPesquisaRecarga_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOperadora;
        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskAt;
        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
    }
}