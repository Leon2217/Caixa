using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class VerificaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Verificas ver = new Verificas();


        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Verificas Ver { get => ver; set => ver = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region VERIFICANDO SE EXISTE REGISTRO DE INVENTÁRIO
        public Boolean Verifica()
        {
            executarComando("SELECT * FROM VERIFICA;");
            try
            {
                Ver.Id_ver = Convert.ToInt32(tabela_memoria.Rows[0]["id_ver"].ToString());
                Ver.Verifica = tabela_memoria.Rows[0]["verifica"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region INSERIR DE VERIFICA
        public void Inserir(Verificas ver)
        {
            executarComando("INSERT INTO VERIFICA VALUES(0,'" + ver.Verifica.ToString()+ "');");
        }
        #endregion

        #region UPDATE NO VALOR DO VERIFICA
        public void Update(Verificas ver)
        {
            executarComando("UPDATE VERIFICA SET VERIFICA='" + ver.Verifica.ToString() + "';");
        }
        #endregion

    }
}
