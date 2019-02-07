using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class CreditoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Credito cre = new Credito();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Credito Cre { get => cre; set => cre = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region INSERIR CRÉDITO                 
        public void Inserir(Credito cre)
        {
            executarComando("INSERT INTO CREDITO VALUES(0,'" +cre.Desc_credito + "','"+cre.Valor.ToString().Replace(",",".")+"','"+cre.Hora.ToString("HH:mm")+"','"+cre.Data.ToString("yyyy/MM/dd")+"','"+cre.Responsavel+"');");
        }
        #endregion


    }
}
