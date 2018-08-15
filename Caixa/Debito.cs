using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Debito
    {
        int id_credito;
        string desc_debito, responsavel, valor;
        DateTime data, hora;

        public int Id_credito { get => id_credito; set => id_credito = value; }
        public string Desc_debito { get => desc_debito; set => desc_debito = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public string Valor { get => valor; set => valor = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
    }
}
