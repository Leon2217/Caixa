using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class EntradamoedaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Entradamoeda em = new Entradamoeda();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Entradamoeda Em { get => em; set => em = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR ENTRADA DE MOEDA
        public void Inserir(Entradamoeda em)
        {
            executarComando("INSERT INTO ENTRADA_MOEDA VALUES(0,'" +em.Moeda_1 + "','"+em.Moeda_50+"','" +em.Moeda_25+ "','" +em.Moeda_10 + "','" +em.Moeda_5+ "','"+em.Valor.ToString().Replace(",",".")+"','"+em.Hora.ToString("HH:mm")+"','"+em.Data.ToString("yyyy/MM/dd")+"','"+em.Responsavel+"');");
        }
        #endregion
    }
}
