namespace Caixa
{
    class Diferenca
    {
        int id_diferenca, id_caixa;
        string manha, tarde;

        public int Id_diferenca { get => id_diferenca; set => id_diferenca = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public string Manha { get => manha; set => manha = value; }
        public string Tarde { get => tarde; set => tarde = value; }
    }
}
