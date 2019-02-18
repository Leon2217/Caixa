using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class ValorcxmDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Valorcxm vcm = new Valorcxm();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Valorcxm Vcm { get => vcm; set => vcm = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region VERIFICA SE O CAIXA DE MOEDAS ESTÁ VAZIO
        public Boolean Verificavalor()
        {
            executarComando("SELECT * FROM VALOR_CXM;");
            try
            {
                Vcm.Valor = tabela_memoria.Rows[0]["valor"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INSERIR VALOR NO CAIXA DE MOEDA
        public void Inserir(string zero)
        {
            executarComando("INSERT INTO VALOR_CXM VALUES(0,'" + zero + "');");
        }
        #endregion

        #region ATUALIZANDO VALOR DO CAIXA DE MOEDAS SOM
        public void Update(Valorcxm cxm)
        {
            executarComando("UPDATE VALOR_CXM SET valor=valor+'" + cxm.Valor.ToString().Replace(",", ".") + "';");
        }
        #endregion

        #region ATUALIZANDO VALOR CAIXA DE MOEDAS SUB
        public void Update2(Valorcxm cxm)
        {
            executarComando("UPDATE VALOR_CXM SET valor=valor-'" + cxm.Valor.ToString().Replace(",", ".") + "';");
        }
        #endregion
    }
}
