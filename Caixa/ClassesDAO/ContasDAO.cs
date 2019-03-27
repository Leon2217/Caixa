using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
   class ContasDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Contas con = new Contas();
        Contas2 con2 = new Contas2();
        Contas3 con3 = new Contas3();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        internal Contas Con { get => con; set => con = value; }
        public static int Codfudeu { get => codfudeu; set => codfudeu = value; }
        internal Contas2 Con2 { get => con2; set => con2 = value; }
        internal Contas3 Con3 { get => con3; set => con3 = value; }

        public static int codfudeu;

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        #region VERIFICA O VALOR DO ID
        public Boolean Verificavalor(string id)
        {
            executarComando("SELECT * FROM CONTAS where id_contas='"+id+"';");
            try
            {
                Con.Valor = tabela_memoria.Rows[0]["valor"].ToString();
                Con.Data= Convert.ToDateTime(tabela_memoria.Rows[0]["data"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void Excluir(string id, string n)
        {
            executarComando("DELETE FROM CONTAS WHERE id_contas ='" + id + "' || NF='"+n +"';");
        }

        #region INSERIR CONTA
        public void Inserir(Contas con)
        {
            executarComando("INSERT INTO CONTAS VALUES(0,'" + con.Id_pessoa + "','" + con.Valor.ToString().Replace(",", ".") + "','" + con.Nf + "','" +con.Data.ToString("yyyy/MM/dd") + "','" + con.Data_em.ToString("yyyy/MM/dd") + "','" + con.Status + "');");
        }
        #endregion

        #region INSERIR CONTA2
        public void Inserir2(Contas2 con)
        {
            executarComando("INSERT INTO CONTAS VALUES(0,'" + con.Id_pessoa + "','" + con.Valor.ToString().Replace(",", ".") + "','" + con.Nf + "','" + con.Data.ToString("yyyy/MM/dd") + "','" + con.Data_em.ToString("yyyy/MM/dd") + "','" + con.Status + "');");
        }
        #endregion

        #region INSERIR CONTA3
        public void Inserir3(Contas3 con)
        {
            executarComando("INSERT INTO CONTAS VALUES(0,'" + con.Id_pessoa + "','" + con.Valor.ToString().Replace(",", ".") + "','" + con.Nf + "','" + con.Data.ToString("yyyy/MM/dd") + "','" + con.Data_em.ToString("yyyy/MM/dd") + "','" + con.Status + "');");
        }
        #endregion

        #region LISTAR NOTA FISCAL
        public DataTable ListarNF(string nf)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE C.NF LIKE '" + nf + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();        
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa ORDER BY C.ID_CONTAS;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();               
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SOMENTE POR FORNECEDOR E STATUS
        public DataTable ListarFS(string fornecedor, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE p.nome LIKE'" + fornecedor + "%' and c.status LIKE'" + status + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE
        public DataTable ListarD(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.data='" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime de, DateTime at)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DATA E FORNECEDOR
        public DataTable ListarDF(DateTime de, string fornecedor)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.data='" + de.ToString("yyyy/MM/dd") + "' and p.nome LIKE '" + fornecedor + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DATA E STATUS
        public DataTable ListarDS(DateTime de, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.data='" + de.ToString("yyyy/MM/dd") + "' and c.status LIKE '" + status + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DATA E NF
        public DataTable ListarDNF(DateTime de, string nf)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.data='" + de.ToString("yyyy/MM/dd") + "' and c.nf LIKE '" + nf + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SOMENTE POR FORNECEDOR
        public DataTable ListarF(string fornecedor)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE p.nome LIKE'" + fornecedor + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR SOMENTE POR STATUS
        public DataTable ListarS(string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.status LIKE'" + status + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E FORNECEDOR
        public DataTable ListarBF(DateTime de, DateTime at, string fornecedor)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,c.status as STATUS,p.nome as FORNECEDOR,NF,DATE_FORMAT(data, '%d/%m/%y') as VENC1EM,DATE_FORMAT(data, '%d/%m/%y')  as VENC1,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL,if(c.data2=('0001-01-01'),'',DATE_FORMAT(data2, '%d/%m/%y'))  as VENC2,IF(c.valor2=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor2, 2), '.', '|'), ',', '.'), '|', ','))) PARCELA1,if(c.data3=('0001-01-01'),'',DATE_FORMAT(data3, '%d/%m/%y'))  as VENC3,IF(c.valor3=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor3, 2), '.', '|'), ',', '.'), '|', ','))) PARCELA2,IF(c.valor4=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor4, 2), '.', '|'), ',', '.'), '|', ','))) PARCELA3 FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and p.nome LIKE'" + fornecedor + "%' ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E STATUS
        public DataTable ListarBS(DateTime de, DateTime at, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and c.status LIKE'" + status + "%' ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR NOTA FISCAL E STATUS
        public DataTable ListarNS(string nf, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE C.NF LIKE '" + nf + "%' and c.status LIKE'" + status + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN E NOTA FISCAL
        public DataTable ListarBN(DateTime de, DateTime at, string nf)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and c.nf LIKE'" + nf + "%' ;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR PEDIDO/CHEQUE E FORNECEDOR
        public DataTable ListarPF(string pc, string fornecedor)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE C.NF LIKE '" + pc + "%' and p.nome LIKE'" + fornecedor + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region BETWEEN,FORNECEDOR E STATUS
        public DataTable ListarBFS(DateTime de, DateTime at, string fornecedor, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE p.nome LIKE'" + fornecedor + "%' and c.status LIKE'" + status + "%' AND DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region BETWEEN,NF E STATUS
        public DataTable ListarBNS(DateTime de, DateTime at, string nf, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.nf LIKE'" + nf + "%' and c.status LIKE'" + status + "%' AND DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region BETWEEN,PEDIDO/CHEQUE,FORNECEDOR E STATUS
        public DataTable ListarBPFS(DateTime de, DateTime at, string fornecedor, string status, string pc)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE p.nome LIKE'" + fornecedor + "%' and c.status LIKE'" + status + "%' AND DATA BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' AND  C.NF LIKE '" + pc + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE,FORNECEDOR E STATUS
        public DataTable ListarDFS(DateTime de, string fornecedor, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.data='" + de.ToString("yyyy/MM/dd") + "' and  p.nome LIKE'" + fornecedor + "%' and c.status LIKE'" + status + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();

                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE,NF E STATUS
        public DataTable ListarDNS(DateTime de, string nf, string status)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE c.data='" + de.ToString("yyyy/MM/dd") + "' and  c.nf LIKE'" + nf + "%' and c.status LIKE'" + status + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region DE,PEDIDO/CHEQUE,FORNECEDOR E STATUS
        public DataTable ListarDPFS(DateTime de, string fornecedor, string status, string pc)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,c.status as STATUS,p.nome as FORNECEDOR,NF,DATE_FORMAT(data, '%d/%m/%y') as VENC1EM,DATE_FORMAT(data, '%d/%m/%y')  as VENC1,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS TOTAL,if(c.data2=('0001-01-01'),'',DATE_FORMAT(data2, '%d/%m/%y'))  as VENC2,IF(c.valor2=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor2, 2), '.', '|'), ',', '.'), '|', ','))) PARCELA1,if(c.data3=('0001-01-01'),'',DATE_FORMAT(data3, '%d/%m/%y'))  as VENC3,IF(c.valor3=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor3, 2), '.', '|'), ',', '.'), '|', ','))) PARCELA2,IF(c.valor4=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor4, 2), '.', '|'), ',', '.'), '|', ','))) PARCELA3 FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE p.nome LIKE'" + fornecedor + "%' and c.status LIKE'" + status + "%' AND DATA='" + de.ToString("yyyy/MM/dd") + "' AND  C.NF LIKE '" + pc + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region PEDIDO/CHEQUE,FORNECEDOR E STATUS
        public DataTable ListarPFS(string fornecedor, string status, string pc)
        {
            DataTable listaDescripto;
            executarComando("SELECT c.id_contas as ID,nf as NF,p.nome as FORNECEDOR,DATE_FORMAT(data_em, '%d/%m/%y') as EMISSAO,DATE_FORMAT(data, '%d/%m/%y') as VENC,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa WHERE p.nome LIKE'" + fornecedor + "%' and c.status LIKE'" + status + "%' AND  C.NF LIKE '" + pc + "%';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["ID"] = tabela_memoria.Rows[i]["ID"].ToString();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                linha["EMISSAO"] = tabela_memoria.Rows[i]["EMISSAO"].ToString();
                linha["VENC"] = tabela_memoria.Rows[i]["VENC"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region STATUS
        public DataTable ListarStatus(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT status as STATUS FROM CONTAS WHERE ID_CONTAS='" + id + "';");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region UPDATE STATUS PELO ID
        public void UpdateStatus(string status, string id)
        {
            executarComando("UPDATE CONTAS SET STATUS='" + status + "' where id_contas='" + id + "';");
        }
        #endregion

        #region UPDATE STATUS PELA NF
        public void UpdateStatusNF(string status, string nf)
        {
            executarComando("UPDATE CONTAS SET STATUS='" + status + "' where NF='" + nf + "';");
        }
        #endregion

        #region UPDATE CONTAS
        public void UpdateAtrasado()
        {
            executarComando("UPDATE CONTAS SET STATUS='Atrasado' where data<curdate() and status!='Pago';");
        }
        #endregion

        #region LISTAR DIFERENCIADO 2018 FODA
        public DataTable ListarDiferenciado()
        {
            DataTable listaDescripto;
            executarComando("SELECT nf as NF,p.nome as FORNECEDOR,IF(c.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(valor, 2), '.', '|'), ',', '.'), '|', ','))) AS VALOR,status as STATUS FROM CONTAS C inner join pessoa p on p.id_pessoa=c.id_pessoa;");
            listaDescripto = tabela_memoria.Clone();

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["STATUS"] = tabela_memoria.Rows[i]["STATUS"].ToString();
                linha["FORNECEDOR"] = tabela_memoria.Rows[i]["FORNECEDOR"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                linha["NF"] = tabela_memoria.Rows[i]["NF"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            return listaDescripto;
        }
        #endregion

        #region VERIFICA A QTD DE CONTAS ATRASADAS
        public Boolean VerificaAtrasado()
        {
            executarComando("select count(*) as QTD from contas where status = 'Atrasado';");
            try
            {
                Con.N = Convert.ToInt32(tabela_memoria.Rows[0]["QTD"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region VERIFICA A QTD DE CONTAS EM ABERTO
        public Boolean VerificaEmAberto()
        {
            executarComando("select count(*) as QTD from contas where status = 'Em aberto';");
            try
            {
                Con.N = Convert.ToInt32(tabela_memoria.Rows[0]["QTD"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


    }
}
