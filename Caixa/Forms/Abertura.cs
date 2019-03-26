using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Caixa.Classes;

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
            if (Directory.Exists("c:\\CaixaBackupTemp"))
            { }
            else
            {
                Directory.CreateDirectory("c:\\CaixaBackupTemp");
            }
            string path = "c:\\CaixaBackupTemp";

            MysqlBackup_Restore(path, "backup");

            //corre uma thread com o processo que faz o backup ou restore
            System.Threading.Thread.Sleep(420);

            //quando executar fara o codigo seguinte
            //exemplo do path

            //corre uma thread com o processo que faz o backup ou restore
            Thread t = new Thread(delegate () { MySqlProcess(path, "backup"); });
            t.Start();
        }

        private static void MysqlBackup_Restore(string path, string type)
        {
            //Caminho onde o mysql esta instalado
            string cmd = "\"C:/Arquivos de programas/MySQL/MySQL Server 5.1/bin/";

            //create a bath file to run the script database.
            StreamWriter sw = File.CreateText(path + "\\CaixaBackup.cmd");
            //sw.WriteLine("c:");
            sw.WriteLine("c:");
            sw.WriteLine("cd\\");
            sw.WriteLine("cd " + cmd);

            string caminhoTemporario;
            string arquivoTemporario;

            if (type == "backup")
            {
                string dt = System.DateTime.Now.ToString().Replace("/", "_").Replace(":", "-").Replace(" ", "--");
                arquivoTemporario = "BackupCaixa" + dt;
                caminhoTemporario = path + "\\BackupCaixa" + dt + ".sql";
                arquivoTemporario = "BackupCaixa" + dt;

                Backup.DataBackup = dt;
                //se for backup
                sw.WriteLine("mysqldump.exe -uroot -pCoxinha#2019 --databases caixa1 > " + caminhoTemporario);
                sw.WriteLine("");
            }
            else
            {
                arquivoTemporario = "c:\\CaixaBackupTemp\\restaurar.sql";
                //se for restore
                sw.WriteLine("mysql -uroot -pCoxinha#2019 < " + arquivoTemporario);
                sw.WriteLine("");
            }

            sw.Close();
        }

        private static void MySqlProcess(string Path, string tipo)
        {
            try
            {
                //cria o processo a correr o MySqlbackup.cmd
                Process.Start(Path + "\\CaixaBackup.cmd");

                System.Threading.Thread.Sleep(420);
                if (tipo == "restore")
                {
                    System.Threading.Thread.Sleep(420);
                    File.Delete("c:\\CaixaBackupTemp\\restaurar.sql");
                    File.Delete("c:\\CaixaBackupTemp\\CaixaBackup.cmd");

                    Directory.Delete("c:\\CaixaBackupTemp");
                }

                System.Threading.Thread.Sleep(420);
                if (tipo == "backup")
                {
                    //cria o processo a correr o MySqlbackup.cmd
                    Process.Start(Path + "\\CaixaBackup.cmd");

                    string caminhoTemporario;
                    string arquivoTemporario;
                    string path = "c:\\CaixaBackupTemp";
                    caminhoTemporario = path + "\\BackupCaixa" + Backup.DataBackup + ".sql";
                    arquivoTemporario = "BackupCaixa" + Backup.DataBackup;

                    int count2 = 0;

                    while (count2 != 1)
                    {
                        try
                        {
                            File.Move(caminhoTemporario, Backup.LocalBackup + arquivoTemporario + ".sql");

                            File.Delete("c:\\CaixaBackupTemp\\restaurar.sql");
                            File.Delete("c:\\CaixaBackupTemp\\CaixaBackup.cmd");

                            Directory.Delete("c:\\CaixaBackupTemp");
                            count2 = 1;
                        }
                        catch
                        {
                            count2 = 0;
                        }
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCadusu u = new frmCadusu();
            u.Owner = this;
            u.ShowDialog();
        }         
    }
}
