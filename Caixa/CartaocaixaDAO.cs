using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Caixa
{
    class CartaocaixaDAO
    {
        Criptografia cripto = new Criptografia("MICROSTATION");
        Cartaocaixa carcai = new Cartaocaixa();

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;


        public static string vscred;
        public static string vsdeb;
        public static string elocred;
        public static string elodeb;
        public static string mscred;
        public static string msdeb;
        public static string hipercard;
        public static string electron;
        public static string eloali;
        public static string eloref;
        public static string sodexoali;
        public static string sodexoref;
        public static string ticket;
        public static string vrali;
        public static string vrrefei;
        public static string fakeline;
        public static string alisoft;
        public static string refsoft;
        public static Boolean verifica;
        public static string total;
        public static string total2;


        


        internal Cartaocaixa Carcai { get => carcai; set => carcai = value; }

        public static string Codcaixa { get => codcaixa; set => codcaixa = value; }
        public static string Vscred { get => vscred; set => vscred = value; }
        public static string Vsdeb { get => vsdeb; set => vsdeb = value; }
        public static string Elocred { get => elocred; set => elocred = value; }
        public static string Elodeb { get => elodeb; set => elodeb = value; }
        public static string Mscred { get => mscred; set => mscred = value; }
        public static string Msdeb { get => msdeb; set => msdeb = value; }
        public static string Hipercard { get => hipercard; set => hipercard = value; }
        public static string Electron { get => electron; set => electron = value; }
        public static string Eloali { get => eloali; set => eloali = value; }
        public static string Eloref { get => eloref; set => eloref = value; }
        public static string Sodexoali { get => sodexoali; set => sodexoali = value; }
        public static string Sodexoref { get => sodexoref; set => sodexoref = value; }
        public static string Ticket { get => ticket; set => ticket = value; }
        public static string Vrali { get => vrali; set => vrali = value; }

        public static bool Verifica { get => verifica; set => verifica = value; }
        public static string Vrrefei { get => vrrefei; set => vrrefei = value; }
        public static string Fakeline { get => fakeline; set => fakeline = value; }
        public static string Total2 { get => total2; set => total2 = value; }
        public static string Alisoft { get => alisoft; set => alisoft = value; }
        public static string Refsoft { get => refsoft; set => refsoft = value; }

        public static string codcaixa;

        private void executarComando(string comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }


        public void inserir(Cartaocaixa carcai)
        {
            executarComando("INSERT INTO CARTAOCAIXA VALUES('"+carcai.Id_caixa+"','" + carcai.Id_cartao + "','" + carcai.Id_maquina + "','" +carcai.Valor.ToString().Replace(",",".")+"');");
        }

        public void update(Cartaocaixa carcai)
        {
            executarComando("UPDATE CARTAOCAIXA SET valor='" + carcai.Valor.ToString().Replace(",",".") + "' where id_cartao='"+carcai.Id_cartao+"' and id_maquina='"+carcai.Id_maquina+"' and id_caixa='"+carcai.Id_caixa+"';");
        }

        public Boolean testa(DateTime data)
        {
            executarComando("Select sum(valor) from cartaocaixa cc inner join caixa c on c.id_caixa=cc.id_caixa inner join turno t on t.id_turno=c.id_turno where c.id_turno=1 and datainicio='"+data.ToString("yyyy/MM/dd")+"';");
            try
            {

                total = tabela_memoria.Rows[0]["sum(valor)"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean testa2(DateTime data)
        {
            executarComando("Select sum(valor) from cartaocaixa cc inner join caixa c on c.id_caixa=cc.id_caixa inner join turno t on t.id_turno=c.id_turno where c.id_turno=2 and datainicio='" + data.ToString("yyyy/MM/dd") + "';");
            try
            {

                Total2 = tabela_memoria.Rows[0]["sum(valor)"].ToString();


                return true;
            }
            catch
            {
                return false;
            }
        }



        public  Boolean vercarcai(string codcaixa,string codmaq)
        {
            executarComando("SELECT valor FROM CARTAOCAIXA WHERE id_caixa='" +codcaixa + "' and id_maquina='"+codmaq+"';");
            try
            {
                vscred = null;
                vsdeb = null;
                elocred = null;
                elodeb = null;
                msdeb = null;
                mscred = null;
                hipercard = null;
                electron = null;
                eloali = null;
                eloref = null;
                sodexoali = null;
                sodexoref = null;
                ticket = null;
                vrrefei = null;
                vrali = null;
                fakeline = null;
                alisoft = null;
                refsoft =null;

                vscred = tabela_memoria.Rows[0]["valor"].ToString();
                vsdeb = tabela_memoria.Rows[1]["valor"].ToString();
                elocred = tabela_memoria.Rows[5]["valor"].ToString();
                elodeb = tabela_memoria.Rows[4]["valor"].ToString();
                mscred = tabela_memoria.Rows[2]["valor"].ToString();
                msdeb = tabela_memoria.Rows[3]["valor"].ToString();
                hipercard =tabela_memoria.Rows[6]["valor"].ToString();
                electron = tabela_memoria.Rows[12]["valor"].ToString();
                eloali = tabela_memoria.Rows[7]["valor"].ToString();
                eloref = tabela_memoria.Rows[8]["valor"].ToString();
                sodexoali = tabela_memoria.Rows[9]["valor"].ToString();
                sodexoref = tabela_memoria.Rows[10]["valor"].ToString();
                ticket = tabela_memoria.Rows[11]["valor"].ToString();
                vrrefei = tabela_memoria.Rows[13]["valor"].ToString();
                vrali = tabela_memoria.Rows[14]["valor"].ToString();
                fakeline= tabela_memoria.Rows[15]["valor"].ToString();
                alisoft= tabela_memoria.Rows[16]["valor"].ToString();
                refsoft = tabela_memoria.Rows[17]["valor"].ToString();


               
                return true;
            }
            catch
            {
                if (alisoft == null && refsoft==null && vscred==null &&
                    vsdeb==null && elocred==null && elodeb==null &&
                    mscred==null && msdeb==null && hipercard==null &&
                    electron==null && eloali==null && eloref==null &&
                    sodexoali==null && sodexoref==null && ticket==null &&
                    vrrefei==null && vrali==null && fakeline==null)
                {
                    return false;
                }
                else
                {

                    return true;
                }


            }
           
        }

        #region LISTAR TUDO
        public DataTable ListarTudo()
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as TOTAL from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();                                                
                    linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();             
                    linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();             
                    linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();              
                    linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();              
                    linha["TOTAL"] = tabela_memoria.Rows[i]["TOTAL"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion



        #region LISTAR DE
        public DataTable ListarDe(DateTime de)
        {
            DataTable listaDescripto;
            executarComando("select DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio='"+de.ToString("yyyy/MM/dd")+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE E BANDEIRA
        public DataTable ListarDB(DateTime De, string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and  cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + id + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE E TURNO
        public DataTable ListarDT(DateTime de,string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='"+id+"' and  cx.datainicio='" + de.ToString("yyyy/MM/dd") + "';");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE E MÁQUINA
        public DataTable ListarDM(DateTime de, string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and  cx.datainicio='" + de.ToString("yyyy/MM/dd") + "' and m.id_maquina='"+id+"';");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region BANDEIRA
        public DataTable ListarB(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and ma.id_marca='" + id + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();                
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region MAQUINA
        public DataTable ListarM(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and m.id_maquina='" + id + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();               
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region TURNO
        public DataTable ListarT(string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='" + id + "' GROUP BY c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();                
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BANDEIRA E CARTAO
        public DataTable ListarBC(string id2, string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and  c.id_cartao='" + id2+ "' and ma.id_marca='" + id + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BANDEIRA E TURNO
        public DataTable ListarBT(string id2, string id)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='" + id2 + "' and ma.id_marca='" + id + "' GROUP BY c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();                
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BANDEIRA E MAQUINA
        public DataTable ListarBM(string codban, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and ma.id_marca='" + codban + "' and m.id_maquina='"+codmaq+"' GROUP BY c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();             
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR TURNO E MAQUINA
        public DataTable ListarTM(string codturno, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='" + codturno + "' and m.id_maquina='" + codmaq + "' GROUP BY c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();                
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN
        public DataTable ListarB(DateTime de,DateTime at)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '"+at.ToString("yyyy/MM/dd")+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
               
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN e BANDEIRA
        public DataTable ListarBB(DateTime de, DateTime at,string codban)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and ma.id_marca='"+codban+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();
                
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN e TURNO
        public DataTable ListarBTU(DateTime de, DateTime at, string codturno)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and t.id_turno='" + codturno + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN e MAQUINA
        public DataTable ListarBTM(DateTime de, DateTime at, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, BANDEIRA E TURNO
        public DataTable ListarDBT(DateTime De, string codban,string codturno)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and t.id_turno='"+codturno+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, BANDEIRA E MAQUINA
        public DataTable ListarDBM(DateTime De, string codban, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and  cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, TURNO E MAQUINA
        public DataTable ListarDTM(DateTime De, string codturno, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and t.id_turno='" + codturno + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region BANDEIRA, TURNO E MAQUINA
        public DataTable ListarBTM(string codban, string codturno, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where ma.id_marca='" +codban+ "' and t.id_turno='" + codturno + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();               
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, BANDEIRA E TURNO
        public DataTable ListarBBT(DateTime de, DateTime at, string codban,string codturno)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and t.id_turno='"+codturno+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, BANDEIRA E MAQUINA
        public DataTable ListarBBM(DateTime de, DateTime at, string codban, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, BANDEIRA E CART
        public DataTable ListarBBC(DateTime de, DateTime at, string codban, string codcart)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and c.id_cartao='" + codcart + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, TURNO E MAQUINA
        public DataTable ListarBTM(DateTime de, DateTime at, string codturno, string codmaq)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='"+codturno+"' and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, BANDEIRA,CART E TURNO
        public DataTable ListarBBCT(DateTime de, DateTime at, string codban, string codcart,string codturno)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='"+codturno+"' and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and c.id_cartao='" + codcart + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, BANDEIRA, TURNO E MAQUINA
        public DataTable ListarBBTM(DateTime de, DateTime at, string codban,string codturno,string codmaq)
        {
            DataTable listaDescripto;
            executarComando("select t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join marca ma on ma.id_marca=c.id_marca inner join caixa cx on cx.id_caixa=cc.id_caixa inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='" + codturno + "' and cx.datainicio Between'" + de.ToString("yyyy/MM/dd") + "' and '" + at.ToString("yyyy/MM/dd") + "' and m.id_maquina='" + codmaq + "' and ma.id_marca='"+codban+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = listaDescripto.NewRow();

                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();
                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, BANDEIRA, TURNO E CARTAO
        public DataTable ListarDBTC(DateTime De, string codban, string codturno,string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and t.id_turno='" + codturno + "' and c.id_cartao='"+codcart+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, BANDEIRA, MAQUINA E CARTAO
        public DataTable ListarDBMC(DateTime De, string codban, string codmaq,string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno=2 and cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and m.id_maquina='" + codmaq + "' and c.id_cartao='"+codcart+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, BANDEIRA, MAQUINA E TURNO
        public DataTable ListarDBMT(DateTime De, string codban, string codmaq,string codturno)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='"+codturno+"' and cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and m.id_maquina='" + codmaq + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region BANDEIRA, TURNO, MAQUINA E CARTAO
        public DataTable ListarBTMC(string codban, string codturno, string codmaq,string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where ma.id_marca='" + codban + "' and t.id_turno='" + codturno + "' and m.id_maquina='" + codmaq + "' and c.id_cartao='"+codcart+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR DE, BANDEIRA, MAQUINA, TURNO E CARTAO
        public DataTable ListarDBMTC(DateTime De, string codban, string codmaq, string codturno,string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT DATE_FORMAT(cx.datainicio, '%d/%m/%y')  as DATA,t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,IF(cc.valor=('0.00' OR '0'),'',Concat(Replace(Replace(Replace(Format(cc.valor, 2), '.', '|'), ',', '.'), '|', ','))) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='" + codturno + "' and cx.datainicio='" + De.ToString("yyyy/MM/dd") + "' and ma.id_marca='" + codban + "' and m.id_maquina='" + codmaq + "' and c.id_cartao='"+codcart+"' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                linha["DATA"] = tabela_memoria.Rows[i]["DATA"].ToString();
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion

        #region LISTAR BETWEEN, BANDEIRA, MAQUINA, TURNO E CARTAO
        public DataTable ListarBBMTC(DateTime De,DateTime at,string codban, string codmaq, string codturno, string codcart)
        {
            DataTable listaDescripto;
            executarComando("SELECT t.turno as TURNO,ma.marca as MARCA,c.tipo as TIPO,cartao as CART,SUM(cc.valor) as VALOR from cartaocaixa cc inner join cartao c on c.id_cartao=cc.id_cartao inner join caixa cx on cx.id_caixa=cc.id_caixa inner join marca ma on ma.id_marca=c.id_marca inner join maquina m on m.id_maquina=cc.id_maquina inner join turno t on t.id_turno=cx.id_turno where t.id_turno='" + codturno + "' and (cx.datainicio BETWEEN'" + De.ToString("yyyy/MM/dd") + "' and '"+at.ToString("yyyy/MM/dd") + "') and ma.id_marca='" + codban + "' and m.id_maquina='" + codmaq + "' and c.id_cartao='" + codcart + "' group by c.id_cartao;");
            listaDescripto = tabela_memoria.Clone();
            #region FOR
            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {

                DataRow linha = listaDescripto.NewRow();
                
                linha["TURNO"] = tabela_memoria.Rows[i]["TURNO"].ToString();
                linha["MARCA"] = tabela_memoria.Rows[i]["MARCA"].ToString();
                linha["TIPO"] = tabela_memoria.Rows[i]["TIPO"].ToString();
                linha["CART"] = tabela_memoria.Rows[i]["CART"].ToString();
                linha["VALOR"] = tabela_memoria.Rows[i]["VALOR"].ToString();


                listaDescripto.Rows.Add(linha);
            }
            #endregion
            return listaDescripto;
        }
        #endregion
    }
}
