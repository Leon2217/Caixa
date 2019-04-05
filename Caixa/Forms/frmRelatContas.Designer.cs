namespace Caixa
{
    partial class frmRelatContas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatContas));
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNf = new System.Windows.Forms.CheckBox();
            this.chkPc = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.txtNf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbS = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAt = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblAtrasado = new System.Windows.Forms.Label();
            this.lblEmaberto = new System.Windows.Forms.Label();
            this.lblCountatrasado = new System.Windows.Forms.Label();
            this.lblCountemaberto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaideFamilia
            // 
            this.btnPaideFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatAppearance.BorderSize = 2;
            this.btnPaideFamilia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(882, 14);
            this.btnPaideFamilia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(181, 65);
            this.btnPaideFamilia.TabIndex = 14;
            this.btnPaideFamilia.Text = "Gerar .PDF";
            this.btnPaideFamilia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPaideFamilia.UseVisualStyleBackColor = false;
            this.btnPaideFamilia.Click += new System.EventHandler(this.btnPaideFamilia_Click);
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
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Location = new System.Drawing.Point(882, 89);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(181, 65);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // mskAté
            // 
            this.mskAté.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAté.Location = new System.Drawing.Point(224, 16);
            this.mskAté.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mskAté.Mask = "00/00/0000";
            this.mskAté.Name = "mskAté";
            this.mskAté.Size = new System.Drawing.Size(119, 26);
            this.mskAté.TabIndex = 2;
            this.mskAté.TextChanged += new System.EventHandler(this.mskAté_TextChanged);
            this.mskAté.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskAté_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Até";
            // 
            // mskDe
            // 
            this.mskDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDe.Location = new System.Drawing.Point(55, 16);
            this.mskDe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mskDe.Mask = "00/00/0000";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(119, 26);
            this.mskDe.TabIndex = 1;
            this.mskDe.TextChanged += new System.EventHandler(this.mskDe_TextChanged);
            this.mskDe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskDe_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "De:";
            // 
            // chkNf
            // 
            this.chkNf.AutoSize = true;
            this.chkNf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chkNf.Location = new System.Drawing.Point(161, 53);
            this.chkNf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNf.Name = "chkNf";
            this.chkNf.Size = new System.Drawing.Size(50, 24);
            this.chkNf.TabIndex = 5;
            this.chkNf.Text = "NF";
            this.chkNf.UseVisualStyleBackColor = true;
            this.chkNf.CheckedChanged += new System.EventHandler(this.chkNf_CheckedChanged);
            // 
            // chkPc
            // 
            this.chkPc.AutoSize = true;
            this.chkPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chkPc.Location = new System.Drawing.Point(12, 53);
            this.chkPc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkPc.Name = "chkPc";
            this.chkPc.Size = new System.Drawing.Size(141, 24);
            this.chkPc.TabIndex = 4;
            this.chkPc.Text = "Pedido/Cheque";
            this.chkPc.UseVisualStyleBackColor = true;
            this.chkPc.CheckedChanged += new System.EventHandler(this.chkPc_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(397, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fornecedor:";
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(500, 16);
            this.cmbFornecedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(299, 28);
            this.cmbFornecedor.TabIndex = 3;
            this.cmbFornecedor.SelectedIndexChanged += new System.EventHandler(this.cmbFornecedor_SelectedIndexChanged);
            this.cmbFornecedor.TextChanged += new System.EventHandler(this.cmbFornecedor_TextChanged);
            // 
            // txtNf
            // 
            this.txtNf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNf.Location = new System.Drawing.Point(219, 51);
            this.txtNf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNf.MaxLength = 10;
            this.txtNf.Name = "txtNf";
            this.txtNf.Size = new System.Drawing.Size(124, 26);
            this.txtNf.TabIndex = 6;
            this.txtNf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNf.Visible = false;
            this.txtNf.TextChanged += new System.EventHandler(this.txtNf_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(397, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Atrasado",
            "Em aberto",
            "Pago"});
            this.cmbStatus.Location = new System.Drawing.Point(500, 51);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 28);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            this.cmbStatus.TextChanged += new System.EventHandler(this.cmbStatus_TextChanged);
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gvExibir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvExibir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExibir.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvExibir.Location = new System.Drawing.Point(12, 89);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExibir.Size = new System.Drawing.Size(862, 425);
            this.gvExibir.TabIndex = 21;
            this.gvExibir.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvExibir_CellClick_1);
            this.gvExibir.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvExibir_CellFormatting);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(878, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(919, 344);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(139, 26);
            this.txtID.TabIndex = 23;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // cmbS
            // 
            this.cmbS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbS.FormattingEnabled = true;
            this.cmbS.Items.AddRange(new object[] {
            "Em aberto",
            "Pago"});
            this.cmbS.Location = new System.Drawing.Point(882, 396);
            this.cmbS.Name = "cmbS";
            this.cmbS.Size = new System.Drawing.Size(181, 28);
            this.cmbS.TabIndex = 24;
            this.cmbS.SelectedIndexChanged += new System.EventHandler(this.cmbS_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(875, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Status:";
            // 
            // btnAt
            // 
            this.btnAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAt.BackColor = System.Drawing.Color.White;
            this.btnAt.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnAt.FlatAppearance.BorderSize = 2;
            this.btnAt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnAt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAt.Location = new System.Drawing.Point(882, 430);
            this.btnAt.Name = "btnAt";
            this.btnAt.Size = new System.Drawing.Size(181, 39);
            this.btnAt.TabIndex = 26;
            this.btnAt.Text = "Atualizar";
            this.btnAt.UseVisualStyleBackColor = false;
            this.btnAt.Click += new System.EventHandler(this.btnAt_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnExcluir.FlatAppearance.BorderSize = 2;
            this.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Location = new System.Drawing.Point(882, 475);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(181, 39);
            this.btnExcluir.TabIndex = 29;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblAtrasado
            // 
            this.lblAtrasado.AutoSize = true;
            this.lblAtrasado.ForeColor = System.Drawing.Color.Red;
            this.lblAtrasado.Location = new System.Drawing.Point(878, 215);
            this.lblAtrasado.Name = "lblAtrasado";
            this.lblAtrasado.Size = new System.Drawing.Size(82, 20);
            this.lblAtrasado.TabIndex = 30;
            this.lblAtrasado.Text = "Atrasado: ";
            // 
            // lblEmaberto
            // 
            this.lblEmaberto.AutoSize = true;
            this.lblEmaberto.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblEmaberto.Location = new System.Drawing.Point(878, 259);
            this.lblEmaberto.Name = "lblEmaberto";
            this.lblEmaberto.Size = new System.Drawing.Size(87, 20);
            this.lblEmaberto.TabIndex = 31;
            this.lblEmaberto.Text = "Em aberto:";
            // 
            // lblCountatrasado
            // 
            this.lblCountatrasado.AutoSize = true;
            this.lblCountatrasado.ForeColor = System.Drawing.Color.Red;
            this.lblCountatrasado.Location = new System.Drawing.Point(966, 215);
            this.lblCountatrasado.Name = "lblCountatrasado";
            this.lblCountatrasado.Size = new System.Drawing.Size(0, 20);
            this.lblCountatrasado.TabIndex = 32;
            // 
            // lblCountemaberto
            // 
            this.lblCountemaberto.AutoSize = true;
            this.lblCountemaberto.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblCountemaberto.Location = new System.Drawing.Point(966, 259);
            this.lblCountemaberto.Name = "lblCountemaberto";
            this.lblCountemaberto.Size = new System.Drawing.Size(0, 20);
            this.lblCountemaberto.TabIndex = 33;
            // 
            // frmRelatContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1070, 523);
            this.Controls.Add(this.lblCountemaberto);
            this.Controls.Add(this.lblCountatrasado);
            this.Controls.Add(this.lblEmaberto);
            this.Controls.Add(this.lblAtrasado);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbS);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNf);
            this.Controls.Add(this.cmbFornecedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkPc);
            this.Controls.Add(this.chkNf);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRelatContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatórios de contas";
            this.Load += new System.EventHandler(this.frmRelatContas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelatContas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MaskedTextBox mskAté;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNf;
        private System.Windows.Forms.CheckBox chkPc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFornecedor;
        private System.Windows.Forms.TextBox txtNf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAt;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblAtrasado;
        private System.Windows.Forms.Label lblEmaberto;
        private System.Windows.Forms.Label lblCountatrasado;
        private System.Windows.Forms.Label lblCountemaberto;
    }
}