using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlApp.DTO
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataRemocao { get; set; }

        public IEnumerable<ProdutoDTO> Produtos { get; set; }   
    }
}