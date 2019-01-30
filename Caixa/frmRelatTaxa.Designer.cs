namespace Caixa
{
    partial class frmRelatTaxa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatTaxa));
            this.gvExibir = new System.Windows.Forms.DataGridView();
            this.btnPaideFamilia = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mskAté = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDe = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCart = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBandeira = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCredito = new System.Windows.Forms.Label();
            this.lblCred = new System.Windows.Forms.Label();
            this.lblDebito = new System.Windows.Forms.Label();
            this.lblDeb = new System.Windows.Forms.Label();
            this.lblVR = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblSodexo = new System.Windows.Forms.Label();
            this.lblSod = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblTic = new System.Windows.Forms.Label();
            this.lblAlelo = new System.Windows.Forms.Label();
            this.lblAle = new System.Windows.Forms.Label();
            this.lblPlcard = new System.Windows.Forms.Label();
            this.lblSoft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibir)).BeginInit();
            this.SuspendLayout();
            // 
            // gvExibir
            // 
            this.gvExibir.AllowUserToAddRows = false;
            this.gvExibir.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.gvExibir, "gvExibir");
            this.gvExibir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExibir.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvExibir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibir.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gvExibir.Name = "gvExibir";
            this.gvExibir.ReadOnly = true;
            // 
            // btnPaideFamilia
            // 
            resources.ApplyResources(this.btnPaideFamilia, "btnPaideFamilia");
            this.btnPaideFamilia.BackColor = System.Drawing.Color.White;
            this.btnPaideFamilia.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatAppearance.BorderSize = 2;
            this.btnPaideFamilia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnPaideFamilia.Image = global::Caixa.Properties.Resources.adobe_pdf_document_14979__1_;
            this.btnPaideFamilia.Name = "btnPaideFamilia";
            this.btnPaideFamilia.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.Image = global::Caixa.Properties.Resources.document_microsoft_excel_15023;
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // mskAté
            // 
            resources.ApplyResources(this.mskAté, "mskAté");
            this.mskAté.Name = "mskAté";
            this.mskAté.TextChanged += new System.EventHandler(this.mskAté_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // mskDe
            // 
            resources.ApplyResources(this.mskDe, "mskDe");
            this.mskDe.Name = "mskDe";
            this.mskDe.TextChanged += new System.EventHandler(this.mskDe_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmbCart
            // 
            this.cmbCart.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCart, "cmbCart");
            this.cmbCart.Name = "cmbCart";
            this.cmbCart.SelectedIndexChanged += new System.EventHandler(this.cmbCart_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cmbBandeira
            // 
            this.cmbBandeira.FormattingEnabled = true;
            resources.ApplyResources(this.cmbBandeira, "cmbBandeira");
            this.cmbBandeira.Name = "cmbBandeira";
            this.cmbBandeira.SelectedIndexChanged += new System.EventHandler(this.cmbBandeira_SelectedIndexChanged);
            this.cmbBandeira.TextChanged += new System.EventHandler(this.cmbBandeira_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.Name = "lblTotal";
            // 
            // lblCredito
            // 
            resources.ApplyResources(this.lblCredito, "lblCredito");
            this.lblCredito.Name = "lblCredito";
            // 
            // lblCred
            // 
            resources.ApplyResources(this.lblCred, "lblCred");
            this.lblCred.Name = "lblCred";
            // 
            // lblDebito
            // 
            resources.ApplyResources(this.lblDebito, "lblDebito");
            this.lblDebito.Name = "lblDebito";
            // 
            // lblDeb
            // 
            resources.ApplyResources(this.lblDeb, "lblDeb");
            this.lblDeb.Name = "lblDeb";
            // 
            // lblVR
            // 
            resources.ApplyResources(this.lblVR, "lblVR");
            this.lblVR.Name = "lblVR";
            // 
            // lblV
            // 
            resources.ApplyResources(this.lblV, "lblV");
            this.lblV.Name = "lblV";
            // 
            // lblSodexo
            // 
            resources.ApplyResources(this.lblSodexo, "lblSodexo");
            this.lblSodexo.Name = "lblSodexo";
            // 
            // lblSod
            // 
            resources.ApplyResources(this.lblSod, "lblSod");
            this.lblSod.Name = "lblSod";
            // 
            // lblTicket
            // 
            resources.ApplyResources(this.lblTicket, "lblTicket");
            this.lblTicket.Name = "lblTicket";
            // 
            // lblTic
            // 
            resources.ApplyResources(this.lblTic, "lblTic");
            this.lblTic.Name = "lblTic";
            // 
            // lblAlelo
            // 
            resources.ApplyResources(this.lblAlelo, "lblAlelo");
            this.lblAlelo.Name = "lblAlelo";
            // 
            // lblAle
            // 
            resources.ApplyResources(this.lblAle, "lblAle");
            this.lblAle.Name = "lblAle";
            // 
            // lblPlcard
            // 
            resources.ApplyResources(this.lblPlcard, "lblPlcard");
            this.lblPlcard.Name = "lblPlcard";
            // 
            // lblSoft
            // 
            resources.ApplyResources(this.lblSoft, "lblSoft");
            this.lblSoft.Name = "lblSoft";
            // 
            // frmRelatTaxa
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cmbBandeira);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCart);
            this.Controls.Add(this.gvExibir);
            this.Controls.Add(this.btnPaideFamilia);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskAté);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskDe);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "frmRelatTaxa";
            this.Load += new System.EventHandler(this.frmRelatTaxa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelatTaxa_KeyDown);
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
        private System.Windows.Forms.ComboBox cmbCart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBandeira;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label lblCred;
        private System.Windows.Forms.Label lblDebito;
        private System.Windows.Forms.Label lblDeb;
        private System.Windows.Forms.Label lblVR;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblSodexo;
        private System.Windows.Forms.Label lblSod;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblTic;
        private System.Windows.Forms.Label lblAlelo;
        private System.Windows.Forms.Label lblAle;
        private System.Windows.Forms.Label lblPlcard;
        private System.Windows.Forms.Label lblSoft;
    }
}