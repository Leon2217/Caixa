using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class AuditoriaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Auditoria aud = new Auditoria();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Auditoria Aud { get => aud; set => aud = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR PESSOA
        public void Inserir(Auditoria aud)
        {
            executarComando("INSERT INTO AUDITORIA VALUES(0,'" + aud.Acao + "','" + aud.Responsavel + "','"+aud.Data.ToString("yyyy/MM/dd")+"','"+aud.Hora.ToString("hh:mm:ss")+"');");
        }
        #endregion
    }
}
