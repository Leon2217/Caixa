using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Sangria
    {
        int id_sangria, id_caixa;
        string  valor;

        public int Id_sangria { get => id_sangria; set => id_sangria = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
