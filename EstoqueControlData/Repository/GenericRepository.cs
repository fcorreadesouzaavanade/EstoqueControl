using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;

namespace EstoqueControlData.Repository
{
    public abstract class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : BaseModel, new()
    {

        protected readonly EstoqueControlDbContext _context;
        protected readonly DbSet<Entity> _dbSet;

        protected GenericRepository(EstoqueControlDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public async Task<IEnumerable<Entity>> ObterTodosAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<Entity> ObterPorId(Guid id)
        {
            return await _dbSet.AsNoTracking().Where(e => e.Id == id).FirstAsync();
        }
        public async Task Adicionar(Entity entity)
        {
            _dbSet.Add(entity);
            await SalvarAlteracoes();
        }

        public async Task Atualizar(Entity entity)
        {
            _dbSet.Update(entity);
            await SalvarAlteracoes();
        }
        public async Task Excluir(Guid id)
        {
            _dbSet.Remove(new Entity() { Id = id });
            await SalvarAlteracoes();            
        }
        public async Task<bool> SalvarAlteracoes()
        {
            return await _context.CommitAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}