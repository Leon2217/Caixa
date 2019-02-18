using System;
using System.Windows.Forms;

namespace Caixa
{
    static class Program
    {       
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Conexao.criar_Conexao();
            UsuarioDAO usuDAO = new UsuarioDAO();
            if (usuDAO.VerificaExiste()==true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                UsuarioDAO.Existe = true;
                Application.Run(new Login());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                UsuarioDAO.Existe = false;
                Application.Run(new frmCadusu());
            }     
        }
    }
}
