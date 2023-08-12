using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlBusiness.Modelos
{
    public class Produto : _BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeEmEstoque { get; set; }        
    }
}