using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class DebitoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Debito deb = new Debito();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Debito Deb { get => deb; set => deb = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        public void Inserir(Debito deb)
        {
            executarComando("INSERT INTO DEBITO VALUES(0,'" + deb.Desc_debito + "','" + deb.Valor.ToString().Replace(",", ".") + "','" + deb.Hora.ToString("HH:mm") + "','" + deb.Data.ToString("yyyy/MM/dd") + "','" + deb.Responsavel+"');");
        }
    }
}
