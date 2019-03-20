using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class SangriaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Sangria san = new Sangria();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Sangria San { get => san; set => san = value; }

        public static string totalsangria;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public void Inserir(Sangria san)
        {
            executarComando("INSERT INTO SANGRIA VALUES(0,'" + san.Id_caixa + "','" + san.Valor.ToString().Replace(",", ".") + "');");
        }

        public Boolean Verificasangria(string codcaixa)
        {
            executarComando("SELECT sum(valor) FROM sangria WHERE id_caixa='" + codcaixa + "';");
            try
            {
                totalsangria = tabela_memoria.Rows[0]["sum(valor)"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region LISTAR SANGRIA
        public DataTable ListarTudoSangria()
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,turno as TURNO, valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA MANHA
        public DataTable ListarSangriaManha()
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,turno as TURNO, valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno =1;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA TARDE
        public DataTable ListarSangriaTarde()
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,turno as TURNO, valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA MANHA DE
        public DataTable ListarSangriaManhaDe(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,t.turno as TURNO, s.valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=1 and cx.datainicio='" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA TARDE DE
        public DataTable ListarSangriaTardeDe(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("select  cx.datainicio as DATA,t.turno as TURNO, s.valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio='" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA MANHA BTN
        public DataTable ListarSangriaManhaBtn(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,t.turno as TURNO, s.valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=1 and cx.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd")+"';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA TARDE BTN
        public DataTable ListarSangriaTardeBtn(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,t.turno as TURNO, s.valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA DE
        public DataTable ListarSangriaDe(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,t.turno as TURNO, s.valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where cx.datainicio='" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SANGRIA TARDE
        public DataTable ListarSangriaBtn(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("select cx.datainicio as DATA,t.turno as TURNO, s.valor as VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where cx.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion


        //VERIFICA SANGRIA

        #region VERIFICA A SOMA DE TUDO
        public Boolean VerificaSoma()
        {
            executarComando("SELECT SUM(valor) AS VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno =1;");
            try
            {
                San.Valor = tabela_memoria.Rows[0]["VALOR"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE TUDO TURNO 2
        public Boolean VerificaSoma2()
        {
            executarComando("SELECT SUM(valor) AS VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno =2;");
            try
            {
                San.Valor = tabela_memoria.Rows[0]["VALOR"].ToString();
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
            executarComando("SELECT SUM(valor) AS VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=1 and cx.datainicio='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                San.Valor = tabela_memoria.Rows[0]["VALOR"].ToString();
            
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E DE TURNO 2
        public Boolean VerificaSD2(DateTime de)
        {
            executarComando("SELECT SUM(valor) AS VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                San.Valor = tabela_memoria.Rows[0]["VALOR"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN
        public Boolean VerificaSB(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor) AS VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=1 and cx.datainicio BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                San.Valor = tabela_memoria.Rows[0]["VALOR"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA E BETWEEN TURNO 2
        public Boolean VerificaSB2(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor) AS VALOR from sangria s inner join caixa cx on cx.id_caixa=s.id_caixa inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio BETWEEN'" + de.ToString("yyyy/MM/dd") + "'and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                San.Valor = tabela_memoria.Rows[0]["VALOR"].ToString();
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
