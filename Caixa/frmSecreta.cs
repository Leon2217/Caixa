using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmSecreta : Form
    {
        assinadaDAO assDAO = new assinadaDAO();
        DateTime de, at;

        public frmSecreta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion

            if (mskDe.MaskFull == true && mskAté.MaskFull == true)
            {
                string senha1 = textBox1.Text;
           
                if (assDAO.VerificaT(senha1) == true)
                {
                    DialogResult op;

                    op = MessageBox.Show("É Recomendável fazer o Backup antes, pois irá perder algumas informações........ Deseja continuar?",
                        "------AVISO-------", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {
                        assDAO.DeletaTudoDeAt(de, at);
                        Application.Restart();
                        assDAO.DeletaT();
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não conferem");
                }
            }
            else
            {
                string senha = textBox1.Text;

                if (assDAO.VerificaT(senha) == true)
                {
                    DialogResult op;

                    op = MessageBox.Show("É Recomendável fazer o Backup antes, pois irá perder algumas informações........ Deseja continuar?",
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
                    MessageBox.Show("As senhas não conferem");

                }
            }


           
        }

        private void frmSecreta_Load(object sender, EventArgs e)
        {
            string datatela = DateTime.Now.ToShortDateString();
            mskDe.Text = datatela;
            mskAté.Text = datatela;
        }

        private void mskAté_TextChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion
        }

        private void chkSenha_CheckedChanged(object sender, EventArgs e)
        {
            #region MOSTRA SENHA
            if (chkSenha.Checked == true)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
            #endregion
        }

        private void mskDe_TextChanged(object sender, EventArgs e)
        {
            #region DE
            if (mskDe.MaskFull == true)
            {
                try
                {
                    de = Convert.ToDateTime(mskDe.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskDe.Clear();
                }

            }
            #endregion

            #region ATÉ
            if (mskAté.MaskFull == true)
            {
                try
                {
                    at = Convert.ToDateTime(mskAté.Text);
                }
                catch
                {
                    MessageBox.Show("Data inválida !!!");
                    mskAté.Clear();
                }

            }
            #endregion
        }
    }
}
