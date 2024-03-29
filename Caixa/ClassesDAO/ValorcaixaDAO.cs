﻿using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class ValorcaixaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Valorcaixa vc = new Valorcaixa();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Valorcaixa Vc { get => vc; set => vc = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region ATUALIZANDO VALOR DO CAIXA SOM
        public void Update(string valor)
        {
            executarComando("UPDATE VALOR_CAIXA SET valor=valor+'"+valor.ToString().Replace(",",".")+ "';");
        }
        #endregion

        #region INSERINDO ZERO NO VALOR CASO NÃO TENHA
        public void Inserir(string zero)
        {
            executarComando("INSERT INTO VALOR_CAIXA VALUES(0,'"+zero+"');");
        }
        #endregion

        #region VERIFICA SE ESTÁ VAZIO
        public Boolean Verificavalor()
        {
            executarComando("SELECT * FROM VALOR_CAIXA;");
            try
            {
                Vc.Valor = tabela_memoria.Rows[0]["valor"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ATUALIZANDO VALOR DO CAIXA SUB
        public void Update2(string valor)
        {
            executarComando("UPDATE VALOR_CAIXA SET valor=valor-'" + valor.ToString().Replace(",", ".") + "';");
        }
        #endregion
    }
}
