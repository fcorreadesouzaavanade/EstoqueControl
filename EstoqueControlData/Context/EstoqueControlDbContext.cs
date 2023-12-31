using System.Linq.Expressions;
using EstoqueControlBusiness.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EstoqueControlData.Context
{
    public class EstoqueControlDbContext : DbContext
    {
        public EstoqueControlDbContext(DbContextOptions<EstoqueControlDbContext> options) : base(options) { }
        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set;}
        public DbSet<Produto> Produtos{ get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstoqueControlDbContext).Assembly);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;  
        }

        public async Task<bool> CommitAsync()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataRegistro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            
                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                    entry.Property("DataRegistro").IsModified = false;
                }
            }
            
            return await base.SaveChangesAsync() > 0;
        }
    }
}