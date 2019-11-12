using System;
using Caixa.Classes;
using System.Data;
using MySql.Data.MySqlClient;


namespace Caixa.ClassesDAO
{
    class VendaSSDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        VendaSS vgds = new VendaSS();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        public static string Manha { get => manha; set => manha = value; }
        public static string Tarde { get => tarde; set => tarde = value; }
        public static string Noite { get => noite; set => noite = value; }
        internal VendaSS Vgds { get => vgds; set => vgds = value; }

        public static string manha;
        public static string tarde;
        public static string noite;

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        public void Inserir(VendaSS vgds)
        {
            executarComando("INSERT INTO VENDA_GDS VALUES(0,'" + vgds.Id_caixa + "','" + vgds.Qtd_gds + "','" + vgds.Valor_gds.ToString().Replace(",", ".") + "','" + vgds.Total_gds.ToString().Replace(",", ".") + "','" + vgds.Qtd_estoque + "','" + vgds.Total_vendas + "','" + vgds.Data.ToString("yyyy/MM/dd") + "','" + vgds.Hora.ToString("HH:mm") + "','" + vgds.Descr + "');");
        }

        #region VERIFICANDO SE EXISTE VENDA DE SANTA SORTE
        public Boolean VerificaVenda()
        {
            executarComando("SELECT * FROM VENDA_GDS ORDER BY ID_GDS DESC LIMIT 1;");
            try
            {
                Vgds.Total_vendas = Convert.ToInt32(tabela_memoria.Rows[0]["total_vendas"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region BUSCAR SOMA DE VENDA_GDS POR TURNO1
        public Boolean VerificaVenda(DateTime data)
        {
            executarComando("SELECT sum(total_gds) FROM VENDA_GDS V INNER JOIN CAIXA C ON C.ID_CAIXA=V.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=1 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                manha = tabela_memoria.Rows[0]["sum(total_gds)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region BUSCAR SOMA DE VENDA_GDS POR TURNO2
        public Boolean VerificaVenda2(DateTime data)
        {
            executarComando("SELECT sum(total_gds) FROM VENDA_GDS V INNER JOIN CAIXA C ON C.ID_CAIXA=V.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=2 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                tarde = tabela_memoria.Rows[0]["sum(total_gds)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region BUSCAR SOMA DE VENDA_GDS POR TURNO3
        public Boolean VerificaVenda3(DateTime data)
        {
            executarComando("SELECT sum(total_gds) FROM VENDA_GDS V INNER JOIN CAIXA C ON C.ID_CAIXA=V.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=3 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                noite = tabela_memoria.Rows[0]["sum(total_gds)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region TotalLabelTudo
        public DataTable VerificaTotalLabelTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT sum(total_gds) FROM VENDA_GDS;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                vgds.Total_gds = tabela_memoria.Rows[i]["sum(total_gds)"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region TotalGeralLabel
        public DataTable VerificaTotalLabel(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT sum(total_gds) FROM VENDA_GDS WHERE YEARWEEK(DATA,0)=YEARWEEK('" + data.ToString("yyyy/MM/dd") + "',0);");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                vgds.Total_gds = tabela_memoria.Rows[i]["sum(total_gds)"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarTudo
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT descr as DESCR,qtd_gds as QTD_VENDA,IF(valor_gds=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_gds, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total_gds=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total_gds, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,qtd_estoque as QTD_EST,total_vendas as TOTAL_VENDAS,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM VENDA_GDS;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["QTD_VENDA"] = tabela_memoria.Rows[i]["QTD_VENDA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["QTD_EST"] = tabela_memoria.Rows[i]["QTD_EST"].ToString();
                linha["TOTAL_VENDAS"] = tabela_memoria.Rows[i]["TOTAL_VENDAS"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region ListarSemana
        public DataTable ListarSemana(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT descr as DESCR,qtd_gds as QTD_VENDA,IF(valor_gds=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_gds, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total_gds=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total_gds, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,qtd_estoque as QTD_EST,total_vendas as TOTAL_VENDAS,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM VENDA_GDS WHERE YEARWEEK(DATA,0)=YEARWEEK('" + data.ToString("yyyy/MM/dd") + "',0);");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["QTD_VENDA"] = tabela_memoria.Rows[i]["QTD_VENDA"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["QTD_EST"] = tabela_memoria.Rows[i]["QTD_EST"].ToString();
                linha["TOTAL_VENDAS"] = tabela_memoria.Rows[i]["TOTAL_VENDAS"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion
    }
}
