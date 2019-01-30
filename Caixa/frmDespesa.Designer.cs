namespace Caixa
{
    partial class frmDespesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespesa));
            this.cmbOp = new System.Windows.Forms.ComboBox();
            this.chkForn = new System.Windows.Forms.CheckBox();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFunc = new System.Windows.Forms.CheckBox();
            this.btnRelat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbParcela = new System.Windows.Forms.ComboBox();
            this.chkDespesa = new System.Windows.Forms.CheckBox();
            this.btnTipoDespesa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbOp
            // 
            this.cmbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOp.FormattingEnabled = true;
            this.cmbOp.Location = new System.Drawing.Point(12, 75);
            this.cmbOp.Name = "cmbOp";
            this.cmbOp.Size = new System.Drawing.Size(348, 28);
            this.cmbOp.TabIndex = 1;
            this.cmbOp.SelectedIndexChanged += new System.EventHandler(this.cmbOp_SelectedIndexChanged);
            // 
            // chkForn
            // 
            this.chkForn.AutoSize = true;
            this.chkForn.Location = new System.Drawing.Point(16, 45);
            this.chkForn.Name = "chkForn";
            this.chkForn.Size = new System.Drawing.Size(110, 24);
            this.chkForn.TabIndex = 21;
            this.chkForn.Text = "Fornecedor";
            this.chkForn.UseVisualStyleBackColor = true;
            this.chkForn.CheckedChanged += new System.EventHandler(this.chkF_CheckedChanged);
            // 
            // mskData
            // 
            this.mskData.Location = new System.Drawing.Point(123, 200);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(100, 26);
            this.mskData.TabIndex = 3;
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            this.mskData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskData_KeyDown);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(123, 110);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(237, 84);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(64, 11);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 26);
            this.txtValor.TabIndex = 0;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnAdicionar.FlatAppearance.BorderSize = 2;
            this.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Location = new System.Drawing.Point(12, 266);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(348, 43);
            this.btnAdicionar.TabIndex = 4;
            this.btnAdicionar.Text = "Salvar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Valor:";
            // 
            // chkFunc
            // 
            this.chkFunc.AutoSize = true;
            this.chkFunc.Location = new System.Drawing.Point(143, 45);
            this.chkFunc.Name = "chkFunc";
            this.chkFunc.Size = new System.Drawing.Size(111, 24);
            this.chkFunc.TabIndex = 23;
            this.chkFunc.Text = "Funcionário";
            this.chkFunc.UseVisualStyleBackColor = true;
            this.chkFunc.CheckedChanged += new System.EventHandler(this.chkFunc_CheckedChanged);
            // 
            // btnRelat
            // 
            this.btnRelat.BackColor = System.Drawing.Color.White;
            this.btnRelat.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnRelat.FlatAppearance.BorderSize = 2;
            this.btnRelat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRelat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnRelat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelat.Location = new System.Drawing.Point(12, 315);
            this.btnRelat.Name = "btnRelat";
            this.btnRelat.Size = new System.Drawing.Size(348, 43);
            this.btnRelat.TabIndex = 24;
            this.btnRelat.Text = "Relatório de Despesas";
            this.btnRelat.UseVisualStyleBackColor = false;
            this.btnRelat.Click += new System.EventHandler(this.btnRelat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Meses:";
            // 
            // cmbParcela
            // 
            this.cmbParcela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParcela.FormattingEnabled = true;
            this.cmbParcela.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5 ",
            "6 ",
            "7 ",
            "8 ",
            "9",
            "10",
            "11",
            "12"});
            this.cmbParcela.Location = new System.Drawing.Point(123, 232);
            this.cmbParcela.Name = "cmbParcela";
            this.cmbParcela.Size = new System.Drawing.Size(100, 28);
            this.cmbParcela.TabIndex = 26;
            this.cmbParcela.SelectedIndexChanged += new System.EventHandler(this.cmbParcela_SelectedIndexChanged);
            // 
            // chkDespesa
            // 
            this.chkDespesa.AutoSize = true;
            this.chkDespesa.Location = new System.Drawing.Point(284, 45);
            this.chkDespesa.Name = "chkDespesa";
            this.chkDespesa.Size = new System.Drawing.Size(76, 24);
            this.chkDespesa.TabIndex = 27;
            this.chkDespesa.Text = "Outros";
            this.chkDespesa.UseVisualStyleBackColor = true;
            this.chkDespesa.CheckedChanged += new System.EventHandler(this.chkDespesa_CheckedChanged);
            // 
            // btnTipoDespesa
            // 
            this.btnTipoDespesa.BackColor = System.Drawing.Color.White;
            this.btnTipoDespesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTipoDespesa.Location = new System.Drawing.Point(340, 25);
            this.btnTipoDespesa.Name = "btnTipoDespesa";
            this.btnTipoDespesa.Size = new System.Drawing.Size(18, 26);
            this.btnTipoDespesa.TabIndex = 28;
            this.btnTipoDespesa.Text = "+";
            this.btnTipoDespesa.UseVisualStyleBackColor = false;
            this.btnTipoDespesa.Click += new System.EventHandler(this.btnTipoDespesa_Click);
            // 
            // frmDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(370, 362);
            this.Controls.Add(this.btnTipoDespesa);
            this.Controls.Add(this.chkDespesa);
            this.Controls.Add(this.cmbParcela);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRelat);
            this.Controls.Add(this.chkFunc);
            this.Controls.Add(this.cmbOp);
            this.Controls.Add(this.chkForn);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDespesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Despesas fixas";
            this.Load += new System.EventHandler(this.frmDespesa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDespesa_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOp;
        private System.Windows.Forms.CheckBox chkForn;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFunc;
        private System.Windows.Forms.Button btnRelat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbParcela;
        private System.Windows.Forms.CheckBox chkDespesa;
        private System.Windows.Forms.Button btnTipoDespesa;
    }
}