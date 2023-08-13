using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;

namespace EstoqueControlData.Repository
{
    public class ProdutoRepository :  GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstoqueControlDbContext context) : base(context) { }
    }
}