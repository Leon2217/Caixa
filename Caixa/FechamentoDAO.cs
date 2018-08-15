using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class FechamentoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Fechamento fec = new Fechamento();


        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        public static int codcaixa;
        public static string codturno;

        public static DateTime data;
        internal Fechamento Fec { get => fec; set => fec = value; }
        public static int Codcaixa { get => codcaixa; set => codcaixa = value; }
        public static DateTime Data { get => data; set => data = value; }
        public static string Codturno { get => codturno; set => codturno = value; }
        public static string Valor { get => valor; set => valor = value; }

        public static string valor;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public void inserir(Fechamento fecha)
        {
            executarComando("INSERT INTO CAIXA VALUES(0,'" +fecha.Id_turno+ "','" +fecha.Data.ToString("yyyy/MM/dd")+ "','"+ fecha.Datafinal.ToString("yyyy/MM/dd") + "','"+fecha.Hrinicio.ToString("HH:mm:ss")+"','"+ fecha.Hrfinal.ToString("HH:mm") + "','" +fecha.Status + "','"+fecha.Responsavel+"','"+fecha.Valor+"');");
        }
        public Boolean Pesquisacart(Fechamento fec)
        {
            executarComando("select id_caixa,id_turno,datainicio,valor_relat from caixa WHERE responsavel='"+fec.Responsavel+ "' and ID_CAIXA=(SELECT MAX(ID_CAIXA) FROM CAIXA WHERE responsavel='"+fec.Responsavel+"');");
            try
            {
                Fec.Id_caixa = Convert.ToInt32(tabela_memoria.Rows[0]["id_caixa"].ToString());
                Fec.Id_turno = Convert.ToInt32(tabela_memoria.Rows[0]["id_turno"].ToString());
                Fec.Data = Convert.ToDateTime(tabela_memoria.Rows[0]["datainicio"].ToString());
                Fec.Valor = tabela_memoria.Rows[0]["valor_relat"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public Boolean Pesquisavalor(Fechamento fec)
        //{
        //    executarComando("select valor_relat from caixa WHERE id_caixa='"+fec.Id_caixa+"');");
        //    try
        //    {
        //        Fec.Valor= tabela_memoria.Rows[0]["valor_relat"].ToString();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public void fechar(Fechamento fec)
        {
            executarComando("UPDATE CAIXA SET DATAFINAL='" + fec.Datafinal.ToString("yyyy/MM/dd") + "',STATUS='" + fec.Status + "',HRFINAL='" +fec.Hrfinal.ToString("HH:mm:ss") + "' WHERE ID_CAIXA='" + fec.Id_caixa + "' and RESPONSAVEL='"+fec.Responsavel+"';");
        }

        public void Updatevalor(string valor,string codcaixa)
        {
            executarComando("UPDATE CAIXA SET VALOR_RELAT='" + valor.ToString().Replace(",",".") + "' WHERE ID_CAIXA='" + codcaixa + "';");
        }


        public Boolean VerificaCaixa(string login)
        {
            executarComando("select id_caixa,id_turno,datainicio,valor_relat from caixa WHERE responsavel='" + login+"' and status='Aberto';");
            try
            {
                Fec.Id_caixa = Convert.ToInt32(tabela_memoria.Rows[0]["id_caixa"].ToString());
                Fec.Data = Convert.ToDateTime(tabela_memoria.Rows[0]["datainicio"].ToString());
                Fec.Id_turno = Convert.ToInt32(tabela_memoria.Rows[0]["id_turno"].ToString());
                Fec.Valor = tabela_memoria.Rows[0]["valor_relat"].ToString();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public Boolean Verifica(string codper,DateTime datainicio)
        {
            executarComando("select id_caixa,responsavel from caixa WHERE id_turno='" + codper + "' and status='Aberto' and datainicio='"+datainicio.ToString("yyyy/MM/dd")+"';");
            try
            {
                Fec.Id_caixa = Convert.ToInt32(tabela_memoria.Rows[0]["id_caixa"].ToString());
                Fec.Responsavel = tabela_memoria.Rows[0]["responsavel"].ToString();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public Boolean VerificaCaixa2(string codper,DateTime data)
        {
            executarComando("select id_caixa,id_turno,datainicio,valor_relat from caixa WHERE status='Fechado' and id_turno='"+codper+"' and datainicio='"+data.ToString("yyyy/MM/dd")+"';");
            try
            {
                Fec.Id_caixa = Convert.ToInt32(tabela_memoria.Rows[0]["id_caixa"].ToString());
                Fec.Id_turno = Convert.ToInt32(tabela_memoria.Rows[0]["id_turno"].ToString());
                Fec.Data = Convert.ToDateTime(tabela_memoria.Rows[0]["datainicio"].ToString());
                fec.Valor = tabela_memoria.Rows[0]["valor_relat"].ToString();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public Boolean VerificaRelat(string codcaixa)
        {
            executarComando("select valor_relat from caixa WHERE id_caixa='"+codcaixa+"';");
            try
            {
                fec.Valor = tabela_memoria.Rows[0]["valor_relat"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
