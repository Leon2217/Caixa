using System;

namespace Caixa.Classes
{
    class VendaSS
    {
        int id_gds, id_caixa, qtd_gds, qtd_estoque, total_vendas;
        string valor_gds, total_gds, descr;
        DateTime data, hora;

        public int Id_gds { get => id_gds; set => id_gds = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public int Qtd_gds { get => qtd_gds; set => qtd_gds = value; }
        public int Qtd_estoque { get => qtd_estoque; set => qtd_estoque = value; }
        public int Total_vendas { get => total_vendas; set => total_vendas = value; }
        public string Valor_gds { get => valor_gds; set => valor_gds = value; }
        public string Total_gds { get => total_gds; set => total_gds = value; }
        public string Descr { get => descr; set => descr = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
    }
}
