using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class RelattxDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Relattx rlx = new Relattx();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Relattx Rlx { get => rlx; set => rlx = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR TAXA EM UM CARTÃO
        public void Inserir(Relattx rlx)
        {
            executarComando("INSERT INTO relattx VALUES('" +rlx.Id_caixa+ "','" +rlx.Id_cartao+ "','"+rlx.Id_maquina+"','"+ rlx.Data.ToString("yyyy/MM/dd") + "','"+rlx.Valor.ToString().Replace(",",".")+"','"+rlx.Taxa.ToString().Replace(",",".")+"','"+rlx.Valor_ct.ToString().Replace(",",".")+"');");
        }
        #endregion

        #region UPDATE DAS TAXAS POR CARTAO
        public void Update(Relattx rlx)
        {
            executarComando("UPDATE RELATTX SET valor='" + rlx.Valor.ToString().Replace(",", ".") + "',valor_ct='" + rlx.Valor_ct.ToString().Replace(",",".") + "',taxa='"+rlx.Taxa.ToString().Replace(",",".")+"' WHERE ID_CARTAO='" + rlx.Id_cartao + "' AND ID_CAIXA='"+rlx.Id_caixa+"' AND ID_MAQUINA='"+rlx.Id_maquina+"';");
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 or t.id_turno=3 group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString()+" %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarDE(DateTime data)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,r.valor as VALOR,r.valor_ct as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and data='" + data.ToString("yyyy/MM/dd") + "'group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE E BANDEIRA
        public DataTable ListarDB(DateTime de,string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,r.valor as VALOR,r.valor_ct as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and r.data='"+de.ToString("yyyy/MM/dd")+"' and ma.id_marca='" +id+ "'group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BANDEIRA
        public DataTable ListarB(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca='" + id + "'group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BANDEIRA E CARTAO
        public DataTable ListarBC(string id,string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca='" + id + "' and c.id_cartao='"+codcart+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                
                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarBT(DateTime de,DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and data between'" + de.ToString("yyyy/MM/dd") + "' and '"+at.ToString("yyyy/MM/dd") + "'group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BANDEIRA BETWEEN
        public DataTable ListarBB(DateTime de, DateTime at, string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and (data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "') and ma.id_marca='"+id+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

               
                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE BANDEIRA E CARTAO
        public DataTable ListarDBC(DateTime de,string id, string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca='" + id + "' and c.id_cartao='" + codcart + "' and r.data='"+de.ToString("yyyy/MM/dd")+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN BANDEIRA E CARTAO
        public DataTable ListarBBC(DateTime de,DateTime at, string id, string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT ma.marca as BANDEIRA,c.cartao as CARTAO,r.taxa as TAXA,sum(r.valor) as VALOR,sum(r.valor_ct) as TAXADO FROM RELATTX r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca='" + id + "' and c.id_cartao='" + codcart + "' and (r.data BETWEEN'" + de.ToString("yyyy/MM/dd") + "' and '"+at.ToString("yyyy/MM/dd")+"') group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["BANDEIRA"] = tabela_memoria.Rows[i]["BANDEIRA"].ToString();
                linha["CARTAO"] = tabela_memoria.Rows[i]["CARTAO"].ToString();
                linha["TAXA"] = tabela_memoria.Rows[i]["TAXA"].ToString() + " %";
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["TAXADO"] = tabela_memoria.Rows[i]["TAXADO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region VERIFICA A SOMA DE TODOS OS CREDITOS
        public Boolean VerificaSC()
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno where (c.id_cartao=1 or c.id_cartao=3 or c.id_cartao=6 or c.id_cartao=7 or c.id_cartao=14) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();                
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE TODOS OS DEBITOS
        public Boolean VerificaSD()
        {
            executarComando("SELECT SUM(valor_ct) AS DEB FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno where (c.id_cartao=2 or c.id_cartao=4 or c.id_cartao=5 or c.id_cartao=13) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["DEB"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE VR
        public Boolean VerificaSVR()
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=8) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE SODEXO
        public Boolean VerificaSDX()
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=5) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA TICKET
        public Boolean VerificaT()
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=6) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA ELO
        public Boolean VerificaSe()
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_cartao=8 or c.id_cartao=9) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA SOFTNEX
        public Boolean VerificaSFN()
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=9) and (t.id_turno=2 or t.id_turno=3);");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE(DE) TODOS OS CREDITOS
        public Boolean VerificaDC(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno where (c.id_cartao=1 or c.id_cartao=3 or c.id_cartao=6 or c.id_cartao=7 or c.id_cartao=14) and (t.id_turno=2 or t.id_turno=3) and r.data='"+de.ToString("yyyy/MM/dd")+"';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE(DE) TODOS OS DEBITOS
        public Boolean VerificaDD(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS DEB FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno where (c.id_cartao=2 or c.id_cartao=4 or c.id_cartao=5 or c.id_cartao=13) and (t.id_turno=2 or t.id_turno=3) and r.data='" + de.ToString("yyyy/MM/dd") +"' ; ");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["DEB"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(DE) DE VR
        public Boolean VerificaDVR(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=8) and (t.id_turno=2 or t.id_turno=3) and  r.data='" + de.ToString("yyyy/MM/dd") + "' ;");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(DE) DE SODEXO
        public Boolean VerificaDSDX(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=5) and (t.id_turno=2 or t.id_turno=3) and r.data='" + de.ToString("yyyy/MM/dd") + "' ;");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(DE) TICKET
        public Boolean VerificaDT(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=6) and (t.id_turno=2 or t.id_turno=3) and r.data='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(DE) ELO
        public Boolean VerificaDELO(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_cartao=8 or c.id_cartao=9) and (t.id_turno=2 or t.id_turno=3) and r.data='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(DE) SOFTNEX
        public Boolean VerificaDSOFT(DateTime de)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=9) and (t.id_turno=2 or t.id_turno=3) and r.data='" + de.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE(BTN) TODOS OS CREDITOS
        public Boolean VerificaBC(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno where (c.id_cartao=1 or c.id_cartao=3 or c.id_cartao=6 or c.id_cartao=7 or c.id_cartao=14) and (t.id_turno=2 or t.id_turno=3) and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA DE(BTN) TODOS OS DEBITOS
        public Boolean VerificaBDD(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS DEB FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno where (c.id_cartao=2 or c.id_cartao=4 or c.id_cartao=5 or c.id_cartao=13) and (t.id_turno=2 or t.id_turno=3) and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["DEB"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(BTN) DE VR
        public Boolean VerificaBVR(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=8) and (t.id_turno=2 or t.id_turno=3) and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(BTN) DE SODEXO
        public Boolean VerificaBSDX(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=5) and (t.id_turno=2 or t.id_turno=3) and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(BTN) TICKET
        public Boolean VerificaBTK(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=6) and (t.id_turno=2 or t.id_turno=3) and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(BTN) ELO
        public Boolean VerificaBELO(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_cartao=8 or c.id_cartao=9) and (t.id_turno=2 or t.id_turno=3)and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A SOMA(BTN) SOFTNEX
        public Boolean VerificaSOFT(DateTime de, DateTime at)
        {
            executarComando("SELECT SUM(valor_ct) AS CRED FROM RELATTX R INNER JOIN CARTAO C ON C.ID_CARTAO=R.ID_CARTAO inner join caixa cx on cx.id_caixa=r.id_caixa inner join turno t on t.id_turno=cx.id_turno inner join marca m on m.id_marca=c.id_marca where (c.id_marca=9) and (t.id_turno=2 or t.id_turno=3)and data between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            try
            {
                Rlx.Valor_ct = tabela_memoria.Rows[0]["CRED"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO SODEXO
        public Boolean IntervaloSD()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca=5 and curdate()=adddate(cx.datainicio,interval 28 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO TICKET
        public Boolean IntervaloTic()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca=6 and curdate()=adddate(cx.datainicio,interval 30 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO ALELO
        public Boolean IntervaloAlelo()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and (c.id_cartao=8 or c.id_cartao=9) and curdate()=adddate(cx.datainicio,interval 31 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO VR
        public Boolean IntervaloVR()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca=8 and curdate()=adddate(cx.datainicio,interval 28 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO PLCARD
        public Boolean IntervaloPlcard()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and ma.id_marca=9 and curdate()=adddate(cx.datainicio,interval 48 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO CRÉDITO
        public Boolean IntervaloC()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and (c.id_cartao=1 or c.id_cartao=3 or c.id_cartao=6 or c.id_cartao=7 or c.id_cartao=14) and curdate()=adddate(cx.datainicio,interval 30 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INTERVALO DÉBITO
        public Boolean IntervaloD()
        {
            executarComando("Select sum(valor_ct) as TOTAL from relattx r inner join caixa cx on cx.id_caixa=r.id_caixa inner join cartao c on c.id_cartao=r.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join turno t on t.id_turno=cx.id_turno where (t.id_turno=2 or t.id_turno=3) and (c.id_cartao=2 or c.id_cartao=4 or c.id_cartao=5 or c.id_cartao=13) and curdate()=adddate(cx.datainicio,interval 1 day);");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA SODEXO
        public Boolean SDX(DateTime de)
        {
            executarComando("select * from geral where data='"+de.ToString("yyyy/MM/dd")+"' and desc_g='SODEXO';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA TICKET
        public Boolean TIC(DateTime de)
        {
            executarComando("select * from geral where data='" + de.ToString("yyyy/MM/dd") + "' and desc_g='TICKET';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA ALELO
        public Boolean ALELO(DateTime de)
        {
            executarComando("select * from geral where data='" + de.ToString("yyyy/MM/dd") + "' and desc_g='ALELO';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA VR
        public Boolean VR(DateTime de)
        {
            executarComando("select * from geral where data='" + de.ToString("yyyy/MM/dd") + "' and desc_g='VR';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA PLCARD
        public Boolean PLCARD(DateTime de)
        {
            executarComando("select * from geral where data='" + de.ToString("yyyy/MM/dd") + "' and desc_g='PLCARD';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA CRÉDITO
        public Boolean CRED(DateTime de)
        {
            executarComando("select * from geral where data='" + de.ToString("yyyy/MM/dd") + "' and desc_g='CARTÃO CRÉDITO';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA DÉBITO
        public Boolean DEB(DateTime de)
        {
            executarComando("select * from geral where data='" + de.ToString("yyyy/MM/dd") + "' and desc_g='CARTÃO DÉBITO';");
            try
            {

                Rlx.Valor_ct = tabela_memoria.Rows[0]["TOTAL"].ToString();


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
