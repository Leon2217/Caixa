using System;

namespace Caixa
{
    class Despesa
    {
        int id_despesa;
        string descr, valor, status;
        DateTime data;
        Nullable<int> id_pessoa = null;
        Nullable<int> id_tipodespesa = null;

        int n;

        public int Id_despesa { get => id_despesa; set => id_despesa = value; }   
        public string Descr { get => descr; set => descr = value; }
        public string Valor { get => valor; set => valor = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Status { get => status; set => status = value; }
        public int? Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public int? Id_tipodespesa { get => id_tipodespesa; set => id_tipodespesa = value; }
        public int N { get => n; set => n = value; }
    }
}
