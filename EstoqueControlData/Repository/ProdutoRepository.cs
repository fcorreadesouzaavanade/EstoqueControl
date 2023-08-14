using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;

namespace EstoqueControlData.Repository
{
    public class ProdutoRepository :  GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstoqueControlDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(Guid categoriaId)
        {
            return await _context.Produtos.AsNoTracking()
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }
    }
}