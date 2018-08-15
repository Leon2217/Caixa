using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Entradamoeda
    {
        int id_em;
        int moeda_1, moeda_50, moeda_25, moeda_10, moeda_5;
        DateTime data, hora;
        string valor, responsavel;

        public int Id_em { get => id_em; set => id_em = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public int Moeda_1 { get => moeda_1; set => moeda_1 = value; }
        public int Moeda_50 { get => moeda_50; set => moeda_50 = value; }
        public int Moeda_25 { get => moeda_25; set => moeda_25 = value; }
        public int Moeda_10 { get => moeda_10; set => moeda_10 = value; }
        public int Moeda_5 { get => moeda_5; set => moeda_5 = value; }
    }
}
