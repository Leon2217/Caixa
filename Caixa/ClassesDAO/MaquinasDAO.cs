using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class MaquinasDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Maquinas maq = new Maquinas();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Maquinas Maq { get => maq; set => maq = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT * FROM MAQUINA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["id_maquina"] = tabela_memoria.Rows[i]["id_maquina"].ToString();
                linha["maquina"] = tabela_memoria.Rows[i]["maquina"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
    }
}
