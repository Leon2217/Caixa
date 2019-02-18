using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class TurnoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Turnos tur = new Turnos();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Turnos Tur { get => tur; set => tur = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
    }
}
