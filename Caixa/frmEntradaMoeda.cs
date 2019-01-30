using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixa
{
    public partial class frmEntradaMoeda : Form
    {
        #region VAR
        int qtd1;
        int qtd2;
        int qtd3;
        int qtd4;
        int qtd5;
        double total5c;
        double total10c;
        double total25c;
        double total50c;
        double total1r;
        double totalmoeda;
        #endregion

        #region INSTANCIAMENTO DE CLASSES
        Entradamoeda em = new Entradamoeda();
        EntradamoedaDAO emDAO = new EntradamoedaDAO();
        ValorcxmDAO cxmDAO = new ValorcxmDAO();
        Valorcxm cxm = new Valorcxm();
        ValorcaixaDAO vcxDAO = new ValorcaixaDAO();
        credDebDAO cdDAO = new credDebDAO();
        CredDeb cd = new CredDeb();
        EntradaDev ed = new EntradaDev();
        EntradaDevDAO edDAO = new EntradaDevDAO();
        Sangria san = new Sangria();
        SangriaDAO sanDAO = new SangriaDAO();
        ValorgeralDAO vgDAO = new ValorgeralDAO();
        Valorgeral vg = new Valorgeral();
        GeralDAO gerDAO = new GeralDAO();
        Geral ger = new Geral();
        Auditoria aud = new Auditoria();
        AuditoriaDAO audDAO = new AuditoriaDAO();


        #endregion
        public frmEntradaMoeda()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            txt1Real.Clear();
            txt5Centavos.Clear();
            txt10Centavos.Clear();
            txt25Centavos.Clear();
            txt50Centavos.Clear();
            Deshab();
        }
        public void Deshab()
        {
            chkBaixo.Checked = false;
            chkPDV.Checked = false;
            txt1Real.Enabled = false;
            txt5Centavos.Enabled = false;
            txt10Centavos.Enabled = false;
            txt25Centavos.Enabled = false;
            txt50Centavos.Enabled = false;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult op;

                op = MessageBox.Show("Você tem certeza dessas informações?",
                    "Salvando!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    if (txt5Centavos.Text == string.Empty)
                    {
                        em.Moeda_5 = 0;
                    }
                    else
                    {
                        em.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                    }

                    if (txt10Centavos.Text == string.Empty)
                    {
                        em.Moeda_10 = 0;
                    }
                    else
                    {
                        em.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                    }
                    if (txt25Centavos.Text == string.Empty)
                    {
                        em.Moeda_25 = 0;
                    }
                    else
                    {
                        em.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                    }
                    if (txt50Centavos.Text == string.Empty)
                    {
                        em.Moeda_50 = 0;
                    }
                    else
                    {
                        em.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                    }

                    if (txt1Real.Text == string.Empty)
                    {
                        em.Moeda_1 = 0;
                    }
                    else
                    {
                        em.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                    }
                    #region ENTRADA DE MOEDA
                    try
                    {
                        em.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                        em.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                        em.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        em.Responsavel = UsuarioDAO.login;
                        emDAO.Inserir(em);

                        MessageBox.Show("Informações salvas com sucesso!!!");

                        aud.Acao = "INSERIU MOEDA";
                        aud.Data = FechamentoDAO.data;
                        aud.Hora = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        aud.Responsavel = UsuarioDAO.login;
                        audDAO.Inserir(aud);
                    }
                    catch
                    {
                        MessageBox.Show("Favor verificar as informações digitadas");
                    }

                    #endregion

                    if (cxmDAO.Verificavalor()==true)
                    {
                        if (chkBaixo.Checked == true)
                        {
                            #region SOMANDO NO CAIXA DE MOEDA
                            cxm.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cxmDAO.Update(cxm);
                            #endregion


                           


                                #region SUBTRAINDO DO CAIXA NORMAL
                                if (vcxDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            else
                            {
                                string zero1 = "0.00";
                                vcxDAO.Inserir(zero1);
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            #endregion

                            vcxDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            cd.Desc_db = "Saída p/ caixa moeda";
                            cd.Deb_db = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cd.Cred_db = "0,00";
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcxDAO.Vc.Valor;
                            cdDAO.Inserir(cd);

                            #endregion

                            cxmDAO.Verificavalor();
                            #region INSERINDO NA TABELA ENTRADA_DEV
                            if (txt5Centavos.Text == string.Empty)
                            {
                                ed.Moeda_5 = 0;
                            }
                            else
                            {
                                ed.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                ed.Moeda_10 = 0;
                            }
                            else
                            {
                                ed.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                ed.Moeda_25 = 0;
                            }
                            else
                            {
                                ed.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                ed.Moeda_50 = 0;
                            }
                            else
                            {
                                ed.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                ed.Moeda_1 = 0;
                            }
                            else
                            {
                                ed.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }
                            ed.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            ed.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            ed.Desc_ed = "Entrada moeda caixa";
                            ed.Entrada_ed = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            ed.Saida_ed = "0,00";
                            ed.Responsa_ed = UsuarioDAO.login;
                            ed.Total = cxmDAO.Vcm.Valor;
                            edDAO.Inserir(ed);
                            #endregion


                            #region GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vgDAO.Update2(valor);
                                vgDAO.Verificavalor();
                                
                                ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                ger.Desc_g = "";
                                ger.Cred_g = "0.00";
                                ger.Deb_g = valor.ToString().Replace(".", "");
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);

                                
                            }
                            else
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update(valor);

                                string zero1 = "0.00";
                                vgDAO.Inserir(zero1);
                                vgDAO.Update2(valor.ToString().Replace(".", ""));
                                vgDAO.Verificavalor();

                                

                                ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                ger.Desc_g = "";
                                ger.Cred_g = "0,00";
                                ger.Deb_g = valor.ToString().Replace(".", "");
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);

                                #endregion
                            }

                            Limpar();
                        }
                        else
                        {
                            // FAZ A DO PDV
                            #region INSERINDO ZERO NO CAIXA DE MOEDA
                            string zero = "0.00";
                            cxmDAO.Inserir(zero);
                            #endregion

                            #region SOMANDO NO CAIXA NORMAL
                            if (vcxDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update(valor);
                            }

                            else
                            {
                                string zero1 = "0.00";
                                vcxDAO.Inserir(zero1);
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update(valor);
                            }
                            #endregion

                            vcxDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            cd.Desc_db = "Entrada moeda PDV";
                            cd.Deb_db = "0,00";
                            cd.Cred_db = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcxDAO.Vc.Valor;
                            cdDAO.Inserir(cd);

                            #endregion

                            #region GERAL
                            if (vgDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vgDAO.Update(valor);
                                vgDAO.Verificavalor();
                                #region GERAL
                                ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                ger.Desc_g = "";
                                ger.Cred_g = valor.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);

                                #endregion
                            }
                            else
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update(valor);

                                string zero1 = "0.00";
                                vgDAO.Inserir(zero1);
                                vgDAO.Update(valor.ToString().Replace(".", ""));
                                vgDAO.Verificavalor();

                                

                                ger.Data = Convert.ToDateTime(FechamentoDAO.data);
                                ger.Desc_g = "CRÉDITO CAIXA MOEDA";
                                ger.Cred_g = valor.ToString().Replace(".", "");
                                ger.Deb_g = "0,00";
                                ger.Forn = "0,00";
                                ger.Func = "0,00";
                                ger.Total = vgDAO.Vg.Valor;
                                gerDAO.Inserir(ger);

                                
                            }
                            #endregion

                            #region SUBTRAINDO NO CAIXA NORMAL
                            if (vcxDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            else
                            {
                                string zero1 = "0.00";
                                vcxDAO.Inserir(zero1);
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            #endregion

                            vcxDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            cd.Cred_db = "0,00";
                            cd.Desc_db = "Saída p/ caixa moeda";
                            cd.Deb_db = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcxDAO.Vc.Valor;
                            cdDAO.Inserir(cd);

                            #endregion

                            #region SOMANDO NO CAIXA DE MOEDA
                            cxm.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cxmDAO.Update(cxm);
                            #endregion

                            cxmDAO.Verificavalor();
                            #region INSERINDO NA TABELA ENTRADA_DEV
                            if (txt5Centavos.Text == string.Empty)
                            {
                                ed.Moeda_5 = 0;
                            }
                            else
                            {
                                ed.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                ed.Moeda_10 = 0;
                            }
                            else
                            {
                                ed.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                ed.Moeda_25 = 0;
                            }
                            else
                            {
                                ed.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                ed.Moeda_50 = 0;
                            }
                            else
                            {
                                ed.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                ed.Moeda_1 = 0;
                            }
                            else
                            {
                                ed.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }
                            ed.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            ed.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            ed.Desc_ed = "Entrada moeda caixa";
                            ed.Entrada_ed = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            ed.Saida_ed = "0,00";
                            ed.Responsa_ed = UsuarioDAO.login;
                            ed.Total = cxmDAO.Vcm.Valor;
                            edDAO.Inserir(ed);
                            #endregion

                            #region SANGRIA
                            san.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                            san.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            sanDAO.Inserir(san);

                            var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                         where frm is InicialCaixa
                                         select frm;

                            if (qrForm != null && qrForm.Count() > 0)
                            {
                                ((InicialCaixa)qrForm.First()).Atualizadados();
                            }
                            #endregion

                            Limpar();

                            
                        }

                    }
                    else
                    {
                        if (chkBaixo.Checked == true)
                        {
                            #region INSERINDO ZERO NO CAIXA DE MOEDA
                            string zero = "0.00";
                            cxmDAO.Inserir(zero);
                            #endregion

                            #region SOMANDO NO CAIXA DE MOEDA
                            cxm.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cxmDAO.Update(cxm);
                            #endregion

                            #region SUBTRAINDO DO CAIXA NORMAL
                            if (vcxDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            else
                            {
                                string zero1 = "0.00";
                                vcxDAO.Inserir(zero1);
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }

                            #endregion

                            vcxDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            cd.Desc_db = "Saída p/ caixa moeda";
                            cd.Deb_db = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cd.Cred_db = "0,00";
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcxDAO.Vc.Valor;
                            cdDAO.Inserir(cd);

                            #endregion


                            cxmDAO.Verificavalor();
                            #region INSERINDO NA TABELA ENTRADA_DEV
                            if (txt5Centavos.Text == string.Empty)
                            {
                                ed.Moeda_5 = 0;
                            }
                            else
                            {
                                ed.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                ed.Moeda_10 = 0;
                            }
                            else
                            {
                                ed.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                ed.Moeda_25 = 0;
                            }
                            else
                            {
                                ed.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                ed.Moeda_50 = 0;
                            }
                            else
                            {
                                ed.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                ed.Moeda_1 = 0;
                            }
                            else
                            {
                                ed.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }
                            ed.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            ed.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            ed.Desc_ed = "Entrada moeda caixa";
                            ed.Entrada_ed = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            ed.Saida_ed = "0,00";
                            ed.Responsa_ed = UsuarioDAO.login;
                            ed.Total = cxmDAO.Vcm.Valor;
                            edDAO.Inserir(ed);
                            #endregion

                            Limpar();
                        }
                        else
                        {

                            // FAZ A DO PDV
                            #region INSERINDO ZERO NO CAIXA DE MOEDA
                            string zero = "0.00";
                            cxmDAO.Inserir(zero);
                            #endregion

                            #region SOMANDO NO CAIXA NORMAL
                            if (vcxDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update(valor);
                            }
                            else
                            {
                                string zero1 = "0.00";
                                vcxDAO.Inserir(zero1);
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update(valor);
                            }
                            #endregion

                            vcxDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            cd.Desc_db = "Entrada moeda PDV";
                            cd.Cred_db = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cd.Deb_db = "0,00";
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcxDAO.Vc.Valor;
                            cdDAO.Inserir(cd);

                          

                            #endregion

                            #region SUBTRAINDO NO CAIXA NORMAL
                            if (vcxDAO.Verificavalor() == true)
                            {
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            else
                            {
                                string zero1 = "0.00";
                                vcxDAO.Inserir(zero1);
                                string valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                                vcxDAO.Update2(valor);
                            }
                            #endregion

                            vcxDAO.Verificavalor();
                            #region CREDITO DEBITO
                            cd.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            cd.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            cd.Cred_db = "0,00";
                            cd.Desc_db = "Saída p/ caixa moeda";
                            cd.Deb_db = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cd.Responsa_db = UsuarioDAO.login;
                            cd.Total = vcxDAO.Vc.Valor;
                            cdDAO.Inserir(cd);

                            #endregion

                            #region SOMANDO NO CAIXA DE MOEDA
                            cxm.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            cxmDAO.Update(cxm);
                            #endregion

                            cxmDAO.Verificavalor();
                            #region INSERINDO NA TABELA ENTRADA_DEV
                            if (txt5Centavos.Text == string.Empty)
                            {
                                ed.Moeda_5 = 0;
                              
                            }
                            else
                            {
                                ed.Moeda_5 = Convert.ToInt32(txt5Centavos.Text);
                            }

                            if (txt10Centavos.Text == string.Empty)
                            {
                                ed.Moeda_10 = 0;
                            }
                            else
                            {
                                ed.Moeda_10 = Convert.ToInt32(txt10Centavos.Text);
                            }
                            if (txt25Centavos.Text == string.Empty)
                            {
                                ed.Moeda_25 = 0;
                            }
                            else
                            {
                                ed.Moeda_25 = Convert.ToInt32(txt25Centavos.Text);
                            }
                            if (txt50Centavos.Text == string.Empty)
                            {
                                ed.Moeda_50 = 0;
                            }
                            else
                            {
                                ed.Moeda_50 = Convert.ToInt32(txt50Centavos.Text);
                            }

                            if (txt1Real.Text == string.Empty)
                            {
                                ed.Moeda_1 = 0;
                            }
                            else
                            {
                                ed.Moeda_1 = Convert.ToInt32(txt1Real.Text);
                            }
                            ed.Data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            ed.Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                            ed.Desc_ed = "Entrada moeda caixa";
                            ed.Entrada_ed = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            ed.Saida_ed = "0,00";
                            ed.Responsa_ed = UsuarioDAO.login;
                            ed.Total = cxmDAO.Vcm.Valor;
                            edDAO.Inserir(ed);


                           
                            #endregion

                            #region SANGRIA
                            san.Id_caixa = Convert.ToInt32(DinheiroDAO.codcaixa);
                            san.Valor = (total5c + total10c + total25c + total50c + total1r).ToString().Replace(".", "");
                            sanDAO.Inserir(san);

                            var qrForm = from frm in Application.OpenForms.Cast<Form>()
                                         where frm is InicialCaixa
                                         select frm;

                            if (qrForm != null && qrForm.Count() > 0)
                            {
                                ((InicialCaixa)qrForm.First()).Atualizadados();
                            }
                            #endregion

                            Limpar();
                        }


                    }

                }
            }
            catch
            {
                MessageBox.Show("Favor verificar as informações digitadas !!!");
            }
        }

        private void frmEntradaMoeda_Load(object sender, EventArgs e)
        {
            Calcular();
        }

        public void Calcular()
        {
            total5c = (qtd1 * 0.05);
            lbl5c.Text = "= " + total5c.ToString("C2");

            total10c = (qtd2 * 0.1);
            lbl10c.Text = "= " + total10c.ToString("C2");

            total25c = (qtd3 * 0.25);
            lbl25c.Text = "= " + total25c.ToString("C2");

            total50c = (qtd4 * 0.5);
            lbl50c.Text = "= " + total50c.ToString("C2");

            total1r = (qtd5 * 1);
            lbl1r.Text = "= " + total1r.ToString("C2");

            totalmoeda = total5c + total10c + total25c + total50c + total1r;
            lblMoeda.Text = "= " + totalmoeda.ToString("C2");

        }

        private void txt5Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt5Centavos.Text != string.Empty)
            {
                qtd1 = Convert.ToInt32(txt5Centavos.Text);
                Calcular();
            }
            else
            {
                qtd1 = 0;
                Calcular();
            }
        }

        private void txt10Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt10Centavos.Text != string.Empty)
            {
                qtd2 = Convert.ToInt32(txt10Centavos.Text);
                Calcular();
            }
            else
            {
                qtd2 = 0;
                Calcular();
            }
        }

        private void txt25Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt25Centavos.Text != string.Empty)
            {
                qtd3 = Convert.ToInt32(txt25Centavos.Text);
                Calcular();
            }
            else
            {
                qtd3 = 0;
                Calcular();
            }
        }

        private void txt50Centavos_TextChanged(object sender, EventArgs e)
        {
            if (txt50Centavos.Text != string.Empty)
            {
                qtd4 = Convert.ToInt32(txt50Centavos.Text);
                Calcular();
            }
            else
            {
                qtd4 = 0;
                Calcular();
            }
        }

        private void txt1Real_TextChanged(object sender, EventArgs e)
        {
            if (txt1Real.Text != string.Empty)
            {
                qtd5 = Convert.ToInt32(txt1Real.Text);
                Calcular();
            }
            else
            {
                qtd5 = 0;
                Calcular();
            }
        }

        private void txt5Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt10Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt25Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt50Centavos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt1Real_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;

            }
        }

        private void txt5Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt10Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt25Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt50Centavos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txt1Real_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void frmEntradaMoeda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void chkPDV_CheckedChanged(object sender, EventArgs e)
        {
            #region VERIFICA CHECK
            if (chkPDV.Checked == true)
            {
                chkBaixo.Enabled = false;
                txt1Real.Enabled = true;
                txt5Centavos.Enabled = true;
                txt10Centavos.Enabled = true;
                txt25Centavos.Enabled = true;
                txt50Centavos.Enabled = true;
                btnAdicionar.Enabled = true;

                this.ProcessTabKey(true);

            }
            else
            {
                chkBaixo.Enabled = true;
                txt1Real.Enabled = false;
                txt5Centavos.Enabled = false;
                txt10Centavos.Enabled = false;
                txt25Centavos.Enabled = false;
                txt50Centavos.Enabled = false;
                btnAdicionar.Enabled = false;
            }
            #endregion
        }

        private void chkBaixo_CheckedChanged(object sender, EventArgs e)
        {
            #region VERIFICA CHECK
            if (chkBaixo.Checked == true)
            {
                chkPDV.Enabled = false;
                txt1Real.Enabled = true;
                txt5Centavos.Enabled = true;
                txt10Centavos.Enabled = true;
                txt25Centavos.Enabled = true;
                txt50Centavos.Enabled = true;
                btnAdicionar.Enabled = true;

                this.ProcessTabKey(true);
            }
            else
            {
                chkPDV.Enabled = true;
                txt1Real.Enabled = false;
                txt5Centavos.Enabled = false;
                txt10Centavos.Enabled = false;
                txt25Centavos.Enabled = false;
                txt50Centavos.Enabled = false;
                btnAdicionar.Enabled = false;
            }
            #endregion
        }
    }
}
