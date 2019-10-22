using System;
using System.Windows.Forms;
using Caixa.Classes;
using Caixa.ClassesDAO;

namespace Caixa.Forms
{
    public partial class frmRelatConsumo : Form
    {
        RelatConsumo rlc = new RelatConsumo();
        relatconsumoDAO rlcDAO = new relatconsumoDAO();

        DateTime de;
        DateTime at;
        string nome;
        public frmRelatConsumo()
        {
            InitializeComponent();
        }

        private void FrmRelatConsumo_Load(object sender, EventArgs e)
        {
            try
            {
                #region DATA INCIAL
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

                #region DATA FINAL
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

                mskAté.Text = DateTime.Now.ToShortDateString();
                mskDe.Text = DateTime.Now.ToShortDateString();

                #region AJUSTE GRID
                foreach (DataGridViewColumn column in gvExibir.Columns)
                {
                    if (column.DataPropertyName == "VALOR")
                        column.Width = 50; //tamanho fixo da coluna VALOR
                    else if (column.DataPropertyName == "DATA")
                        column.Width = 80; //tamanho fixo da coluna DATA
                    else if (column.DataPropertyName == "NOME")
                        column.Width = 130; //tamanho fixo da coluna DESCRICAO


                    else
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                #endregion

            }
            catch
            {

            }
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            #region DATA INCIAL
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

            #region DATA FINAL
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

            #region SOMENTE NOME PREENCHIDO
            if (txtNome.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarNome(nome);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E NOME
            if (txtNome.Text != string.Empty && mskDe.MaskFull == true)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarDeNome(nome, de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskDe.MaskFull == true && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarDe(de);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTN(de, at);
            }
            #endregion

            #region TODOS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text != string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTNNOME(nome, de, at);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarTudo();
            }
            #endregion
        }

        private void MskAté_TextChanged(object sender, EventArgs e)
        {
            #region DATA INCIAL
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

            #region DATA FINAL
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

            #region SOMENTE NOME PREENCHIDO
            if (txtNome.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarNome(nome);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E NOME
            if (txtNome.Text != string.Empty && mskDe.MaskFull == true)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarDeNome(nome, de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskDe.MaskFull == true && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarDe(de);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTN(de, at);
            }
            #endregion

            #region TODOS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text != string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTNNOME(nome, de, at);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarTudo();
            }
            #endregion
        }

        private void MskDe_TextChanged(object sender, EventArgs e)
        {
            #region DATA INCIAL
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

            #region DATA FINAL
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

            #region SOMENTE NOME PREENCHIDO
            if (txtNome.Text != string.Empty && mskDe.MaskFull == false && mskAté.MaskFull == false)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarNome(nome);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA E NOME
            if (txtNome.Text != string.Empty && mskDe.MaskFull == true)
            {
                nome = txtNome.Text;
                gvExibir.DataSource = rlcDAO.ListarDeNome(nome, de);
            }
            #endregion

            #region SOMENTE A PRIMEIRA DATA 
            if (mskDe.MaskFull == true && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarDe(de);
            }
            #endregion

            #region BETWEEN
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text == string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTN(de, at);
            }
            #endregion

            #region TODOS
            if (mskDe.MaskFull == true && mskAté.MaskFull == true && txtNome.Text != string.Empty)
            {
                gvExibir.DataSource = rlcDAO.ListarBTNNOME(nome, de, at);
            }
            #endregion

            #region TODOS VAZIOS
            if (mskDe.MaskFull == false && txtNome.Text == string.Empty && mskAté.MaskFull == false)
            {
                gvExibir.DataSource = rlcDAO.ListarTudo();
            }
            #endregion
        }

        private void FrmRelatConsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
}
