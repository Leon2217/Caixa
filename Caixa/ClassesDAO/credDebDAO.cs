﻿using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace Caixa
{   
    class credDebDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        CredDeb cd = new CredDeb();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR CREDITO_DEBITO
        public void Inserir(CredDeb cd)
        {
            executarComando("INSERT INTO CREDITO_DEBITO VALUES(0,'"+cd.Data.ToString("yyyy/MM/dd")+ "','" +cd.Hora.ToString("HH:mm")+ "','" + cd.Desc_db+ "','" + cd.Responsa_db + "','" + cd.Cred_db.ToString().Replace(",",".")+ "','"+cd.Deb_db.ToString().Replace(",",".")+ "','"+cd.Total.ToString()+"','"+cd.C+"');");
        }
        #endregion

        #region UPDATE CONFERIDO PELO ID
        public void UpdateConferido(string id)
        {
            executarComando("UPDATE CREDITO_DEBITO SET c = 'C' where id_cd='" + id + "';");
        }
        #endregion        

        #region UPDATE RETIRANDO CONFERIDO PELO ID
        public void UpdateConferido2(string id)
        {
            executarComando("UPDATE CREDITO_DEBITO SET c = '' where id_cd='" + id + "';");
        }
        #endregion        

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime de,DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C  FROM CREDITO_DEBITO WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd")+"' and '"+at.ToString("yyyy/MM/dd")+"' ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] =tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarD(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID,DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C  FROM CREDITO_DEBITO WHERE DATA='" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();


                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();
      

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C FROM CREDITO_DEBITO;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }

        public DataTable Teste()
        {
            DataTable listaDescripto;
            executarComando("SELECT CAST(total as decimal(8,2)) FROM CREDITO_DEBITO;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["CAST(total as decimal(8,2))"] = tabela_memoria.Rows[i]["CAST(total as decimal(8,2))"].ToString();
               

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DESC
        public DataTable ListarDesc(string descr)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C FROM CREDITO_DEBITO WHERE desc_db LIKE '" + descr + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();


                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE DESC
        public DataTable ListarDD(DateTime de, string descr)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C FROM CREDITO_DEBITO WHERE DATA='" + de.ToString("yyyy/MM/dd") + "' and desc_db LIKE '" + descr + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();



                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN DESC
        public DataTable ListarBDESC(DateTime de, DateTime at, string descr)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C  FROM CREDITO_DEBITO WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and desc_db LIKE '" + descr + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();


                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR VALOR
        public DataTable ListarValor(string credito, string debito)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C FROM CREDITO_DEBITO WHERE (cred_db LIKE '" + credito.ToString().Replace(',','.') + "%' OR deb_db LIKE '" + debito.ToString().Replace(',', '.') + "%');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DESC VALOR ZICA
        public DataTable ListarDescValor(string descr, string credito, string debito)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C FROM CREDITO_DEBITO WHERE desc_db LIKE '" + descr + "%' AND  (cred_db LIKE '" + credito.ToString().Replace(',', '.') + "%' OR deb_db LIKE '" + debito.ToString().Replace(',', '.') + "%');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE VALOR
        public DataTable ListarDV(DateTime de, string credito, string debito)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C  FROM CREDITO_DEBITO WHERE DATA='" + de.ToString("yyyy/MM/dd") + "' AND (cred_db LIKE '" + credito.ToString().Replace(',', '.') + "%' OR deb_db LIKE '" + debito.ToString().Replace(',', '.') + "%');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();


                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN VALOR
        public DataTable ListarBVALOR(DateTime de, DateTime at, string credito, string debito)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C  FROM CREDITO_DEBITO WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' AND (cred_db LIKE '" + credito.ToString().Replace(',', '.') + "%' OR deb_db LIKE '" + debito.ToString().Replace(',', '.') + "%');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();


                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE DESC VALOR
        public DataTable ListarDDV(DateTime de, string descr, string credito, string debito)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C FROM CREDITO_DEBITO WHERE DATA='" + de.ToString("yyyy/MM/dd") + "' and desc_db LIKE '" + descr + "%' AND (cred_db LIKE '" + credito.ToString().Replace(',', '.') + "%' OR deb_db LIKE '" + debito.ToString().Replace(',', '.') + "%');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN DESC VALOR
        public DataTable ListarBDESCVALOR(DateTime de, DateTime at, string descr, string credito, string debito)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_cd as ID, DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_db as DESCR,responsa_db as RESP,IF(cred_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(cred_db, 2), '.', '|'), ',', '.'), '|', ','))) as CRED,IF(deb_db=('0.00'),'',Concat(Replace(Replace(Replace(Format(deb_db, 2), '.', '|'), ',', '.'), '|', ','))) as DEB,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL, TIME_FORMAT(hora,'%H:%i') as HORA, c as C  FROM CREDITO_DEBITO WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and desc_db LIKE '" + descr + "%' AND (cred_db LIKE '" + credito.ToString().Replace(',', '.') + "%' OR deb_db LIKE '" + debito.ToString().Replace(',', '.') + "%');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();


                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["CRED"] = tabela_memoria.Rows[i]["CRED"].ToString();
                linha["DEB"] = tabela_memoria.Rows[i]["DEB"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["C"] = tabela_memoria.Rows[i]["C"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
