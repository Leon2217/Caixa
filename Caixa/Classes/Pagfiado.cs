using System;

namespace Caixa.Classes
{
    class Pagfiado
    {
        int id_pag, id_pessoa;
        string valor, forma;
        DateTime data;

        public int Id_pag { get => id_pag; set => id_pag = value; }
        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Forma { get => forma; set => forma = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
