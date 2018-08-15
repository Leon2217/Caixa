namespace Caixa
{
    partial class frmRelatFalta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatFalta));
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // mskAté
            // 
            this.mskAté.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAté.Location = new System.Drawing.Point(200, 12);
            this.mskAté.Mask = "00/00/0000";
            this.mskAté.Name = "mskAté";
            this.mskAté.Size = new System.Drawing.Size(100, 26);
            this.mskAté.TabIndex = 2;
            this.mskAté.TextChanged += new System.EventHandler(this.mskAté_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Até";
            // 
            // mskDe
            // 
            this.mskDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDe.Location = new System.Drawing.Point(45, 12);
            this.mskDe.Mask = "00/00/0000";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(100, 26);
            this.mskDe.TabIndex = 1;
            this.mskDe.TextChanged += new System.EventHandler(this.mskDe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "De:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(376, 12);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(231, 26);
            this.txtNome.TabIndex = 3;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // btnPaideFamilia
            // 
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(510, 44);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(97, 92);
            this.btnPaideFamilia.TabIndex = 4;
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
            this.btnExport.Location = new System.Drawing.Point(510, 142);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 92);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.Location = new System.Drawing.Point(12, 44);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(492, 361);
            this.gvExibir.TabIndex = 13;
            // 
            // frmRelatFalta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(619, 413);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmRelatFalta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatório de faltas";
            this.Load += new System.EventHandler(this.frmRelatFalta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelatFalta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskAté;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView gvExibir;
    }
}