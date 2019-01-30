namespace Caixa
{
    partial class frmCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredito));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtResponsa = new System.Windows.Forms.TextBox();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.mskHr = new System.Windows.Forms.MaskedTextBox();
            this.chkF = new System.Windows.Forms.CheckBox();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hora:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Responsável:";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnAdicionar.FlatAppearance.BorderSize = 2;
            this.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Location = new System.Drawing.Point(11, 264);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(345, 43);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(119, 12);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 26);
            this.txtValor.TabIndex = 1;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(119, 78);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(237, 84);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // txtResponsa
            // 
            this.txtResponsa.Location = new System.Drawing.Point(118, 232);
            this.txtResponsa.Name = "txtResponsa";
            this.txtResponsa.Size = new System.Drawing.Size(238, 26);
            this.txtResponsa.TabIndex = 5;
            this.txtResponsa.TextChanged += new System.EventHandler(this.txtResponsa_TextChanged);
            this.txtResponsa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponsa_KeyDown);
            this.txtResponsa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResponsa_KeyPress);
            // 
            // mskData
            // 
            this.mskData.Enabled = false;
            this.mskData.Location = new System.Drawing.Point(119, 168);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(100, 26);
            this.mskData.TabIndex = 3;
            this.mskData.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskData_MaskInputRejected);
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            this.mskData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskData_KeyDown);
            // 
            // mskHr
            // 
            this.mskHr.Enabled = false;
            this.mskHr.Location = new System.Drawing.Point(119, 200);
            this.mskHr.Mask = "00:00";
            this.mskHr.Name = "mskHr";
            this.mskHr.Size = new System.Drawing.Size(57, 26);
            this.mskHr.TabIndex = 4;
            this.mskHr.TextChanged += new System.EventHandler(this.mskHr_TextChanged);
            this.mskHr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskHr_KeyDown);
            // 
            // chkF
            // 
            this.chkF.AutoSize = true;
            this.chkF.Location = new System.Drawing.Point(11, 46);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(110, 24);
            this.chkF.TabIndex = 8;
            this.chkF.Text = "Fornecedor";
            this.chkF.UseVisualStyleBackColor = true;
            this.chkF.CheckedChanged += new System.EventHandler(this.chkF_CheckedChanged);
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFornecedor.Enabled = false;
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(120, 44);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(236, 28);
            this.cmbFornecedor.TabIndex = 9;
            this.cmbFornecedor.SelectedIndexChanged += new System.EventHandler(this.cmbFornecedor_SelectedIndexChanged);
            // 
            // frmCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(368, 312);
            this.Controls.Add(this.cmbFornecedor);
            this.Controls.Add(this.chkF);
            this.Controls.Add(this.mskHr);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.txtResponsa);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Tela Crédito";
            this.Load += new System.EventHandler(this.frmCredito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCredito_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtResponsa;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.MaskedTextBox mskHr;
        private System.Windows.Forms.CheckBox chkF;
        private System.Windows.Forms.ComboBox cmbFornecedor;
    }
}