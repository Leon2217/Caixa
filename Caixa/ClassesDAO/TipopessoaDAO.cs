using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class TipopessoaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Tipopessoa tipopes = new Tipopessoa();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Tipopessoa Tipopes { get => tipopes; set => tipopes = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }


        #region INSERIR TIPOPESSOA
        public void Inserir(Tipopessoa tp)
        {
            executarComando("INSERT INTO TIPO_PESSOA VALUES('" + tp.Id_tipo + "','"+tp.Id_pessoa+"');");
        }
        #endregion

        #region EXCLUIR
        public void Excluir(string id)
        {
            executarComando("DELETE FROM TIPO_PESSOA WHERE id_pessoa ='" + id + "';");
        }
        #endregion



    }
}
