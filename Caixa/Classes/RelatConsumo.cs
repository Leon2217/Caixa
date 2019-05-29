using System;

namespace Caixa.Classes
{
    class RelatConsumo
    {
        int id_fiado, id_pessoa;
        string valor, descr;
        DateTime data;

        public int Id_fiado { get => id_fiado; set => id_fiado = value; }
        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Descr { get => descr; set => descr = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
