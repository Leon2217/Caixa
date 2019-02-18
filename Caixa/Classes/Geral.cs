using System;

namespace Caixa
{
    class Geral
    {
        int id_g;
        string desc_g, cred_g, deb_g, total, forn, func;
        DateTime data;

        public int Id_g { get => id_g; set => id_g = value; }
        public string Desc_g { get => desc_g; set => desc_g = value; }
        public string Cred_g { get => cred_g; set => cred_g = value; }
        public string Deb_g { get => deb_g; set => deb_g = value; }
        public string Total { get => total; set => total = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Func { get => func; set => func = value; }
        public string Forn { get => forn; set => forn = value; }
    }
}
