namespace Caixa
{
    class Contato
    {
        int id_contato, id_pessoa;
        string nome, email, telefone, dep;

        public int Id_contato { get => id_contato; set => id_contato = value; }
        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Dep { get => dep; set => dep = value; }
    }
}
