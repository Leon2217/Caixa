namespace Caixa
{
    partial class frmEntradaMoeda
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl1r = new System.Windows.Forms.Label();
            this.lbl50c = new System.Windows.Forms.Label();
            this.lbl25c = new System.Windows.Forms.Label();
            this.lbl10c = new System.Windows.Forms.Label();
            this.lbl5c = new System.Windows.Forms.Label();
            this.txt1Real = new System.Windows.Forms.TextBox();
            this.txt5Centavos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt50Centavos = new System.Windows.Forms.TextBox();
            this.txt10Centavos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt25Centavos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl5Centavos = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.chkPDV = new System.Windows.Forms.CheckBox();
            this.chkBaixo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl1r);
            this.groupBox1.Controls.Add(this.lbl50c);
            this.groupBox1.Controls.Add(this.lbl25c);
            this.groupBox1.Controls.Add(this.lbl10c);
            this.groupBox1.Controls.Add(this.lbl5c);
            this.groupBox1.Controls.Add(this.txt1Real);
            this.groupBox1.Controls.Add(this.txt5Centavos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt50Centavos);
            this.groupBox1.Controls.Add(this.txt10Centavos);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt25Centavos);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl5Centavos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 205);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[Moedas]";
            // 
            // lbl1r
            // 
            this.lbl1r.AutoSize = true;
            this.lbl1r.Location = new System.Drawing.Point(202, 165);
            this.lbl1r.Name = "lbl1r";
            this.lbl1r.Size = new System.Drawing.Size(0, 20);
            this.lbl1r.TabIndex = 99;
            // 
            // lbl50c
            // 
            this.lbl50c.AutoSize = true;
            this.lbl50c.Location = new System.Drawing.Point(202, 133);
            this.lbl50c.Name = "lbl50c";
            this.lbl50c.Size = new System.Drawing.Size(0, 20);
            this.lbl50c.TabIndex = 98;
            // 
            // lbl25c
            // 
            this.lbl25c.AutoSize = true;
            this.lbl25c.Location = new System.Drawing.Point(202, 101);
            this.lbl25c.Name = "lbl25c";
            this.lbl25c.Size = new System.Drawing.Size(0, 20);
            this.lbl25c.TabIndex = 97;
            // 
            // lbl10c
            // 
            this.lbl10c.AutoSize = true;
            this.lbl10c.Location = new System.Drawing.Point(202, 69);
            this.lbl10c.Name = "lbl10c";
            this.lbl10c.Size = new System.Drawing.Size(0, 20);
            this.lbl10c.TabIndex = 96;
            // 
            // lbl5c
            // 
            this.lbl5c.AutoSize = true;
            this.lbl5c.Location = new System.Drawing.Point(202, 37);
            this.lbl5c.Name = "lbl5c";
            this.lbl5c.Size = new System.Drawing.Size(0, 20);
            this.lbl5c.TabIndex = 95;
            // 
            // txt1Real
            // 
            this.txt1Real.Enabled = false;
            this.txt1Real.Location = new System.Drawing.Point(126, 162);
            this.txt1Real.MaxLength = 5;
            this.txt1Real.Name = "txt1Real";
            this.txt1Real.Size = new System.Drawing.Size(70, 26);
            this.txt1Real.TabIndex = 11;
            this.txt1Real.TextChanged += new System.EventHandler(this.txt1Real_TextChanged);
            this.txt1Real.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt1Real_KeyDown);
            this.txt1Real.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt1Real_KeyPress);
            // 
            // txt5Centavos
            // 
            this.txt5Centavos.Enabled = false;
            this.txt5Centavos.Location = new System.Drawing.Point(126, 34);
            this.txt5Centavos.MaxLength = 5;
            this.txt5Centavos.Name = "txt5Centavos";
            this.txt5Centavos.Size = new System.Drawing.Size(70, 26);
            this.txt5Centavos.TabIndex = 7;
            this.txt5Centavos.TextChanged += new System.EventHandler(this.txt5Centavos_TextChanged);
            this.txt5Centavos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt5Centavos_KeyDown);
            this.txt5Centavos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt5Centavos_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 68;
            this.label4.Text = "1 Real:";
            // 
            // txt50Centavos
            // 
            this.txt50Centavos.Enabled = false;
            this.txt50Centavos.Location = new System.Drawing.Point(126, 130);
            this.txt50Centavos.MaxLength = 5;
            this.txt50Centavos.Name = "txt50Centavos";
            this.txt50Centavos.Size = new System.Drawing.Size(70, 26);
            this.txt50Centavos.TabIndex = 10;
            this.txt50Centavos.TextChanged += new System.EventHandler(this.txt50Centavos_TextChanged);
            this.txt50Centavos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt50Centavos_KeyDown);
            this.txt50Centavos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt50Centavos_KeyPress);
            // 
            // txt10Centavos
            // 
            this.txt10Centavos.Enabled = false;
            this.txt10Centavos.Location = new System.Drawing.Point(126, 66);
            this.txt10Centavos.MaxLength = 5;
            this.txt10Centavos.Name = "txt10Centavos";
            this.txt10Centavos.Size = new System.Drawing.Size(70, 26);
            this.txt10Centavos.TabIndex = 8;
            this.txt10Centavos.TextChanged += new System.EventHandler(this.txt10Centavos_TextChanged);
            this.txt10Centavos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt10Centavos_KeyDown);
            this.txt10Centavos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt10Centavos_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "50 Centavos:";
            // 
            // txt25Centavos
            // 
            this.txt25Centavos.Enabled = false;
            this.txt25Centavos.Location = new System.Drawing.Point(126, 98);
            this.txt25Centavos.MaxLength = 5;
            this.txt25Centavos.Name = "txt25Centavos";
            this.txt25Centavos.Size = new System.Drawing.Size(70, 26);
            this.txt25Centavos.TabIndex = 9;
            this.txt25Centavos.TextChanged += new System.EventHandler(this.txt25Centavos_TextChanged);
            this.txt25Centavos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt25Centavos_KeyDown);
            this.txt25Centavos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt25Centavos_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 66;
            this.label10.Text = "10 Centavos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 65;
            this.label9.Text = "25 Centavos:";
            // 
            // lbl5Centavos
            // 
            this.lbl5Centavos.AutoSize = true;
            this.lbl5Centavos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5Centavos.Location = new System.Drawing.Point(6, 37);
            this.lbl5Centavos.Name = "lbl5Centavos";
            this.lbl5Centavos.Size = new System.Drawing.Size(104, 20);
            this.lbl5Centavos.TabIndex = 67;
            this.lbl5Centavos.Text = "5 Centavos:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 98);
            this.groupBox4.TabIndex = 82;
            this.groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblMoeda);
            this.groupBox6.Location = new System.Drawing.Point(10, 39);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(275, 50);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Location = new System.Drawing.Point(6, 22);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(0, 20);
            this.lblMoeda.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "TOTAL MOEDA:";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.Enabled = false;
            this.btnAdicionar.Location = new System.Drawing.Point(12, 367);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(300, 46);
            this.btnAdicionar.TabIndex = 83;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // chkPDV
            // 
            this.chkPDV.AutoSize = true;
            this.chkPDV.Location = new System.Drawing.Point(12, 12);
            this.chkPDV.Name = "chkPDV";
            this.chkPDV.Size = new System.Drawing.Size(61, 24);
            this.chkPDV.TabIndex = 100;
            this.chkPDV.Text = "PDV";
            this.chkPDV.UseVisualStyleBackColor = true;
            this.chkPDV.CheckedChanged += new System.EventHandler(this.chkPDV_CheckedChanged);
            // 
            // chkBaixo
            // 
            this.chkBaixo.AutoSize = true;
            this.chkBaixo.Location = new System.Drawing.Point(79, 12);
            this.chkBaixo.Name = "chkBaixo";
            this.chkBaixo.Size = new System.Drawing.Size(108, 24);
            this.chkBaixo.TabIndex = 101;
            this.chkBaixo.Text = "Caixa baixo";
            this.chkBaixo.UseVisualStyleBackColor = true;
            this.chkBaixo.CheckedChanged += new System.EventHandler(this.chkBaixo_CheckedChanged);
            // 
            // frmEntradaMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(324, 418);
            this.Controls.Add(this.chkBaixo);
            this.Controls.Add(this.chkPDV);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmEntradaMoeda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Entrada de Moeda";
            this.Load += new System.EventHandler(this.frmEntradaMoeda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntradaMoeda_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl1r;
        private System.Windows.Forms.Label lbl50c;
        private System.Windows.Forms.Label lbl25c;
        private System.Windows.Forms.Label lbl10c;
        private System.Windows.Forms.Label lbl5c;
        private System.Windows.Forms.TextBox txt1Real;
        private System.Windows.Forms.TextBox txt5Centavos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt50Centavos;
        private System.Windows.Forms.TextBox txt10Centavos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt25Centavos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl5Centavos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.CheckBox chkPDV;
        private System.Windows.Forms.CheckBox chkBaixo;
    }
}