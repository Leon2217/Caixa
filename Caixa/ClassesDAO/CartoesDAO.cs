using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class CartoesDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Cartoes car = new Cartoes();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Cartoes Car { get => car; set => car = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
    }
}
