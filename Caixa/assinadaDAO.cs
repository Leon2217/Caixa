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

        internal assinada Ass { get => ass; set => ass = value; }
        public static string Codcaixa { get => codcaixa; set => codcaixa = value; }
        public static string Classm { get => classm; set => classm = value; }
        public static string Julio { get => julio; set => julio = value; }
        public static string Assinada { get => assinada; set => assinada = value; }

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
            executarComando("insert into assinadas values(0,'" + ass.Id_caixa + "','" + ass.Classm.ToString().Replace(",",".") + "','" + ass.Julio.ToString().Replace(",", ".") + "','"+ass.Assinadas.ToString().Replace(",", ".") + "');");
        }
        #endregion

        #region BUSCAR OK
        public Boolean Buscar(string codcaixa)
        {
            executarComando("select classm,julio,assinada from assinadas a inner join caixa ca on ca.id_caixa=a.id_caixa where ca.id_caixa='"+codcaixa+ "';");
            try
            {
                classm =tabela_memoria.Rows[0]["classm"].ToString();
                julio=tabela_memoria.Rows[0]["julio"].ToString();
                assinada= tabela_memoria.Rows[0]["assinada"].ToString();
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
            executarComando("update assinadas set classm='" + ass.Classm.ToString().Replace(",",".")+ "',julio='"+ass.Julio.ToString().Replace(",",".")+"',assinada='"+ass.Assinadas.ToString().Replace(",",".")+"' where id_caixa='" + ass.Id_caixa + "';");
        }





    }
}
