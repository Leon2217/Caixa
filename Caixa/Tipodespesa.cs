using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Tipodespesa
    {
        int id_tipodespesa;
        string nome;

        public int Id_tipodespesa { get => id_tipodespesa; set => id_tipodespesa = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
