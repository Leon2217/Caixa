using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class FaltaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Falta falta = new Falta();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Falta Falta { get => falta; set => falta = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR FALTA
        public void Inserir(Falta fal)
        {
            executarComando("INSERT INTO FALTA VALUES(0,'" + fal.Id_pessoa + "','"+fal.Data.ToString("yyyy/MM/dd")+"','"+fal.Periodo.ToString()+"');");
        }
        #endregion

        #region LISTAR TODAS AS FALTAS
        public DataTable Listartudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,DATE_FORMAT(f.data,'%d/%m/%y') as DATA,f.periodo as PERIODO FROM FALTA F INNER JOIN PESSOA P ON P.ID_PESSOA=F.ID_PESSOA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();                
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["PERIODO"] = tabela_memoria.Rows[i]["PERIODO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TODAS AS FALTAS POR NOME
        public DataTable ListarNome(string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,DATE_FORMAT(f.data,'%d/%m/%y') as DATA,f.periodo as PERIODO FROM FALTA F INNER JOIN PESSOA P ON P.ID_PESSOA=F.ID_PESSOA WHERE p.NOME LIKE '" + nome + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["PERIODO"] = tabela_memoria.Rows[i]["PERIODO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE E NOME
        public DataTable ListarDN(DateTime data,string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,DATE_FORMAT(f.data,'%d/%m/%y') as DATA,f.periodo as PERIODO FROM FALTA F INNER JOIN PESSOA P ON P.ID_PESSOA=F.ID_PESSOA WHERE f.data = '" + data.ToString("yyyy/MM/dd") + "' AND p.nome LIKE '" + nome + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["PERIODO"] = tabela_memoria.Rows[i]["PERIODO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarDe(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,DATE_FORMAT(f.data,'%d/%m/%y') as DATA,f.periodo as PERIODO FROM FALTA F INNER JOIN PESSOA P ON P.ID_PESSOA=F.ID_PESSOA WHERE f.data = '" + data.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["PERIODO"] = tabela_memoria.Rows[i]["PERIODO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime data,DateTime data2)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,DATE_FORMAT(f.data,'%d/%m/%y') as DATA,f.periodo as PERIODO FROM FALTA F INNER JOIN PESSOA P ON P.ID_PESSOA=F.ID_PESSOA WHERE f.data BETWEEN '" + data.ToString("yyyy/MM/dd") + "' AND '" + data2.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["PERIODO"] = tabela_memoria.Rows[i]["PERIODO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BN
        public DataTable ListarBN(DateTime data, DateTime data2,string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,DATE_FORMAT(f.data,'%d/%m/%y') as DATA,f.periodo as PERIODO FROM FALTA F INNER JOIN PESSOA P ON P.ID_PESSOA=F.ID_PESSOA WHERE f.data BETWEEN '" + data.ToString("yyyy/MM/dd") + "' AND '" + data2.ToString("yyyy/MM/dd") + "' AND p.nome LIKE '" + nome + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["PERIODO"] = tabela_memoria.Rows[i]["PERIODO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
