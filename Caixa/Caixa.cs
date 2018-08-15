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
    public partial class Caixa : Form
    {
        DateTime data_hora;
        CartaomaquinaDAO carMaquinaDAO=new CartaomaquinaDAO();
        MaquinasDAO maqDAO = new MaquinasDAO();
        Cartaocaixa carcai = new Cartaocaixa();
        CartaocaixaDAO carcaiDAO = new CartaocaixaDAO();
        Fechamento fecha = new Fechamento();
        FechamentoDAO fechaDAO = new FechamentoDAO();
        //string codmaq;
        //string codcart;
        public Caixa()
        {
            InitializeComponent();
            
            
                             
        }

        private void Caixa_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
           
            //gvExibir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //gvExibir.DataSource = carMaquinaDAO.ListarTudo();
            lblNome.Text =UsuarioDAO.login;
            CarregarComboMaquina();

            string data = DateTime.Now.ToShortDateString();
            fecha.Datafinal = Convert.ToDateTime(data);
            string usu = UsuarioDAO.login;
            fecha.Responsavel = usu;
            string status ="Em Aberto";
            fecha.Status = status;
            string id_turno = "1";
            fecha.Id_turno = Convert.ToInt32(id_turno);
          

            fechaDAO.inserir(fecha);
            



            
            

        }



        public void CarregarComboMaquina()
        {
            //cmbMaquina.DataSource = maqDAO.ListarTudo();
            //cmbMaquina.DisplayMember = "maquina";
            //cmbMaquina.ValueMember = "id_maquina";
           
            //codmaq= cmbMaquina.SelectedValue.ToString();

            //string codcart1 = "1";
            //string codcart2 = "2";
            //string codcart3 = "3";
            //string codcart4 = "4";
            //string codcart5 = "5";
            //string codcart6 = "6";
            //string codcart7 = "7";
            //string codcart8 = "8";
            //string codcart9 = "9";
            //string codcart10 = "10";
            //string codcart11 = "11";
            //string codcart12 = "12";
            //string codcart13 = "14";
            //string codcart14 = "15";
            //string codcart15 = "16";



            //if (carMaquinaDAO.Pesquisacart(codcart1,codmaq) == true)
            //{
            //    txtVsCred.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart2,codmaq) == true)
            //{
            //    txtVsDeb.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart3,codmaq) == true)
            //{
            //    txtMsCred.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart4,codmaq) == true)
            //{
            //    txtMsDeb.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart5,codmaq) == true)
            //{
            //    txtEdebito.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart6,codmaq) == true)
            //{
            //    txtEcredito.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart7,codmaq) == true)
            //{
            //    txtHcredito.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart8,codmaq) == true)
            //{
            //    txtEali.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart9,codmaq) == true)
            //{
            //    txtEref.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart10,codmaq) == true)
            //{
            //    txtSali.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart11,codmaq) == true)
            //{
            //    txtSref.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart12,codmaq) == true)
            //{
            //    txtTref.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart13,codmaq) == true)
            //{
            //    txtEdebito.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart14,codmaq) == true)
            //{
            //    txtVrali.Enabled = true;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart15,codmaq) == true)
            //{
            //    txtVrref.Enabled = true;
            //}

       
        }


        private void tmrHora_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            lblData.Text =data_hora.ToLongDateString();
            lblHora.Text=data_hora.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void txtVscred_TextChanged(object sender, EventArgs e)
        {

            //string valor =txtValor.Text;

            //if(txtValor.TextLength==1)
            //{
            //    string numponto = "00" + valor;
            //}
            //if (txtValor.TextLength == 2)
            //{
            //    string numponto = "0" + valor;
            //}

            //if (txtValor.TextLength == 6|| txtValor.TextLength == 7|| txtValor.TextLength == 8)
            //{
            //    string numponto =
            //}
            //            Sub formataMoeda()
            //    valor = TextBox1.Value
            //    If IsNumeric(valor) Then
            //        If InStr(1, valor, "-") >= 1 Then valor = Replace(valor, "-", "") 'retira sinal negativo
            //        If InStr(1, valor, ",") >= 1 Then valor = CDbl(Replace(valor, ",", "")) 'retirar a virgula
            //        If InStr(1, valor, ".") >= 1 Then valor = Replace(valor, ".", "") 'para trabalhar melhor retiramos ponto
            //        Select Case Len(valor) 'verifica casas para inserção de ponto
            //            Case 1
            //            numPonto = "00" & valor
            //            Case 2
            //            numPonto = "0" & valor
            //            Case 6 To 8
            //            numPonto = Left(valor, Len(valor) - 5) & "." & Right(valor, 5)
            //            Case 9 To 11
            //            numPonto = inseriPonto(8, valor)
            //            Case 12 To 14
            //            numPonto = inseriPonto(11, valor)
            //            Case Else
            //            numPonto = valor
            //        End Select
            //        numVirgula = Left(numPonto, Len(numPonto) - 2) & "," & Right(numPonto, 2)
            //        TextBox1.Value = numVirgula
            //    Else
            //        If valor = "" Then Exit Sub
            //        MsgBox "Número invalido", vbCritical, "Caracter Invalido"
            //        Exit Sub
            //    End If
            //End Sub


            //Function inseriPonto(inicio, valor)
            //    I = Left(valor, Len(valor) - inicio)
            //    M1 = Left(Right(valor, inicio), 3)
            //    M2 = Left(Right(valor, 8), 3)
            //    F = Right(valor, 5)
            //    If(M2 = M1) And(Len(valor) < 12) Then
            //  inseriPonto = I & "." & M1 & "." & F
            //    Else
            //    inseriPonto = I & "." & M1 & "." & M2 & "." & F
            //    End If
            //End Function






            //if (txtVsCred.Text != string.Empty)
            //{

            //    codcart = "1";
            //    carcai.Valor = Convert.ToDouble(txtVsCred.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
        }




        private void txtVsDeb_TextChanged(object sender, EventArgs e)
        {
            ////2
            //if(txtVsDeb.Text!=string.Empty)
            //{
            //    codcart = "2";
            //    carcai.Valor = Convert.ToDouble(txtVsDeb.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
         
        }

        private void txtMsCred_TextChanged(object sender, EventArgs e)
        {
            //3
            //if(txtMsCred.Text!=string.Empty)
            //{
            //    codcart = "3";
            //    carcai.Valor = Convert.ToDouble(txtMsCred.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}

        }

        private void txtMsDeb_TextChanged(object sender, EventArgs e)
        {
            //4
            //if(txtMsDeb.Text!=string.Empty)
            //{
            //    codcart = "4";
            //    carcai.Valor = Convert.ToDouble(txtMsDeb.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
        }

        private void txtEcredito_TextChanged(object sender, EventArgs e)
        {
            //6
            //if(txtEcredito.Text!=string.Empty)
            //{
            //    codcart = "6";
            //    carcai.Valor = Convert.ToDouble(txtEcredito.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
        
        }

        private void txtEdebito_TextChanged(object sender, EventArgs e)
        {
            //5
            //if(txtEdebito.Text!=string.Empty)
            //{
            //    codcart = "5";
            //    carcai.Valor = Convert.ToDouble(txtEdebito.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
 
        }

        private void txtEali_TextChanged(object sender, EventArgs e)
        {
            //8
            //if(txtEali.Text!=string.Empty)
            //{
            //    codcart = "8";
            //    carcai.Valor = Convert.ToDouble(txtEali.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
      
        }

        private void txtEref_TextChanged(object sender, EventArgs e)
        {
            //9
            //if(txtEref.Text!=string.Empty)
            //{
            //    codcart = "9";
            //    carcai.Valor = Convert.ToDouble(txtEref.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
     
        }

        private void txtSali_TextChanged(object sender, EventArgs e)
        {
            //10
            //if(txtSali.Text!=string.Empty)
            //{
            //    codcart = "10";
            //    carcai.Valor = Convert.ToDouble(txtSali.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}

        }

        private void txtSref_TextChanged(object sender, EventArgs e)
        {
            //11
            //if(txtSref.Text!=string.Empty)
            //{
            //    codcart = "11";
            //    carcai.Valor = Convert.ToDouble(txtSref.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
      
        }

        private void txtTref_TextChanged(object sender, EventArgs e)
        {
            //12
            //if(txtTref.Text!=string.Empty)
            //{
            //    codcart = "12";
            //    carcai.Valor = Convert.ToDouble(txtTref.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
           
        }

        private void txtEldebito_TextChanged(object sender, EventArgs e)
        {
            //if (txtEdebito.Text != string.Empty)
            //{
            //    codcart = "14";
            //    carcai.Valor = Convert.ToDouble(txtEdebito.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
        }


        private void txtVrali_TextChanged(object sender, EventArgs e)
        {
            //15
            //if(txtVrali.Text!=string.Empty)
            //{
            //    codcart = "15";
            //    carcai.Valor = Convert.ToDouble(txtVrali.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
 
        }

        private void txtVrref_TextChanged(object sender, EventArgs e)
        {

            //16
            //if(txtVrref.Text!=string.Empty)
            //{
            //    codcart = "16";
            //    carcai.Valor = Convert.ToDouble(txtVrref.Text);
            //    carcai.Id_cartao = Convert.ToInt32(codcart);
            //    carcai.Id_maquina = Convert.ToInt32(codmaq);
            //}
         

        }

        private void txtVsCred_TabIndexChanged(object sender, EventArgs e)
        {
            carcaiDAO.inserir(carcai);
        }

        private void txtVsCred_Leave(object sender, EventArgs e)
        {
         

         
        }

        private void txtVsCred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtVsDeb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtMsCred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtMsDeb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtSali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtSref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtTref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtEcredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtEdebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtEali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtEref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtEldebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtVrali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtVrref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtHcredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void cmbMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
           //codmaq = cmbMaquina.SelectedValue.ToString();

            //string codcart1 = "1";
            //string codcart2 = "2";
            //string codcart3 = "3";
            //string codcart4 = "4";
            //string codcart5 = "5";
            //string codcart6 = "6";
            //string codcart7 = "7";
            //string codcart8 = "8";
            //string codcart9 = "9";
            //string codcart10 = "10";
            //string codcart11 = "11";
            //string codcart12 = "12";
            //string codcart13 = "14";
            //string codcart14 = "15";
            //string codcart15 = "16";



            //if (carMaquinaDAO.Pesquisacart(codcart1, codmaq) == true)
            //{
            //    txtVsCred.Enabled = true;
            //}else
            //{
            //    txtVsCred.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart2, codmaq) == true)
            //{
            //    txtVsDeb.Enabled = true;
            //}
            //else
            //{
            //    txtVsDeb.Enabled = false;
            //}


            //if (carMaquinaDAO.Pesquisacart(codcart3, codmaq) == true)
            //{
            //    txtMsCred.Enabled = true;
            //}
            //else
            //{
            //    txtMsCred.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart4, codmaq) == true)
            //{
            //    txtMsDeb.Enabled = true;
            //}
            //else
            //{
            //    txtMsDeb.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart5, codmaq) == true)
            //{
            //    txtEdebito.Enabled = true;
            //}
            //else
            //{
            //    txtEdebito.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart6, codmaq) == true)
            //{
            //    txtEcredito.Enabled = true;
            //}
            //else
            //{
            //    txtEcredito.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart7, codmaq) == true)
            //{
            //    txtHcredito.Enabled = true;
            //}
            //else
            //{
            //    txtHcredito.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart8, codmaq) == true)
            //{
            //    txtEali.Enabled = true;
            //}else
            //{
            //    txtEali.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart9, codmaq) == true)
            //{
            //    txtEref.Enabled = true;
            //}
            //else
            //{
            //    txtEref.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart10, codmaq) == true)
            //{
            //    txtSali.Enabled = true;
            //}
            //else
            //{
            //    txtSali.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart11, codmaq) == true)
            //{
            //    txtSref.Enabled = true;
            //}
            //else
            //{
            //    txtSref.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart12, codmaq) == true)
            //{
            //    txtTref.Enabled = true;
            //}
            //else
            //{
            //    txtTref.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart13, codmaq) == true)
            //{
            //    txtEldebito.Enabled = true;
            //}
            //else
            //{
            //    txtEldebito.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart14, codmaq) == true)
            //{
            //    txtVrali.Enabled = true;
            //}
            //else
            //{
            //    txtVrali.Enabled = false;
            //}

            //if (carMaquinaDAO.Pesquisacart(codcart15, codmaq) == true)
            //{
            //    txtVrref.Enabled = true;
            //}
            //else
            //{
            //    txtVrref.Enabled = false;
            //}
        }

        private void txtVsCred_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

     

     
    }
}
