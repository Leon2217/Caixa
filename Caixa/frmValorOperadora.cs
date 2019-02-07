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
    public partial class frmValorOperadora : Form
    {
        OperadoraDAO opDAO = new OperadoraDAO();
        Operadoras op = new Operadoras();
        Valoroperadora vop = new Valoroperadora();
        ValoroperadoraDAO vopDAO = new ValoroperadoraDAO();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();

        string codop;
        string operadora;
        string valor;
        public frmValorOperadora()
        {
            InitializeComponent();
        }
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {

            }
        }


        private void frmValorOperadora_Load(object sender, EventArgs e)
        {
            try
            {
                Moeda(ref txtValor);
                CarregarComboOperadora();
                //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            }
            catch
            {

            }
          
        }
        public void CarregarComboOperadora()
        {

            cmbOperadora.DataSource = opDAO.Listartudo();
            cmbOperadora.DisplayMember = "operadora";
            cmbOperadora.ValueMember = "id_operadora";
            codop = cmbOperadora.SelectedValue.ToString();
        }

        private void cmbOperadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            codop = cmbOperadora.SelectedValue.ToString();
            operadora = cmbOperadora.Text.ToString();
            gvExibir.DataSource = vopDAO.Listarvalores(operadora);
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValor);
            valor = txtValor.Text.ToString();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult op;

            op = MessageBox.Show("Você tem certeza dessas informações?" + "\n Valor : " + valor + " R$",
                "Salvando!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (op == DialogResult.Yes)
            {

                try
                {                   
                        vop.Id_operadora = Convert.ToInt32(codop);
                        vop.Valor = txtValor.Text.ToString().Replace(".", "");
                        vopDAO.Inserir(vop);

                        aud.Acao = "INSERIU VALOR DE OPERADORA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);

                        txtValor.Clear();
                        gvExibir.DataSource = vopDAO.Listarvalores(operadora);                    
                }
                catch
                {
                    MessageBox.Show("Favor verificar as informações digitadas !!!");
                }
               
            



            }
        }

        private void frmValorOperadora_KeyPress(object sender, KeyPressEventArgs e)
        {




        }

        private void frmValorOperadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }
    }
}
