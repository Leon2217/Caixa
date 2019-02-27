using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Caixa.Classes;

namespace Caixa
{
    public partial class frmBackup : Form
    {
        assinadaDAO assDAO = new assinadaDAO();

        public frmBackup()
        {
            InitializeComponent();
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

            MessageBox.Show("Backup realizado com sucesso! Confira no diretório C://");
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;

            if (assDAO.VerificaT(senha) == true)
            {
                if (Directory.Exists("c:\\CaixaBackupTemp"))
                { }
                else
                {
                    Directory.CreateDirectory("c:\\CaixaBackupTemp");
                }

                opnSelecionarBackup.InitialDirectory = Backup.LocalBackup;
                opnSelecionarBackup.Filter = "SQL Files (.sql)|*.sql";
                DialogResult dr = opnSelecionarBackup.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string caminhoArq = opnSelecionarBackup.FileName.Replace("/", "\\");
                    try
                    {
                        File.Copy(caminhoArq, "c:\\CaixaBackupTemp\\restaurar.sql");
                        MysqlBackup_Restore("c:\\CaixaBackupTemp", "restore");

                        //corre uma thread com o processo que faz o backup ou restore
                        System.Threading.Thread.Sleep(420);
                        Thread t = new Thread(delegate () { MySqlProcess("c:\\CaixaBackupTemp", "restore"); });
                        t.Start();

                        Application.Restart();
                    }
                    catch
                    {
                        MessageBox.Show("Por favor apague o arquivo 'Restaurar.sql' no diretório c:\\CaixaBackupTemp\\restaurar.sql, e tente novamente. ");
                    }                                     
                }
                else
                {
                    try
                    {
                        Directory.Delete("c:\\CaixaBackupTemp");
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("As senhas não conferem...");
            }
        }

        private void chkSenha_CheckedChanged(object sender, EventArgs e)
        {
            #region MOSTRA SENHA
            if (chkSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
            #endregion
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;

            if (assDAO.VerificaT(senha) == true)
            {
                DialogResult op;

                op = MessageBox.Show("É Recomendável fazer o Backup antes, pois irá perder a maioria das informações........ Deseja continuar?",
                    "------AVISO-------", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    assDAO.DeletaTudo();
                    Application.Restart();
                    assDAO.DeletaT();
                }
            }
            else
            {
                MessageBox.Show("As senhas não conferem...");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBackup_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyValue.Equals(27))
            {
                Close();
            }
        }
    }
}
