using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;

namespace EstoqueControlData.Repository
{
    public class CategoriaRepository :  GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EstoqueControlDbContext context) : base(context) { }

        public async Task<Categoria> ObterCategoriaProdutosPorId(Guid categoriaId)
        {
            return await _context.Categorias.AsNoTracking()
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == categoriaId) ?? new Categoria();
        }
    }
}