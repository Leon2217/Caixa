using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class TaxasDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Taxas taxas = new Taxas();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Taxas Taxas { get => taxas; set => taxas = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR TAXA EM UM CARTÃO
        public void Inserir(Taxas taxas)
        {
            executarComando("INSERT INTO TAXAS VALUES('" +taxas.Id_cartao+ "','" +taxas.Taxa.ToString().Replace(",",".") + "','" + taxas.Dias + "');");
        }
        #endregion

        #region UPDATE DAS TAXAS POR CARTAO
        public void Update(Taxas tx)
        {
            executarComando("UPDATE TAXAS SET taxa='" +tx.Taxa.ToString().Replace(",",".") + "',dias='" + tx.Dias + "' WHERE ID_CARTAO='" + tx.Id_cartao + "';");
        }
        #endregion

        #region VERIFICA EXISTE
        public Boolean VerificaExiste()
        {
            executarComando("SELECT * FROM TAXAS;");
            try
            {
                Taxas.Id_cartao = Convert.ToInt32(tabela_memoria.Rows[0]["id_cartao"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region PESQUISA SODEXO
        public Boolean PesquisaSodexo()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where m.marca='SODEXO';");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {               
                    return false;
            }

        }
        #endregion

        #region PESQUISA VR
        public Boolean PesquisaVr()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where m.marca='VR';");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region PESQUISA TICKET
        public Boolean PesquisaT()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where m.marca='Ticket';");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region PESQUISA ELO
        public Boolean PesquisaElo()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where m.marca='Elo' and c.tipo='Refeicao';");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region PESQUISA SOFTNEX
        public Boolean PesquisaSoft()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where m.marca='Elo' and c.tipo='Softnex';");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region PESQUISA CREDITO
        public Boolean PesquisaCred()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where c.id_cartao=1;");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region PESQUISA DEBITO
        public Boolean PesquisaDEB()
        {
            executarComando("Select * from taxas t inner join cartao c on c.id_cartao=t.id_cartao inner join marca m on m.id_marca=c.id_marca where c.id_cartao=2;");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
                Taxas.Dias = tabela_memoria.Rows[0]["dias"].ToString();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region VERIFICA TAXA POR ID
        public Boolean VerificaTaxa(string id)
        {
            executarComando("SELECT taxa FROM TAXAS where id_cartao='"+id+"';");
            try
            {
                Taxas.Taxa = tabela_memoria.Rows[0]["taxa"].ToString();
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
