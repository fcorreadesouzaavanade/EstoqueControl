using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Services
{
    public class ProdutoService : BaseService, IProdutoService 
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
           return await  _produtoRepository.ObterTodosAsync();
        }
        public async Task<Produto> ObterProdutoPorId(Guid produtoId)
        {
            return await _produtoRepository.ObterPorId(produtoId);
        }
        public async Task AdicionarProduto(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }
        public async Task AtualizarProduto(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        public async Task ExcluirProduto(Guid produtoId)
        {
            await _produtoRepository.Excluir(produtoId);
        }
    }
}