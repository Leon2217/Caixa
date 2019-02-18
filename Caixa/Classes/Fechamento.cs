using System;

namespace Caixa
{
    class Fechamento
    {
        int id_caixa, id_turno;
        string status, responsavel, valor;
        DateTime data, datafinal, hrinicio, hrfinal;
      
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public int Id_turno { get => id_turno; set => id_turno = value; }
        public string Status { get => status; set => status = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Datafinal { get => datafinal; set => datafinal = value; }
        public DateTime Hrinicio { get => hrinicio; set => hrinicio = value; }
        public DateTime Hrfinal { get => hrfinal; set => hrfinal = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
