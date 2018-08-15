using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace Caixa
{
    class diferencaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Diferenca dif = new Diferenca();


        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Diferenca Dif { get => dif; set => dif = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR DIFERENCA
        public void Inserir(Diferenca dif)
        {
            executarComando("INSERT INTO DIFERENCA VALUES(0,'" + dif.Id_caixa + "','" + dif.Manha.ToString().Replace(",", ".") + "','" + dif.Tarde.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region UPDATE NA DIFERENCA
        public void Update(string valor, DateTime data)
        {
            executarComando("UPDATE DIFERENCA DIF INNER JOIN CAIXA C ON C.ID_CAIXA=DIF.ID_CAIXA SET TARDE='" + valor.ToString().Replace(",", ".") + "' WHERE C.DATAINICIO='" + data.ToString("yyyy/MM/dd") + "';");
        }
        #endregion

        #region LISTAR TUDO
        public DataTable Listartudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT c.datainicio as DATA,IF(d.manha=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(d.manha, 2), '.', '|'), ',', '.'), '|', ','))) as MANHA,IF(d.tarde=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(d.tarde, 2), '.', '|'), ',', '.'), '|', ','))) as TARDE FROM DIFERENCA d inner join CAIXA c on c.id_caixa=d.id_caixa;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["MANHA"] = tabela_memoria.Rows[i]["MANHA"].ToString();
                linha["TARDE"] = tabela_memoria.Rows[i]["TARDE"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DATA
        public DataTable ListarD(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.datainicio as DATA,IF(d.manha=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(d.manha, 2), '.', '|'), ',', '.'), '|', ','))) as MANHA,IF(d.tarde=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(d.tarde, 2), '.', '|'), ',', '.'), '|', ','))) as TARDE FROM DIFERENCA d inner join CAIXA c on c.id_caixa=d.id_caixa WHERE c.datainicio='" + data.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["MANHA"] = tabela_memoria.Rows[i]["MANHA"].ToString();
                linha["TARDE"] = tabela_memoria.Rows[i]["TARDE"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime data, DateTime data2)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.datainicio as DATA,IF(d.manha=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(d.manha, 2), '.', '|'), ',', '.'), '|', ','))) as MANHA,IF(d.tarde=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(d.tarde, 2), '.', '|'), ',', '.'), '|', ','))) as TARDE FROM DIFERENCA d inner join CAIXA c on c.id_caixa=d.id_caixa WHERE c.datainicio BETWEEN '" + data.ToString("yyyy/MM/dd") + "' AND '" + data2.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["MANHA"] = tabela_memoria.Rows[i]["MANHA"].ToString();
                linha["TARDE"] = tabela_memoria.Rows[i]["TARDE"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        public Boolean Verifica()
        {
            executarComando("SELECT * FROM DIFERENCA ;");
            try
            {
                dif.Id_diferenca = Convert.ToInt32(tabela_memoria.Rows[0]["id_diferenca"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
