using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class DinheiroDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Dinheiro dinh = new Dinheiro();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Dinheiro Dinh { get => dinh; set => dinh = value; }
        public static string Codcaixa { get => codcaixa; set => codcaixa = value; }
        public static string Totalmanha { get => totalmanha; set => totalmanha = value; }
        public static string Totaltarde { get => totaltarde; set => totaltarde = value; }
        public static string Abre { get => abre; set => abre = value; }
        public static string Totalgaveta { get => totalgaveta; set => totalgaveta = value; }

        private static string totaltarde;

        public static string codcaixa;

        public static string totalmanha;

        public static string totalgaveta;


        public static string abre;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        public void inserir(Dinheiro dinh)
        {
            executarComando("INSERT INTO DINHEIRO VALUES(0,'"+dinh.Id_caixa+"','" + dinh.Nota_100 + "','" + dinh.Nota_50 + "','" + dinh.Nota_20 + "','" + dinh.Nota_10 + "','" + dinh.Nota_5 + "','" + dinh.Nota_2 +"','"+dinh.Moeda_1+"','"+dinh.Moeda_50+"','"+dinh.Moeda_25+"','"+dinh.Moeda_10+"','"+dinh.Moeda_5+"','"+dinh.Total+"');");
        }

        public Boolean Verificagaveta(string codcaixa)
        {
            executarComando("SELECT * FROM gaveta WHERE id_caixa='" + codcaixa + "';");
            try
            {
                dinh.Id_qtd = Convert.ToInt32(tabela_memoria.Rows[0]["id_qtd"].ToString());
                dinh.Id_caixa = Convert.ToInt32(tabela_memoria.Rows[0]["id_caixa"].ToString());
                dinh.Nota_100 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_100"].ToString());
                dinh.Nota_50 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_50"].ToString());
                dinh.Nota_20 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_20"].ToString());
                dinh.Nota_10 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_10"].ToString());
                dinh.Nota_5 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_5"].ToString());
                dinh.Nota_2 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_2"].ToString());
                dinh.Moeda_1 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_1"].ToString());
                dinh.Moeda_50 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_50"].ToString());
                dinh.Moeda_25 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_25"].ToString());
                dinh.Moeda_10 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_10"].ToString());
                dinh.Moeda_5 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_5"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Verificadinheiro(string codcaixa)
        {
            executarComando("SELECT * FROM DINHEIRO WHERE id_caixa='" + codcaixa + "';");
            try
            {
                dinh.Id_qtd = Convert.ToInt32(tabela_memoria.Rows[0]["id_qtd"].ToString());
                dinh.Id_caixa = Convert.ToInt32(tabela_memoria.Rows[0]["id_caixa"].ToString());
                dinh.Nota_100 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_100"].ToString());
                dinh.Nota_50 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_50"].ToString());
                dinh.Nota_20 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_20"].ToString());
                dinh.Nota_10 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_10"].ToString());
                dinh.Nota_5 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_5"].ToString());
                dinh.Nota_2 = Convert.ToInt32(tabela_memoria.Rows[0]["nota_2"].ToString());
                dinh.Moeda_1 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_1"].ToString());
                dinh.Moeda_50 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_50"].ToString());
                dinh.Moeda_25 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_25"].ToString());
                dinh.Moeda_10 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_10"].ToString());
                dinh.Moeda_5 = Convert.ToInt32(tabela_memoria.Rows[0]["moeda_5"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean Verificaqtd(string codcaixa)
        {
            executarComando("SELECT id_qtd FROM DINHEIRO WHERE id_caixa='" + codcaixa + "';");
            try
            {
                dinh.Id_qtd = Convert.ToInt32(tabela_memoria.Rows[0]["id_qtd"].ToString());
   
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Verificatotal(string codcaixa)
        {
            executarComando("select d.total from dinheiro d inner join caixa ca on ca.id_caixa=d.id_caixa inner join turno t on t.id_turno=ca.id_turno where ca.id_caixa='" +codcaixa + "';");
            try
            {
               totalmanha = tabela_memoria.Rows[0]["total"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void update(Dinheiro din)
        {
          executarComando("UPDATE DINHEIRO SET nota_100='" +din.Nota_100 + "',nota_50='" +din.Nota_50+ "',nota_20='" +din.Nota_20 + "',nota_10='" +din.Nota_10+ "',nota_5='" +din.Nota_5+ "',nota_2='" +din.Nota_2+ "',moeda_1='" +din.Moeda_1 + "',moeda_50='" +din.Moeda_50+ "',moeda_25='" + din.Moeda_25 + "',moeda_10='" +din.Moeda_10 + "',moeda_5='" +din.Moeda_5 + "' WHERE ID_CAIXA='" + din.Id_caixa + "';");
        }


        public void updatetotal(string codqtd)
        {
            executarComando("update dinheiro set total=(nota_100*100)+(nota_50*50)+(nota_20*20)+(nota_10*10)+(nota_5*5)+(nota_2*2)+(moeda_1*1)+(moeda_50*0.50)+(moeda_25*0.25)+(moeda_10*0.10)+(moeda_5*0.05) where id_qtd='"+codqtd+"';");
        }

        #region GAVETA
        public void Updategaveta(Dinheiro din)
        {
            executarComando("UPDATE gaveta SET nota_100='" + din.Nota_100 + "',nota_50='" + din.Nota_50 + "',nota_20='" + din.Nota_20 + "',nota_10='" + din.Nota_10 + "',nota_5='" + din.Nota_5 + "',nota_2='" + din.Nota_2 + "',moeda_1='" + din.Moeda_1 + "',moeda_50='" + din.Moeda_50 + "',moeda_25='" + din.Moeda_25 + "',moeda_10='" + din.Moeda_10 + "',moeda_5='" + din.Moeda_5 + "' WHERE ID_CAIXA='" + din.Id_caixa + "';");
        }


        public void Updatetotalgaveta(string codqtd)
        {
            executarComando("update gaveta set total=(nota_100*100)+(nota_50*50)+(nota_20*20)+(nota_10*10)+(nota_5*5)+(nota_2*2)+(moeda_1*1)+(moeda_50*0.50)+(moeda_25*0.25)+(moeda_10*0.10)+(moeda_5*0.05) where id_qtd='" + codqtd + "';");
        }

        public Boolean Verificaqtdgaveta(string codcaixa)
        {
            executarComando("SELECT id_qtd FROM gaveta WHERE id_caixa='" + codcaixa + "';");
            try
            {
                dinh.Id_qtd = Convert.ToInt32(tabela_memoria.Rows[0]["id_qtd"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public void Inserirgaveta(Dinheiro dinh)
        {
            executarComando("INSERT INTO gaveta VALUES(0,'" + dinh.Id_caixa + "','" + dinh.Nota_100 + "','" + dinh.Nota_50 + "','" + dinh.Nota_20 + "','" + dinh.Nota_10 + "','" + dinh.Nota_5 + "','" + dinh.Nota_2 + "','" + dinh.Moeda_1 + "','" + dinh.Moeda_50 + "','" + dinh.Moeda_25 + "','" + dinh.Moeda_10 + "','" + dinh.Moeda_5 + "','" + dinh.Total + "');");
        }

        public Boolean Verificatotalgaveta(string codcaixa)
        {
            executarComando("select total from gaveta g inner join caixa ca on ca.id_caixa=g.id_caixa inner join turno t on t.id_turno=ca.id_turno where ca.id_caixa='" + codcaixa + "';");
            try
            {
                totalgaveta = tabela_memoria.Rows[0]["total"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean PegaUltimoIdTurno1()
        {
            executarComando("SELECT max(id_qtd) as ID FROM gaveta g inner join caixa cx on cx.id_caixa=g.id_caixa inner join turno t on t.id_turno = cx.id_turno where t.id_turno = 1;");
            try
            {
                Dinh.Id_qtd= Convert.ToInt32(tabela_memoria.Rows[0]["ID"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean PegaUltimoIdTurno2()
        {
            executarComando("SELECT max(id_qtd) as ID FROM gaveta g inner join caixa cx on cx.id_caixa=g.id_caixa inner join turno t on t.id_turno = cx.id_turno where t.id_turno = 2;");
            try
            {
                Dinh.Id_qtd = Convert.ToInt32(tabela_memoria.Rows[0]["ID"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean PegaTotalUltimoIdTurno1(string cod)
        {
            executarComando("SELECT total as TOTAL FROM gaveta g inner join caixa cx on cx.id_caixa=g.id_caixa inner join turno t on t.id_turno = cx.id_turno WHERE g.id_qtd = '"+cod+"' and  cx.id_turno = 1; ");
            try
            {
                Dinh.Total = tabela_memoria.Rows[0]["TOTAL"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean PegaTotalUltimoIdTurno2(string cod)
        {
            executarComando("SELECT total as TOTAL FROM gaveta g inner join caixa cx on cx.id_caixa=g.id_caixa inner join turno t on t.id_turno = cx.id_turno WHERE g.id_qtd = '" + cod + "' and  cx.id_turno = 2; ");
            try
            {
                Dinh.Total = tabela_memoria.Rows[0]["TOTAL"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
