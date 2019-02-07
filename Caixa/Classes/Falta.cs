using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Falta
    {
        int id_falta, id_pessoa;
        DateTime data;
        string periodo;

        public DateTime Data { get => data; set => data = value; }
        public string Periodo { get => periodo; set => periodo = value; }
        public int Id_falta { get => id_falta; set => id_falta = value; }
        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
    }
}
