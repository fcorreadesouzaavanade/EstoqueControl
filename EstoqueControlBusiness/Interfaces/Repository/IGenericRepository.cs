using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Repository
{
    public interface IGenericRepository<Entity> : IDisposable where Entity : _BaseModel
    {
        Task<IEnumerable<Entity>> ObterTodosAsync();
        Task<Entity?> ObterPorId(Guid id);
        Task Insert(Entity entity);        
        Task Update(Entity entity);
        Task Delete(Guid id);
        Task<bool> SaveChanges();
    }
}