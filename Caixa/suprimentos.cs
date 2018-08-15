using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class suprimentos
    {
        int id_supri, id_caixa;
        string valor;

        public int Id_supri { get => id_supri; set => id_supri = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
