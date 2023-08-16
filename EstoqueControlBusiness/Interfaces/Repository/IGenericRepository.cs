using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Interfaces.Repository
{
    public interface IGenericRepository<Entity> 
        : IDisposable where Entity : BaseModel
    {
        Task<IEnumerable<Entity>> ObterTodosAsync();
        Task<Entity> ObterPorId(Guid id);
        Task Adicionar(Entity entity);
        Task Atualizar(Entity entity);
        Task Excluir(Guid id);
        Task<bool> SalvarAlteracoes();
        
    }
}