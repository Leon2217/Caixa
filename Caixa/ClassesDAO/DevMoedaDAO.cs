using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class DevMoedaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        DevMoeda dm = new DevMoeda();
        
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal DevMoeda Dm { get => dm; set => dm = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        public void Inserir(DevMoeda dm)
        {
            executarComando("INSERT INTO DEV_MOEDA VALUES(0,'" + dm.Valor + "','" + dm.Hora.ToString("HH:mm") + "','" + dm.Data.ToString("yyyy/MM/dd") + "','" +dm.Responsavel + "');");
        }
    }
}
