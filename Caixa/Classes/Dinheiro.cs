using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Dinheiro
    {
        int id_qtd, id_caixa, nota_100, nota_50, nota_20, nota_10, nota_5, nota_2, moeda_1, moeda_50, moeda_25, moeda_10, moeda_5;
        string total;
        public int Id_qtd { get => id_qtd; set => id_qtd = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public int Nota_100 { get => nota_100; set => nota_100 = value; }
        public int Nota_50 { get => nota_50; set => nota_50 = value; }
        public int Nota_20 { get => nota_20; set => nota_20 = value; }
        public int Nota_10 { get => nota_10; set => nota_10 = value; }
        public int Nota_5 { get => nota_5; set => nota_5 = value; }
        public int Nota_2 { get => nota_2; set => nota_2 = value; }
        public int Moeda_1 { get => moeda_1; set => moeda_1 = value; }
        public int Moeda_50 { get => moeda_50; set => moeda_50 = value; }
        public int Moeda_25 { get => moeda_25; set => moeda_25 = value; }
        public int Moeda_10 { get => moeda_10; set => moeda_10 = value; }
        public int Moeda_5 { get => moeda_5; set => moeda_5 = value; }
        public string Total { get => total; set => total = value; }
    }
}
