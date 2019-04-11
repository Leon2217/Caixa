using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class GeralDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Geral ger = new Geral();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Geral Ger { get => ger; set => ger = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR GERAL
        public void Inserir(Geral gr)
        {
            executarComando("INSERT INTO GERAL VALUES(0,'" + gr.Data.ToString("yyyy/MM/dd") + "','" +gr.Desc_g.ToString()+ "','" + gr.Cred_g.ToString().Replace(",",".") + "','" + gr.Deb_g.ToString().Replace(",", ".") + "','" + gr.Total.ToString().Replace(",", ".") + "','" + gr.Forn.ToString().Replace(",",".")+ "','" + gr.Func.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region VERIFICA A SOMA FORN
        public Boolean VerificaSomaForn()
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL WHERE FORN NOT IN('0.00');");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA FUNC
        public Boolean VerificaSomaFunc()
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL WHERE FUNC NOT IN('0.00');");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE FORN
        public Boolean VerificaSDForn(DateTime de)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where FORN not in('0.00') AND data='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE FUNC
        public Boolean VerificaSDFunc(DateTime de)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where FUNC not in('0.00') AND data='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN FORN
        public Boolean VerificaSBForn(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where FORN not in('0.00') AND data BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN FUNC
        public Boolean VerificaSBFunc(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where FUNC not in('0.00') AND data BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA FORNFUNC
        public Boolean VerificaSomaFornFunc()
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL WHERE FORN NOT IN('0.00') || FUNC NOT IN('0.00');");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE FORNFUNC
        public Boolean VerificaSDFornFunc(DateTime de)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where (FORN not in('0.00') || FUNC not in('0.00')) AND data='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN FORNFUNC
        public Boolean VerificaSBFornFunc(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where (FORN not in('0.00') || FUNC not in('0.00') AND data BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE TUDO
        public Boolean VerificaSoma()
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL;");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E DE
        public Boolean VerificaSD(DateTime de)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where data='" + de.ToString("yyyy/MM/dd")+"';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN
        public Boolean VerificaSB(DateTime de,DateTime at)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where data BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '"+at.ToString("yyyy/MM/dd")+"';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E DESC
        public Boolean VerificaSDC(string desc)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where desc_g='" + desc+ "';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE DESC 
        public Boolean VerificaSDD(DateTime de,string desc)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where desc_g='" + desc + "' and data='"+de.ToString("yyyy/MM/dd")+"';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN
        public Boolean VerificaSBD(DateTime de, DateTime at,string desc)
        {
            executarComando("SELECT SUM(cred_g) AS CRED,SUM(deb_g) AS DEB, SUM(forn) as FORN,SUM(func) as FUNC FROM GERAL where data BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '" + at.ToString("yyyy/MM/dd") + "' and desc_g='"+desc+"';");
            try
            {
                Ger.Cred_g = tabela_memoria.Rows[0]["CRED"].ToString();
                Ger.Deb_g = tabela_memoria.Rows[0]["DEB"].ToString();
                Ger.Func = tabela_memoria.Rows[0]["FUNC"].ToString();
                Ger.Forn = tabela_memoria.Rows[0]["FORN"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA SE EXISTE
        public Boolean VerificaExiste()
        {
            executarComando("SELECT id_g as ID FROM GERAL where desc_g='CARTÃO' and curdate()=adddate(data,interval 30 day);");
            try
            {
                Ger.Id_g = Convert.ToInt32(tabela_memoria.Rows[0]["ID"].ToString());
               
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(cred_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_g, 2), '.', '|'), ',', '.'), '|', ','))) AS CREDITO,IF(deb_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_g, 2), '.', '|'), ',', '.'), '|', ','))) AS DEBITO,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
              
                    linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();               
                    linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();              
                    linha["CREDITO"] = tabela_memoria.Rows[i]["CREDITO"].ToString();               
                    linha["DEBITO"] = tabela_memoria.Rows[i]["DEBITO"].ToString();             
                    linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                    linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                    linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarDE(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(cred_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_g, 2), '.', '|'), ',', '.'), '|', ','))) AS CREDITO,IF(deb_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_g, 2), '.', '|'), ',', '.'), '|', ','))) AS DEBITO,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE data='" + data.ToString("yyyy/MM/dd")+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["CREDITO"] = tabela_memoria.Rows[i]["CREDITO"].ToString();
                linha["DEBITO"] = tabela_memoria.Rows[i]["DEBITO"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DESC
        public DataTable ListarDS(string desc)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(cred_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_g, 2), '.', '|'), ',', '.'), '|', ','))) AS CREDITO,IF(deb_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_g, 2), '.', '|'), ',', '.'), '|', ','))) AS DEBITO,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE desc_g LIKE '" + desc+ "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["CREDITO"] = tabela_memoria.Rows[i]["CREDITO"].ToString();
                linha["DEBITO"] = tabela_memoria.Rows[i]["DEBITO"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DESC E DE
        public DataTable ListarDD(string desc,DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(cred_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_g, 2), '.', '|'), ',', '.'), '|', ','))) AS CREDITO,IF(deb_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_g, 2), '.', '|'), ',', '.'), '|', ','))) AS DEBITO,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE desc_g LIKE '" + desc + "%' and data='"+de.ToString("yyyy/MM/dd")+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["CREDITO"] = tabela_memoria.Rows[i]["CREDITO"].ToString();
                linha["DEBITO"] = tabela_memoria.Rows[i]["DEBITO"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime de,DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(cred_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_g, 2), '.', '|'), ',', '.'), '|', ','))) AS CREDITO,IF(deb_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_g, 2), '.', '|'), ',', '.'), '|', ','))) AS DEBITO,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '"+at.ToString("yyyy/MM/dd")+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["CREDITO"] = tabela_memoria.Rows[i]["CREDITO"].ToString();
                linha["DEBITO"] = tabela_memoria.Rows[i]["DEBITO"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E DESC
        public DataTable ListarBD(DateTime de, DateTime at,string desc)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(cred_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cred_g, 2), '.', '|'), ',', '.'), '|', ','))) AS CREDITO,IF(deb_g=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(deb_g, 2), '.', '|'), ',', '.'), '|', ','))) AS DEBITO,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE (data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "') and desc_g='"+desc+"' ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["CREDITO"] = tabela_memoria.Rows[i]["CREDITO"].ToString();
                linha["DEBITO"] = tabela_memoria.Rows[i]["DEBITO"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SÓ FORNECEDOR
        public DataTable ListarForn()
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FORN NOT IN('0.00');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SÓ FUNCIONÁRIO
        public DataTable ListarFunc()
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FUNC NOT IN('0.00');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE FUNC
        public DataTable ListarDEFunc(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FUNC NOT IN('0.00') AND data='" + data.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE FORN
        public DataTable ListarDEForn(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FORN NOT IN('0.00') AND data='" + data.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN FUNC
        public DataTable ListarBFunc(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FUNC NOT IN('0.00') AND data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN  FORN
        public DataTable ListarBForn(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FORN NOT IN('0.00') AND data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR FORNFUNC
        public DataTable ListarFornFunc()
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE FUNC NOT IN('0.00') || FORN NOT IN('0.00');");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE FORNFUNC
        public DataTable ListarDEFornFunc(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE (FUNC NOT IN('0.00') || FORN NOT IN('0.00')) AND data='" + data.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN FORNFUNC
        public DataTable ListarBTNFornFunc(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,desc_g as DESCR,IF(forn=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(forn, 2), '.', '|'), ',', '.'), '|', ','))) AS FORN,IF(func=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(func, 2), '.', '|'), ',', '.'), '|', ','))) AS FUNC,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL FROM GERAL WHERE (FORN NOT IN('0.00') || FUNC NOT IN('0.00')) AND data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["FUNC"] = tabela_memoria.Rows[i]["FUNC"].ToString();
                linha["FORN"] = tabela_memoria.Rows[i]["FORN"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
