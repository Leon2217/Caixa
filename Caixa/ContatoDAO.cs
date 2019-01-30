using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class ContatoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Contato con = new Contato();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Contato Con { get => con; set => con = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }


        #region INSERIR CONTATO
        public void Inserir(Contato con)
        {
            executarComando("INSERT INTO CONTATO VALUES(0,'" + con.Id_pessoa + "','" + con.Nome + "','" + con.Email + "','" + con.Telefone + "','" + con.Dep + "');");
        }
        #endregion

        #region LISTA TODAS OS CONTATOS POR ID DA PESSOA
        public DataTable ListarID(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_contato as ID,nome as NOME,email as EMAIL,telefone as TEL,dep as DEPARTAMENTO FROM CONTATO  where id_pessoa='" +id+ "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["EMAIL"] = tabela_memoria.Rows[i]["EMAIL"].ToString();
                linha["TEL"] = tabela_memoria.Rows[i]["TEL"].ToString();
                linha["DEPARTAMENTO"] = tabela_memoria.Rows[i]["DEPARTAMENTO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region UPDATE CONTATO
        public void Update(Contato con)
        {
            executarComando("UPDATE CONTATO SET nome='" + con.Nome + "',email='" + con.Email + "',telefone='" + con.Telefone + "',dep='"+con.Dep+"' WHERE id_contato='" + con.Id_contato + "';");
        }
        #endregion
    }
}
