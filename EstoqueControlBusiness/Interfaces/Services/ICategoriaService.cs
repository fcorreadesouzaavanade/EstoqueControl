using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObterCategorias ();
        Task<Categoria> ObterCategoriaPorId(Guid categoriaId);
        Task AdicionarCategoria(Categoria categoria);        
        Task AtualizarCategoria(Categoria categoria);
        Task ExcluirCategoria (Guid categoriaId);
    }
}