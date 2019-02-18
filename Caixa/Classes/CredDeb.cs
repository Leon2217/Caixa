using System;

namespace Caixa
{
    class CredDeb
    {
        int id_cd;
        DateTime data, hora;
        string desc_db, responsa_db, cred_db, deb_db, total;
        char? c;

        public int Id_cd { get => id_cd; set => id_cd = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Desc_db { get => desc_db; set => desc_db = value; }
        public string Responsa_db { get => responsa_db; set => responsa_db = value; }
        public string Cred_db { get => cred_db; set => cred_db = value; }
        public string Deb_db { get => deb_db; set => deb_db = value; }
        public string Total { get => total; set => total = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public char? C { get => c; set => c = value; }
    }
}
