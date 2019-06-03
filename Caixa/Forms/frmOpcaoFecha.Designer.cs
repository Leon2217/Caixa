namespace Caixa
{
    partial class frmOpcaoFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcaoFecha));
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValorRelat = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnGaveta = new System.Windows.Forms.Button();
            this.btnSuprimento = new System.Windows.Forms.Button();
            this.btnFiado = new System.Windows.Forms.Button();
            this.btnCartão = new System.Windows.Forms.Button();
            this.btnDinheiro = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblDif = new System.Windows.Forms.Label();
            this.btnValor = new System.Windows.Forms.Button();
            this.lblVendaLq = new System.Windows.Forms.Label();
            this.lblValorVendaLq = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(660, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 20);
            this.label10.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 24);
            this.label11.TabIndex = 19;
            this.label11.Text = "Valor caixa relatório:";
            // 
            // txtValorRelat
            // 
            this.txtValorRelat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRelat.Location = new System.Drawing.Point(198, 206);
            this.txtValorRelat.Name = "txtValorRelat";
            this.txtValorRelat.Size = new System.Drawing.Size(115, 29);
            this.txtValorRelat.TabIndex = 20;
            this.txtValorRelat.TextChanged += new System.EventHandler(this.txtValorRelat_TextChanged);
            this.txtValorRelat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorRelat_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(319, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 24);
            this.label12.TabIndex = 21;
            this.label12.Text = "R$";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltar.FlatAppearance.BorderSize = 3;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = global::Caixa.Properties.Resources._1489436625_chartmoneydollarcurrency_81885;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.Location = new System.Drawing.Point(480, 102);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(228, 84);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "[F6] - Relatório de Diferença";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnGaveta
            // 
            this.btnGaveta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGaveta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGaveta.FlatAppearance.BorderSize = 3;
            this.btnGaveta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnGaveta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaveta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaveta.Image = global::Caixa.Properties.Resources.Accounting_icon_icons_com_74682__1_;
            this.btnGaveta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGaveta.Location = new System.Drawing.Point(246, 12);
            this.btnGaveta.Name = "btnGaveta";
            this.btnGaveta.Size = new System.Drawing.Size(228, 84);
            this.btnGaveta.TabIndex = 2;
            this.btnGaveta.Text = "F2 - Dinheiro Gaveta";
            this.btnGaveta.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGaveta.UseVisualStyleBackColor = false;
            this.btnGaveta.Click += new System.EventHandler(this.btnGaveta_Click);
            // 
            // btnSuprimento
            // 
            this.btnSuprimento.BackColor = System.Drawing.Color.White;
            this.btnSuprimento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuprimento.FlatAppearance.BorderSize = 3;
            this.btnSuprimento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnSuprimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuprimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuprimento.Image = global::Caixa.Properties.Resources._1486564179_finance_saving_81499;
            this.btnSuprimento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuprimento.Location = new System.Drawing.Point(246, 102);
            this.btnSuprimento.Name = "btnSuprimento";
            this.btnSuprimento.Size = new System.Drawing.Size(228, 84);
            this.btnSuprimento.TabIndex = 5;
            this.btnSuprimento.Text = "F5 - Suprimento";
            this.btnSuprimento.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSuprimento.UseVisualStyleBackColor = false;
            this.btnSuprimento.Click += new System.EventHandler(this.btnSuprimento_Click);
            // 
            // btnFiado
            // 
            this.btnFiado.BackColor = System.Drawing.Color.White;
            this.btnFiado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFiado.FlatAppearance.BorderSize = 3;
            this.btnFiado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnFiado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiado.Image = global::Caixa.Properties.Resources.business_color_money_time_icon_icons_com_53444;
            this.btnFiado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiado.Location = new System.Drawing.Point(12, 102);
            this.btnFiado.Name = "btnFiado";
            this.btnFiado.Size = new System.Drawing.Size(228, 84);
            this.btnFiado.TabIndex = 4;
            this.btnFiado.Text = "F4 - Assinadas";
            this.btnFiado.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFiado.UseVisualStyleBackColor = false;
            this.btnFiado.Click += new System.EventHandler(this.btnFiado_Click);
            // 
            // btnCartão
            // 
            this.btnCartão.BackColor = System.Drawing.Color.White;
            this.btnCartão.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCartão.FlatAppearance.BorderSize = 3;
            this.btnCartão.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCartão.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartão.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.btnCartão.Image = global::Caixa.Properties.Resources.businesspaymentcard_paymentcard_visa_negocio_pag_2339;
            this.btnCartão.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCartão.Location = new System.Drawing.Point(480, 12);
            this.btnCartão.Name = "btnCartão";
            this.btnCartão.Size = new System.Drawing.Size(228, 84);
            this.btnCartão.TabIndex = 3;
            this.btnCartão.Text = "F3 - Cartão";
            this.btnCartão.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCartão.UseVisualStyleBackColor = false;
            this.btnCartão.Click += new System.EventHandler(this.btnCartão_Click);
            // 
            // btnDinheiro
            // 
            this.btnDinheiro.BackColor = System.Drawing.Color.White;
            this.btnDinheiro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDinheiro.FlatAppearance.BorderSize = 3;
            this.btnDinheiro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnDinheiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinheiro.Image = global::Caixa.Properties.Resources.cash_icon_icons_com_51090;
            this.btnDinheiro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDinheiro.Location = new System.Drawing.Point(12, 12);
            this.btnDinheiro.Name = "btnDinheiro";
            this.btnDinheiro.Size = new System.Drawing.Size(228, 84);
            this.btnDinheiro.TabIndex = 1;
            this.btnDinheiro.Text = "F1 - Dinheiro retirada";
            this.btnDinheiro.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDinheiro.UseVisualStyleBackColor = false;
            this.btnDinheiro.Click += new System.EventHandler(this.btnDinheiro_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalvar.FlatAppearance.BorderSize = 3;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(358, 201);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(116, 39);
            this.btnSalvar.TabIndex = 22;
            this.btnSalvar.Text = "F10 - Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblDif
            // 
            this.lblDif.AutoSize = true;
            this.lblDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDif.Location = new System.Drawing.Point(504, 212);
            this.lblDif.Name = "lblDif";
            this.lblDif.Size = new System.Drawing.Size(0, 20);
            this.lblDif.TabIndex = 23;
            // 
            // btnValor
            // 
            this.btnValor.BackColor = System.Drawing.Color.White;
            this.btnValor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnValor.FlatAppearance.BorderSize = 3;
            this.btnValor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValor.Location = new System.Drawing.Point(358, 245);
            this.btnValor.Name = "btnValor";
            this.btnValor.Size = new System.Drawing.Size(116, 39);
            this.btnValor.TabIndex = 25;
            this.btnValor.Text = "Enviar retirada";
            this.btnValor.UseVisualStyleBackColor = false;
            this.btnValor.Click += new System.EventHandler(this.btnValor_Click);
            // 
            // lblVendaLq
            // 
            this.lblVendaLq.AutoSize = true;
            this.lblVendaLq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendaLq.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblVendaLq.Location = new System.Drawing.Point(12, 251);
            this.lblVendaLq.Name = "lblVendaLq";
            this.lblVendaLq.Size = new System.Drawing.Size(131, 24);
            this.lblVendaLq.TabIndex = 26;
            this.lblVendaLq.Text = "Venda líquida:";
            this.lblVendaLq.Visible = false;
            // 
            // lblValorVendaLq
            // 
            this.lblValorVendaLq.AutoSize = true;
            this.lblValorVendaLq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVendaLq.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblValorVendaLq.Location = new System.Drawing.Point(138, 251);
            this.lblValorVendaLq.Name = "lblValorVendaLq";
            this.lblValorVendaLq.Size = new System.Drawing.Size(0, 24);
            this.lblValorVendaLq.TabIndex = 27;
            this.lblValorVendaLq.Visible = false;
            // 
            // frmOpcaoFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(718, 292);
            this.Controls.Add(this.lblValorVendaLq);
            this.Controls.Add(this.lblVendaLq);
            this.Controls.Add(this.btnValor);
            this.Controls.Add(this.lblDif);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnGaveta);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtValorRelat);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSuprimento);
            this.Controls.Add(this.btnFiado);
            this.Controls.Add(this.btnCartão);
            this.Controls.Add(this.btnDinheiro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmOpcaoFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Conferência de fechamento";
            this.Load += new System.EventHandler(this.frmOpcaoFecha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOpcaoFecha_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDinheiro;
        private System.Windows.Forms.Button btnCartão;
        private System.Windows.Forms.Button btnFiado;
        private System.Windows.Forms.Button btnSuprimento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtValorRelat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGaveta;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblDif;
        private System.Windows.Forms.Button btnValor;
        private System.Windows.Forms.Label lblVendaLq;
        private System.Windows.Forms.Label lblValorVendaLq;
    }
}