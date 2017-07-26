using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ
{
    class Fornecedor
    {
        public Fornecedor(string nome,Int64 cnpj,string end,Int64 cep, Int64 telefone,string email, Int64 ie)
        {
            Nome = nome;
            CNPJ = cnpj;
            Endereco = end;
            CEP = cep;
            Telefone = telefone;
            Email = email;
            IE = ie;
        }
        public string Nome { get; set; }
        public Int64 CNPJ { get; set; }
        public string Endereco { get; set; }
        public Int64 CEP { get; set; }
        public Int64 Telefone { get; set; }
        public string Email { get; set; }
        public Int64 IE { get; set; }
    }
}
