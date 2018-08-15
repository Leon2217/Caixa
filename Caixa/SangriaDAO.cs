using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class SangriaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Sangria san = new Sangria();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Sangria San { get => san; set => san = value; }



        public static string totalsangria;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public void Inserir(Sangria san)
        {
            executarComando("INSERT INTO SANGRIA VALUES(0,'" + san.Id_caixa + "','" + san.Valor.ToString().Replace(",", ".") + "');");
        }

        public Boolean Verificasangria(string codcaixa)
        {
            executarComando("SELECT sum(valor) FROM sangria WHERE id_caixa='" + codcaixa + "';");
            try
            {
                totalsangria = tabela_memoria.Rows[0]["sum(valor)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
