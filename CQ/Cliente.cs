using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQ
{
    class Cliente
    {
        public Cliente(string nome, string endereco,Int64 telefone,Int64 cep, string email,Int64 cnpj, Int64 ie)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            CEP = cep;
            Email = email;
            CNPJ = cnpj;
            IE = ie;
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Int64 Telefone { get; set; }
        public Int64 CEP { get; set; }
        public string Email { get; set; }
        public Int64 CNPJ { get; set; }
        public Int64 IE { get; set; }
    }
}
