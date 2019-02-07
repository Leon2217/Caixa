using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Endereco
    {
        int id_end, id_pessoa, n_casa;
        string cep, bairro, uf, rua, cidade, tipo;
        string complemento;

        public int Id_end { get => id_end; set => id_end = value; }
        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public int N_casa { get => n_casa; set => n_casa = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Complemento { get => complemento; set => complemento = value; }
    }
}
