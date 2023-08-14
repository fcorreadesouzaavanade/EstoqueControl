using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Interfaces.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<Fornecedor>> ObterTodosFornecedores ();
        Task<Fornecedor> ObterFornecedorPorId(Guid fornecedorId);
        Task AdicionarFornecedor(Fornecedor fornecedor);        
        Task AtualizarFornecedor(Fornecedor fornecedor);
        Task ExcluirFonecedor (Guid fornecedorId);
    }
}