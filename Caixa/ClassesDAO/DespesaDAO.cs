using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class DespesaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Despesa desp = new Despesa(); 

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Despesa Desp { get => desp; set => desp = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }


        #region INSERIR DESPESA
        public void Inserir(Despesa desp)
        {
            executarComando("INSERT INTO DESPESA VALUES(0,'" + desp.Id_pessoa + "',null,'" + desp.Descr + "','" + desp.Valor.ToString().Replace(",",".") + "','" + desp.Data.ToString("yyyy/MM/dd") + "','"+desp.Status+"');");
        }
        #endregion

        #region INSERIR DESPESA OUTROS
        public void Inserir2(Despesa desp)
        {
            executarComando("INSERT INTO DESPESA VALUES(0,null,'"+desp.Id_tipodespesa+"','" + desp.Descr + "','" + desp.Valor.ToString().Replace(",", ".") + "','" + desp.Data.ToString("yyyy/MM/dd") + "','" + desp.Status + "');");
        }
        #endregion

         public void Excluir(string id)
        {
            executarComando("DELETE FROM DESPESA WHERE id_despesa ='" + id + "';");
        }

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
      
        #region ListarTudoSemForn
        public DataTable ListarTudoSemForn()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,tp.nome as TIPO,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN TIPO_DESPESA TP ON TP.ID_TIPODESPESA=D.ID_TIPODESPESA ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarSemForn DE
        public DataTable ListarSemFornDE(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,tp.nome as TIPO,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN TIPO_DESPESA TP ON TP.ID_TIPODESPESA=D.ID_TIPODESPESA WHERE data='" + de.ToString("yyyy/MM/dd") + "' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarSemForn BTN
        public DataTable ListarSemFornBTN(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,tp.nome as TIPO,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN TIPO_DESPESA TP ON TP.ID_TIPODESPESA=D.ID_TIPODESPESA WHERE data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' ORDER BY data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarSemFornStatus
        public DataTable ListarSemFornStatus(string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,tp.nome as TIPO,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN TIPO_DESPESA TP ON TP.ID_TIPODESPESA=D.ID_TIPODESPESA WHERE status='" + status + "' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarSemFornStatus DE
        public DataTable ListarSemFornStatusDE(string status, DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,tp.nome as TIPO,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN TIPO_DESPESA TP ON TP.ID_TIPODESPESA=D.ID_TIPODESPESA WHERE status='" + status + "' and data='" + de.ToString("yyyy/MM/dd") + "' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarSemFornStatus BTN
        public DataTable ListarSemFornStatusBTN(DateTime de, DateTime at, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,tp.nome as TIPO,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN TIPO_DESPESA TP ON TP.ID_TIPODESPESA=D.ID_TIPODESPESA WHERE data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and status='" + status + "' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarDE(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where data='"+de.ToString("yyyy/MM/dd")+ "' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR PESSOA LIKE
        public DataTable ListarP(string pes)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where p.nome LIKE '" +pes+ "%' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR PESSOA LIKE
        public DataTable ListarPD(string pes,DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where p.nome LIKE '" + pes + "%' and data='"+data.ToString("yyyy/MM/dd")+"' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR STATUS
        public DataTable ListarS(string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA Where status='"+status+"' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE STATUS
        public DataTable ListarDS(DateTime de,string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA Where status='" + status + "' and data='"+de.ToString("yyyy/MM/dd")+"' ORDER BY ID_DESPESA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '"+at.ToString("yyyy/MM/dd")+"' ORDER BY data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E PESSOA
        public DataTable ListarBP(DateTime de, DateTime at,string pessoa)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and p.nome='"+pessoa+"' ORDER BY data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E STATUS
        public DataTable ListarBS(DateTime de, DateTime at, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and status='" + status + "' ORDER BY data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR STATUS E PESSOA
        public DataTable ListarSP(string status, string pessoa)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA Where status='" + status + "' and p.nome='"+pessoa+"' ORDER BY data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE STATUS E PESSOA
        public DataTable ListarDSP(DateTime de,string status, string pessoa)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA Where data='"+de.ToString("yyyy/MM/dd")+"'and status='" + status + "' and p.nome='" + pessoa + "' ORDER BY id_despesa;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E PESSOA E STATUS
        public DataTable ListarBPS(DateTime de, DateTime at, string pessoa,string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_despesa as ID,DATE_FORMAT(data, '%d/%m/%y')  as DATA,p.nome as PESSOA,descr as DESCR,IF(valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM DESPESA D INNER JOIN PESSOA P ON P.ID_PESSOA=D.ID_PESSOA  where data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and p.nome='" + pessoa + "' and status='"+status+"' ORDER BY data;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["PESSOA"] = tabela_memoria.Rows[i]["PESSOA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region UPDATE STATUS PELO ID
        public void UpdateStatus(string status, string id)
        {
            executarComando("UPDATE DESPESA SET STATUS='" + status + "' where id_despesa='" + id + "';");
        }
        #endregion

        #region VERIFICA O VALOR DO ID
        public Boolean Verificavalor(string id)
        {
            executarComando("SELECT * FROM DESPESA where id_despesa='" + id + "';");
            try
            {
                Desp.Valor = tabela_memoria.Rows[0]["valor"].ToString();
                Desp.Data = Convert.ToDateTime(tabela_memoria.Rows[0]["data"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region UPDATE CONTAS
        public void UpdateAtrasado()
        {
            executarComando("UPDATE DESPESA SET STATUS='Atrasado' where data<curdate() and status!='Pago';");
        }
        #endregion

        #region VERIFICA A QTD DE DESPESA ATRASADAS
        public Boolean VerificaAtrasado()
        {
            executarComando("select count(*) as QTD from despesa where status = 'Atrasado';");
            try
            {
                Desp.N = Convert.ToInt32(tabela_memoria.Rows[0]["QTD"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A QTD DE DESPESA EM ABERTO
        public Boolean VerificaEmAberto()
        {
            executarComando("select count(*) as QTD from despesa where status = 'Em aberto';");
            try
            {
                Desp.N = Convert.ToInt32(tabela_memoria.Rows[0]["QTD"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region UPDATE VALOR PELO ID
        public void UpdateValorDespesa(string valor, string id)
        {
            executarComando("UPDATE DESPESA SET valor='" + valor.ToString().Replace(",", ".") + "' where id_despesa='" + id + "';");
        }
        #endregion

        #region VERIFICA STATUS
        public Boolean VerificaStatusEmAberto(string id)
        {
            executarComando("select status as STATUS from despesa where status = 'Em Aberto' and id_despesa = '" + id + "'; ");
            try
            {
                Desp.Status = (tabela_memoria.Rows[0]["STATUS"].ToString());
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
