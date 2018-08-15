namespace Caixa
{
    partial class frmFalta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFalta));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNome = new System.Windows.Forms.ComboBox();
            this.lblPeríodo = new System.Windows.Forms.Label();
            this.chkIntegral = new System.Windows.Forms.CheckBox();
            this.chkParcial = new System.Windows.Forms.CheckBox();
            this.chkManha = new System.Windows.Forms.CheckBox();
            this.chkTarde = new System.Windows.Forms.CheckBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblAt = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.mskAte = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnRelat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // cmbNome
            // 
            this.cmbNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNome.FormattingEnabled = true;
            this.cmbNome.Location = new System.Drawing.Point(66, 18);
            this.cmbNome.Name = "cmbNome";
            this.cmbNome.Size = new System.Drawing.Size(213, 28);
            this.cmbNome.TabIndex = 1;
            this.cmbNome.SelectedIndexChanged += new System.EventHandler(this.cmbNome_SelectedIndexChanged);
            // 
            // lblPeríodo
            // 
            this.lblPeríodo.AutoSize = true;
            this.lblPeríodo.Location = new System.Drawing.Point(13, 74);
            this.lblPeríodo.Name = "lblPeríodo";
            this.lblPeríodo.Size = new System.Drawing.Size(67, 20);
            this.lblPeríodo.TabIndex = 2;
            this.lblPeríodo.Text = "Período:";
            // 
            // chkIntegral
            // 
            this.chkIntegral.AutoSize = true;
            this.chkIntegral.Location = new System.Drawing.Point(83, 74);
            this.chkIntegral.Name = "chkIntegral";
            this.chkIntegral.Size = new System.Drawing.Size(82, 24);
            this.chkIntegral.TabIndex = 2;
            this.chkIntegral.Text = "Integral";
            this.chkIntegral.UseVisualStyleBackColor = true;
            this.chkIntegral.CheckedChanged += new System.EventHandler(this.chkIntegral_CheckedChanged);
            // 
            // chkParcial
            // 
            this.chkParcial.AutoSize = true;
            this.chkParcial.Location = new System.Drawing.Point(195, 74);
            this.chkParcial.Name = "chkParcial";
            this.chkParcial.Size = new System.Drawing.Size(75, 24);
            this.chkParcial.TabIndex = 3;
            this.chkParcial.Text = "Parcial";
            this.chkParcial.UseVisualStyleBackColor = true;
            this.chkParcial.CheckedChanged += new System.EventHandler(this.chkParcial_CheckedChanged);
            // 
            // chkManha
            // 
            this.chkManha.AutoSize = true;
            this.chkManha.Location = new System.Drawing.Point(83, 104);
            this.chkManha.Name = "chkManha";
            this.chkManha.Size = new System.Drawing.Size(77, 24);
            this.chkManha.TabIndex = 4;
            this.chkManha.Text = "Manhã";
            this.chkManha.UseVisualStyleBackColor = true;
            this.chkManha.CheckedChanged += new System.EventHandler(this.chkManha_CheckedChanged);
            // 
            // chkTarde
            // 
            this.chkTarde.AutoSize = true;
            this.chkTarde.Location = new System.Drawing.Point(195, 104);
            this.chkTarde.Name = "chkTarde";
            this.chkTarde.Size = new System.Drawing.Size(69, 24);
            this.chkTarde.TabIndex = 5;
            this.chkTarde.Text = "Tarde";
            this.chkTarde.UseVisualStyleBackColor = true;
            this.chkTarde.CheckedChanged += new System.EventHandler(this.chkTarde_CheckedChanged);
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(39, 135);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(70, 20);
            this.lblDe.TabIndex = 7;
            this.lblDe.Text = "Das(de):";
            this.lblDe.Visible = false;
            // 
            // lblAt
            // 
            this.lblAt.AutoSize = true;
            this.lblAt.Location = new System.Drawing.Point(167, 135);
            this.lblAt.Name = "lblAt";
            this.lblAt.Size = new System.Drawing.Size(38, 20);
            this.lblAt.TabIndex = 8;
            this.lblAt.Text = "Até:";
            this.lblAt.Visible = false;
            // 
            // mskDe
            // 
            this.mskDe.Location = new System.Drawing.Point(115, 132);
            this.mskDe.Mask = "00:00";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(46, 26);
            this.mskDe.TabIndex = 9;
            this.mskDe.Visible = false;
            // 
            // mskAte
            // 
            this.mskAte.Location = new System.Drawing.Point(211, 132);
            this.mskAte.Mask = "00:00";
            this.mskAte.Name = "mskAte";
            this.mskAte.Size = new System.Drawing.Size(49, 26);
            this.mskAte.TabIndex = 10;
            this.mskAte.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data:";
            // 
            // mskData
            // 
            this.mskData.Enabled = false;
            this.mskData.Location = new System.Drawing.Point(67, 170);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(98, 26);
            this.mskData.TabIndex = 6;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(4, 212);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(283, 43);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnRelat
            // 
            this.btnRelat.BackColor = System.Drawing.Color.White;
            this.btnRelat.Location = new System.Drawing.Point(4, 261);
            this.btnRelat.Name = "btnRelat";
            this.btnRelat.Size = new System.Drawing.Size(283, 43);
            this.btnRelat.TabIndex = 8;
            this.btnRelat.Text = "Relatório de Faltas";
            this.btnRelat.UseVisualStyleBackColor = false;
            this.btnRelat.Click += new System.EventHandler(this.btnRelat_Click);
            // 
            // frmFalta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(296, 316);
            this.Controls.Add(this.btnRelat);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskAte);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.lblAt);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.chkTarde);
            this.Controls.Add(this.chkManha);
            this.Controls.Add(this.chkParcial);
            this.Controls.Add(this.chkIntegral);
            this.Controls.Add(this.lblPeríodo);
            this.Controls.Add(this.cmbNome);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmFalta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faltas";
            this.Load += new System.EventHandler(this.frmFalta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFalta_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNome;
        private System.Windows.Forms.Label lblPeríodo;
        private System.Windows.Forms.CheckBox chkIntegral;
        private System.Windows.Forms.CheckBox chkParcial;
        private System.Windows.Forms.CheckBox chkManha;
        private System.Windows.Forms.CheckBox chkTarde;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblAt;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.MaskedTextBox mskAte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRelat;
    }
}