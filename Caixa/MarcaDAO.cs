using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class MarcaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Marcas mar = new Marcas();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Marcas Mar { get => mar; set => mar = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region LISTARTUDOMARCA
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;  
            executarComando("SELECT id_marca as ID,marca as MARCA FROM MARCA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();             
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTARTUDOCARTAO
        public DataTable ListarCartao(string codmarca)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cartao as ID,cartao as CART FROM CARTAO where id_marca='"+codmarca+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
