using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Pessoa
    {
        int id_pessoa, id_tp;
        string nome;
        string tipo;

        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Id_tp { get => id_tp; set => id_tp = value; }
    }
}
