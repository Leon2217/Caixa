using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class ValoroperadoraDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Valoroperadora valorop = new Valoroperadora();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Valoroperadora Valorop { get => valorop; set => valorop = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region INSERIR VALORES NAS OPERADORAS
        public void Inserir(Valoroperadora vop)
        {
            executarComando("INSERT INTO VALOR_OPERADORA VALUES(0,'"+vop.Id_operadora+"','" +vop.Valor.ToString().Replace(",",".")+"');");
        }
        #endregion

        #region LISTA OS VALOR POR OPERADORA
        public DataTable Listarvalores(string operadora)
        {
            DataTable listaDescripto;
            executarComando("SELECT valor FROM VALOR_OPERADORA VO INNER JOIN OPERADORA OP ON OP.ID_OPERADORA=VO.ID_OPERADORA  WHERE OP.OPERADORA='" + operadora + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["valor"] = tabela_memoria.Rows[i]["valor"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA OS VALORES E O ID DO VALOR
        public DataTable Listarvalores2(string operadora)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_valor,valor FROM VALOR_OPERADORA VO INNER JOIN OPERADORA OP ON OP.ID_OPERADORA=VO.ID_OPERADORA  WHERE OP.OPERADORA='"+operadora+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["id_valor"]= tabela_memoria.Rows[i]["id_valor"].ToString();
                linha["valor"] = tabela_memoria.Rows[i]["valor"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region DELETAR VALORES PELO ID DO VALOR
        public void Excluir(string id)
        {
            executarComando("DELETE FROM VALOR_OPERADORA WHERE id_valor ='" + id + "';");
        }
        #endregion      

        #region LISTA OS VALORES POR ID DA OPERADORA
        public DataTable Listarvalores3(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_valor,valor FROM VALOR_OPERADORA VO INNER JOIN OPERADORA OP ON OP.ID_OPERADORA=VO.ID_OPERADORA WHERE OP.id_operadora='" + id + "' ORDER by CAST(valor as decimal) asc;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["valor"] = tabela_memoria.Rows[i]["valor"].ToString();
                linha["id_valor"] = tabela_memoria.Rows[i]["id_valor"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
