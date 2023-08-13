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
        where Entity : _BaseModel
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
        public async Task<Entity?> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task Insert(Entity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(Entity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            var entity = await ObterPorId(id);
            if(entity is null) return;
            
            entity.DataRemocao = DateTime.Now;
            await SaveChanges();            
        }
        public async Task<bool> SaveChanges()
        {
            return await _context.CommitAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}