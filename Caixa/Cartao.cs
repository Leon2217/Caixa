using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Cartoes
    {
        int id_cartao;
        string cartao, tipo;

        public int Id_cartao { get => id_cartao; set => id_cartao = value; }
        public string Cartao { get => cartao; set => cartao = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
