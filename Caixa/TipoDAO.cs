using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class TipoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        TipoPessoa tipo = new TipoPessoa();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal TipoPessoa Tipo { get => tipo; set => tipo = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR TIPO
        public void Inserir(TipoPessoa tp)
        {
            executarComando("INSERT INTO TIPO_PESSOA VALUES(0,'" + tp.Tipo + "');");
        }
        #endregion

        #region LISTAR TUDO
        public DataTable Listartudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_tp as ID,tipo as TIPO FROM TIPO_PESSOA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region EXCLUIR
        public void Excluir(string id)
        {
            executarComando("DELETE FROM tipo_pessoa WHERE id_tp ='" + id + "';");
        }
        #endregion

        #region VERIFICA SE O NOME JÁ FOI CADASTRADO
        public Boolean Verificaexiste(string nome)
        {
            executarComando("SELECT tipo FROM tipo_pessoa WHERE tipo='" + nome + "';");
            try
            {
                tipo.Tipo = tabela_memoria.Rows[0]["tipo"].ToString();      
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

       
    }
}
