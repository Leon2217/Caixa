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
    public partial class frmFalta : Form
    {
        #region INSTANCIAMENTO CLASSES
        PessoaDAO pesDAO = new PessoaDAO();
        Falta fal = new Falta();
        FaltaDAO falDAO = new FaltaDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();
        #endregion

        #region VAR
        string codpes;
        #endregion
        public frmFalta()
        {
            InitializeComponent();
        }

        private void btnRelat_Click(object sender, EventArgs e)
        {
            frmRelatFalta rf = new frmRelatFalta();
            rf.Owner = this;
            rf.ShowDialog();
        }

        private void frmFalta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        public void CarregarComboNome()
        {          
            cmbNome.DataSource = pesDAO.ListarFU();
            cmbNome.DisplayMember = "nome";
            cmbNome.ValueMember = "ID";
            codpes = cmbNome.SelectedValue.ToString();
        }

        private void frmFalta_Load(object sender, EventArgs e)
        {
            try
            {
                mskData.Text = DateTime.Now.ToShortDateString();
              
                CarregarComboNome();
            }catch
            {

            }
           
        }

        private void chkIntegral_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIntegral.Checked == true)
            {
                chkManha.Enabled = false;
                chkTarde.Enabled = false;
                chkParcial.Enabled = false;
            }
            else
            {
                chkManha.Enabled = true;
                chkTarde.Enabled = true;
                chkParcial.Enabled = true;
            }

           
        }

        private void chkParcial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParcial.Checked == true)
            {
                chkIntegral.Enabled = false;
                chkTarde.Enabled = false;
                chkManha.Enabled = false;
                mskDe.Visible = true;
                mskAte.Visible = true;
                lblDe.Visible = true;
                lblAt.Visible = true;
                
            }
            else
            {
                chkIntegral.Enabled = true;
                chkTarde.Enabled = true;
                chkManha.Enabled = true;
                mskDe.Visible = false;
                mskAte.Visible = false;
                lblDe.Visible = false;
                lblAt.Visible = false;
            }
        }

        private void chkManha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManha.Checked == true)
            {
                chkIntegral.Enabled = false;
                chkParcial.Enabled = false;
                chkTarde.Enabled = false;
            }
            else
            {
                chkIntegral.Enabled = true;
                chkParcial.Enabled = true;
                chkTarde.Enabled = true;
            }
        }

        private void chkTarde_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTarde.Checked == true)
            {
                chkIntegral.Enabled = false;
                chkManha.Enabled = false;
                chkParcial.Enabled = false;
            }
            else
            {
                chkIntegral.Enabled = true;
                chkManha.Enabled = true;
                chkParcial.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region INSERIR FALTAS
            if (chkParcial.Checked == true||chkIntegral.Checked==true||chkManha.Checked==true||
                chkTarde.Checked==true)
            {
                #region PARCIAL
                if (chkParcial.Checked==true )
                {
                    if (mskDe.MaskFull == false || mskAte.MaskFull == false)
                    {
                        MessageBox.Show("Favor inserir as horas que o funcionário permaneceu no estabelecimento !!!");
                    }
                    else
                    {
                        //INSERIR
                        try
                        {
                            fal.Id_pessoa = Convert.ToInt32(codpes);
                            fal.Data = Convert.ToDateTime(mskData.Text);
                            fal.Periodo = " Faltou De(as) : " + mskDe.Text + " Ate : " + mskAte.Text;
                            falDAO.Inserir(fal);
                            MessageBox.Show("Falta salva com sucesso !!!");
                            chkParcial.Checked = false;
                            cmbNome.SelectedIndex = 0;
                            mskDe.Clear();
                            mskAte.Clear();

                            aud.Acao = "INSERIU FALTA";
                            aud.Data = FechamentoDAO.data;
                            aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                            aud.Responsavel = UsuarioDAO.login;
                            audDAO.Inserir(aud);
                        }
                        catch
                        {
                            MessageBox.Show("Favor verificar as informações digitadas !!!");
                        }
                        
                    }               
                }
              
                #endregion

                #region INTEGRAL
                if (chkIntegral.Checked == true)
                {
                    //INSERIR
                    try
                    {
                        fal.Id_pessoa = Convert.ToInt32(codpes);
                        fal.Data = Convert.ToDateTime(mskData.Text);
                        fal.Periodo = "Integral";
                        falDAO.Inserir(fal);
                        MessageBox.Show("Falta salva com sucesso !!!");
                        chkIntegral.Checked = false;
                        cmbNome.SelectedIndex = 0;

                        aud.Acao = "INSERIU FALTA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                  
                }
                #endregion

                #region MANHA
                if (chkManha.Checked == true)
                {
                    //INSERIR
                    try
                    {
                        fal.Id_pessoa = Convert.ToInt32(codpes);
                        fal.Data = Convert.ToDateTime(mskData.Text);
                        fal.Periodo = "Manha";
                        falDAO.Inserir(fal);
                        MessageBox.Show("Falta salva com sucesso !!!");
                        chkManha.Checked = false;
                        cmbNome.SelectedIndex = 0;

                        aud.Acao = "INSERIU FALTA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                 
                }
                #endregion

                #region TARDE
                if (chkTarde.Checked == true)
                {
                    //INSERIR
                    try
                    {
                        fal.Id_pessoa = Convert.ToInt32(codpes);
                        fal.Data = Convert.ToDateTime(mskData.Text);
                        fal.Periodo = "Tarde";
                        falDAO.Inserir(fal);
                        MessageBox.Show("Falta salva com sucesso !!!");
                        chkTarde.Checked = false;
                        cmbNome.SelectedIndex = 0;

                        aud.Acao = "INSERIU FALTA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas !!!");
                    }
                   
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Favor escolher um dos períodos acima !!!");
            }
            #endregion

        }

        private void cmbNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            codpes = cmbNome.SelectedValue.ToString();
        }
    }
}
