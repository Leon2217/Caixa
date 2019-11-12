namespace Caixa.Forms
{
    partial class frmOpApostas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpApostas));
            this.btnGiroDaSorte = new System.Windows.Forms.Button();
            this.btnValeCAP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGiroDaSorte
            // 
            this.btnGiroDaSorte.BackColor = System.Drawing.Color.White;
            this.btnGiroDaSorte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGiroDaSorte.FlatAppearance.BorderSize = 2;
            this.btnGiroDaSorte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnGiroDaSorte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.btnGiroDaSorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiroDaSorte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiroDaSorte.Location = new System.Drawing.Point(12, 102);
            this.btnGiroDaSorte.Name = "btnGiroDaSorte";
            this.btnGiroDaSorte.Size = new System.Drawing.Size(228, 84);
            this.btnGiroDaSorte.TabIndex = 4;
            this.btnGiroDaSorte.Text = "F2 - Santa Sorte";
            this.btnGiroDaSorte.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGiroDaSorte.UseVisualStyleBackColor = false;
            this.btnGiroDaSorte.Click += new System.EventHandler(this.btnGiroDaSorte_Click);
            // 
            // btnValeCAP
            // 
            this.btnValeCAP.BackColor = System.Drawing.Color.White;
            this.btnValeCAP.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnValeCAP.FlatAppearance.BorderSize = 2;
            this.btnValeCAP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnValeCAP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnValeCAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValeCAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValeCAP.Location = new System.Drawing.Point(12, 12);
            this.btnValeCAP.Name = "btnValeCAP";
            this.btnValeCAP.Size = new System.Drawing.Size(228, 84);
            this.btnValeCAP.TabIndex = 3;
            this.btnValeCAP.Text = "F1 - Vale Cap";
            this.btnValeCAP.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnValeCAP.UseVisualStyleBackColor = false;
            this.btnValeCAP.Click += new System.EventHandler(this.btnValeCAP_Click);
            // 
            // frmOpApostas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(254, 197);
            this.Controls.Add(this.btnGiroDaSorte);
            this.Controls.Add(this.btnValeCAP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOpApostas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Apostas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOpApostas_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnGiroDaSorte;
        public System.Windows.Forms.Button btnValeCAP;
    }
}