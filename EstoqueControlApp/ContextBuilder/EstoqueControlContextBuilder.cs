
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstoqueControlApp.ContextBuilder
{
    public class EstoqueControlContextBuilder : IDesignTimeDbContextFactory<EstoqueControlDbContext>
    {
        public EstoqueControlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EstoqueControlDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("EstoqueControlConnectString"));

            return new EstoqueControlDbContext(builder.Options);

        }
    }
}