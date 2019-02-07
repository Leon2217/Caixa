using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Recarga
    {
        int id_recarga, id_caixa, id_operadora;
        string valor_rec, descricao;
        string n_telefone, total;
        string operadora;
        DateTime hora, data;

        public int Id_recarga { get => id_recarga; set => id_recarga = value; }
        public int Id_caixa { get => id_caixa; set => id_caixa = value; }
        public int Id_operadora { get => id_operadora; set => id_operadora = value; }
        public string Valor_rec { get => Valor_rec1; set => Valor_rec1 = value; }
        public string N_telefone { get => n_telefone; set => n_telefone = value; }
        public string Operadora { get => operadora; set => operadora = value; }
        public string Valor_rec1 { get => valor_rec; set => valor_rec = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Total { get => total; set => total = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
