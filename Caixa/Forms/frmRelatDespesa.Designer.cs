namespace Caixa
{
    partial class frmRelatDespesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatDespesa));
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPessoa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbS = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChkFr = new System.Windows.Forms.CheckBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCountatrasado = new System.Windows.Forms.Label();
            this.lblCountEmaberto = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
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
            this.gvExibir.Location = new System.Drawing.Point(12, 76);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExibir.Size = new System.Drawing.Size(588, 390);
            this.gvExibir.TabIndex = 22;
            this.gvExibir.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvExibir_CellClick);
            this.gvExibir.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvExibir_CellFormatting);
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
            this.btnPaideFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(610, 12);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(181, 65);
            this.btnPaideFamilia.TabIndex = 17;
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
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Location = new System.Drawing.Point(610, 83);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(181, 65);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Pessoa:";
            // 
            // mskAté
            // 
            this.mskAté.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAté.Location = new System.Drawing.Point(194, 10);
            this.mskAté.Mask = "00/00/0000";
            this.mskAté.Name = "mskAté";
            this.mskAté.Size = new System.Drawing.Size(100, 26);
            this.mskAté.TabIndex = 15;
            this.mskAté.TextChanged += new System.EventHandler(this.mskAté_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Até";
            // 
            // mskDe
            // 
            this.mskDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDe.Location = new System.Drawing.Point(48, 10);
            this.mskDe.Mask = "00/00/0000";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(100, 26);
            this.mskDe.TabIndex = 14;
            this.mskDe.TextChanged += new System.EventHandler(this.mskDe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "De:";
            // 
            // cmbPessoa
            // 
            this.cmbPessoa.FormattingEnabled = true;
            this.cmbPessoa.Location = new System.Drawing.Point(84, 42);
            this.cmbPessoa.Name = "cmbPessoa";
            this.cmbPessoa.Size = new System.Drawing.Size(234, 28);
            this.cmbPessoa.TabIndex = 23;
            this.cmbPessoa.SelectedIndexChanged += new System.EventHandler(this.cmbPessoa_SelectedIndexChanged);
            this.cmbPessoa.TextChanged += new System.EventHandler(this.cmbPessoa_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Atrasado",
            "Em aberto",
            "Pago"});
            this.cmbStatus.Location = new System.Drawing.Point(386, 42);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(214, 28);
            this.cmbStatus.TabIndex = 25;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            this.cmbStatus.TextChanged += new System.EventHandler(this.cmbStatus_TextChanged);
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
            this.btnAt.Location = new System.Drawing.Point(610, 385);
            this.btnAt.Name = "btnAt";
            this.btnAt.Size = new System.Drawing.Size(181, 39);
            this.btnAt.TabIndex = 33;
            this.btnAt.Text = "Atualizar";
            this.btnAt.UseVisualStyleBackColor = false;
            this.btnAt.Click += new System.EventHandler(this.btnAt_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(606, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Status:";
            // 
            // cmbS
            // 
            this.cmbS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbS.FormattingEnabled = true;
            this.cmbS.Items.AddRange(new object[] {
            "Em aberto",
            "Pago"});
            this.cmbS.Location = new System.Drawing.Point(610, 351);
            this.cmbS.Name = "cmbS";
            this.cmbS.Size = new System.Drawing.Size(181, 28);
            this.cmbS.TabIndex = 31;
            this.cmbS.SelectedIndexChanged += new System.EventHandler(this.cmbS_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(642, 267);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(149, 26);
            this.txtID.TabIndex = 30;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(606, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "ID:";
            // 
            // ChkFr
            // 
            this.ChkFr.AutoSize = true;
            this.ChkFr.Location = new System.Drawing.Point(328, 12);
            this.ChkFr.Name = "ChkFr";
            this.ChkFr.Size = new System.Drawing.Size(76, 24);
            this.ChkFr.TabIndex = 34;
            this.ChkFr.Text = "Outros";
            this.ChkFr.UseVisualStyleBackColor = true;
            this.ChkFr.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            this.btnExcluir.Location = new System.Drawing.Point(610, 430);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(181, 39);
            this.btnExcluir.TabIndex = 35;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(606, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Atrasado: ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Goldenrod;
            this.label8.Location = new System.Drawing.Point(606, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Em aberto:";
            // 
            // lblCountatrasado
            // 
            this.lblCountatrasado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountatrasado.AutoSize = true;
            this.lblCountatrasado.ForeColor = System.Drawing.Color.Red;
            this.lblCountatrasado.Location = new System.Drawing.Point(694, 183);
            this.lblCountatrasado.Name = "lblCountatrasado";
            this.lblCountatrasado.Size = new System.Drawing.Size(0, 20);
            this.lblCountatrasado.TabIndex = 38;
            // 
            // lblCountEmaberto
            // 
            this.lblCountEmaberto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountEmaberto.AutoSize = true;
            this.lblCountEmaberto.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblCountEmaberto.Location = new System.Drawing.Point(694, 228);
            this.lblCountEmaberto.Name = "lblCountEmaberto";
            this.lblCountEmaberto.Size = new System.Drawing.Size(0, 20);
            this.lblCountEmaberto.TabIndex = 39;
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(642, 299);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(149, 26);
            this.txtValor.TabIndex = 41;
            this.txtValor.TextChanged += new System.EventHandler(this.TxtValor_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(606, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = "R$:";
            // 
            // frmRelatDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(802, 478);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCountEmaberto);
            this.Controls.Add(this.lblCountatrasado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.ChkFr);
            this.Controls.Add(this.btnAt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbS);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPessoa);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRelatDespesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatório Despesas";
            this.Load += new System.EventHandler(this.frmRelatDespesa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelatDespesa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskAté;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPessoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbS;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChkFr;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCountatrasado;
        private System.Windows.Forms.Label lblCountEmaberto;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label9;
    }
}