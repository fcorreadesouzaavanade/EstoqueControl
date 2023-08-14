using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;

namespace EstoqueControlData.Repository
{
    public class FornecedorRepository :  GenericRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(EstoqueControlDbContext context) : base(context) { }

        public async Task<IEnumerable<Fornecedor>> ObterFornecedoresEnderecos()
        {
            return await _context.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco).ToListAsync();
        }

        public async Task<Fornecedor> ObterFornecedorEnderecoProdutos(Guid fornecedorId)
        {
            return await _context.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }
    }
}