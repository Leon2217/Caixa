namespace Caixa
{
    partial class frmGeral
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
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.lblAt = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.cmbDescricao = new System.Windows.Forms.ComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDeb = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCred = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaideFamilia
            // 
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(303, 7);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(137, 67);
            this.btnPaideFamilia.TabIndex = 14;
            this.btnPaideFamilia.Text = "Gerar .PDF";
            this.btnPaideFamilia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPaideFamilia.UseVisualStyleBackColor = false;
            this.btnPaideFamilia.Click += new System.EventHandler(this.btnPaideFamilia_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Location = new System.Drawing.Point(446, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 67);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // mskAté
            // 
            this.mskAté.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAté.Location = new System.Drawing.Point(194, 13);
            this.mskAté.Mask = "00/00/0000";
            this.mskAté.Name = "mskAté";
            this.mskAté.Size = new System.Drawing.Size(103, 26);
            this.mskAté.TabIndex = 12;
            this.mskAté.TextChanged += new System.EventHandler(this.mskAté_TextChanged);
            // 
            // lblAt
            // 
            this.lblAt.AutoSize = true;
            this.lblAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAt.Location = new System.Drawing.Point(154, 16);
            this.lblAt.Name = "lblAt";
            this.lblAt.Size = new System.Drawing.Size(34, 20);
            this.lblAt.TabIndex = 11;
            this.lblAt.Text = "Até";
            // 
            // mskDe
            // 
            this.mskDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDe.Location = new System.Drawing.Point(48, 13);
            this.mskDe.Mask = "00/00/0000";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(100, 26);
            this.mskDe.TabIndex = 10;
            this.mskDe.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskDe_MaskInputRejected);
            this.mskDe.TextChanged += new System.EventHandler(this.mskDe_TextChanged);
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(8, 16);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(34, 20);
            this.lblDe.TabIndex = 9;
            this.lblDe.Text = "De:";
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Empty;
            this.gvExibir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.Location = new System.Drawing.Point(12, 80);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(574, 513);
            this.gvExibir.TabIndex = 8;
            this.gvExibir.TabStop = false;
            // 
            // cmbDescricao
            // 
            this.cmbDescricao.FormattingEnabled = true;
            this.cmbDescricao.Items.AddRange(new object[] {
            "DÉBITO",
            "CRÉDITO",
            "NF",
            "CRÉDITO CAIXA MOEDA",
            "CARTAO"});
            this.cmbDescricao.Location = new System.Drawing.Point(98, 45);
            this.cmbDescricao.Name = "cmbDescricao";
            this.cmbDescricao.Size = new System.Drawing.Size(199, 28);
            this.cmbDescricao.TabIndex = 15;
            this.cmbDescricao.SelectedIndexChanged += new System.EventHandler(this.cmbDescricao_SelectedIndexChanged);
            this.cmbDescricao.TextChanged += new System.EventHandler(this.cmbDescricao_TextChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(8, 48);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(84, 20);
            this.lblDesc.TabIndex = 16;
            this.lblDesc.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 635);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "BALANÇO:";
            // 
            // lblDeb
            // 
            this.lblDeb.AutoSize = true;
            this.lblDeb.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDeb.Location = new System.Drawing.Point(355, 635);
            this.lblDeb.Name = "lblDeb";
            this.lblDeb.Size = new System.Drawing.Size(0, 20);
            this.lblDeb.TabIndex = 18;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(474, 635);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 19;
            // 
            // lblCred
            // 
            this.lblCred.AutoSize = true;
            this.lblCred.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblCred.Location = new System.Drawing.Point(247, 635);
            this.lblCred.Name = "lblCred";
            this.lblCred.Size = new System.Drawing.Size(0, 20);
            this.lblCred.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 615);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "ENTRADA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "SAÍDA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 615);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "TOTAL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 635);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 635);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "=";
            // 
            // frmGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(595, 660);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCred);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDeb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.cmbDescricao);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.lblAt);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.gvExibir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGeral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatório geral";
            this.Load += new System.EventHandler(this.frmGeral_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGeral_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MaskedTextBox mskAté;
        private System.Windows.Forms.Label lblAt;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.ComboBox cmbDescricao;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDeb;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCred;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}