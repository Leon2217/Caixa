using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Caixa
{
    public partial class Abertura : Form
    {
        FechamentoDAO fecDAO = new FechamentoDAO();
        Fechamento fec = new Fechamento();
        UsuarioDAO usuDao = new UsuarioDAO();
        Verificas ver = new Verificas();
        VerificaDAO verDAO = new VerificaDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        assinadaDAO assDAO = new assinadaDAO();

        string tipo;
        DateTime data;
        string codper;
        string login;
        DateTime data_hora;

        public Abertura()
        {
            InitializeComponent();
        }

        private void Abertura_Load(object sender, EventArgs e)
        {
                login = UsuarioDAO.login;
            usuDao.VerificaCargo(login);
            if (usuDao.Usu.Tipo == "Administrador")
            {
                txtUsu.Text = UsuarioDAO.login;
                login = txtUsu.Text;
                string datatela = DateTime.Now.ToShortDateString();
                mskData.Text = datatela;
                data = Convert.ToDateTime(mskData.Text);
                Height = 299;

            }
            else
            {
                txtUsu.Text = UsuarioDAO.login;
                login = txtUsu.Text;
                string datatela = DateTime.Now.ToShortDateString();
                mskData.Text = datatela;
                data = Convert.ToDateTime(mskData.Text);               
            }          
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {           
            if (cmbTurno.SelectedIndex == 0)
            {
                codper = "1";
            }

            if (cmbTurno.SelectedIndex == 1)
            {
                codper = "2";
            }

            if (cmbTurno.SelectedIndex == 2)
            {
                codper = "3";
            }
            login = UsuarioDAO.login;
            usuDao.VerificaCargo(login);
            tipo = usuDao.Usu.Tipo.ToString();

            if (tipo == "Administrador")
            {           
                if (fecDAO.Verifica(codper, data) == true)
                {
                    #region ABRIR ABERTO
                    login = UsuarioDAO.login;

                    usuDao.VerificaCargo(login);
                    tipo = usuDao.Usu.Tipo.ToString();

                    if (tipo == "Administrador")
                    {
                        fec.Responsavel = UsuarioDAO.login;                 
                        FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                        DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                        FechamentoDAO.data = fecDAO.Fec.Data;
                        FechamentoDAO.valor = fecDAO.Fec.Valor;

                        aud.Acao = "ABRIU NOVAMENTE";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        this.Hide();
                        InicialCaixa i = new InicialCaixa();
                        i.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Você não possui privilégios para reabrir caixa");
                    }
                    #endregion
                }
                else
                {
                    #region ABRIR FECHADO
                    if (fecDAO.VerificaCaixa2(codper, data) == true)
                    {
                        DialogResult op;

                        op = MessageBox.Show("Deseja reabri-lo?",
                            "Este já caixa foi fechado!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (op == DialogResult.Yes)
                        {
                            login = UsuarioDAO.login;

                            usuDao.VerificaCargo(login);
                            tipo = usuDao.Usu.Tipo.ToString();

                            if (tipo == "Administrador")
                            {
                                fec.Responsavel = UsuarioDAO.login;
                                FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                                DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                                FechamentoDAO.data = fecDAO.Fec.Data;
                                FechamentoDAO.valor = fecDAO.Fec.Valor;

                                aud.Acao = "ABRIU FECHADO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                this.Hide();
                                InicialCaixa i = new InicialCaixa();
                                i.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Você não possui privilégios para reabrir caixa");
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        if (Convert.ToDateTime(data)>DateTime.Now)
                        {
                            MessageBox.Show("De volta para o futuro???");
                        }
                        else
                        {
                            #region ABRE UM NOVO
                            try
                            {
                                verDAO.Verifica();
                                if (verDAO.Ver.Verifica == "NAO")
                                {
                                    MessageBox.Show("O valor de retirada PDV não foi enviado no caixa anterior !!!");
                                }
                                else
                                {
                                    data_hora = DateTime.Now;
                                    fec.Data = Convert.ToDateTime(mskData.Text);
                                    fec.Status = "Aberto";
                                    fec.Responsavel = login;
                                    fec.Hrinicio = Convert.ToDateTime(data_hora.ToLongTimeString());
                                    fec.Id_turno = Convert.ToInt32(codper);
                                    fec.Valor = "0.00";
                                    fecDAO.inserir(fec);
                                    fecDAO.Pesquisacart(fec);
                                    if (verDAO.Verifica() == true)
                                    {
                                        ver.Verifica = "NAO";
                                        verDAO.Update(ver);
                                    }
                                    else
                                    {
                                        ver.Verifica = "NAO";
                                        verDAO.Inserir(ver);
                                    }
                                    FechamentoDAO.valor = fecDAO.Fec.Valor.ToString();
                                    FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                                    DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                    CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                    assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                    suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                    FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                                    FechamentoDAO.data = fecDAO.Fec.Data;

                                    aud.Acao = "ABRIU NOVO";
                                    aud.Data = FechamentoDAO.data;
                                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                    aud.Responsavel = UsuarioDAO.login;
                                    audDAO.Inserir(aud);

                                    this.Hide();
                                    InicialCaixa i = new InicialCaixa();
                                    i.ShowDialog();
                                }
                            }
                            catch
                            {

                            }
                            #endregion
                        }

                    }
                }               
            }
            else
            {
                if (fecDAO.Verifica(codper, data) == true)
                {
                    usuDao.VerificaCargo(fecDAO.Fec.Responsavel);
                    if (usuDao.Usu.Tipo=="Administrador")
                    {
                        login = UsuarioDAO.login;

                        usuDao.VerificaCargo(login);
                        tipo = usuDao.Usu.Tipo.ToString();
                        fec.Responsavel = UsuarioDAO.login;

                        FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                        fec.Id_caixa = fecDAO.Fec.Id_caixa;
                        fecDAO.UpdateResp(fec);
                        DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                        FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                        FechamentoDAO.data = fecDAO.Fec.Data;
                        FechamentoDAO.valor = fecDAO.Fec.Valor;

                        aud.Acao = "ABRIU NOVAMENTE";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        this.Hide();
                        InicialCaixa i = new InicialCaixa();
                        i.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Esse caixa já foi aberto por : " + fecDAO.Fec.Responsavel);
                    }                  
                }
                else
                {
                    #region ABRIR FECHADO
                    if (fecDAO.VerificaCaixa2(codper, data) == true)
                    {
                        DialogResult op;

                        op = MessageBox.Show("Deseja reabri-lo?",
                            "Este já caixa foi fechado!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (op == DialogResult.Yes)
                        {
                            login = UsuarioDAO.login;

                            usuDao.VerificaCargo(login);
                            tipo = usuDao.Usu.Tipo.ToString();

                            if (tipo == "Administrador")
                            {
                                fec.Responsavel = UsuarioDAO.login;                               
                                FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                                DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                                FechamentoDAO.data = fecDAO.Fec.Data;
                                FechamentoDAO.valor = fecDAO.Fec.Valor;

                                aud.Acao = "ABRINDO FECHADO";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                this.Hide();
                                InicialCaixa i = new InicialCaixa();
                                i.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Você não possui privilégios para reabrir caixa");
                            }
                        }
                        #endregion

                    }
                    else
                    {
                        #region ABRE UM NOVO
                        try
                        {
                            verDAO.Verifica();

                            if (verDAO.Ver.Verifica == "NAO")
                            {
                                MessageBox.Show("O valor de retirada PDV não foi enviado no caixa anterior !!!");
                            }
                            else
                            {
                                data_hora = DateTime.Now;

                                fec.Data = Convert.ToDateTime(mskData.Text);
                                fec.Status = "Aberto";
                                fec.Responsavel = login;
                                fec.Hrinicio = Convert.ToDateTime(data_hora.ToLongTimeString());
                                fec.Id_turno = Convert.ToInt32(codper);
                                fec.Valor = "0.00";
                                fecDAO.inserir(fec);
                                fecDAO.Pesquisacart(fec);


                                if (verDAO.Verifica() == true)
                                {

                                    ver.Verifica = "NAO";
                                    verDAO.Update(ver);
                                }
                                else
                                {
                                    ver.Verifica = "NAO";
                                    verDAO.Inserir(ver);

                                }

                                FechamentoDAO.valor = fecDAO.Fec.Valor.ToString();
                                FechamentoDAO.codcaixa = fecDAO.Fec.Id_caixa;
                                DinheiroDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                CartaocaixaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                assinadaDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                suprimentoDAO.codcaixa = fecDAO.Fec.Id_caixa.ToString();
                                FechamentoDAO.codturno = fecDAO.Fec.Id_turno.ToString();
                                FechamentoDAO.data = fecDAO.Fec.Data;

                                aud.Acao = "LOGOU";
                                aud.Data = FechamentoDAO.data;
                                aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                                aud.Responsavel = UsuarioDAO.login;
                                audDAO.Inserir(aud);

                                this.Hide();
                                InicialCaixa i = new InicialCaixa();
                                i.ShowDialog();
                            }


                        }
                        catch
                        {

                        }
                        #endregion
                    }
                }
            }
        }

        private void mskData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cmbTurno_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (mskData.MaskFull == true)
                {
                    data = Convert.ToDateTime(mskData.Text);
                }
            }
            catch
            {
                MessageBox.Show("A data inserida é inválida !!!");
                mskData.Clear();
                string datatela = DateTime.Now.ToShortDateString();
                mskData.Text = datatela;
            }
        }

        private void Abertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza?",
                    "Saindo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    this.Hide();
                    Login l = new Login();
                    l.ShowDialog();
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Deseja realmente fazer o Backup?",
                "Backup?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                Process myProcess = new Process();

                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "C:\\Backup Mysql\\back_up.bat";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();

                    MessageBox.Show("Backup realizado com sucesso");
                }

                catch
                {
                    MessageBox.Show("Por favor verifique se existe uma pasta chamada \"Backup Mysql\" no diretório C:, caso contrário contate um administrador ");
                }
            }
            else
            {

            }
        }

        private void btnEsgotar_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("É Recomendável fazer o Backup antes, pois irá perder algumas informações........ Deseja continuar?",
                "------AVISO-------", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {
                assDAO.DeletaTudo();
                Application.Restart();
            }
            else
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmCadusu u = new frmCadusu();
            u.Owner = this;
            u.ShowDialog();
        }

        private void mskData_Leave(object sender, EventArgs e)
        {          

        }
    }
}
