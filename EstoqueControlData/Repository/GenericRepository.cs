using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using EstoqueControlBusiness.Repository;
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;

namespace EstoqueControlData.Repository
{
    public abstract class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : _BaseModel, new()
    {

        private readonly EstoqueControlDbContext _context;
        private readonly DbSet<Entity> _dbSet;

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
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
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