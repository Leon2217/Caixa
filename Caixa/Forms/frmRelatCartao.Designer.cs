namespace Caixa
{
    partial class frmRelatCartao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatCartao));
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBandeira = new System.Windows.Forms.ComboBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.cmbMaquina = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCartao = new System.Windows.Forms.ComboBox();
            this.btnTaxa = new System.Windows.Forms.Button();
            this.lblSoft = new System.Windows.Forms.Label();
            this.lblPlcard = new System.Windows.Forms.Label();
            this.lblAlelo = new System.Windows.Forms.Label();
            this.lblAle = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblTic = new System.Windows.Forms.Label();
            this.lblSodexo = new System.Windows.Forms.Label();
            this.lblSod = new System.Windows.Forms.Label();
            this.lblVR = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblDebito = new System.Windows.Forms.Label();
            this.lblDeb = new System.Windows.Forms.Label();
            this.lblCredito = new System.Windows.Forms.Label();
            this.lblCred = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            this.gvExibir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExibir.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvExibir.Location = new System.Drawing.Point(12, 114);
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            this.gvExibir.Size = new System.Drawing.Size(698, 365);
            this.gvExibir.TabIndex = 22;
            // 
            // btnPaideFamilia
            // 
            this.btnPaideFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatAppearance.BorderSize = 2;
            this.btnPaideFamilia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaideFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Location = new System.Drawing.Point(716, 15);
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.Size = new System.Drawing.Size(178, 60);
            this.btnPaideFamilia.TabIndex = 17;
            this.btnPaideFamilia.Text = "Gerar .PDF";
            this.btnPaideFamilia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPaideFamilia.UseVisualStyleBackColor = false;
            this.btnPaideFamilia.Click += new System.EventHandler(this.btnPaideFamilia_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Location = new System.Drawing.Point(716, 80);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(178, 60);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Gerar Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bandeira:";
            // 
            // mskAté
            // 
            this.mskAté.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAté.Location = new System.Drawing.Point(216, 12);
            this.mskAté.Mask = "00/00/0000";
            this.mskAté.Name = "mskAté";
            this.mskAté.Size = new System.Drawing.Size(100, 26);
            this.mskAté.TabIndex = 15;
            this.mskAté.TextChanged += new System.EventHandler(this.mskAté_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Até";
            // 
            // mskDe
            // 
            this.mskDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDe.Location = new System.Drawing.Point(48, 12);
            this.mskDe.Mask = "00/00/0000";
            this.mskDe.Name = "mskDe";
            this.mskDe.Size = new System.Drawing.Size(100, 26);
            this.mskDe.TabIndex = 14;
            this.mskDe.TextChanged += new System.EventHandler(this.mskDe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "De:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Turno:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Máquina:";
            // 
            // cmbBandeira
            // 
            this.cmbBandeira.FormattingEnabled = true;
            this.cmbBandeira.Location = new System.Drawing.Point(91, 46);
            this.cmbBandeira.Name = "cmbBandeira";
            this.cmbBandeira.Size = new System.Drawing.Size(225, 28);
            this.cmbBandeira.TabIndex = 25;
            this.cmbBandeira.SelectedIndexChanged += new System.EventHandler(this.cmbBandeira_SelectedIndexChanged);
            this.cmbBandeira.TextChanged += new System.EventHandler(this.cmbBandeira_TextChanged);
            // 
            // cmbTurno
            // 
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Items.AddRange(new object[] {
            "Manhã",
            "Tarde"});
            this.cmbTurno.Location = new System.Drawing.Point(91, 80);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(225, 28);
            this.cmbTurno.TabIndex = 26;
            this.cmbTurno.SelectedIndexChanged += new System.EventHandler(this.cmbTurno_SelectedIndexChanged);
            // 
            // cmbMaquina
            // 
            this.cmbMaquina.FormattingEnabled = true;
            this.cmbMaquina.Location = new System.Drawing.Point(485, 80);
            this.cmbMaquina.Name = "cmbMaquina";
            this.cmbMaquina.Size = new System.Drawing.Size(225, 28);
            this.cmbMaquina.TabIndex = 27;
            this.cmbMaquina.SelectedIndexChanged += new System.EventHandler(this.cmbMaquina_SelectedIndexChanged);
            this.cmbMaquina.TextChanged += new System.EventHandler(this.cmbMaquina_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cartão:";
            // 
            // cmbCartao
            // 
            this.cmbCartao.FormattingEnabled = true;
            this.cmbCartao.Location = new System.Drawing.Point(485, 46);
            this.cmbCartao.Name = "cmbCartao";
            this.cmbCartao.Size = new System.Drawing.Size(225, 28);
            this.cmbCartao.TabIndex = 29;
            this.cmbCartao.SelectedIndexChanged += new System.EventHandler(this.cmbCartao_SelectedIndexChanged);
            this.cmbCartao.TextChanged += new System.EventHandler(this.cmbCartao_TextChanged);
            // 
            // btnTaxa
            // 
            this.btnTaxa.BackColor = System.Drawing.Color.White;
            this.btnTaxa.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnTaxa.FlatAppearance.BorderSize = 2;
            this.btnTaxa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTaxa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnTaxa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaxa.Location = new System.Drawing.Point(716, 419);
            this.btnTaxa.Name = "btnTaxa";
            this.btnTaxa.Size = new System.Drawing.Size(178, 60);
            this.btnTaxa.TabIndex = 30;
            this.btnTaxa.Text = "F10 - Relatório Taxa";
            this.btnTaxa.UseVisualStyleBackColor = false;
            this.btnTaxa.Click += new System.EventHandler(this.btnTaxa_Click);
            // 
            // lblSoft
            // 
            this.lblSoft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSoft.AutoSize = true;
            this.lblSoft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSoft.Location = new System.Drawing.Point(526, 517);
            this.lblSoft.Name = "lblSoft";
            this.lblSoft.Size = new System.Drawing.Size(0, 20);
            this.lblSoft.TabIndex = 57;
            // 
            // lblPlcard
            // 
            this.lblPlcard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlcard.AutoSize = true;
            this.lblPlcard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlcard.Location = new System.Drawing.Point(526, 497);
            this.lblPlcard.Name = "lblPlcard";
            this.lblPlcard.Size = new System.Drawing.Size(84, 20);
            this.lblPlcard.TabIndex = 56;
            this.lblPlcard.Text = "SOFTNEX";
            // 
            // lblAlelo
            // 
            this.lblAlelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAlelo.AutoSize = true;
            this.lblAlelo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAlelo.Location = new System.Drawing.Point(189, 542);
            this.lblAlelo.Name = "lblAlelo";
            this.lblAlelo.Size = new System.Drawing.Size(61, 20);
            this.lblAlelo.TabIndex = 55;
            this.lblAlelo.Text = "ALELO";
            // 
            // lblAle
            // 
            this.lblAle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAle.AutoSize = true;
            this.lblAle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAle.Location = new System.Drawing.Point(189, 562);
            this.lblAle.Name = "lblAle";
            this.lblAle.Size = new System.Drawing.Size(0, 20);
            this.lblAle.TabIndex = 54;
            // 
            // lblTicket
            // 
            this.lblTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTicket.AutoSize = true;
            this.lblTicket.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTicket.Location = new System.Drawing.Point(365, 497);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(64, 20);
            this.lblTicket.TabIndex = 53;
            this.lblTicket.Text = "TICKET";
            // 
            // lblTic
            // 
            this.lblTic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTic.AutoSize = true;
            this.lblTic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTic.Location = new System.Drawing.Point(365, 517);
            this.lblTic.Name = "lblTic";
            this.lblTic.Size = new System.Drawing.Size(0, 20);
            this.lblTic.TabIndex = 52;
            // 
            // lblSodexo
            // 
            this.lblSodexo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSodexo.AutoSize = true;
            this.lblSodexo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSodexo.Location = new System.Drawing.Point(365, 542);
            this.lblSodexo.Name = "lblSodexo";
            this.lblSodexo.Size = new System.Drawing.Size(78, 20);
            this.lblSodexo.TabIndex = 51;
            this.lblSodexo.Text = "SODEXO";
            // 
            // lblSod
            // 
            this.lblSod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSod.AutoSize = true;
            this.lblSod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSod.Location = new System.Drawing.Point(365, 562);
            this.lblSod.Name = "lblSod";
            this.lblSod.Size = new System.Drawing.Size(0, 20);
            this.lblSod.TabIndex = 50;
            // 
            // lblVR
            // 
            this.lblVR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVR.AutoSize = true;
            this.lblVR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVR.Location = new System.Drawing.Point(8, 542);
            this.lblVR.Name = "lblVR";
            this.lblVR.Size = new System.Drawing.Size(32, 20);
            this.lblVR.TabIndex = 49;
            this.lblVR.Text = "VR";
            // 
            // lblV
            // 
            this.lblV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblV.AutoSize = true;
            this.lblV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblV.Location = new System.Drawing.Point(8, 562);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(0, 20);
            this.lblV.TabIndex = 48;
            // 
            // lblDebito
            // 
            this.lblDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDebito.AutoSize = true;
            this.lblDebito.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDebito.Location = new System.Drawing.Point(189, 497);
            this.lblDebito.Name = "lblDebito";
            this.lblDebito.Size = new System.Drawing.Size(69, 20);
            this.lblDebito.TabIndex = 47;
            this.lblDebito.Text = "DÉBITO";
            // 
            // lblDeb
            // 
            this.lblDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeb.AutoSize = true;
            this.lblDeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDeb.Location = new System.Drawing.Point(189, 517);
            this.lblDeb.Name = "lblDeb";
            this.lblDeb.Size = new System.Drawing.Size(0, 20);
            this.lblDeb.TabIndex = 46;
            // 
            // lblCredito
            // 
            this.lblCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCredito.AutoSize = true;
            this.lblCredito.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCredito.Location = new System.Drawing.Point(8, 497);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(81, 20);
            this.lblCredito.TabIndex = 45;
            this.lblCredito.Text = "CRÉDITO";
            // 
            // lblCred
            // 
            this.lblCred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCred.AutoSize = true;
            this.lblCred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCred.Location = new System.Drawing.Point(8, 517);
            this.lblCred.Name = "lblCred";
            this.lblCred.Size = new System.Drawing.Size(0, 20);
            this.lblCred.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(527, 542);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "**TOTAL**";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(527, 562);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 42;
            // 
            // frmRelatCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(899, 591);
            this.Controls.Add(this.lblSoft);
            this.Controls.Add(this.lblPlcard);
            this.Controls.Add(this.lblAlelo);
            this.Controls.Add(this.lblAle);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.lblTic);
            this.Controls.Add(this.lblSodexo);
            this.Controls.Add(this.lblSod);
            this.Controls.Add(this.lblVR);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.lblDebito);
            this.Controls.Add(this.lblDeb);
            this.Controls.Add(this.lblCredito);
            this.Controls.Add(this.lblCred);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnTaxa);
            this.Controls.Add(this.cmbCartao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMaquina);
            this.Controls.Add(this.cmbTurno);
            this.Controls.Add(this.cmbBandeira);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRelatCartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Relatório de vendas de Cartões";
            this.Load += new System.EventHandler(this.frmRelatCartao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelatCartao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvExibir;
        private System.Windows.Forms.Button btnPaideFamilia;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskAté;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBandeira;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.ComboBox cmbMaquina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCartao;
        private System.Windows.Forms.Button btnTaxa;
        private System.Windows.Forms.Label lblSoft;
        private System.Windows.Forms.Label lblPlcard;
        private System.Windows.Forms.Label lblAlelo;
        private System.Windows.Forms.Label lblAle;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblTic;
        private System.Windows.Forms.Label lblSodexo;
        private System.Windows.Forms.Label lblSod;
        private System.Windows.Forms.Label lblVR;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblDebito;
        private System.Windows.Forms.Label lblDeb;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label lblCred;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
    }
}