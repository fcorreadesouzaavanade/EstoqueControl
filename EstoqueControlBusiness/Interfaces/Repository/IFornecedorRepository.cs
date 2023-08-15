using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Interfaces.Repository
{
    public interface IFornecedorRepository : IGenericRepository<Fornecedor> 
    {
        Task<IEnumerable<Fornecedor>> ObterFornecedoresEnderecos();
        Task<Fornecedor> ObterFornecedorEnderecoProdutos(Guid fornecedorId);
     }
}