using System;
using System.Drawing;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmRecarga : Form
    {
        OperadoraDAO opDAO = new OperadoraDAO();
        Inventariorec ir = new Inventariorec();
        InventariorecDAO irDAO = new InventariorecDAO();
        ValoroperadoraDAO vopDAO = new ValoroperadoraDAO();
        Recarga rec = new Recarga();
        RecargaDAO recDAO = new RecargaDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string codop;
          
        public frmRecarga()
        {
            InitializeComponent();
        }

        private void frmRecarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (mskCel.MaskFull==false)
            {
                mskCel.BackColor = Color.Red;
                MessageBox.Show("Favor inserir um N° de celular !!!");
            }
            else
            {
                try
                {
                    rec.Id_caixa = FechamentoDAO.codcaixa;
                    rec.Operadora = cmbOperadora.Text.ToString();
                    rec.Valor_rec = cmbValor.Text.ToString();

                    string fudeu = rec.Valor_rec;
                    irDAO.UpdateTotal(fudeu);
                    irDAO.VerificaInventário();

                    rec.N_telefone = mskCel.Text.ToString();
                    rec.Descricao = "Recarga";
                    rec.Data= Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    rec.Hora= Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                    rec.Total = irDAO.Invr.Total;

                    recDAO.Inserir(rec);
                    mskCel.Clear();

                    ((InicialCaixa)this.Owner).Atualizadados();
                    MessageBox.Show("Cadastro efetuado com sucesso !!!");

                    aud.Acao = "INSERIU RECARGA";
                    aud.Data = FechamentoDAO.data;
                    aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    aud.Responsavel = UsuarioDAO.login;
                    audDAO.Inserir(aud);
                }
                catch
                {
                    MessageBox.Show("Favor fazer inventário primeiro !!!");
                }
            }
        }
        public void CarregarComboOperadora()
        {
            cmbOperadora.DataSource = opDAO.Listartudo();
            cmbOperadora.DisplayMember = "operadora";
            cmbOperadora.ValueMember = "id_operadora";
            codop = cmbOperadora.SelectedValue.ToString();
            CarregarComboValor();
        }
        public void CarregarComboValor()
        {
            cmbValor.DataSource = vopDAO.Listarvalores3(codop);
            cmbValor.DisplayMember = "valor";
            cmbValor.ValueMember = "id_valor";
        }
        private void frmRecarga_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarComboOperadora();
                CarregarComboValor();
            }
            catch
            {
            }       
        }

        private void cmbOperadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            codop = cmbOperadora.SelectedValue.ToString();
            CarregarComboValor();
        }

        private void mskCel_TextChanged(object sender, EventArgs e)
        {
            mskCel.BackColor = Color.Empty;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                frmPesquisaRecarga pr = new frmPesquisaRecarga();
                pr.Owner = this;
                pr.ShowDialog();
            }
            catch
            {
            } 
        }

        private void btnInventário_Click(object sender, EventArgs e)
        {
            frmInventariorec ir = new frmInventariorec();
            ir.Owner = this;
            ir.ShowDialog();
        }

        private void mskCel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
