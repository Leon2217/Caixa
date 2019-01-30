using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa
{
    class Pessoa
    {
        int id_pessoa, id_tp, n_casa;
        string nome;
        string cpfnj, im, ie, fornecimento, rs, cep, bairro, uf, rua, cidade, cel, tel, email;
        string tipo, obs, fisjur;

        public int Id_pessoa { get => id_pessoa; set => id_pessoa = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Id_tp { get => id_tp; set => id_tp = value; }
        public string Cpfnj { get => cpfnj; set => cpfnj = value; }
        public string Im { get => im; set => im = value; }
        public string Ie { get => ie; set => ie = value; }
        public string Fornecimento { get => fornecimento; set => fornecimento = value; }
        public string Rs { get => rs; set => rs = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Cel { get => cel; set => cel = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Email { get => email; set => email = value; }
        public string Obs { get => obs; set => obs = value; }
        public int N_casa { get => n_casa; set => n_casa = value; }
        public string Fisjur { get => fisjur; set => fisjur = value; }
    }
}
