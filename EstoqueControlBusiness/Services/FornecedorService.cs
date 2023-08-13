using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Services
{
    
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
        {
            return await _fornecedorRepository.ObterTodosAsync();
        }

        public async Task<Fornecedor> ObterFornecedorPorId(Guid fornecedorId)
        {
            return await _fornecedorRepository.ObterPorId(fornecedorId);
        }

        public async Task AdicionarFornecedor(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task ExcluirFonecedor(Guid fornecedorId)
        {
            await _fornecedorRepository.Excluir(fornecedorId);
        }
    }
}