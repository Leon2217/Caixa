namespace Caixa
{
    partial class frmMovimentoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimentoCaixa));
            this.btnCrédito = new System.Windows.Forms.Button();
            this.btnDebito = new System.Windows.Forms.Button();
            this.btnMovimento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrédito
            // 
            this.btnCrédito.BackColor = System.Drawing.Color.White;
            this.btnCrédito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCrédito.FlatAppearance.BorderSize = 3;
            this.btnCrédito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCrédito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrédito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrédito.Location = new System.Drawing.Point(12, 12);
            this.btnCrédito.Name = "btnCrédito";
            this.btnCrédito.Size = new System.Drawing.Size(228, 84);
            this.btnCrédito.TabIndex = 0;
            this.btnCrédito.Text = "F1 - Crédito";
            this.btnCrédito.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCrédito.UseVisualStyleBackColor = false;
            this.btnCrédito.Click += new System.EventHandler(this.btnCrédito_Click);
            // 
            // btnDebito
            // 
            this.btnDebito.BackColor = System.Drawing.Color.White;
            this.btnDebito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDebito.FlatAppearance.BorderSize = 3;
            this.btnDebito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnDebito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebito.Location = new System.Drawing.Point(12, 102);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(228, 84);
            this.btnDebito.TabIndex = 1;
            this.btnDebito.Text = "F2 - Débito";
            this.btnDebito.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDebito.UseVisualStyleBackColor = false;
            this.btnDebito.Click += new System.EventHandler(this.btnDebito_Click);
            // 
            // btnMovimento
            // 
            this.btnMovimento.BackColor = System.Drawing.Color.White;
            this.btnMovimento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMovimento.FlatAppearance.BorderSize = 3;
            this.btnMovimento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnMovimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovimento.Location = new System.Drawing.Point(12, 192);
            this.btnMovimento.Name = "btnMovimento";
            this.btnMovimento.Size = new System.Drawing.Size(228, 84);
            this.btnMovimento.TabIndex = 3;
            this.btnMovimento.Text = "F3 - Movimento";
            this.btnMovimento.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMovimento.UseVisualStyleBackColor = false;
            this.btnMovimento.Click += new System.EventHandler(this.btnMovimento_Click);
            // 
            // frmMovimentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(250, 291);
            this.Controls.Add(this.btnMovimento);
            this.Controls.Add(this.btnDebito);
            this.Controls.Add(this.btnCrédito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMovimentoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Movimento de caixa";
            this.Load += new System.EventHandler(this.frmMovimentoCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMovimentoCaixa_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrédito;
        private System.Windows.Forms.Button btnDebito;
        private System.Windows.Forms.Button btnMovimento;
    }
}