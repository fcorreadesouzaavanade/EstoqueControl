using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using EstoqueControlBusiness.Repository;

namespace EstoqueControlBusiness.Interfaces.Repository
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(Guid categoriaId);
    }
}