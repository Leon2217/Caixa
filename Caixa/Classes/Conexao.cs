using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Caixa
{
    class Conexao
    {
        static MySqlConnection conectar;

        public static MySqlConnection Conectar
        {
            get { return Conexao.conectar; }
            set { Conexao.conectar = value; }
        }

        public static String criar_Conexao()
        {
            if (conectar != null)
            {
                conectar.Close();
            }

            // serve para configurar os parametros do banco de dados
            ////Padaria Vista Verde
            //string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql;sslMode=none;pooling=false", "25.37.204.167", "root", "Coxinha#2019");
            ////Padaria Parque das Américas 
            //string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql;sslMode=none;pooling=false", "25.48.37.81", "root", "Coxinha#2019");
            //Padrão
            string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql;sslMode=none;pooling=false", "127.0.0.1", "root", "Coxinha#2019");
            //string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql;sslMode=none;pooling=false", "127.0.0.1", "root", "ALUNOS");
            //string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql; pooling=false", "127.0.0.1", "root", "aluno@etep");
            // tenta estabelecer conectar

            try
            {
                conectar = new MySqlConnection(configuracao);
                conectar.Open();
            }// caso não consiga exibe erro de conexão
            catch (MySqlException erro)
            {
                return ("Erro ao conectar " + erro);
            }
        
            //criar um banco em branco na memória
           MySqlDataReader banco = null;

            // fazer uso do banco escolhido
            MySqlCommand usar = new MySqlCommand("use caixa1", conectar);

            // tenta criar o banco
            try
            {
                banco = usar.ExecuteReader();
            }// caso ocorra erro
            catch (MySqlException erro)
            {
                return ("Failed to populate database list: " + erro);
            }// no fim fecha
            finally
            {
                if (banco != null)
                {
                    banco.Close();
                }
            }
            return ("Conexão OK!!!");
        }
    }
}
