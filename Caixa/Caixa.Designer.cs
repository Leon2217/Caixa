namespace Caixa
{
    partial class Caixa
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
            this.components = new System.ComponentModel.Container();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grpHora = new System.Windows.Forms.GroupBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.grpUsuario = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.grpData.SuspendLayout();
            this.grpHora.SuspendLayout();
            this.grpUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 18);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(0, 16);
            this.lblNome.TabIndex = 2;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(6, 18);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 16);
            this.lblData.TabIndex = 3;
            // 
            // tmrHora
            // 
            this.tmrHora.Enabled = true;
            this.tmrHora.Interval = 1000;
            this.tmrHora.Tick += new System.EventHandler(this.tmrHora_Tick);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lblData);
            this.grpData.Location = new System.Drawing.Point(12, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(296, 42);
            this.grpData.TabIndex = 4;
            this.grpData.TabStop = false;
            this.grpData.Text = "Data:";
            // 
            // grpHora
            // 
            this.grpHora.Controls.Add(this.lblHora);
            this.grpHora.Location = new System.Drawing.Point(314, 0);
            this.grpHora.Name = "grpHora";
            this.grpHora.Size = new System.Drawing.Size(116, 42);
            this.grpHora.TabIndex = 5;
            this.grpHora.TabStop = false;
            this.grpHora.Text = "Hora:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(6, 18);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(0, 16);
            this.lblHora.TabIndex = 3;
            // 
            // grpUsuario
            // 
            this.grpUsuario.Controls.Add(this.lblNome);
            this.grpUsuario.Location = new System.Drawing.Point(12, 48);
            this.grpUsuario.Name = "grpUsuario";
            this.grpUsuario.Size = new System.Drawing.Size(418, 42);
            this.grpUsuario.TabIndex = 6;
            this.grpUsuario.TabStop = false;
            this.grpUsuario.Text = "Usuário:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(12, 626);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(422, 39);
            this.btnFinalizar.TabIndex = 9;
            this.btnFinalizar.Text = "Finalizar caixa";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Caixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 677);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.grpUsuario);
            this.Controls.Add(this.grpHora);
            this.Controls.Add(this.grpData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Caixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.Load += new System.EventHandler(this.Caixa_Load);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpHora.ResumeLayout(false);
            this.grpHora.PerformLayout();
            this.grpUsuario.ResumeLayout(false);
            this.grpUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.GroupBox grpUsuario;
        private System.Windows.Forms.Button btnFinalizar;
    }
}