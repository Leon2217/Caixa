using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class RecargaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
       Recarga rec = new Recarga();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Recarga Rec { get => rec; set => rec = value; }
        public static string Totalrecarga { get => totalrecarga; set => totalrecarga = value; }
        public static string Totalrecarga2 { get => totalrecarga2; set => totalrecarga2 = value; }

        public static string totalrecarga;

        public static string totalrecarga2;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region INSERIR RECARGA
        public void Inserir(Recarga rec)
        {
            executarComando("INSERT INTO RECARGA VALUES(0,'" + rec.Id_caixa + "','" + rec.Operadora + "','" + rec.Valor_rec.ToString().Replace(",",".") + "','" + rec.N_telefone + "','" + rec.Descricao +"','"+rec.Data.ToString("yyyy/MM/dd")+"','"+rec.Hora.ToString("HH:mm")+"','"+rec.Total.ToString().Replace(",",".")+"');");
        }
        #endregion

        #region BUSCAR SOMA DE RECARGA POR TURNO
        public Boolean Verificarecarga(DateTime data)
        {
            executarComando("SELECT sum(valor_rec) FROM RECARGA R INNER JOIN CAIXA C ON C.ID_CAIXA=R.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=1 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                totalrecarga = tabela_memoria.Rows[0]["sum(valor_rec)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region BUSCAR RECARGA POR OPERADORA E DATA
        public DataTable Listarfiltro(DateTime data ,string operadora)
        {
            DataTable listaDescripto;
            executarComando("SELECT descricao as DESCR,IF(valor_rec=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_rec, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,operadora as OP,telefone as TEL,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM RECARGA WHERE data='" + data.ToString("yyyy/MM/dd")+"' AND OPERADORA LIKE '" + operadora + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["OP"] = tabela_memoria.Rows[i]["OP"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR PELA DATA
        public DataTable ListarData(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT descricao as DESCR,IF(valor_rec=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_rec, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,operadora as OP,telefone as TEL,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM RECARGA WHERE data='" + data.ToString("yyyy/MM/dd")+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["OP"] = tabela_memoria.Rows[i]["OP"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR PELAS DUAS DATAS
        public DataTable ListarB(DateTime data, DateTime data2)
        {
            DataTable listaDescripto;
            executarComando("SELECT descricao as DESCR,IF(valor_rec=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_rec, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,operadora as OP,telefone as TEL,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM RECARGA WHERE data BETWEEN '" + data.ToString("yyyy/MM/dd") + "' AND '" + data2.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["OP"] = tabela_memoria.Rows[i]["OP"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR PELAS DUAS DATAS E OPERADORA
        public DataTable ListarBO(DateTime data, DateTime data2,string operadora)
        {
            DataTable listaDescripto;
            executarComando("SELECT descricao as DESCR,IF(valor_rec=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_rec, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,operadora as OP,telefone as TEL,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM RECARGA WHERE data BETWEEN '" + data.ToString("yyyy/MM/dd") + "' AND '" + data2.ToString("yyyy/MM/dd") + "' AND OPERADORA LIKE '" + operadora + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["OP"] = tabela_memoria.Rows[i]["OP"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TUDO
        public DataTable Listartudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT descricao as DESCR,IF(valor_rec=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_rec, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,operadora as OP,telefone as TEL,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM RECARGA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["OP"] = tabela_memoria.Rows[i]["OP"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAOPERADORA
        public DataTable ListarOperadora(string operadora)
        {
            DataTable listaDescripto;
            executarComando("SELECT descricao as DESCR,IF(valor_rec=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor_rec, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR,IF(total=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(total, 2), '.', '|'), ',', '.'), '|', ','))) as TOTAL,operadora as OP,telefone as TEL,DATE_FORMAT(data, '%d/%m/%y') as DATA,TIME_FORMAT(hora,'%H:%i') as HORA FROM RECARGA WHERE OPERADORA LIKE '" + operadora + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DESCR"] = tabela_memoria.Rows[i]["DESCR"].ToString();
                linha["OP"] = tabela_memoria.Rows[i]["OP"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["HORA"] = tabela_memoria.Rows[i]["HORA"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region BUSCAR SOMA DE RECARGA POR TURNO
        public Boolean Verificarecarga2(DateTime data)
        {
            executarComando("SELECT sum(valor_rec) FROM RECARGA R INNER JOIN CAIXA C ON C.ID_CAIXA=R.ID_CAIXA INNER JOIN TURNO T ON C.ID_TURNO=T.ID_TURNO WHERE t.ID_TURNO=2 AND C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {
                totalrecarga2 = tabela_memoria.Rows[0]["sum(valor_rec)"].ToString();
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
