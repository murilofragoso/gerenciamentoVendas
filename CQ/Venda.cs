using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ
{
    class Venda
    {
        public Venda(string cliente, string produto, int quantidade,decimal desconto, decimal total,DateTime data)
        {
            NomeCliente = cliente;
            NomeProduto = produto;
            Quantidade = quantidade;
            Desconto = desconto;
            Total = total;
            Data = data;
        }
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
        public DateTime Data { get; set; }

        public string DescontoEditado => $"{Desconto:N}";
        public string TotalEditado => $"{Total:N}";
    }
}
