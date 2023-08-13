using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
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
            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task ExcluirCategoria(Guid categoriaId)
        {
            await _categoriaRepository.Excluir(categoriaId);
        }
    }
}