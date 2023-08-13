using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;
using EstoqueControlBusiness.Validations;

namespace EstoqueControlBusiness.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(INotificador notificador, ICategoriaRepository categoriaRepository) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _categoriaRepository.ObterTodosAsync();
        }

        public async Task<Categoria> ObterCategoriaPorId(Guid categoriaId)
        {
            return await _categoriaRepository.ObterPorId(categoriaId);
        }

        public async Task AdicionarCategoria(Categoria categoria)
        {
            if(!Validar(new CategoriaValidator(), categoria)) return;            
            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            if(!Validar(new CategoriaValidator(), categoria)) return;
            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task ExcluirCategoria(Guid categoriaId)
        {
            await _categoriaRepository.Excluir(categoriaId);
        }
    }
}