using System;

namespace Caixa
{
    class Relattx
    {
        int id_relattx, id_caixa, id_cartao, id_maquina;
        DateTime data;
        string valor, taxa, valor_ct;

        public int Id_relattx { get => id_relattx; set => id_relattx = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public int Id_cartao { get => id_cartao; set => id_cartao = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Taxa { get => taxa; set => taxa = value; }
        public string Valor_ct { get => valor_ct; set => valor_ct = value; }
        public int Id_maquina { get => id_maquina; set => id_maquina = value; }
    }
}
