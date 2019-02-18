using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class EnderecoDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Endereco end = new Endereco();
             
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Endereco End { get => end; set => end = value; }

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region INSERIR PESSOA
        public void Inserir(Endereco end)
        {
            executarComando("INSERT INTO ENDERECO VALUES(0,'" + end.Id_pessoa + "','" + end.Tipo + "','" + end.Cep + "','" + end.Bairro + "','" + end.Uf + "','" + end.N_casa + "','" + end.Rua + "','" + end.Cidade + "','"+end.Complemento+"');");
        }
        #endregion

        #region UPDATE PESSOA
        public void Update(Endereco end)
        {
            executarComando("UPDATE ENDERECO SET cep='" + end.Cep + "',bairro='" + end.Bairro + "',uf='" + end.Uf + "',n_casa='" + end.N_casa + "',rua='" + end.Rua + "',complemento='"+end.Complemento+"',cidade='" + end.Cidade + "' WHERE id_pessoa='" + end.Id_pessoa + "'and tipo='cobranca';");
        }
        #endregion

        #region UPDATE PESSOA
        public void Update2(Endereco end)
        {
            executarComando("UPDATE ENDERECO SET cep='" + end.Cep + "',bairro='" + end.Bairro + "',uf='" + end.Uf + "',n_casa='" + end.N_casa + "',rua='" + end.Rua + "',complemento='"+end.Complemento+"',cidade='" + end.Cidade + "' WHERE id_pessoa='" + end.Id_pessoa + "'and tipo='entrega';");
        }
        #endregion

        #region UPDATE PESSOA
        public void Update3(Endereco end)
        {
            executarComando("UPDATE ENDERECO SET cep='" + end.Cep + "',bairro='" + end.Bairro + "',uf='" + end.Uf + "',n_casa='" + end.N_casa + "',rua='" + end.Rua + "',complemento='" + end.Complemento + "',cidade='" + end.Cidade + "' WHERE id_pessoa='" + end.Id_pessoa + "'and tipo='Primário';");
        }

        #endregion

        #region VERIFICA ID
        public Boolean VerificaID(string id)
        {

            executarComando("select * from ENDERECO WHERE id_pessoa='" +id + "' and tipo='cobranca';");
            try
            {       
                end.Cep = tabela_memoria.Rows[0]["cep"].ToString();
                end.Bairro = tabela_memoria.Rows[0]["bairro"].ToString();
                end.Uf = tabela_memoria.Rows[0]["uf"].ToString();
                end.Rua = tabela_memoria.Rows[0]["rua"].ToString();
                end.Cidade = tabela_memoria.Rows[0]["cidade"].ToString();
                end.N_casa = Convert.ToInt32(tabela_memoria.Rows[0]["n_casa"]);
                end.Complemento =tabela_memoria.Rows[0]["complemento"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA ID
        public Boolean VerificaID2(string id)
        {

            executarComando("select * from ENDERECO WHERE id_pessoa='" + id + "' and tipo='entrega';");
            try
            {
                end.Cep = tabela_memoria.Rows[0]["cep"].ToString();
                end.Bairro = tabela_memoria.Rows[0]["bairro"].ToString();
                end.Uf = tabela_memoria.Rows[0]["uf"].ToString();
                end.Rua = tabela_memoria.Rows[0]["rua"].ToString();
                end.Cidade = tabela_memoria.Rows[0]["cidade"].ToString();
                end.N_casa = Convert.ToInt32(tabela_memoria.Rows[0]["n_casa"]);
                end.Complemento = tabela_memoria.Rows[0]["complemento"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void ExcluirEndereco(string id_pessoa)
        {
            executarComando("DELETE FROM ENDERECO WHERE id_pessoa ='" + id_pessoa + "' and(tipo='cobranca' or tipo='entrega');");
        }
    }
}
