using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class InventariorecDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Inventariorec invr = new Inventariorec();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Inventariorec Invr { get => invr; set => invr = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR INV RECARGA
        public void Inserir(Inventariorec invr)
        {
            executarComando("INSERT INTO INVENTARIO_REC VALUES(0,'" + invr.Total.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region ATUALIZANDO VALORES DO INVENTÁRIO DA RECARGA
        public void Update(Inventariorec invr)
        {
            executarComando("UPDATE INVENTARIO_REC SET TOTAL='" + invr.Total.ToString().Replace(",", ".") + "';");
        }
        #endregion

        #region VERIFICANDO SE EXISTE REGISTRO DE INVENTÁRIO DA RECARGA
        public Boolean VerificaInventário()
        {
            executarComando("SELECT * FROM INVENTARIO_REC;");
            try
            {
                Invr.Id_ir = Convert.ToInt32(tabela_memoria.Rows[0]["id_ir"].ToString());
                Invr.Total = tabela_memoria.Rows[0]["total"].ToString();
          
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region UPDATE NO VALOR DO INVENTÁRIO
        public void UpdateTotal(string valor)
        {
            executarComando("UPDATE INVENTARIO_REC SET TOTAL=TOTAL -'" + valor + "';");
        }
        #endregion
    }
}