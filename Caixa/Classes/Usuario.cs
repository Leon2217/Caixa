namespace Caixa
{
    class Usuario
    {
        int id_usu;
        string login_usu, senha_usu, tipo, status;

        public int Id_usu { get => id_usu; set => id_usu = value; }
        public string Login_usu { get => login_usu; set => login_usu = value; }
        public string Senha_usu { get => senha_usu; set => senha_usu = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Status { get => status; set => status = value; }
    }
}
