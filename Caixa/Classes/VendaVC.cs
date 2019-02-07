using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class VendaVC
    {
        int id_vc, qtd_vc, qtd_estoque, total_vendas, id_caixa;
        string valor_vc, total_vc, descr;
        DateTime data, hora;

        public int Id_vc { get => id_vc; set => id_vc = value; }
        public int Qtd_vc { get => qtd_vc; set => qtd_vc = value; }
        public int Qtd_estoque { get => qtd_estoque; set => qtd_estoque = value; }
        public int Total_vendas { get => total_vendas; set => total_vendas = value; }
        public string Valor_vc { get => valor_vc; set => valor_vc = value; }
        public string Total_vc { get => total_vc; set => total_vc = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public string Descr { get => descr; set => descr = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
    }
}
