using System;

namespace Caixa
{
    class Contas3
    {
        int id_contas, id_pessoa;
        string valor, nf, status;
        string valor2, valor3, valor4;
        DateTime data_em, data2, data3;
        DateTime data;

        public int Id_contas { get => id_contas; set => id_contas = value; }
        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Nf { get => nf; set => nf = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Status { get => status; set => status = value; }
        public string Valor2 { get => valor2; set => valor2 = value; }
        public string Valor3 { get => valor3; set => valor3 = value; }
        public DateTime Data_em { get => data_em; set => data_em = value; }
        public DateTime Data2 { get => data2; set => data2 = value; }
        public DateTime Data3 { get => data3; set => data3 = value; }
        public string Valor4 { get => valor4; set => valor4 = value; }
    }
}
