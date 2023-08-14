using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;
using EstoqueControlBusiness.Validations;

namespace EstoqueControlBusiness.Services
{
    
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedores()
        {
            return await _fornecedorRepository.ObterFornecedoresEnderecos();
        }

        public async Task<Fornecedor> ObterFornecedorPorId(Guid fornecedorId)
        {
            return await _fornecedorRepository.ObterFornecedorEnderecoProdutos(fornecedorId);
        }

        public async Task AdicionarFornecedor(Fornecedor fornecedor)
        {
            if(!Validar(new FornecedorValidator(), fornecedor)) return;
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            if(!Validar(new FornecedorValidator(), fornecedor)) return;
            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task ExcluirFonecedor(Guid fornecedorId)
        {
            await _fornecedorRepository.Excluir(fornecedorId);
        }
    }
}