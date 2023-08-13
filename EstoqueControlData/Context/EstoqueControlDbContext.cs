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

        override protected void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EstoqueControlDbContext).Assembly);

            foreach(var entity in builder.Model.GetEntityTypes())
            {
                var possuiCampoDataRemocao = entity.FindProperty("DataRemocao");
                if(possuiCampoDataRemocao != null && possuiCampoDataRemocao.ClrType == typeof(DateTime))
                {
                    var param = Expression.Parameter(entity.ClrType, "e");
                    var filtro = Expression.Lambda(Expression.NotEqual(param, Expression.Constant(null, typeof(object))), param);
                    entity.SetQueryFilter(filtro);
                }
            }
            
            

            foreach(var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
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
            
                if(entry.State == EntityState.Modified && !entry.Property("DataRemocao").IsModified)                
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;                
            }
            
            return await base.SaveChangesAsync() > 0;
        }
    }
}