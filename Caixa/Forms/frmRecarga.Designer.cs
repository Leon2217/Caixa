namespace Caixa
{
    partial class frmRecarga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecarga));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOperadora = new System.Windows.Forms.ComboBox();
            this.cmbValor = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mskCel = new System.Windows.Forms.MaskedTextBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnInventário = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operadora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor:";
            // 
            // cmbOperadora
            // 
            this.cmbOperadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperadora.FormattingEnabled = true;
            this.cmbOperadora.Location = new System.Drawing.Point(107, 12);
            this.cmbOperadora.Name = "cmbOperadora";
            this.cmbOperadora.Size = new System.Drawing.Size(132, 28);
            this.cmbOperadora.TabIndex = 1;
            this.cmbOperadora.SelectedIndexChanged += new System.EventHandler(this.cmbOperadora_SelectedIndexChanged);
            // 
            // cmbValor
            // 
            this.cmbValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValor.FormattingEnabled = true;
            this.cmbValor.Location = new System.Drawing.Point(107, 78);
            this.cmbValor.Name = "cmbValor";
            this.cmbValor.Size = new System.Drawing.Size(132, 28);
            this.cmbValor.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnSalvar.FlatAppearance.BorderSize = 2;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(16, 121);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(223, 40);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Celular";
            // 
            // mskCel
            // 
            this.mskCel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskCel.Location = new System.Drawing.Point(107, 46);
            this.mskCel.Mask = "(00)00000-0000";
            this.mskCel.Name = "mskCel";
            this.mskCel.Size = new System.Drawing.Size(132, 26);
            this.mskCel.TabIndex = 2;
            this.mskCel.TextChanged += new System.EventHandler(this.mskCel_TextChanged);
            this.mskCel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCel_KeyDown);
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.White;
            this.btnConsulta.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnConsulta.FlatAppearance.BorderSize = 2;
            this.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(17, 167);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(223, 40);
            this.btnConsulta.TabIndex = 7;
            this.btnConsulta.Text = "Consulta de Recarga";
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnInventário
            // 
            this.btnInventário.BackColor = System.Drawing.Color.White;
            this.btnInventário.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnInventário.FlatAppearance.BorderSize = 2;
            this.btnInventário.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInventário.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnInventário.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventário.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventário.Location = new System.Drawing.Point(17, 213);
            this.btnInventário.Name = "btnInventário";
            this.btnInventário.Size = new System.Drawing.Size(223, 40);
            this.btnInventário.TabIndex = 8;
            this.btnInventário.Text = "Inventário";
            this.btnInventário.UseVisualStyleBackColor = false;
            this.btnInventário.Click += new System.EventHandler(this.btnInventário_Click);
            // 
            // frmRecarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(257, 267);
            this.Controls.Add(this.btnInventário);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.mskCel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbValor);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cmbOperadora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmRecarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Recarga de Celular";
            this.Load += new System.EventHandler(this.frmRecarga_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecarga_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOperadora;
        private System.Windows.Forms.ComboBox cmbValor;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskCel;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnInventário;
    }
}