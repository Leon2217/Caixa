using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class suprimentoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        suprimentos supri = new suprimentos();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal suprimentos Supri { get => supri; set => supri = value; }

        public static string Codcaixa { get => codcaixa; set => codcaixa = value; }
        public static string Totalsuprimento { get => totalsuprimento; set => totalsuprimento = value; }
        public static string Totaltardesupri { get => totaltardesupri; set => totaltardesupri = value; }

        public static string codcaixa;

        public static string totaltardesupri;

        public static string totalsuprimento;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        public void inserir(suprimentos supri)
        {
            executarComando("INSERT INTO SUPRIMENTO VALUES(0,'" + supri.Id_caixa + "','" + supri.Valor.ToString().Replace(",",".") + "');");
        }

        public Boolean Verificasupri(string codcaixa)
        {
            executarComando("SELECT * FROM SUPRIMENTO WHERE id_caixa='" + codcaixa + "';");
            try
            {
                supri.Valor =tabela_memoria.Rows[0]["valor"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void update(suprimentos supri)
        {
            executarComando("UPDATE SUPRIMENTO SET valor='" + supri.Valor.ToString().Replace(",",".") +"' where id_caixa='"+supri.Id_caixa+"';");
        }

        public Boolean Verificatotalsupri(string codcaixa)
        {
            executarComando("select valor from suprimento s inner join caixa ca on ca.id_caixa=s.id_caixa inner join turno t on t.id_turno=ca.id_turno where ca.id_caixa='" +codcaixa + "';");
            try
            {
                 totalsuprimento = tabela_memoria.Rows[0]["valor"].ToString();
                 return true;
            }
            catch
            {
                return false;
            }
        }

       


    }
}
