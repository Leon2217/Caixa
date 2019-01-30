using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Auditoria
    {
        int id_aud;
        string acao, responsavel;
        DateTime hora, data;

        public int Id_aud { get => id_aud; set => id_aud = value; }
        public string Acao { get => acao; set => acao = value; }
        public string Responsavel { get => responsavel; set => responsavel = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
