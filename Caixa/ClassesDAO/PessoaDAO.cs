using System;
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

        public static string tp0;
        public static string tp1;
        public static string tp2;
        public static string tp3;

        internal Pessoa Pes { get => pes; set => pes = value; }
        DataTable listapessoa;
        
        public static string Tp0 { get => tp0; set => tp0 = value; }
        public static string Tp1 { get => tp1; set => tp1 = value; }
        public static string Tp2 { get => tp2; set => tp2 = value; }
        public static string Tp3 { get => tp3; set => tp3 = value; }
        public DataTable Listapessoa { get => listapessoa; set => listapessoa = value; }

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
            executarComando("INSERT INTO PESSOA VALUES(0,'"+pes.Nome+"','"+pes.Tipo+"','"+pes.Cpfnj+"','"+pes.Im+"','"+pes.Ie+"','"+pes.Fornecimento+"','"+pes.Rs+"','"+pes.Cel+"','"+pes.Tel+"','"+pes.Email+"','"+pes.Obs+"');");
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
        public void Excluir(string cpfnj)
        {
            executarComando("DELETE FROM PESSOA WHERE cpfnj ='" + cpfnj + "';");
        }
        #endregion

        #region Excluir Nome
        public void ExcluirNome(string nome, string cpfnj)
        {
            executarComando("DELETE FROM PESSOA WHERE nome ='" + nome + "' and cpfnj ='" + cpfnj + "';");
        }
        #endregion Excluir Nome

        #region EXCLUIR
        public void ExcluirCpfnj(string cpfnj)
        {
            executarComando("DELETE FROM PESSOA WHERE cpfnj ='" + cpfnj + "';");
        }
        #endregion

        public void ExcluirContato(string id_con)
        {
            executarComando("DELETE FROM CONTATO WHERE id_contato ='" +id_con + "';");
        }

        #region LISTA TODAS AS PESSOAS LIKE
        public DataTable ListarNome(string nome,string tipo)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,t.tipo as CATEGORIA,p.fisjur as TIPO,p.cpfnj as CPFNJ FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE p.nome LIKE '" + nome + "%' and t.tipo LIKE '%"+tipo+"%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["CATEGORIA"] = tabela_memoria.Rows[i]["CATEGORIA"].ToString();
                linha["CPFNJ"] = tabela_memoria.Rows[i]["CPFNJ"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA TODAS AS PESSOAS LIKE
        public DataTable ListarT()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,t.tipo as CATEGORIA,p.fisjur as TIPO,p.cpfnj as CPFNJ FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo GROUP BY p.id_pessoa ORDER BY p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["CATEGORIA"] = tabela_memoria.Rows[i]["CATEGORIA"].ToString();
                linha["CPFNJ"] = tabela_memoria.Rows[i]["CPFNJ"].ToString();
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
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,t.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE t.tipo LIKE 'Fornecedor%' order by p.nome ASC;");
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
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,t.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE t.tipo LIKE 'Func%' order by p.nome ASC;");
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

           
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,p.fisjur as TIPO,p.cpfnj as CPFNJ FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE t.tipo LIKE '%" + tipo + "%' GROUP BY p.id_pessoa ORDER BY p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["CPFNJ"] = tabela_memoria.Rows[i]["CPFNJ"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA TODAS PESSOA DESPESAS
        public DataTable ListarTDP()
        {
            DataTable listaDescripto;
            executarComando("SELECT id_pessoa as ID,nome as NOME FROM PESSOA ORDER BY nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region VERIFICA CPF E CNPJ
        public Boolean VerificaCPF(string cpf)
        {

            executarComando("select * from PESSOA p inner join endereco e on e.id_pessoa = p.id_pessoa WHERE cpfnj='"+cpf+"';");
            try
            {
                pes.Id_pessoa= Convert.ToInt32(tabela_memoria.Rows[0]["id_pessoa"]);
              
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA CPF E CNPJ
        public Boolean VerificaCPFNJ(string cpf)
        {

            executarComando("select p.id_pessoa as ID,p.nome as NOME,cpfnj as CPFNJ,im as IM, ie as IE, fornecimento as FORNECIMENTO, rs as RS, cel as CEL, tel as TEL, email as EMAIL,obs as OBS,e.n_casa as NUM,e.cep as CEP,e.rua as RUA, e.uf as UF,e.cidade as CIDADE,e.bairro as BAIRRO,t.tipo as TIPO from PESSOA p inner join endereco e on e.id_pessoa = p.id_pessoa INNER JOIN tipo_pessoa tp on tp.id_pessoa = p.id_pessoa INNER JOIN tipo t  on t.id_tipo = tp.id_tipo where cpfnj='"+cpf+"' and e.tipo='Primario';");
            try
            {
                pes.Id_pessoa = Convert.ToInt32(tabela_memoria.Rows[0]["ID"]);
                pes.Nome = tabela_memoria.Rows[0]["NOME"].ToString();
                pes.Cpfnj = tabela_memoria.Rows[0]["CPFNJ"].ToString();
                pes.Im = tabela_memoria.Rows[0]["IM"].ToString();
                pes.Ie = tabela_memoria.Rows[0]["IE"].ToString();
                pes.Fornecimento = tabela_memoria.Rows[0]["FORNECIMENTO"].ToString();
                pes.Rs = tabela_memoria.Rows[0]["RS"].ToString();
                pes.Cel = tabela_memoria.Rows[0]["CEL"].ToString();
                pes.Tel = tabela_memoria.Rows[0]["TEL"].ToString();
                pes.Email = tabela_memoria.Rows[0]["EMAIL"].ToString();
                pes.Obs = tabela_memoria.Rows[0]["OBS"].ToString();
                pes.N_casa = Convert.ToInt32(tabela_memoria.Rows[0]["NUM"].ToString());
                pes.Cep = tabela_memoria.Rows[0]["CEP"].ToString();
                pes.Rua = tabela_memoria.Rows[0]["RUA"].ToString();
                pes.Uf = tabela_memoria.Rows[0]["UF"].ToString();
                pes.Cidade = tabela_memoria.Rows[0]["CIDADE"].ToString();
                pes.Bairro = tabela_memoria.Rows[0]["BAIRRO"].ToString();
                pes.Tipo = tabela_memoria.Rows[0]["TIPO"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA NOMEPESQ
        public Boolean VerificaNOMEPESQ(string nome)
        {
            executarComando("select p.id_pessoa as ID,p.nome as NOME,fisjur as FISJUR,cpfnj as CPFNJ,im as IM, ie as IE, fornecimento as FORNECIMENTO, rs as RS, cel as CEL, tel as TEL, email as EMAIL,obs as OBS,e.n_casa as NUM,e.cep as CEP,e.rua as RUA, e.uf as UF,e.cidade as CIDADE,e.bairro as BAIRRO from PESSOA p inner join endereco e on e.id_pessoa = p.id_pessoa  where p.nome='" + nome + "' and e.tipo='Primario';");
            try
            {
                pes.Id_pessoa = Convert.ToInt32(tabela_memoria.Rows[0]["ID"]);

                pes.Nome = tabela_memoria.Rows[0]["NOME"].ToString();
                pes.Fisjur = tabela_memoria.Rows[0]["FISJUR"].ToString();
                pes.Cpfnj = tabela_memoria.Rows[0]["CPFNJ"].ToString();
                pes.Im = tabela_memoria.Rows[0]["IM"].ToString();
                pes.Ie = tabela_memoria.Rows[0]["IE"].ToString();
                pes.Fornecimento = tabela_memoria.Rows[0]["FORNECIMENTO"].ToString();
                pes.Rs = tabela_memoria.Rows[0]["RS"].ToString();
                pes.Cel = tabela_memoria.Rows[0]["CEL"].ToString();
                pes.Tel = tabela_memoria.Rows[0]["TEL"].ToString();
                pes.Email = tabela_memoria.Rows[0]["EMAIL"].ToString();
                pes.Obs = tabela_memoria.Rows[0]["OBS"].ToString();
                pes.N_casa = Convert.ToInt32(tabela_memoria.Rows[0]["NUM"].ToString());
                pes.Cep = tabela_memoria.Rows[0]["CEP"].ToString();
                pes.Rua = tabela_memoria.Rows[0]["RUA"].ToString();
                pes.Uf = tabela_memoria.Rows[0]["UF"].ToString();
                pes.Cidade = tabela_memoria.Rows[0]["CIDADE"].ToString();
                pes.Bairro = tabela_memoria.Rows[0]["BAIRRO"].ToString();
              

                if (tabela_memoria.Rows.Count > 1)
                {
                    listapessoa = tabela_memoria;
                }
                else
                {
                    listapessoa = null;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region MAXID
        public Boolean VerificaID()
        {
            executarComando("select MAX(id_pessoa) from PESSOA;");
            try
            {
                pes.Id_pessoa = Convert.ToInt32(tabela_memoria.Rows[0]["max(id_pessoa)"]);
              
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void Update(Pessoa pes)
        {
            executarComando("UPDATE PESSOA SET nome='" +pes.Nome+ "',im='" + pes.Im + "',ie='"+pes.Ie+"',fornecimento='"+pes.Fornecimento+"',rs='"+pes.Rs+"',cel='"+pes.Cel+"',tel='"+pes.Tel+"',email='"+pes.Email+"',obs ='"+pes.Obs+"'  WHERE cpfnj='" + pes.Cpfnj + "';");
        }

        #region LISTA TODOS OS CLIENTES
        public DataTable ListarClientes()
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,t.tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE t.tipo LIKE 'Cliente%' or t.tipo LIKE 'Func%' GROUP BY p.nome ORDER BY p.nome ASC;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();               
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTA TODOS OS CLIENTES
        public DataTable ListarIDC(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo where p.id_pessoa='" + id + "' GROUP BY p.nome ORDER BY p.nome ASC ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();    
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        public DataTable ListarTudoPessoa(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT * from from pessoa");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["nome"] = tabela_memoria.Rows[i]["nome"].ToString();
                linha["cpfnj"] = tabela_memoria.Rows[i]["cpfnj"].ToString();
                linha["id_pessoa"] = tabela_memoria.Rows[i]["id_pessoa"].ToString();
                linha["fisjur"] = tabela_memoria.Rows[i]["fisjur"].ToString();
                linha["im"] = tabela_memoria.Rows[i]["im"].ToString();
                linha["ie"] = tabela_memoria.Rows[i]["ie"].ToString();
                linha["fornecimento"] = tabela_memoria.Rows[i]["fornecimento"].ToString();
                linha["rs"] = tabela_memoria.Rows[i]["rs"].ToString();
                linha["cel"] = tabela_memoria.Rows[i]["cel"].ToString();
                linha["tel"] = tabela_memoria.Rows[i]["tel"].ToString();
                linha["email"] = tabela_memoria.Rows[i]["email"].ToString();
                linha["obs"] = tabela_memoria.Rows[i]["obs"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }

        #region LISTA TODAS AS PESSOAS COM ID DO TIPO
        public DataTable ListarIDT(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,nome as NOME,tipo as TIPO FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa= p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE t.id_tipo ='"+id+ "'order by nome ASC; ");
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

        #region LISTA TODAS AS PESSOAS LIKE
        public DataTable ListarNM(string nome)
        {
            DataTable listaDescripto;
            executarComando("SELECT p.id_pessoa as ID,p.nome as NOME,t.tipo as CATEGORIA,p.fisjur as TIPO,p.cpfnj as CPFNJ FROM PESSOA p inner join tipo_pessoa tp on tp.id_pessoa=p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE p.nome LIKE '" + nome + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["NOME"] = tabela_memoria.Rows[i]["NOME"].ToString();
                linha["CATEGORIA"] = tabela_memoria.Rows[i]["CATEGORIA"].ToString();
                linha["CPFNJ"] = tabela_memoria.Rows[i]["CPFNJ"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region VERIFICA TIPOS
        public Boolean VerificaTipo(string cpf)
        {
            executarComando("select t.tipo as TIPO from PESSOA p inner join tipo_pessoa tp on tp.id_pessoa = p.id_pessoa inner join tipo t on t.id_tipo = tp.id_tipo WHERE cpfnj='" + cpf + "';");
            try
            {

                tp0 = null;
                tp1 = null;
                tp2 = null;
                tp3 = null;
                



                tp0 =tabela_memoria.Rows[0]["TIPO"].ToString();
                tp1 = tabela_memoria.Rows[1]["TIPO"].ToString();
                tp2= tabela_memoria.Rows[2]["TIPO"].ToString();
                tp3 = tabela_memoria.Rows[3]["TIPO"].ToString();
                return true;
            }
            catch
            {
                if (tp0 == null && tp1 == null && tp2 ==null && tp3 ==null)
                {
                    return false;
                }
                else
                {

                    return true;
                }
            }
        }
        #endregion     
    }
}
