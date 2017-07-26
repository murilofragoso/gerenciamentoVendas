using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ
{
    class Compra
    {
        public Compra(string fornecedor,string produto, int quantidade, decimal valor, DateTime data)
        {

            Nome_Fornecedor = fornecedor;
            Nome_Produto = produto;
            Quantidade = quantidade;
            Valor_Pago = valor;
            Data = data;

        }

        public string Nome_Fornecedor { get; set; }
        public string Nome_Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_Pago { get; set; }
        public DateTime Data { get; set; }


        public string ValorEditado => $"{Valor_Pago:N}";
    }
}
