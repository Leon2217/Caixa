namespace Caixa
{
    partial class frmDevoluçãodeMoeda
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
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtSangria = new System.Windows.Forms.TextBox();
            this.lblSangria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(12, 38);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(223, 43);
            this.btnAdicionar.TabIndex = 86;
            this.btnAdicionar.Text = "Salvar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtSangria
            // 
            this.txtSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSangria.Location = new System.Drawing.Point(101, 6);
            this.txtSangria.Name = "txtSangria";
            this.txtSangria.Size = new System.Drawing.Size(134, 26);
            this.txtSangria.TabIndex = 88;
            this.txtSangria.TextChanged += new System.EventHandler(this.txtSangria_TextChanged);
            this.txtSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSangria_KeyPress);
            // 
            // lblSangria
            // 
            this.lblSangria.AutoSize = true;
            this.lblSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSangria.Location = new System.Drawing.Point(7, 9);
            this.lblSangria.Name = "lblSangria";
            this.lblSangria.Size = new System.Drawing.Size(88, 20);
            this.lblSangria.TabIndex = 87;
            this.lblSangria.Text = "Devolução:";
            // 
            // frmDevoluçãodeMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(249, 94);
            this.Controls.Add(this.txtSangria);
            this.Controls.Add(this.lblSangria);
            this.Controls.Add(this.btnAdicionar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmDevoluçãodeMoeda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Devolução de Moeda";
            this.Load += new System.EventHandler(this.frmDevoluçãodeMoeda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDevoluçãodeMoeda_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtSangria;
        private System.Windows.Forms.Label lblSangria;
    }
}