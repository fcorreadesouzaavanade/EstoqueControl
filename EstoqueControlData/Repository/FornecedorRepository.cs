using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;

namespace EstoqueControlData.Repository
{
    public class FornecedorRepository :  GenericRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(EstoqueControlDbContext context) : base(context) { }
    }
}