using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using EstoqueControlBusiness.Repository;

namespace EstoqueControlBusiness.Interfaces.Repository
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<Categoria> ObterCategoriaProdutosPorId(Guid categoriaId);
    }
}