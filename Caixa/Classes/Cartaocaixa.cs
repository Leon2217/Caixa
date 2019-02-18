namespace Caixa
{
    class Cartaocaixa
    {
        int id_caixa, id_cartao, id_maquina;
        string valor;

        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public int Id_cartao { get => id_cartao; set => id_cartao = value; }
        public int Id_maquina { get => id_maquina; set => id_maquina = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
