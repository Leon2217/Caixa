using System;
using System.Data;
using MySql.Data.MySqlClient;
using Caixa.Classes;

namespace Caixa.ClassesDAO
{
    class relatconsumoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        RelatConsumo rlc = new RelatConsumo();
        private static string nome;

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal RelatConsumo Rlc { get => rlc; set => rlc = value; }
        public static string Nome { get => nome; set => nome = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR RELATFIADO
        public void Inserir(RelatConsumo rlc)
        {
            executarComando("insert into relatconsumo values(0,'" + rlc.Id_pessoa + "','" + rlc.Valor.ToString().Replace(",", ".") + "','" + rlc.Descr + "','" + rlc.Data.ToString("yyyy/MM/dd") + "');");
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,rf.descr as DESCRICAO,IF(rf.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(rf.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA FROM relatconsumo rf INNER JOIN PESSOA P ON P.ID_PESSOA = RF.ID_PESSOA order by p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DESCRICAO"] = tabela_memoria.Rows[i]["DESCRICAO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTAR NOME
        public DataTable ListarNome(string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,rf.descr as DESCRICAO,IF(rf.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(rf.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA FROM relatconsumo rf INNER JOIN PESSOA P ON P.ID_PESSOA = RF.ID_PESSOA WHERE p.nome LIKE '" + nome + "%' order by p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DESCRICAO"] = tabela_memoria.Rows[i]["DESCRICAO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarDe(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,rf.descr as DESCRICAO,IF(rf.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(rf.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA FROM relatconsumo rf INNER JOIN PESSOA P ON P.ID_PESSOA = RF.ID_PESSOA WHERE rf.data = '" + de.ToString("yyyy/MM/dd") + "' order by rf.data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DESCRICAO"] = tabela_memoria.Rows[i]["DESCRICAO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion        

        #region LISTAR BTN
        public DataTable ListarBTN(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,rf.descr as DESCRICAO,IF(rf.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(rf.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA FROM relatconsumo rf INNER JOIN PESSOA P ON P.ID_PESSOA = RF.ID_PESSOA WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' order by rf.data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DESCRICAO"] = tabela_memoria.Rows[i]["DESCRICAO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTAR DE NOME
        public DataTable ListarDeNome(string nome, DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,rf.descr as DESCRICAO,IF(rf.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(rf.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA FROM relatconsumo rf INNER JOIN PESSOA P ON P.ID_PESSOA = RF.ID_PESSOA WHERE p.nome LIKE '" + nome + "%'  AND  rf.data = '" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DESCRICAO"] = tabela_memoria.Rows[i]["DESCRICAO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion        

        #region LISTAR BTN NOME
        public DataTable ListarBTNNOME(string nome, DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,rf.descr as DESCRICAO,IF(rf.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(rf.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,DATE_FORMAT(data, '%d/%m/%y') as DATA FROM relatconsumo rf INNER JOIN PESSOA P ON P.ID_PESSOA = RF.ID_PESSOA WHERE p.nome LIKE '" + nome + "%' AND DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' order by rf.data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DESCRICAO"] = tabela_memoria.Rows[i]["DESCRICAO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion

        #region LISTARSOMAVALORESGASTOSMES
        public DataTable ListarMes(string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME, IF(round(sum(rc.valor),2)=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(round(sum(rc.valor),2),2), '.', '|'), ',', '.'), '|', ','))) as VALOR FROM consumo A INNER JOIN PESSOA P ON P.ID_PESSOA = A.ID_PESSOA INNER JOIN relatconsumo rc on A.ID_PESSOA = RC.ID_PESSOA where month(data) = month(now()) and p.nome LIKE '" + nome + "%'; ");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();

                listaDescripto.Rows.Add(linha);
            }

            return listaDescripto;
        }
        #endregion       
    }
}
