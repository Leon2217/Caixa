using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class ValorgeralDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Valorgeral vg = new Valorgeral();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Valorgeral Vg { get => vg; set => vg = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region VERIFICA SE ESTÁ VAZIO
        public Boolean Verificavalor()
        {
            executarComando("SELECT * FROM VALOR_GERAL;");
            try
            {
                Vg.Valor = tabela_memoria.Rows[0]["valor"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INSERIR ZERO CASO NÃO TENHA VALOR
        public void Inserir(string zero)
        {
            executarComando("INSERT INTO VALOR_GERAL VALUES(0,'" + zero + "');");
        }
        #endregion

        #region ATUALIZANDO VALOR DO CAIXA SUB
        public void Update2(string valor)
        {
            executarComando("UPDATE VALOR_GERAL SET valor=valor-'" + valor.ToString().Replace(",", ".") + "';");
        }
        #endregion

        #region ATUALIZANDO VALOR DO CAIXA SOM
        public void Update(string valor)
        {
            executarComando("UPDATE VALOR_GERAL SET valor=valor+'" + valor.ToString().Replace(",", ".") + "';");
        }
        #endregion
    }
}
