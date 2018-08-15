namespace Caixa
{
    partial class Abertura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abertura));
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mskData
            // 
            this.mskData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskData.Location = new System.Drawing.Point(86, 52);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(138, 29);
            this.mskData.TabIndex = 2;
            this.mskData.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskData_MaskInputRejected);
            this.mskData.TextChanged += new System.EventHandler(this.mskData_TextChanged);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(12, 58);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(48, 20);
            this.lblData.TabIndex = 12;
            this.lblData.Text = "Data:";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(12, 93);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(54, 20);
            this.lblTurno.TabIndex = 11;
            this.lblTurno.Text = "Turno:";
            // 
            // cmbTurno
            // 
            this.cmbTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Items.AddRange(new object[] {
            "Manhã",
            "Tarde"});
            this.cmbTurno.Location = new System.Drawing.Point(86, 87);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(138, 32);
            this.cmbTurno.TabIndex = 3;
            this.cmbTurno.TextChanged += new System.EventHandler(this.cmbTurno_TextChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(12, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(68, 20);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "Usuário:";
            // 
            // txtUsu
            // 
            this.txtUsu.Enabled = false;
            this.txtUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsu.Location = new System.Drawing.Point(86, 17);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(138, 29);
            this.txtUsu.TabIndex = 1;
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.White;
            this.btnAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.Image = global::Caixa.Properties.Resources._1485477182_open_lock_78586;
            this.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrir.Location = new System.Drawing.Point(16, 125);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(208, 43);
            this.btnAbrir.TabIndex = 4;
            this.btnAbrir.Text = "Abrir Caixa";
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // Abertura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(247, 177);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.cmbTurno);
            this.Controls.Add(this.btnAbrir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Abertura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura";
            this.Load += new System.EventHandler(this.Abertura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Abertura_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsu;
    }
}