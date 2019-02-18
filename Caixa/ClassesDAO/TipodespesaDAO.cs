using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class TipodespesaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Tipodespesa tipodespesa = new Tipodespesa();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Tipodespesa Tipodespesa { get => tipodespesa; set => tipodespesa = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR TIPODESPESA
        public void Inserir(Tipodespesa td)
        {
            executarComando("INSERT INTO TIPO_DESPESA VALUES(0,'" + td.Nome + "');");
        }
        #endregion

        #region VERIFICA SE O NOME JÁ FOI CADASTRADO
        public Boolean Verificaexiste(string nome)
        {
            executarComando("SELECT nome FROM TIPO_DESPESA WHERE nome='" + nome + "';");
            try
            {
                tipodespesa.Nome = tabela_memoria.Rows[0]["nome"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region LISTAR TIPOS DESPESA
        public DataTable ListarTipoDespesa()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_tipodespesa as ID, nome as NOME FROM TIPO_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
