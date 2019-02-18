using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Caixa
{
    class UsuarioDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Usuario usu = new Usuario();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Usuario Usu { get => usu; set => usu = value; }

        private static Boolean existe;

        public static string Login { get => login; set => login = value; }
        public static bool Existe { get => existe; set => existe = value; }

        public static string login;

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando,Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region VERIFICA ADMINISTRADOR
        public Boolean VerificaAdm(string login, string senha)
        {

            executarComando("select login_usu from usuario where login_usu='"+login+"' and senha_usu='"+senha+"' and status='Ativo';");
            try
            {

                usu.Login_usu = tabela_memoria.Rows[0]["login_usu"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA CARGO
        public Boolean VerificaCargo(string login)
        {

            executarComando("select tipo from usuario where login_usu='" + login + "';");
            try
            {
                usu.Tipo = tabela_memoria.Rows[0]["tipo"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA EXISTE
        public Boolean VerificaExiste()
        {
            executarComando("select * from usuario;");
            try
            {
                usu.Login_usu = tabela_memoria.Rows[0]["login_usu"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region INSERIR NOVO USUÁRIO
        public void Inserir(Usuario usu)
        {
            executarComando("INSERT INTO USUARIO VALUES(0,'" +usu.Login_usu + "','" +usu.Senha_usu+ "','" + usu.Tipo + "','" + usu.Status + "');");
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_usu as ID,login_usu as LOGIN FROM USUARIO;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["LOGIN"] = tabela_memoria.Rows[i]["LOGIN"].ToString();
             
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region EXCLUIR
        public void Excluir(string id)
        {
            executarComando("DELETE FROM USUARIO WHERE id_usu ='" + id + "';");
        }
        #endregion
    }
}
