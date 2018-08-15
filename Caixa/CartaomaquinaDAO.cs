using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class CartaomaquinaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Cartaomaquina carma = new Cartaomaquina();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Cartaomaquina Carma { get => carma; set => carma = value; }

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
            executarComando("select c.cartao,c.id_cartao from cartaomaquina cm inner join cartao c on c.id_cartao = cm.id_cartao inner join maquina m on m.id_maquina = cm.id_maquina where cm.id_maquina = 1;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["cartao"] = tabela_memoria.Rows[i]["cartao"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }

        public DataTable ListarOutro(string cartao,string codmaq)
        {
            DataTable listaDescripto;
            executarComando("select c.cartao,c.id_cartao from cartaomaquina cm inner join cartao c on c.id_cartao=cm.id_cartao inner join maquina m on m.id_maquina=cm.id_maquina where c.cartao like'"+cartao+"%'and c.id_cartao>16 and m.id_maquina='"+codmaq+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["cartao"] = tabela_memoria.Rows[i]["cartao"].ToString();
                linha["id_cartao"] = tabela_memoria.Rows[i]["id_cartao"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }


        public Boolean Verificacart(string cartao,string codmaq)
        {
            executarComando("select c.cartao,c.id_cartao from cartaomaquina cm inner join cartao c on c.id_cartao=cm.id_cartao inner join maquina m on m.id_maquina=cm.id_maquina where c.cartao like'" + cartao + "%'and c.id_cartao>16 and m.id_maquina='" + codmaq + "';");
            try
            {
                carma.Id_cartao= Convert.ToInt32(tabela_memoria.Rows[0]["id_cartao"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Pesquisacart(string codcart, string codmaq)
        {
            executarComando("SELECT * FROM CARTAOMAQUINA WHERE id_cartao='" + codcart + "'and id_maquina='" + codmaq + "';");
            try
            {
                carma.Id_cartao = Convert.ToInt32(tabela_memoria.Rows[0]["id_cartao"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
