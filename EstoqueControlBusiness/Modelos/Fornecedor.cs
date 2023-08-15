using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlBusiness.Modelos
{
    public class Fornecedor : BaseModel
    {
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Guid EnderecoId { get; set; }

         public IEnumerable<Produto> Produtos { get; set; }
         public Endereco Endereco{ get; set; }
    }
}