namespace Caixa
{
    partial class frmTaxa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxa));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSodexo = new System.Windows.Forms.TextBox();
            this.txtVr = new System.Windows.Forms.TextBox();
            this.txtTicket = new System.Windows.Forms.TextBox();
            this.txtAlelo = new System.Windows.Forms.TextBox();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.txtDebito = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtDiaSodexo = new System.Windows.Forms.NumericUpDown();
            this.txtDiaVr = new System.Windows.Forms.NumericUpDown();
            this.txtDiaTicket = new System.Windows.Forms.NumericUpDown();
            this.txtDiaAlelo = new System.Windows.Forms.NumericUpDown();
            this.txtDiaCredito = new System.Windows.Forms.NumericUpDown();
            this.txtDiaDebito = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPcard = new System.Windows.Forms.TextBox();
            this.txtDiaPcard = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaSodexo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaVr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaAlelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaDebito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaPcard)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Taxas (%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Intervalo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sodexo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "VR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Alelo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ticket:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Crédito:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Débito:";
            // 
            // txtSodexo
            // 
            this.txtSodexo.Location = new System.Drawing.Point(85, 32);
            this.txtSodexo.Name = "txtSodexo";
            this.txtSodexo.Size = new System.Drawing.Size(89, 26);
            this.txtSodexo.TabIndex = 1;
            this.txtSodexo.TextChanged += new System.EventHandler(this.txtSodexo_TextChanged);
            this.txtSodexo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSodexo_KeyDown);
            this.txtSodexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSodexo_KeyPress);
            // 
            // txtVr
            // 
            this.txtVr.Location = new System.Drawing.Point(85, 64);
            this.txtVr.Name = "txtVr";
            this.txtVr.Size = new System.Drawing.Size(89, 26);
            this.txtVr.TabIndex = 3;
            this.txtVr.TextChanged += new System.EventHandler(this.txtVr_TextChanged);
            this.txtVr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVr_KeyDown);
            this.txtVr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVr_KeyPress);
            // 
            // txtTicket
            // 
            this.txtTicket.Location = new System.Drawing.Point(85, 96);
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Size = new System.Drawing.Size(89, 26);
            this.txtTicket.TabIndex = 5;
            this.txtTicket.TextChanged += new System.EventHandler(this.txtTicket_TextChanged);
            this.txtTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTicket_KeyDown);
            this.txtTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTicket_KeyPress);
            // 
            // txtAlelo
            // 
            this.txtAlelo.Location = new System.Drawing.Point(85, 128);
            this.txtAlelo.Name = "txtAlelo";
            this.txtAlelo.Size = new System.Drawing.Size(89, 26);
            this.txtAlelo.TabIndex = 7;
            this.txtAlelo.TextChanged += new System.EventHandler(this.txtAlelo_TextChanged);
            this.txtAlelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAlelo_KeyDown);
            this.txtAlelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlelo_KeyPress);
            // 
            // txtCredito
            // 
            this.txtCredito.Location = new System.Drawing.Point(85, 192);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.Size = new System.Drawing.Size(89, 26);
            this.txtCredito.TabIndex = 11;
            this.txtCredito.TextChanged += new System.EventHandler(this.txtCredito_TextChanged);
            this.txtCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCredito_KeyDown);
            this.txtCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredito_KeyPress);
            // 
            // txtDebito
            // 
            this.txtDebito.Location = new System.Drawing.Point(85, 224);
            this.txtDebito.Name = "txtDebito";
            this.txtDebito.Size = new System.Drawing.Size(89, 26);
            this.txtDebito.TabIndex = 13;
            this.txtDebito.TextChanged += new System.EventHandler(this.txtDebito_TextChanged);
            this.txtDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDebito_KeyDown);
            this.txtDebito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebito_KeyPress);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnSalvar.FlatAppearance.BorderSize = 2;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(16, 260);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(259, 40);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtDiaSodexo
            // 
            this.txtDiaSodexo.Location = new System.Drawing.Point(194, 33);
            this.txtDiaSodexo.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaSodexo.Name = "txtDiaSodexo";
            this.txtDiaSodexo.Size = new System.Drawing.Size(81, 26);
            this.txtDiaSodexo.TabIndex = 2;
            this.txtDiaSodexo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSodexo_KeyDown);
            // 
            // txtDiaVr
            // 
            this.txtDiaVr.Location = new System.Drawing.Point(194, 65);
            this.txtDiaVr.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaVr.Name = "txtDiaVr";
            this.txtDiaVr.Size = new System.Drawing.Size(81, 26);
            this.txtDiaVr.TabIndex = 4;
            this.txtDiaVr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaVr_KeyDown);
            // 
            // txtDiaTicket
            // 
            this.txtDiaTicket.Location = new System.Drawing.Point(194, 97);
            this.txtDiaTicket.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaTicket.Name = "txtDiaTicket";
            this.txtDiaTicket.Size = new System.Drawing.Size(81, 26);
            this.txtDiaTicket.TabIndex = 6;
            this.txtDiaTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaTicket_KeyDown);
            // 
            // txtDiaAlelo
            // 
            this.txtDiaAlelo.Location = new System.Drawing.Point(194, 129);
            this.txtDiaAlelo.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaAlelo.Name = "txtDiaAlelo";
            this.txtDiaAlelo.Size = new System.Drawing.Size(81, 26);
            this.txtDiaAlelo.TabIndex = 8;
            this.txtDiaAlelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaAlelo_KeyDown);
            // 
            // txtDiaCredito
            // 
            this.txtDiaCredito.Location = new System.Drawing.Point(194, 193);
            this.txtDiaCredito.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaCredito.Name = "txtDiaCredito";
            this.txtDiaCredito.Size = new System.Drawing.Size(81, 26);
            this.txtDiaCredito.TabIndex = 12;
            this.txtDiaCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaCredito_KeyDown);
            // 
            // txtDiaDebito
            // 
            this.txtDiaDebito.Location = new System.Drawing.Point(194, 225);
            this.txtDiaDebito.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaDebito.Name = "txtDiaDebito";
            this.txtDiaDebito.Size = new System.Drawing.Size(81, 26);
            this.txtDiaDebito.TabIndex = 14;
            this.txtDiaDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaDebito_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "PCard:";
            // 
            // txtPcard
            // 
            this.txtPcard.Location = new System.Drawing.Point(85, 160);
            this.txtPcard.Name = "txtPcard";
            this.txtPcard.Size = new System.Drawing.Size(89, 26);
            this.txtPcard.TabIndex = 9;
            this.txtPcard.TextChanged += new System.EventHandler(this.txtPcard_TextChanged);
            this.txtPcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPcard_KeyDown);
            this.txtPcard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPcard_KeyPress);
            // 
            // txtDiaPcard
            // 
            this.txtDiaPcard.Location = new System.Drawing.Point(194, 161);
            this.txtDiaPcard.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.txtDiaPcard.Name = "txtDiaPcard";
            this.txtDiaPcard.Size = new System.Drawing.Size(81, 26);
            this.txtDiaPcard.TabIndex = 10;
            this.txtDiaPcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaPcard_KeyDown);
            // 
            // frmTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(285, 312);
            this.Controls.Add(this.txtDiaPcard);
            this.Controls.Add(this.txtPcard);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDiaDebito);
            this.Controls.Add(this.txtDiaCredito);
            this.Controls.Add(this.txtDiaAlelo);
            this.Controls.Add(this.txtDiaTicket);
            this.Controls.Add(this.txtDiaVr);
            this.Controls.Add(this.txtDiaSodexo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtDebito);
            this.Controls.Add(this.txtCredito);
            this.Controls.Add(this.txtAlelo);
            this.Controls.Add(this.txtTicket);
            this.Controls.Add(this.txtVr);
            this.Controls.Add(this.txtSodexo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTaxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Cadastro de Taxa";
            this.Load += new System.EventHandler(this.frmTaxa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTaxa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaSodexo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaVr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaAlelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaDebito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaPcard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSodexo;
        private System.Windows.Forms.TextBox txtVr;
        private System.Windows.Forms.TextBox txtTicket;
        private System.Windows.Forms.TextBox txtAlelo;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.TextBox txtDebito;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.NumericUpDown txtDiaSodexo;
        private System.Windows.Forms.NumericUpDown txtDiaVr;
        private System.Windows.Forms.NumericUpDown txtDiaTicket;
        private System.Windows.Forms.NumericUpDown txtDiaAlelo;
        private System.Windows.Forms.NumericUpDown txtDiaCredito;
        private System.Windows.Forms.NumericUpDown txtDiaDebito;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPcard;
        private System.Windows.Forms.NumericUpDown txtDiaPcard;
    }
}