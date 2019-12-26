using System;
using System.Data;
using MySql.Data.MySqlClient;
using Caixa.Classes;

namespace Caixa.ClassesDAO
{
    class PagfiadoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Pagfiado pgfiado = new Pagfiado();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Pagfiado Pgfiado { get => pgfiado; set => pgfiado = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }


        #region INSERIR PAGFIADO
        public void Inserir(Pagfiado pgf)
        {
            executarComando("insert into pagfiado values(0,'" + pgf.Id_pessoa + "','" + pgf.Valor.ToString().Replace(",", ".") + "','" + pgf.Data.ToString("yyyy/MM/dd") +"','"+ pgf.Forma +"');");
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME, IF(pg.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(pg.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA, pg.forma as FORMA FROM pagfiado pg INNER JOIN PESSOA P ON P.ID_PESSOA = pg.ID_PESSOA order by p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["FORMA"] = tabela_memoria.Rows[i]["FORMA"].ToString();
                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTAR NOME
        public DataTable ListarNome(string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,IF(pg.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(pg.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA, pg.forma as FORMA FROM pagfiado pg INNER JOIN PESSOA P ON P.ID_PESSOA = pg.ID_PESSOA WHERE p.nome LIKE '" + nome + "%' order by p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["FORMA"] = tabela_memoria.Rows[i]["FORMA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarDe(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,IF(pg.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(pg.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA, pg.forma as FORMA FROM pagfiado pg INNER JOIN PESSOA P ON P.ID_PESSOA = pg.ID_PESSOA WHERE pg.data = '" + de.ToString("yyyy/MM/dd") + "' order by pg.data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["FORMA"] = tabela_memoria.Rows[i]["FORMA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion        

        #region LISTAR BTN
        public DataTable ListarBTN(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,IF(pg.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(pg.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA, pg.forma as FORMA FROM pagfiado pg INNER JOIN PESSOA P ON P.ID_PESSOA = pg.ID_PESSOA WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' order by pg.data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["FORMA"] = tabela_memoria.Rows[i]["FORMA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTAR DE NOME
        public DataTable ListarDeNome(string nome, DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,IF(pg.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(pg.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA, pg.forma as FORMA FROM pagfiado pg INNER JOIN PESSOA P ON P.ID_PESSOA = pg.ID_PESSOA WHERE p.nome LIKE '" + nome + "%'  AND  pg.data = '" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["FORMA"] = tabela_memoria.Rows[i]["FORMA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion        

        #region LISTAR BTN NOME
        public DataTable ListarBTNNOME(DateTime de, DateTime at, string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,IF(pg.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(pg.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA, pg.forma as FORMA FROM pagfiado pg INNER JOIN PESSOA P ON P.ID_PESSOA = pg.ID_PESSOA WHERE p.nome LIKE '" + nome + "%' AND DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' order by pg.data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["FORMA"] = tabela_memoria.Rows[i]["FORMA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion
    }
}
