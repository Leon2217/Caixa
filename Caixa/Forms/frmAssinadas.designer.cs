namespace Caixa
{
    partial class frmAssinadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssinadas));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssinada = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblJulio = new System.Windows.Forms.Label();
            this.txtJulio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Assinadas:";
            // 
            // txtAssinada
            // 
            this.txtAssinada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssinada.Location = new System.Drawing.Point(120, 12);
            this.txtAssinada.Name = "txtAssinada";
            this.txtAssinada.Size = new System.Drawing.Size(100, 26);
            this.txtAssinada.TabIndex = 5;
            this.txtAssinada.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            this.txtAssinada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssinada_KeyDown);
            this.txtAssinada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(12, 47);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(52, 20);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Class:";
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
            this.btnSalvar.Location = new System.Drawing.Point(16, 108);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(204, 43);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtClass
            // 
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(120, 44);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 26);
            this.txtClass.TabIndex = 7;
            this.txtClass.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClass_KeyDown);
            this.txtClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblJulio
            // 
            this.lblJulio.AutoSize = true;
            this.lblJulio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJulio.Location = new System.Drawing.Point(12, 79);
            this.lblJulio.Name = "lblJulio";
            this.lblJulio.Size = new System.Drawing.Size(102, 20);
            this.lblJulio.TabIndex = 8;
            this.lblJulio.Text = "Júlio Simões:";
            // 
            // txtJulio
            // 
            this.txtJulio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJulio.Location = new System.Drawing.Point(120, 76);
            this.txtJulio.Name = "txtJulio";
            this.txtJulio.Size = new System.Drawing.Size(100, 26);
            this.txtJulio.TabIndex = 9;
            this.txtJulio.TextChanged += new System.EventHandler(this.txtJulio_TextChanged);
            this.txtJulio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJulio_KeyDown);
            this.txtJulio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJulio_KeyPress);
            // 
            // frmAssinadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(238, 167);
            this.Controls.Add(this.txtJulio);
            this.Controls.Add(this.lblJulio);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAssinada);
            this.Controls.Add(this.lblClass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAssinadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Valor das assinadas";
            this.Load += new System.EventHandler(this.frmAssinadas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAssinadas_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAssinadas_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAssinada;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblJulio;
        private System.Windows.Forms.TextBox txtJulio;
    }
}