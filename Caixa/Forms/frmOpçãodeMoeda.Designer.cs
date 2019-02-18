namespace Caixa
{
    partial class frmOpçãodeMoeda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpçãodeMoeda));
            this.btnMovimento = new System.Windows.Forms.Button();
            this.btnDev = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMovimento
            // 
            this.btnMovimento.BackColor = System.Drawing.Color.White;
            this.btnMovimento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMovimento.FlatAppearance.BorderSize = 2;
            this.btnMovimento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnMovimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovimento.Location = new System.Drawing.Point(11, 193);
            this.btnMovimento.Name = "btnMovimento";
            this.btnMovimento.Size = new System.Drawing.Size(228, 84);
            this.btnMovimento.TabIndex = 6;
            this.btnMovimento.Text = "F3 - Relatório Movimento";
            this.btnMovimento.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMovimento.UseVisualStyleBackColor = false;
            this.btnMovimento.Click += new System.EventHandler(this.btnMovimento_Click);
            // 
            // btnDev
            // 
            this.btnDev.BackColor = System.Drawing.Color.White;
            this.btnDev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDev.FlatAppearance.BorderSize = 2;
            this.btnDev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDev.Location = new System.Drawing.Point(11, 103);
            this.btnDev.Name = "btnDev";
            this.btnDev.Size = new System.Drawing.Size(228, 84);
            this.btnDev.TabIndex = 5;
            this.btnDev.Text = "F2 - Saída cx Moeda p/ o caixa";
            this.btnDev.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDev.UseVisualStyleBackColor = false;
            this.btnDev.Click += new System.EventHandler(this.btnDev_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.White;
            this.btnEntrada.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEntrada.FlatAppearance.BorderSize = 2;
            this.btnEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.Location = new System.Drawing.Point(11, 13);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(228, 84);
            this.btnEntrada.TabIndex = 4;
            this.btnEntrada.Text = "F1 - Entrada cx Moeda";
            this.btnEntrada.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // frmOpçãodeMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(250, 291);
            this.Controls.Add(this.btnMovimento);
            this.Controls.Add(this.btnDev);
            this.Controls.Add(this.btnEntrada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmOpçãodeMoeda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimento de Moeda";
            this.Load += new System.EventHandler(this.frmOpçãodeMoeda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOpçãodeMoeda_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMovimento;
        private System.Windows.Forms.Button btnDev;
        private System.Windows.Forms.Button btnEntrada;
    }
}