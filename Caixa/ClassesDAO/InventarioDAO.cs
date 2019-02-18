using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class InventarioDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Inventario inv = new Inventario();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Inventario Inv { get => inv; set => inv = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR VALORES NO INVENTÁRIO
        public void Inserir(Inventario inv)
        {
            executarComando("INSERT INTO INVENTARIO VALUES(0,'"+inv.Qtd_est+"','"+inv.Valor_vc.ToString().Replace(",", ".")+ "');");
        }
        #endregion

        #region ATUALIZANDO VALORES DO INVENTÁRIO
            public void Update(Inventario inv)
            {
                executarComando("UPDATE INVENTARIO SET QTD_EST='"+inv.Qtd_est+"',VALOR_VC='"+inv.Valor_vc.ToString().Replace(",",".")+"';");
            }
            #endregion

        #region VERIFICANDO SE EXISTE REGISTRO DE INVENTÁRIO
        public Boolean VerificaInventário()
        {
            executarComando("SELECT * FROM INVENTARIO;");
            try
            {
                Inv.Id_iv = Convert.ToInt32(tabela_memoria.Rows[0]["id_iv"].ToString());
                Inv.Valor_vc = tabela_memoria.Rows[0]["valor_vc"].ToString();
                Inv.Qtd_est= Convert.ToInt32(tabela_memoria.Rows[0]["qtd_est"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ATUALIZANDO QTD_ESTOQUE DO INVENTÁRIO
        public void UpdateEstoque(int qtd)
        {
            executarComando("UPDATE INVENTARIO SET QTD_EST=QTD_EST -'" +qtd+ "';");
        }
        #endregion
    }
}
