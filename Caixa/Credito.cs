using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Credito
    {
        int id_credito;
        string desc_credito, responsavel;
        string valor;
        DateTime data, hora;

        public int Id_credito { get => id_credito; set => id_credito = value; }
        public string Desc_credito { get => desc_credito; set => desc_credito = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
      
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
