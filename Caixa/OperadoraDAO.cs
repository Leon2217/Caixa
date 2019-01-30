using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class OperadoraDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Operadoras op = new Operadoras();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Operadoras Op { get => op; set => op = value; }


        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region VERIFICA SE O NOME JÁ FOI CADASTRADO
        public Boolean Verificaexiste(string nome)
        {
            executarComando("SELECT operadora FROM OPERADORA WHERE operadora='"+nome+"';");
            try
            {
                Op.Operadora =tabela_memoria.Rows[0]["operadora"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        

        #region INSERIR OPERADORA
        public void Inserir(Operadoras op)
        {
            executarComando("INSERT INTO OPERADORA VALUES(0,'"+op.Operadora+ "');");
        }
        #endregion

        #region LISTAR TODAS OPERADORAS FILTRANDO
        public DataTable Listarfiltro(string operadora)
        {
            DataTable listaDescripto;
            executarComando("SELECT * FROM OPERADORA WHERE OPERADORA LIKE '"+operadora+"%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["id_operadora"] = tabela_memoria.Rows[i]["id_operadora"].ToString();
                linha["operadora"] = tabela_memoria.Rows[i]["operadora"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion




        #region LISTA TODAS AS OPERADORAS
        public DataTable Listartudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT * FROM OPERADORA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["id_operadora"] = tabela_memoria.Rows[i]["id_operadora"].ToString();
                linha["operadora"] = tabela_memoria.Rows[i]["operadora"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region DELETAR OPERADORA PELO ID
        public void excluir(string id)
        {
            executarComando("DELETE FROM OPERADORA WHERE id_operadora ='" +id+ "';");
        }
        #endregion
    }
}
