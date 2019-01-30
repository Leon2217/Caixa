namespace Caixa
{
    partial class frmPesquisaPessoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaPessoa));
            this.lblFantasia = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFornecimento = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.chkIe = new System.Windows.Forms.CheckBox();
            this.txtIe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUf = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mskCep = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProx = new System.Windows.Forms.Button();
            this.btnAnt = new System.Windows.Forms.Button();
            this.txtPesqNome = new System.Windows.Forms.TextBox();
            this.lblNomee = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.mskCnpjPesquisa = new System.Windows.Forms.MaskedTextBox();
            this.mskCpfPesquisa = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpjPesq = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.btnGrid = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtRs = new System.Windows.Forms.TextBox();
            this.lblRs = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFisJur = new System.Windows.Forms.Label();
            this.cmbTipo4 = new System.Windows.Forms.ComboBox();
            this.cmbTipo3 = new System.Windows.Forms.ComboBox();
            this.cmbTipo1 = new System.Windows.Forms.ComboBox();
            this.cmbTipo2 = new System.Windows.Forms.ComboBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mskTel = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mskCel = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkNome = new System.Windows.Forms.CheckBox();
            this.chkCpfCnpj = new System.Windows.Forms.CheckBox();
            this.lblCpfNj = new System.Windows.Forms.Label();
            this.txtCpfnj = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFantasia
            // 
            this.lblFantasia.AutoSize = true;
            this.lblFantasia.Location = new System.Drawing.Point(326, 146);
            this.lblFantasia.Name = "lblFantasia";
            this.lblFantasia.Size = new System.Drawing.Size(75, 20);
            this.lblFantasia.TabIndex = 181;
            this.lblFantasia.Text = "Fantasia:";
            this.lblFantasia.Visible = false;
            // 
            // txtN
            // 
            this.txtN.Enabled = false;
            this.txtN.Location = new System.Drawing.Point(169, 285);
            this.txtN.MaxLength = 5;
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(81, 26);
            this.txtN.TabIndex = 164;
            this.txtN.TextChanged += new System.EventHandler(this.txtN_TextChanged);
            this.txtN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtN_KeyDown);
            this.txtN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtN_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(133, 288);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 20);
            this.label17.TabIndex = 180;
            this.label17.Text = "Nº:";
            // 
            // txtFornecimento
            // 
            this.txtFornecimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFornecimento.Enabled = false;
            this.txtFornecimento.Location = new System.Drawing.Point(451, 212);
            this.txtFornecimento.Name = "txtFornecimento";
            this.txtFornecimento.Size = new System.Drawing.Size(294, 26);
            this.txtFornecimento.TabIndex = 161;
            this.txtFornecimento.TextChanged += new System.EventHandler(this.txtFornecimento_TextChanged);
            this.txtFornecimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecimento_KeyDown);
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(451, 143);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(294, 26);
            this.txtNome.TabIndex = 159;
            this.txtNome.Visible = false;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(325, 146);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(55, 20);
            this.lblNome.TabIndex = 177;
            this.lblNome.Text = "Nome:";
            this.lblNome.Visible = false;
            // 
            // chkIe
            // 
            this.chkIe.AutoSize = true;
            this.chkIe.Enabled = false;
            this.chkIe.Location = new System.Drawing.Point(288, 213);
            this.chkIe.Name = "chkIe";
            this.chkIe.Size = new System.Drawing.Size(15, 14);
            this.chkIe.TabIndex = 176;
            this.chkIe.UseVisualStyleBackColor = true;
            this.chkIe.CheckedChanged += new System.EventHandler(this.chkIe_CheckedChanged);
            // 
            // txtIe
            // 
            this.txtIe.Enabled = false;
            this.txtIe.Location = new System.Drawing.Point(73, 207);
            this.txtIe.Name = "txtIe";
            this.txtIe.Size = new System.Drawing.Size(235, 26);
            this.txtIe.TabIndex = 158;
            this.txtIe.Text = "Isento";
            this.txtIe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIe_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 20);
            this.label9.TabIndex = 175;
            this.label9.Text = "IE:";
            // 
            // txtIm
            // 
            this.txtIm.Enabled = false;
            this.txtIm.Location = new System.Drawing.Point(73, 175);
            this.txtIm.Name = "txtIm";
            this.txtIm.Size = new System.Drawing.Size(235, 26);
            this.txtIm.TabIndex = 157;
            this.txtIm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIm_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 20);
            this.label8.TabIndex = 174;
            this.label8.Text = "IM:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 173;
            this.label7.Text = "Fornecimento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 172;
            this.label6.Text = "UF:";
            // 
            // txtUf
            // 
            this.txtUf.Enabled = false;
            this.txtUf.Location = new System.Drawing.Point(76, 285);
            this.txtUf.MaxLength = 2;
            this.txtUf.Name = "txtUf";
            this.txtUf.Size = new System.Drawing.Size(51, 26);
            this.txtUf.TabIndex = 163;
            this.txtUf.TextChanged += new System.EventHandler(this.txtUf_TextChanged);
            this.txtUf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUf_KeyDown);
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Location = new System.Drawing.Point(76, 317);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(304, 26);
            this.txtCidade.TabIndex = 165;
            this.txtCidade.TextChanged += new System.EventHandler(this.txtCidade_TextChanged);
            this.txtCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCidade_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 171;
            this.label4.Text = "Cidade:";
            // 
            // mskCep
            // 
            this.mskCep.Enabled = false;
            this.mskCep.Location = new System.Drawing.Point(76, 249);
            this.mskCep.Mask = "00000-000";
            this.mskCep.Name = "mskCep";
            this.mskCep.Size = new System.Drawing.Size(90, 26);
            this.mskCep.TabIndex = 162;
            this.mskCep.TextChanged += new System.EventHandler(this.mskCep_TextChanged);
            this.mskCep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCep_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 170;
            this.label3.Text = "CEP:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProx);
            this.groupBox1.Controls.Add(this.btnAnt);
            this.groupBox1.Controls.Add(this.txtPesqNome);
            this.groupBox1.Controls.Add(this.lblNomee);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.mskCnpjPesquisa);
            this.groupBox1.Controls.Add(this.mskCpfPesquisa);
            this.groupBox1.Controls.Add(this.lblCnpjPesq);
            this.groupBox1.Controls.Add(this.lblCpf);
            this.groupBox1.Controls.Add(this.btnGrid);
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.btnCadastrar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 99);
            this.groupBox1.TabIndex = 154;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pessoa";
            // 
            // btnProx
            // 
            this.btnProx.BackColor = System.Drawing.Color.White;
            this.btnProx.Enabled = false;
            this.btnProx.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnProx.FlatAppearance.BorderSize = 2;
            this.btnProx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnProx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnProx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProx.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnProx.Location = new System.Drawing.Point(307, 57);
            this.btnProx.Name = "btnProx";
            this.btnProx.Size = new System.Drawing.Size(109, 36);
            this.btnProx.TabIndex = 186;
            this.btnProx.Text = ">>";
            this.btnProx.UseVisualStyleBackColor = false;
            this.btnProx.Visible = false;
            this.btnProx.Click += new System.EventHandler(this.btnProx_Click);
            // 
            // btnAnt
            // 
            this.btnAnt.BackColor = System.Drawing.Color.White;
            this.btnAnt.Enabled = false;
            this.btnAnt.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnAnt.FlatAppearance.BorderSize = 2;
            this.btnAnt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnt.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnAnt.Location = new System.Drawing.Point(307, 15);
            this.btnAnt.Name = "btnAnt";
            this.btnAnt.Size = new System.Drawing.Size(109, 36);
            this.btnAnt.TabIndex = 185;
            this.btnAnt.Text = "<<";
            this.btnAnt.UseVisualStyleBackColor = false;
            this.btnAnt.Visible = false;
            this.btnAnt.Click += new System.EventHandler(this.btnAnt_Click);
            // 
            // txtPesqNome
            // 
            this.txtPesqNome.Location = new System.Drawing.Point(71, 44);
            this.txtPesqNome.Name = "txtPesqNome";
            this.txtPesqNome.Size = new System.Drawing.Size(154, 26);
            this.txtPesqNome.TabIndex = 184;
            this.txtPesqNome.Visible = false;
            this.txtPesqNome.TextChanged += new System.EventHandler(this.txtPesqNome_TextChanged);
            // 
            // lblNomee
            // 
            this.lblNomee.AutoSize = true;
            this.lblNomee.Location = new System.Drawing.Point(14, 47);
            this.lblNomee.Name = "lblNomee";
            this.lblNomee.Size = new System.Drawing.Size(55, 20);
            this.lblNomee.TabIndex = 183;
            this.lblNomee.Text = "Nome:";
            this.lblNomee.Visible = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnExcluir.FlatAppearance.BorderSize = 2;
            this.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::Caixa.Properties.Resources.trashcan_full_icon_34338;
            this.btnExcluir.Location = new System.Drawing.Point(644, 21);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(80, 68);
            this.btnExcluir.TabIndex = 182;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // mskCnpjPesquisa
            // 
            this.mskCnpjPesquisa.Location = new System.Drawing.Point(73, 63);
            this.mskCnpjPesquisa.Mask = "00,000,000/0000-00";
            this.mskCnpjPesquisa.Name = "mskCnpjPesquisa";
            this.mskCnpjPesquisa.Size = new System.Drawing.Size(154, 26);
            this.mskCnpjPesquisa.TabIndex = 178;
            this.mskCnpjPesquisa.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mskCnpjPesquisa.Visible = false;
            this.mskCnpjPesquisa.TextChanged += new System.EventHandler(this.mskCnpjPesquisa_TextChanged);
            // 
            // mskCpfPesquisa
            // 
            this.mskCpfPesquisa.Location = new System.Drawing.Point(71, 28);
            this.mskCpfPesquisa.Mask = "000,000,000-00";
            this.mskCpfPesquisa.Name = "mskCpfPesquisa";
            this.mskCpfPesquisa.Size = new System.Drawing.Size(122, 26);
            this.mskCpfPesquisa.TabIndex = 179;
            this.mskCpfPesquisa.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mskCpfPesquisa.Visible = false;
            this.mskCpfPesquisa.TextChanged += new System.EventHandler(this.mskCpfPesquisa_TextChanged);
            this.mskCpfPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCpfPesquisa_KeyDown);
            // 
            // lblCnpjPesq
            // 
            this.lblCnpjPesq.AutoSize = true;
            this.lblCnpjPesq.Location = new System.Drawing.Point(14, 66);
            this.lblCnpjPesq.Name = "lblCnpjPesq";
            this.lblCnpjPesq.Size = new System.Drawing.Size(53, 20);
            this.lblCnpjPesq.TabIndex = 181;
            this.lblCnpjPesq.Text = "CNPJ:";
            this.lblCnpjPesq.Visible = false;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(14, 31);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(44, 20);
            this.lblCpf.TabIndex = 176;
            this.lblCpf.Text = "CPF:";
            this.lblCpf.Visible = false;
            // 
            // btnGrid
            // 
            this.btnGrid.BackColor = System.Drawing.Color.White;
            this.btnGrid.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnGrid.FlatAppearance.BorderSize = 2;
            this.btnGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrid.Image = global::Caixa.Properties.Resources.question_icon_icons1;
            this.btnGrid.Location = new System.Drawing.Point(234, 31);
            this.btnGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(42, 53);
            this.btnGrid.TabIndex = 26;
            this.btnGrid.UseVisualStyleBackColor = false;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnLimpar.FlatAppearance.BorderSize = 2;
            this.btnLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = global::Caixa.Properties.Resources.Cancel_icon_icons2;
            this.btnLimpar.Location = new System.Drawing.Point(556, 21);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(80, 68);
            this.btnLimpar.TabIndex = 25;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.White;
            this.btnCadastrar.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnCadastrar.FlatAppearance.BorderSize = 2;
            this.btnCadastrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCadastrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Image = global::Caixa.Properties.Resources.save_as_22027;
            this.btnCadastrar.Location = new System.Drawing.Point(468, 21);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(80, 68);
            this.btnCadastrar.TabIndex = 24;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtRs
            // 
            this.txtRs.Enabled = false;
            this.txtRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRs.Location = new System.Drawing.Point(451, 178);
            this.txtRs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRs.Name = "txtRs";
            this.txtRs.Size = new System.Drawing.Size(294, 26);
            this.txtRs.TabIndex = 160;
            this.txtRs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRs_KeyDown);
            // 
            // lblRs
            // 
            this.lblRs.AutoSize = true;
            this.lblRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRs.Location = new System.Drawing.Point(324, 181);
            this.lblRs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRs.Name = "lblRs";
            this.lblRs.Size = new System.Drawing.Size(104, 20);
            this.lblRs.TabIndex = 167;
            this.lblRs.Text = "Razão social:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblFisJur);
            this.groupBox2.Controls.Add(this.cmbTipo4);
            this.groupBox2.Controls.Add(this.cmbTipo3);
            this.groupBox2.Controls.Add(this.cmbTipo1);
            this.groupBox2.Controls.Add(this.cmbTipo2);
            this.groupBox2.Controls.Add(this.txtObs);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(397, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 226);
            this.groupBox2.TabIndex = 166;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categorias da pessoa:";
            // 
            // lblFisJur
            // 
            this.lblFisJur.AutoSize = true;
            this.lblFisJur.Location = new System.Drawing.Point(281, 207);
            this.lblFisJur.Name = "lblFisJur";
            this.lblFisJur.Size = new System.Drawing.Size(0, 20);
            this.lblFisJur.TabIndex = 194;
            // 
            // cmbTipo4
            // 
            this.cmbTipo4.Enabled = false;
            this.cmbTipo4.FormattingEnabled = true;
            this.cmbTipo4.Location = new System.Drawing.Point(188, 79);
            this.cmbTipo4.Name = "cmbTipo4";
            this.cmbTipo4.Size = new System.Drawing.Size(154, 28);
            this.cmbTipo4.TabIndex = 21;
            this.cmbTipo4.SelectedIndexChanged += new System.EventHandler(this.cmbTipo4_SelectedIndexChanged);
            this.cmbTipo4.TextChanged += new System.EventHandler(this.cmbTipo4_TextChanged);
            this.cmbTipo4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipo4_KeyDown);
            // 
            // cmbTipo3
            // 
            this.cmbTipo3.Enabled = false;
            this.cmbTipo3.FormattingEnabled = true;
            this.cmbTipo3.Location = new System.Drawing.Point(188, 45);
            this.cmbTipo3.Name = "cmbTipo3";
            this.cmbTipo3.Size = new System.Drawing.Size(154, 28);
            this.cmbTipo3.TabIndex = 19;
            this.cmbTipo3.SelectedIndexChanged += new System.EventHandler(this.cmbTipo3_SelectedIndexChanged);
            this.cmbTipo3.TextChanged += new System.EventHandler(this.cmbTipo3_TextChanged);
            this.cmbTipo3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipo3_KeyDown);
            // 
            // cmbTipo1
            // 
            this.cmbTipo1.Enabled = false;
            this.cmbTipo1.FormattingEnabled = true;
            this.cmbTipo1.Location = new System.Drawing.Point(6, 45);
            this.cmbTipo1.Name = "cmbTipo1";
            this.cmbTipo1.Size = new System.Drawing.Size(154, 28);
            this.cmbTipo1.TabIndex = 18;
            this.cmbTipo1.SelectedIndexChanged += new System.EventHandler(this.cmbTipo1_SelectedIndexChanged);
            this.cmbTipo1.TextChanged += new System.EventHandler(this.cmbTipo1_TextChanged);
            this.cmbTipo1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipo1_KeyDown);
            // 
            // cmbTipo2
            // 
            this.cmbTipo2.Enabled = false;
            this.cmbTipo2.FormattingEnabled = true;
            this.cmbTipo2.Location = new System.Drawing.Point(6, 79);
            this.cmbTipo2.Name = "cmbTipo2";
            this.cmbTipo2.Size = new System.Drawing.Size(154, 28);
            this.cmbTipo2.TabIndex = 20;
            this.cmbTipo2.SelectedIndexChanged += new System.EventHandler(this.cmbTipo2_SelectedIndexChanged);
            this.cmbTipo2.TextChanged += new System.EventHandler(this.cmbTipo2_TextChanged);
            this.cmbTipo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipo2_KeyDown);
            // 
            // txtObs
            // 
            this.txtObs.Enabled = false;
            this.txtObs.Location = new System.Drawing.Point(6, 138);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(333, 92);
            this.txtObs.TabIndex = 22;
            this.txtObs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObs_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 20);
            this.label10.TabIndex = 127;
            this.label10.Text = "Observações:";
            // 
            // mskTel
            // 
            this.mskTel.Enabled = false;
            this.mskTel.Location = new System.Drawing.Point(257, 445);
            this.mskTel.Mask = "(00)0000-0000";
            this.mskTel.Name = "mskTel";
            this.mskTel.Size = new System.Drawing.Size(124, 26);
            this.mskTel.TabIndex = 186;
            this.mskTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskTel_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(217, 448);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 20);
            this.label13.TabIndex = 191;
            this.label13.Text = "Tel:";
            // 
            // mskCel
            // 
            this.mskCel.Enabled = false;
            this.mskCel.Location = new System.Drawing.Point(77, 445);
            this.mskCel.Mask = "(00)00000-0000";
            this.mskCel.Name = "mskCel";
            this.mskCel.Size = new System.Drawing.Size(134, 26);
            this.mskCel.TabIndex = 185;
            this.mskCel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCel_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 448);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 20);
            this.label11.TabIndex = 190;
            this.label11.Text = "Cel:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(77, 413);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(304, 26);
            this.txtEmail.TabIndex = 184;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 189;
            this.label5.Text = "Email:";
            // 
            // txtRua
            // 
            this.txtRua.Enabled = false;
            this.txtRua.Location = new System.Drawing.Point(77, 381);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(304, 26);
            this.txtRua.TabIndex = 183;
            this.txtRua.TextChanged += new System.EventHandler(this.txtRua_TextChanged);
            this.txtRua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRua_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 188;
            this.label2.Text = "Rua:";
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Location = new System.Drawing.Point(77, 349);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(304, 26);
            this.txtBairro.TabIndex = 182;
            this.txtBairro.TextChanged += new System.EventHandler(this.txtBairro_TextChanged);
            this.txtBairro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBairro_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 187;
            this.label1.Text = "Bairro:";
            // 
            // chkNome
            // 
            this.chkNome.AutoSize = true;
            this.chkNome.Location = new System.Drawing.Point(76, 12);
            this.chkNome.Name = "chkNome";
            this.chkNome.Size = new System.Drawing.Size(166, 24);
            this.chkNome.TabIndex = 184;
            this.chkNome.Text = "Pesquisa por Nome";
            this.chkNome.UseVisualStyleBackColor = true;
            this.chkNome.CheckedChanged += new System.EventHandler(this.chkNome_CheckedChanged);
            // 
            // chkCpfCnpj
            // 
            this.chkCpfCnpj.AutoSize = true;
            this.chkCpfCnpj.Location = new System.Drawing.Point(272, 12);
            this.chkCpfCnpj.Name = "chkCpfCnpj";
            this.chkCpfCnpj.Size = new System.Drawing.Size(199, 24);
            this.chkCpfCnpj.TabIndex = 185;
            this.chkCpfCnpj.Text = "Pesquisa por CPF/CNPJ";
            this.chkCpfCnpj.UseVisualStyleBackColor = true;
            this.chkCpfCnpj.CheckedChanged += new System.EventHandler(this.chkCpfCnpj_CheckedChanged);
            // 
            // lblCpfNj
            // 
            this.lblCpfNj.AutoSize = true;
            this.lblCpfNj.Location = new System.Drawing.Point(6, 146);
            this.lblCpfNj.Name = "lblCpfNj";
            this.lblCpfNj.Size = new System.Drawing.Size(88, 20);
            this.lblCpfNj.TabIndex = 192;
            this.lblCpfNj.Text = "CPF/CNPJ:";
            this.lblCpfNj.Visible = false;
            // 
            // txtCpfnj
            // 
            this.txtCpfnj.Enabled = false;
            this.txtCpfnj.Location = new System.Drawing.Point(100, 143);
            this.txtCpfnj.Name = "txtCpfnj";
            this.txtCpfnj.Size = new System.Drawing.Size(208, 26);
            this.txtCpfnj.TabIndex = 193;
            this.txtCpfnj.Visible = false;
            this.txtCpfnj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCpfnj_KeyDown);
            // 
            // frmPesquisaPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(763, 483);
            this.Controls.Add(this.txtCpfnj);
            this.Controls.Add(this.lblCpfNj);
            this.Controls.Add(this.chkCpfCnpj);
            this.Controls.Add(this.mskTel);
            this.Controls.Add(this.chkNome);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mskCel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFantasia);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtFornecimento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.chkIe);
            this.Controls.Add(this.txtIe);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUf);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mskCep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRs);
            this.Controls.Add(this.lblRs);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmPesquisaPessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Pesquisa de Pessoa";
            this.Load += new System.EventHandler(this.frmPesquisaPessoa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPesquisaPessoa_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFantasia;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFornecimento;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.CheckBox chkIe;
        private System.Windows.Forms.TextBox txtIe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUf;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mskCep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtRs;
        private System.Windows.Forms.Label lblRs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTipo4;
        private System.Windows.Forms.ComboBox cmbTipo3;
        private System.Windows.Forms.ComboBox cmbTipo1;
        private System.Windows.Forms.ComboBox cmbTipo2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox mskTel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox mskCel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrid;
        private System.Windows.Forms.MaskedTextBox mskCnpjPesquisa;
        private System.Windows.Forms.MaskedTextBox mskCpfPesquisa;
        private System.Windows.Forms.Label lblCnpjPesq;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkNome;
        private System.Windows.Forms.CheckBox chkCpfCnpj;
        private System.Windows.Forms.Label lblNomee;
        private System.Windows.Forms.TextBox txtPesqNome;
        private System.Windows.Forms.Label lblCpfNj;
        private System.Windows.Forms.Button btnProx;
        private System.Windows.Forms.Button btnAnt;
        private System.Windows.Forms.TextBox txtCpfnj;
        private System.Windows.Forms.Label lblFisJur;
    }
}