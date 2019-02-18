using System;

namespace Caixa
{
    class EntradaDev
    {
        int id_ed, moeda_1, moeda_50, moeda_25, moeda_10, moeda_5;
        DateTime data, hora;
        string desc_ed, responsa_ed,entrada_ed, saida_ed, total;

        public int Id_ed { get => id_ed; set => id_ed = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public string Desc_ed { get => desc_ed; set => desc_ed = value; }
        public string Responsa_ed { get => responsa_ed; set => responsa_ed = value; }      
        public string Entrada_ed { get => entrada_ed; set => entrada_ed = value; }
        public string Saida_ed { get => saida_ed; set => saida_ed = value; }
        public string Total { get => total; set => total = value; }
        public int Moeda_1 { get => moeda_1; set => moeda_1 = value; }
        public int Moeda_50 { get => moeda_50; set => moeda_50 = value; }
        public int Moeda_25 { get => moeda_25; set => moeda_25 = value; }
        public int Moeda_10 { get => moeda_10; set => moeda_10 = value; }
        public int Moeda_5 { get => moeda_5; set => moeda_5 = value; }
    }
}
