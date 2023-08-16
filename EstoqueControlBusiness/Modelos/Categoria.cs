using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlBusiness.Modelos
{
    public class Categoria : BaseModel
    {
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }   
    }
}