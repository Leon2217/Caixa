﻿namespace Caixa
{
    partial class frmSangria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSangria));
            this.lblSangria = new System.Windows.Forms.Label();
            this.txtSangria = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRelatório = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSangria
            // 
            this.lblSangria.AutoSize = true;
            this.lblSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSangria.Location = new System.Drawing.Point(12, 12);
            this.lblSangria.Name = "lblSangria";
            this.lblSangria.Size = new System.Drawing.Size(68, 20);
            this.lblSangria.TabIndex = 0;
            this.lblSangria.Text = "Sangria:";
            // 
            // txtSangria
            // 
            this.txtSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSangria.Location = new System.Drawing.Point(86, 9);
            this.txtSangria.Name = "txtSangria";
            this.txtSangria.Size = new System.Drawing.Size(134, 26);
            this.txtSangria.TabIndex = 1;
            this.txtSangria.TextChanged += new System.EventHandler(this.txtSangria_TextChanged);
            this.txtSangria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSangria_KeyDown);
            this.txtSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSangria_KeyPress);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnAdicionar.FlatAppearance.BorderSize = 2;
            this.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(16, 41);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(204, 43);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRelatório
            // 
            this.btnRelatório.BackColor = System.Drawing.Color.White;
            this.btnRelatório.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnRelatório.FlatAppearance.BorderSize = 2;
            this.btnRelatório.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRelatório.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnRelatório.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatório.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatório.Location = new System.Drawing.Point(16, 90);
            this.btnRelatório.Name = "btnRelatório";
            this.btnRelatório.Size = new System.Drawing.Size(204, 43);
            this.btnRelatório.TabIndex = 3;
            this.btnRelatório.Text = "Relatório de Sangria";
            this.btnRelatório.UseVisualStyleBackColor = false;
            this.btnRelatório.Click += new System.EventHandler(this.btnRelatório_Click);
            // 
            // frmSangria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(241, 141);
            this.Controls.Add(this.btnRelatório);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtSangria);
            this.Controls.Add(this.lblSangria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSangria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Sangria";
            this.Load += new System.EventHandler(this.frmSangria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSangria_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSangria;
        private System.Windows.Forms.TextBox txtSangria;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRelatório;
    }
}