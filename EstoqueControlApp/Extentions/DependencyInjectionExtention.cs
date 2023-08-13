using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Notificador;
using EstoqueControlBusiness.Services;
using EstoqueControlData.Repository;

namespace EstoqueControlApp.Extentions
{
    public static class DependencyInjectionExtention
    {
        public static IServiceCollection InjetarDependencias(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}