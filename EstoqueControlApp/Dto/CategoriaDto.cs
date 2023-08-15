using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlApp.Dto
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<ProdutoDto> Produtos { get; set; }   
    }
}