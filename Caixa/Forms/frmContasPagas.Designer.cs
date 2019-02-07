namespace Caixa
{
    partial class frmContasPagas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContasPagas));
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.txtNf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblEAE = new System.Windows.Forms.Label();
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.chkNf = new System.Windows.Forms.CheckBox();
            this.chkPc = new System.Windows.Forms.CheckBox();
            this.cmbParcela = new System.Windows.Forms.ComboBox();
            this.mskDataem = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskData2 = new System.Windows.Forms.MaskedTextBox();
            this.mskData3 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorVenc1 = new System.Windows.Forms.TextBox();
            this.txtValorVenc3 = new System.Windows.Forms.TextBox();
            this.txtValorVenc2 = new System.Windows.Forms.TextBox();
            this.btnDespesa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(8, 15);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(95, 20);
            this.lblFornecedor.TabIndex = 0;
            this.lblFornecedor.Text = "Fornecedor:";
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(127, 12);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(343, 28);
            this.cmbFornecedor.TabIndex = 1;
            this.cmbFornecedor.SelectedIndexChanged += new System.EventHandler(this.cmbFornecedor_SelectedIndexChanged);
            // 
            // txtNf
            // 
            this.txtNf.Enabled = false;
            this.txtNf.Location = new System.Drawing.Point(127, 46);
            this.txtNf.MaxLength = 10;
            this.txtNf.Name = "txtNf";
            this.txtNf.Size = new System.Drawing.Size(203, 26);
            this.txtNf.TabIndex = 4;
            this.txtNf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNf.Visible = false;
            this.txtNf.TextChanged += new System.EventHandler(this.txtNf_TextChanged);
            this.txtNf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNf_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Venc:";
            // 
            // mskData
            // 
            this.mskData.Location = new System.Drawing.Point(127, 174);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(107, 26);
            this.mskData.TabIndex = 8;
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            this.mskData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnSalvar.FlatAppearance.BorderSize = 2;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(12, 270);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(458, 36);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblEAE
            // 
            this.lblEAE.AutoSize = true;
            this.lblEAE.Location = new System.Drawing.Point(8, 351);
            this.lblEAE.Name = "lblEAE";
            this.lblEAE.Size = new System.Drawing.Size(194, 20);
            this.lblEAE.TabIndex = 9;
            this.lblEAE.Text = "BOLETOS NESSA NOTA:";
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gvExibir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvExibir.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvExibir.Location = new System.Drawing.Point(12, 374);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(458, 157);
            this.gvExibir.TabIndex = 99;
            this.gvExibir.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvExibir_CellFormatting);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.White;
            this.btnRelatorio.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnRelatorio.FlatAppearance.BorderSize = 2;
            this.btnRelatorio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRelatorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Location = new System.Drawing.Point(12, 312);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(458, 36);
            this.btnRelatorio.TabIndex = 15;
            this.btnRelatorio.Text = "Relatório Contas";
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // chkNf
            // 
            this.chkNf.AutoSize = true;
            this.chkNf.Location = new System.Drawing.Point(12, 48);
            this.chkNf.Name = "chkNf";
            this.chkNf.Size = new System.Drawing.Size(69, 24);
            this.chkNf.TabIndex = 3;
            this.chkNf.Text = "N° NF";
            this.chkNf.UseVisualStyleBackColor = true;
            this.chkNf.CheckedChanged += new System.EventHandler(this.chkNf_CheckedChanged);
            // 
            // chkPc
            // 
            this.chkPc.AutoSize = true;
            this.chkPc.Location = new System.Drawing.Point(12, 78);
            this.chkPc.Name = "chkPc";
            this.chkPc.Size = new System.Drawing.Size(134, 24);
            this.chkPc.TabIndex = 2;
            this.chkPc.Text = "Pedido/cheque";
            this.chkPc.UseVisualStyleBackColor = true;
            this.chkPc.CheckedChanged += new System.EventHandler(this.chkPc_CheckedChanged);
            // 
            // cmbParcela
            // 
            this.cmbParcela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParcela.FormattingEnabled = true;
            this.cmbParcela.Items.AddRange(new object[] {
            "1X",
            "2X",
            "3X"});
            this.cmbParcela.Location = new System.Drawing.Point(127, 140);
            this.cmbParcela.Name = "cmbParcela";
            this.cmbParcela.Size = new System.Drawing.Size(49, 28);
            this.cmbParcela.TabIndex = 7;
            this.cmbParcela.SelectedIndexChanged += new System.EventHandler(this.cmbParcela_SelectedIndexChanged);
            this.cmbParcela.TextChanged += new System.EventHandler(this.cmbParcela_TextChanged);
            // 
            // mskDataem
            // 
            this.mskDataem.Location = new System.Drawing.Point(127, 108);
            this.mskDataem.Mask = "00/00/0000";
            this.mskDataem.Name = "mskDataem";
            this.mskDataem.Size = new System.Drawing.Size(107, 26);
            this.mskDataem.TabIndex = 5;
            this.mskDataem.TextChanged += new System.EventHandler(this.mskDataem_TextChanged);
            this.mskDataem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskDataem_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Data Emissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Parcelas:";
            // 
            // mskData2
            // 
            this.mskData2.Enabled = false;
            this.mskData2.Location = new System.Drawing.Point(127, 206);
            this.mskData2.Mask = "00/00/0000";
            this.mskData2.Name = "mskData2";
            this.mskData2.Size = new System.Drawing.Size(107, 26);
            this.mskData2.TabIndex = 10;
            this.mskData2.TextChanged += new System.EventHandler(this.mskData2_TextChanged);
            this.mskData2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskData2_KeyDown);
            // 
            // mskData3
            // 
            this.mskData3.Enabled = false;
            this.mskData3.Location = new System.Drawing.Point(127, 238);
            this.mskData3.Mask = "00/00/0000";
            this.mskData3.Name = "mskData3";
            this.mskData3.Size = new System.Drawing.Size(107, 26);
            this.mskData3.TabIndex = 12;
            this.mskData3.TextChanged += new System.EventHandler(this.mskData3_TextChanged);
            this.mskData3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskData3_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Data Venc3:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data Venc2:";
            // 
            // txtValorVenc1
            // 
            this.txtValorVenc1.Enabled = false;
            this.txtValorVenc1.Location = new System.Drawing.Point(240, 174);
            this.txtValorVenc1.Name = "txtValorVenc1";
            this.txtValorVenc1.Size = new System.Drawing.Size(90, 26);
            this.txtValorVenc1.TabIndex = 9;
            this.txtValorVenc1.TextChanged += new System.EventHandler(this.txtValorVenc1_TextChanged);
            this.txtValorVenc1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorVenc1_KeyDown);
            this.txtValorVenc1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenc1_KeyPress);
            // 
            // txtValorVenc3
            // 
            this.txtValorVenc3.Enabled = false;
            this.txtValorVenc3.Location = new System.Drawing.Point(240, 238);
            this.txtValorVenc3.Name = "txtValorVenc3";
            this.txtValorVenc3.Size = new System.Drawing.Size(90, 26);
            this.txtValorVenc3.TabIndex = 13;
            this.txtValorVenc3.TextChanged += new System.EventHandler(this.txtValorVenc3_TextChanged);
            this.txtValorVenc3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorVenc3_KeyDown);
            this.txtValorVenc3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenc3_KeyPress);
            // 
            // txtValorVenc2
            // 
            this.txtValorVenc2.Enabled = false;
            this.txtValorVenc2.Location = new System.Drawing.Point(240, 206);
            this.txtValorVenc2.Name = "txtValorVenc2";
            this.txtValorVenc2.Size = new System.Drawing.Size(90, 26);
            this.txtValorVenc2.TabIndex = 11;
            this.txtValorVenc2.TextChanged += new System.EventHandler(this.txtValorVenc2_TextChanged);
            this.txtValorVenc2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorVenc2_KeyDown);
            this.txtValorVenc2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenc2_KeyPress);
            // 
            // btnDespesa
            // 
            this.btnDespesa.BackColor = System.Drawing.Color.White;
            this.btnDespesa.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnDespesa.FlatAppearance.BorderSize = 2;
            this.btnDespesa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDespesa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDespesa.Location = new System.Drawing.Point(276, 91);
            this.btnDespesa.Name = "btnDespesa";
            this.btnDespesa.Size = new System.Drawing.Size(194, 60);
            this.btnDespesa.TabIndex = 100;
            this.btnDespesa.Text = "F10 - Despesas Fixas";
            this.btnDespesa.UseVisualStyleBackColor = false;
            this.btnDespesa.Click += new System.EventHandler(this.btnDespesa_Click);
            this.btnDespesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDespesa_KeyDown);
            // 
            // frmContasPagas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(482, 543);
            this.Controls.Add(this.btnDespesa);
            this.Controls.Add(this.txtValorVenc2);
            this.Controls.Add(this.txtValorVenc3);
            this.Controls.Add(this.txtValorVenc1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mskData3);
            this.Controls.Add(this.mskData2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mskDataem);
            this.Controls.Add(this.cmbParcela);
            this.Controls.Add(this.chkPc);
            this.Controls.Add(this.chkNf);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.lblEAE);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNf);
            this.Controls.Add(this.cmbFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmContasPagas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " .: Registrar Conta";
            this.Load += new System.EventHandler(this.frmContasPagas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContasPagas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cmbFornecedor;
        private System.Windows.Forms.TextBox txtNf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblEAE;
        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.CheckBox chkNf;
        private System.Windows.Forms.CheckBox chkPc;
        private System.Windows.Forms.ComboBox cmbParcela;
        private System.Windows.Forms.MaskedTextBox mskDataem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskData2;
        private System.Windows.Forms.MaskedTextBox mskData3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorVenc1;
        private System.Windows.Forms.TextBox txtValorVenc3;
        private System.Windows.Forms.TextBox txtValorVenc2;
        private System.Windows.Forms.Button btnDespesa;
    }
}