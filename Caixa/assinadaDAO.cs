using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class assinadaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        assinada ass = new assinada();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

     
        public static string Codcaixa { get => codcaixa; set => codcaixa = value; }
        public static string Classm { get => classm; set => classm = value; }
        public static string Julio { get => julio; set => julio = value; }
        public static string Assinada { get => assinada; set => assinada = value; }
        internal assinada Ass { get => ass; set => ass = value; }

        public static string codcaixa;

        public static string classm;

        public static string julio;

        public static string assinada;
        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }
        #region INSERIR OK
        public void Inserir(assinada ass)
        {
            executarComando("insert into assinadas values(0,'" + ass.Id_caixa + "','" + ass.Classm.ToString().Replace(",", ".") + "','" + ass.Julio.ToString().Replace(",", ".") + "','" + ass.Assinadas.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region BUSCAR OK
        public Boolean Buscar(string codcaixa)
        {
            executarComando("select classm,julio,assinada from assinadas a inner join caixa ca on ca.id_caixa=a.id_caixa where ca.id_caixa='" + codcaixa + "';");
            try
            {
                classm = tabela_memoria.Rows[0]["classm"].ToString();
                julio = tabela_memoria.Rows[0]["julio"].ToString();
                assinada = tabela_memoria.Rows[0]["assinada"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void Alterar(assinada ass)
        {
            executarComando("update assinadas set classm='" + ass.Classm.ToString().Replace(",", ".") + "',julio='" + ass.Julio.ToString().Replace(",", ".") + "',assinada='" + ass.Assinadas.ToString().Replace(",", ".") + "' where id_caixa='" + ass.Id_caixa + "';");
        }

        #region DeletaTudo
        public void DeletaTudo()
        {
            executarComando("delete from assinadas;");
            executarComando("delete from auditoria;");
            executarComando("delete from contas;");
            executarComando("delete from credito;");
            executarComando("delete from credito_debito;");
            executarComando("delete from debito;");
            executarComando("delete from despesa;");
            executarComando("delete from dev_moeda;");
            executarComando("delete from diferenca;");
            executarComando("delete from dinheiro;");
            executarComando("delete from entrada_dev;");
            executarComando("delete from entrada_moeda;");
            executarComando("delete from falta;");
            executarComando("delete from fiado;");
            executarComando("delete from gaveta;");
            executarComando("delete from geral;");
            executarComando("delete from recarga;");
            executarComando("delete from relatfiado;");
            executarComando("delete from sangria;");
            executarComando("delete from suprimento;");
            executarComando("delete from venda_vc;");

        }
        #endregion

        #region DELETA BTN
        public void DeletaTudoDeAt(DateTime de, DateTime at)
        {
            executarComando("delete a.* FROM assinadas a INNER JOIN caixa c on c.id_caixa = a.id_caixa WHERE c.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "'; ");
            executarComando("delete from auditoria WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from contas WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from credito WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "'; ");
            executarComando("delete from credito_debito WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from debito WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from despesa WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from dev_moeda WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete d.* from diferenca d INNER JOIN caixa c on c.id_caixa = d.id_caixa WHERE c.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete di.* from dinheiro di INNER JOIN caixa c on c.id_caixa = di.id_caixa WHERE c.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from entrada_dev WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from entrada_moeda WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from falta WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            //executarComando("delete from fiado;");
            executarComando("delete g.* from gaveta g INNER JOIN caixa c on c.id_caixa = g.id_caixa WHERE c.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from geral WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from recarga WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from relatfiado WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete sa.* from sangria sa INNER JOIN caixa c on c.id_caixa = sa.id_caixa WHERE c.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete su.* from suprimento su INNER JOIN caixa c on c.id_caixa = su.id_caixa WHERE c.datainicio BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
            executarComando("delete from venda_vc WHERE data BETWEEN '" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "';");
        }
        #endregion


        public void Caixa2()
        {
            executarComando("create database caixa2;");
        }

        public void InserirT(string senha)
        {
            executarComando("insert into temporaria values('"+senha+"');");

        }

        #region VERIFICA CARGO
        public Boolean VerificaT(string senha)
        {

            executarComando("select * from temporaria where chave='" + senha + "';");
            try
            {
                string valor = tabela_memoria.Rows[0]["chave"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void DeletaT()
        {
            executarComando("delete from temporaria;");


        }
    }
}