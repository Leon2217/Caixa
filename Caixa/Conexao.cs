using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            // verificando se existe uma conexão, fecha esta conexão
            if (conectar != null)
            {
                conectar.Close();
            }

            // serve para configurar os parametros do banco de dados
            string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql;sslMode=none;pooling=false", "192.168.0.134", "root", "microstation");
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

            // criar um banco em branco na memória
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
