using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Caixa
{
    public partial class frmSecreta2 : Form
    {
        assinadaDAO assDAO = new assinadaDAO();

        public frmSecreta2()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;

            if (assDAO.VerificaT(senha) == true)
            {
                DialogResult op;

                op = MessageBox.Show("O banco voltará a ter as informações do último backup, tenha certeza de que é necessária a restauração. Deseja continuar?",
                    "------------------------ATENÇÃO------------------------", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    Process myProcess = new Process();

                    try
                    {
                        myProcess.StartInfo.UseShellExecute = false;
                        myProcess.StartInfo.FileName = "C:\\Backup Mysql\\restore.bat";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();

                        MessageBox.Show("Banco restaurado com sucesso");
                        Application.Restart();
                    }

                    catch
                    {
                        MessageBox.Show("ERRO 01P4598F1: CONTATE O ADMINISTRADOR");
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não conferem");
                }
            }
        }

        private void frmSecreta2_Load(object sender, EventArgs e)
        {

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
    }
}
