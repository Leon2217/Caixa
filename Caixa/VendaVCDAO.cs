using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class VendaVCDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        VendaVC vvc = new VendaVC();


        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal VendaVC Vvc { get => vvc; set => vvc = value; }
        public static string Manha { get => manha; set => manha = value; }
        public static string Tarde { get => tarde; set => tarde = value; }

        public static string manha;
        public static string tarde;

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public void Inserir(VendaVC vc)
        {
            executarComando("INSERT INTO VENDA_VC VALUES(0,'"+vc.Id_caixa+"','" +vc.Qtd_vc+ "','" +vc.Valor_vc.ToString().Replace(",",".")+ "','" +vc.Total_vc.ToString().Replace(",", ".")+ "','" +vc.Qtd_estoque+ "','"+vc.Total_vendas+"','"+vc.Data.ToString("yyyy/MM/dd")+"','"+vc.Hora.ToString("HH:mm")+"','"+vc.Descr+"');");
        }


        #region VERIFICANDO SE EXISTE VENDA DE VALECAP
        public Boolean VerificaVenda()
        {
            executarComando("SELECT * FROM VENDA_VC ORDER BY ID_VC DESC LIMIT 1;");
            try
            {
                Vvc.Total_vendas= Convert.ToInt32(tabela_memoria.Rows[0]["total_vendas"].ToString());
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
            executarComando("SELECT descr as DESCR,qtd_vc as QTD_VENDA,IF(valor_vc=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_vc, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total_vc=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total_vc, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,qtd_estoque as QTD_EST,total_vendas as TOTAL_VENDAS,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM VENDA_VC;");
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

        public DataTable ListarData(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT descr as DESCR,qtd_vc as QTD_VENDA,IF(valor_vc=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_vc, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total_vc=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total_vc, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,qtd_estoque as QTD_EST,total_vendas as TOTAL_VENDAS,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM VENDA_VC WHERE YEARWEEK(DATA,0)=YEARWEEK('" + data.ToString("yyyy/MM/dd")+"',0);");
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

        #region BUSCAR SOMA DE RECARGA POR TURNO1
        public Boolean VerificaVenda(DateTime data)
        {
            executarComando("SELECT sum(total_vc) FROM VENDA_VC V INNER JOIN CAIXA C ON C.ID_CAIXA=V.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=1 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                manha = tabela_memoria.Rows[0]["sum(total_vc)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region BUSCAR SOMA DE RECARGA POR TURNO2
        public Boolean VerificaVenda2(DateTime data)
        {
            executarComando("SELECT sum(total_vc) FROM VENDA_VC V INNER JOIN CAIXA C ON C.ID_CAIXA=V.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=2 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                tarde = tabela_memoria.Rows[0]["sum(total_vc)"].ToString();
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
