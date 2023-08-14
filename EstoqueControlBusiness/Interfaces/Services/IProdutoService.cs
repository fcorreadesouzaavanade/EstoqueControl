using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlBusiness.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterTodosProdutos();
        Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(Guid categoriaId);
        Task<Produto> ObterProdutoPorId(Guid produtoId);
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task ExcluirProduto(Guid produtoId);
    }
}