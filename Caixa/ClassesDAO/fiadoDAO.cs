using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class fiadoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        fiado ass = new fiado();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        public static string nome;
        internal fiado Ass { get => ass; set => ass = value; }
        public static string Nome { get => nome; set => nome = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region INSERIR ASSINADA
        public void Inserir(fiado ass)
        {
            executarComando("insert into fiado values('" +ass.Id_pessoa+ "','" + ass.Valor.ToString().Replace(",",".")+ "');");
        }
        #endregion


        #region VERIFICA O VALOR DO ID
        public Boolean Verificafiado(string id)
        {
            executarComando("SELECT * FROM FIADO where id_pessoa='" + id + "';");
            try
            {
                Ass.Id_pessoa = Convert.ToInt32(tabela_memoria.Rows[0]["id_pessoa"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
   
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,IF(a.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(a.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR FROM fiado A INNER JOIN PESSOA P ON P.ID_PESSOA = A.ID_PESSOA order by p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();      
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }

        public DataTable ListarNome(string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,IF(a.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(a.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR FROM fiado A INNER JOIN PESSOA P ON P.ID_PESSOA = A.ID_PESSOA WHERE p.nome='"+nome+"' order by p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }

        public void Update(fiado ass)
        {
            executarComando("UPDATE fiado SET valor=valor+'" + ass.Valor.ToString().Replace(",", ".") + "' where id_pessoa='"+ass.Id_pessoa+"';");
        }

        public void Update2(fiado ass)
        {
            executarComando("UPDATE fiado SET valor=valor-'" + ass.Valor.ToString().Replace(",", ".") + "' where id_pessoa='" + ass.Id_pessoa + "';");
        }
 
        #region VERIFICA NOME
        public Boolean VerificaNome(fiado ass)
        {
            executarComando("select nome from pessoa where id_pessoa='"+ass.Id_pessoa+"';");
            try
            {           
                nome= tabela_memoria.Rows[0]["nome"].ToString();               
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
