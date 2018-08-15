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
            this.SuspendLayout();
            // 
            // cmbOp
            // 
            this.cmbOp.Enabled = false;
            this.cmbOp.FormattingEnabled = true;
            this.cmbOp.Location = new System.Drawing.Point(123, 76);
            this.cmbOp.Name = "cmbOp";
            this.cmbOp.Size = new System.Drawing.Size(238, 28);
            this.cmbOp.TabIndex = 22;
            this.cmbOp.SelectedIndexChanged += new System.EventHandler(this.cmbOp_SelectedIndexChanged);
            // 
            // chkForn
            // 
            this.chkForn.AutoSize = true;
            this.chkForn.Location = new System.Drawing.Point(124, 45);
            this.chkForn.Name = "chkForn";
            this.chkForn.Size = new System.Drawing.Size(110, 24);
            this.chkForn.TabIndex = 21;
            this.chkForn.Text = "Fornecedor";
            this.chkForn.UseVisualStyleBackColor = true;
            this.chkForn.CheckedChanged += new System.EventHandler(this.chkF_CheckedChanged);
            // 
            // mskData
            // 
            this.mskData.Enabled = false;
            this.mskData.Location = new System.Drawing.Point(123, 200);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(100, 26);
            this.mskData.TabIndex = 15;
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(123, 110);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(237, 84);
            this.txtDesc.TabIndex = 13;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(124, 11);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 26);
            this.txtValor.TabIndex = 11;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(16, 232);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(345, 43);
            this.btnAdicionar.TabIndex = 20;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Valor:";
            // 
            // chkFunc
            // 
            this.chkFunc.AutoSize = true;
            this.chkFunc.Location = new System.Drawing.Point(249, 45);
            this.chkFunc.Name = "chkFunc";
            this.chkFunc.Size = new System.Drawing.Size(111, 24);
            this.chkFunc.TabIndex = 23;
            this.chkFunc.Text = "Funcionário";
            this.chkFunc.UseVisualStyleBackColor = true;
            this.chkFunc.CheckedChanged += new System.EventHandler(this.chkFunc_CheckedChanged);
            // 
            // frmDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(372, 285);
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
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDespesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despesa";
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
    }
}