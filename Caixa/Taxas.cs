using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Taxas
    {
        int id_cartao;
        string taxa, dias;
   
        public string Taxa { get => taxa; set => taxa = value; }
        public string Dias { get => dias; set => dias = value; }
        public int Id_cartao { get => id_cartao; set => id_cartao = value; }
    }
}
