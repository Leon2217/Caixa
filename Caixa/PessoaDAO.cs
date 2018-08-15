using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class PessoaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Pessoa pes = new Pessoa();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Pessoa Pes { get => pes; set => pes = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR PESSOA
        public void Inserir(Pessoa pes)
        {
            executarComando("INSERT INTO PESSOA VALUES(0,'"+pes.Id_tp+"','"+pes.Nome+"');");
        }
        #endregion

        #region LISTA TODAS AS PESSOAS
        public DataTable Listartudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT nome as NOME,tipo as TIPO FROM PESSOA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA TODAS AS PESSOAS COM ID
        public DataTable ListarExcluir()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_pessoa as ID,nome as NOME,tipo as TIPO FROM PESSOA;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region EXCLUIR
        public void Excluir(string id)
        {
            executarComando("DELETE FROM PESSOA WHERE id_pessoa ='" + id + "';");
        }
        #endregion

        #region LISTA TODAS AS PESSOAS LIKE
        public DataTable ListarNome(string nome,string tipo)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,tp.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_tp=p.id_tp WHERE p.nome LIKE '" + nome + "%' and tp.tipo LIKE '%"+tipo+"%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA POR TIPO
        public DataTable ListarTipo(string tipo)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_pessoa as ID,nome as NOME,tipo as TIPO FROM PESSOA WHERE tipo ='" + tipo + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA POR TIPO E NOME
        public DataTable ListarTN(string tipo,string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT id_pessoa as ID,nome as NOME,tipo as TIPO FROM PESSOA WHERE tipo ='" + tipo + "'and nome LIKE '" + nome + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TODOS FORNECEDORES
        public DataTable ListarF()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,tp.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_tp = p.id_tp WHERE tp.tipo LIKE'%Fornecedor%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TODOS FUNCIONARIOS
        public DataTable ListarFU()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,tp.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_tp=p.id_tp WHERE tp.tipo LIKE 'Func%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TUDO(NOME E TIPO)
        public DataTable ListarNT()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.nome as NOME,tp.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_tp=p.id_tp;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA TODAS AS PESSOAS COM ID
        public DataTable ListarID(string tipo)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,tp.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_tp=p.id_tp where tp.tipo LIKE'%"+tipo+"%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();              
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion





    }
}
