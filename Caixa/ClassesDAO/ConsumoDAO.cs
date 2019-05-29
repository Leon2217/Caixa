using System;
using System.Data;
using MySql.Data.MySqlClient;
using Caixa.Classes;

namespace Caixa.ClassesDAO
{
    class ConsumoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Consumo cons = new Consumo();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        public static string nome;
        public static string Nome { get => nome; set => nome = value; }
        internal Consumo Cons { get => cons; set => cons = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region VERIFICA O VALOR DO ID
        public Boolean Verificaconsumo(string id)
        {
            executarComando("SELECT * FROM consumo where id_pessoa='" + id + "';");
            try
            {
                Cons.Id_pessoa = Convert.ToInt32(tabela_memoria.Rows[0]["id_pessoa"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INSERIR CONSUMO
        public void Inserir(Consumo cons)
        {
            executarComando("insert into consumo values('" + cons.Id_pessoa + "','" + cons.Valor.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region UPDATE CONSUMO
        public void Update(Consumo cons)
        {
            executarComando("UPDATE consumo SET valor=valor+'" + cons.Valor.ToString().Replace(",", ".") + "' where id_pessoa='" + cons.Id_pessoa + "';");
        }
        #endregion

        #region ListarValoresGastosnoMês
        public DataTable ListarMes()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID, p.nome as NOME, sum(rc.valor) as VALOR FROM consumo A INNER JOIN PESSOA P ON P.ID_PESSOA = A.ID_PESSOA INNER JOIN relatconsumo rc on A.ID_PESSOA = RC.ID_PESSOA where month(data) = month(now()) group by p.nome;");
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
        #endregion

        #region Listar Tudo
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,IF(a.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(a.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR FROM consumo A INNER JOIN PESSOA P ON P.ID_PESSOA = A.ID_PESSOA order by p.nome ASC;");
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
        #endregion
    }
}
