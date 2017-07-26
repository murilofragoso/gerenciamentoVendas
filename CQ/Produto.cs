using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ
{
    class Produto
    {
        public Produto(string nome, decimal valorpadrao,int estoque)
        {
            Nome = nome;
            ValorPadrao = valorpadrao;
            Estoque = estoque;
        }

        public string Nome { get; set; }
        public decimal ValorPadrao { get; set; }
        public int Estoque { get; set; }

        public string ValorEditado => $"{ValorPadrao:N}";

    }
}
