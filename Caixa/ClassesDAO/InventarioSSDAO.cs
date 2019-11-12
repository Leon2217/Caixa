using System;
using System.Data;
using MySql.Data.MySqlClient;
using Caixa.Classes;

namespace Caixa.ClassesDAO
{
    class InventarioSSDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        InventarioSS invGDS = new InventarioSS();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal InventarioSS InvGDS { get => invGDS; set => invGDS = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR VALORES NO INVENTÁRIO
        public void Inserir(InventarioSS invGDS)
        {
            executarComando("INSERT INTO INVENTARIO_GDS VALUES(0,'" + invGDS.Qtd_est + "','" + invGDS.Valor_gds.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region ATUALIZANDO VALORES DO INVENTÁRIO
        public void Update(InventarioSS invGDS)
        {
            executarComando("UPDATE INVENTARIO_GDS SET QTD_EST='" + invGDS.Qtd_est + "',VALOR_GDS='" + invGDS.Valor_gds.ToString().Replace(",", ".") + "';");
        }
        #endregion

        #region VERIFICANDO SE EXISTE REGISTRO DE INVENTÁRIO
        public Boolean VerificaInventário()
        {
            executarComando("SELECT * FROM INVENTARIO_GDS;");
            try
            {
                InvGDS.Id_iv = Convert.ToInt32(tabela_memoria.Rows[0]["id_iv"].ToString());
                InvGDS.Valor_gds = tabela_memoria.Rows[0]["valor_gds"].ToString();
                InvGDS.Qtd_est = Convert.ToInt32(tabela_memoria.Rows[0]["qtd_est"].ToString());
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
            executarComando("UPDATE INVENTARIO_GDS SET QTD_EST=QTD_EST -'" + qtd + "';");
        }
        #endregion
    }
}
