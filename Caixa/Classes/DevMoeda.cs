using System;

namespace Caixa
{
    class DevMoeda
    {
        int id_em;
        string valor, responsavel;
        DateTime data, hora;

        public int Id_em { get => id_em; set => id_em = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime Hora { get => hora; set => hora = value; }
    }
}
