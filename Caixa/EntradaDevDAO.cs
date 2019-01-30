using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class EntradaDevDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        EntradaDev ed = new EntradaDev();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal EntradaDev Ed { get => ed; set => ed = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERINDO NA TABELA DE CONSULTA
        public void Inserir(EntradaDev ed)
        {
            executarComando("INSERT INTO ENTRADA_DEV VALUES(0,'" +ed.Data.ToString("yyyy/MM/dd") + "','" + ed.Hora.ToString("HH:mm") + "','" + ed.Desc_ed + "','" + ed.Responsa_ed + "','"+ed.Moeda_1+"','"+ed.Moeda_50+"','"+ed.Moeda_25+"','"+ed.Moeda_10+"','"+ed.Moeda_5+"','" + ed.Entrada_ed.ToString().Replace(",",".") + "','" + ed.Saida_ed.ToString().Replace(",",".") + "','" + ed.Total.ToString().Replace(",",".") + "');");
        }
        #endregion

        #region ListarTudo
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            try
            {
                executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA,desc_ed as DESCR,responsa_ed as RESP,IF(entrada_ed=('0.00'),'',Concat(Replace(Replace(Replace(Format(entrada_ed, 2), '.', '|'), ',', '.'), '|', ','))) as ENTRADA,IF(saida_ed=('0.00'),'',Concat(Replace(Replace(Replace(Format(saida_ed, 2), '.', '|'), ',', '.'), '|', ','))) as SAIDA,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL,moeda_1 as 1REAL,moeda_50 as 50CENT,moeda_25 as 25CENT,moeda_10 as 10CENT,moeda_5 as 5CENT FROM ENTRADA_DEV;");
            }
            catch
            {
           
            }
          
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["ENTRADA"] = tabela_memoria.Rows[i]["ENTRADA"].ToString();
                linha["SAIDA"] = tabela_memoria.Rows[i]["SAIDA"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["1REAL"] = tabela_memoria.Rows[i]["1REAL"].ToString();
                linha["50CENT"] = tabela_memoria.Rows[i]["50CENT"].ToString();
                linha["25CENT"] = tabela_memoria.Rows[i]["25CENT"].ToString();
                linha["10CENT"] = tabela_memoria.Rows[i]["10CENT"].ToString();
                linha["5CENT"] = tabela_memoria.Rows[i]["5CENT"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion


        public DataTable ListarB(DateTime de,DateTime at)
        {
            DataTable listaDescripto;
            try
            {
                executarComando("SELECT DATE_FORMAT(data, '%d/%m/%y')  as DATA,TIME_FORMAT(hora,'%H:%i') as HORA,desc_ed as DESCR,responsa_ed as RESP,IF(entrada_ed=('0.00'),'',Concat(Replace(Replace(Replace(Format(entrada_ed, 2), '.', '|'), ',', '.'), '|', ','))) as ENTRADA,IF(saida_ed=('0.00'),'',Concat(Replace(Replace(Replace(Format(saida_ed, 2), '.', '|'), ',', '.'), '|', ','))) as SAIDA,Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ',')) as TOTAL,moeda_1 as 1REAL,moeda_50 as 50CENT,moeda_25 as 25CENT,moeda_10 as 10CENT,moeda_5 as 5CENT FROM ENTRADA_DEV WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            }
            catch
            {

            }
            
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

               
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["RESP"] = tabela_memoria.Rows[i]["RESP"].ToString();
                linha["ENTRADA"] = tabela_memoria.Rows[i]["ENTRADA"].ToString();
                linha["SAIDA"] = tabela_memoria.Rows[i]["SAIDA"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                linha["1REAL"] = tabela_memoria.Rows[i]["1REAL"].ToString();
                linha["50CENT"] = tabela_memoria.Rows[i]["50CENT"].ToString();
                linha["25CENT"] = tabela_memoria.Rows[i]["25CENT"].ToString();
                linha["10CENT"] = tabela_memoria.Rows[i]["10CENT"].ToString();
                linha["5CENT"] = tabela_memoria.Rows[i]["5CENT"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }

    }
}
