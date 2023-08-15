using AutoMapper;
using EstoqueControlApp.Dto;
using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueControlApp.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : RootController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutoController(
            INotificador notificador, 
            IProdutoService produtoService, 
            IMapper mapper
        ) : base(notificador)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDto>> ObterTodosProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoService.ObterTodosProdutos());
        }

        [HttpGet("categoria/{categoriaId:Guid}")]
        public async Task<IEnumerable<ProdutoDto>> ObterTodosProdutosPorCategoria(Guid categoriaId)
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoService.ObterTodosProdutosPorCategoria(categoriaId));
        }

        [HttpGet("{produtoId:Guid}")]
        public async Task<ActionResult<ProdutoDto>> ObterProdutoPorId(Guid produtoId)
        {
            var produto = await _produtoService.ObterProdutoPorId(produtoId);
            if(produto is null) return NotFound();
            return ResultadoCustomizado(_mapper.Map<ProdutoDto>(produto));
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> AdicionarProduto(ProdutoDto produtoDto)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            await _produtoService.AdicionarProduto(_mapper.Map<Produto>(produtoDto));
            return ResultadoCustomizado(produtoDto);
        }

        [HttpPut("{produtoId:Guid}")]
        public async Task<ActionResult<ProdutoDto>> AtualizarProduto(Guid produtoId, ProdutoDto produtoDto)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            if(produtoId != produtoDto.Id) return BadRequest();
            if(_produtoService.ObterProdutoPorId(produtoId).Result is null) return NotFound();

            await _produtoService.AtualizarProduto(_mapper.Map<Produto>(produtoDto));
            return ResultadoCustomizado(produtoDto);
        }

        [HttpDelete("{produtoId:Guid}")]
        public async Task<ActionResult<ProdutoDto>> ExcluirProduto(Guid produtoId)
        {
            var produto = await _produtoService.ObterProdutoPorId(produtoId);
            if(produto is null) return NotFound();

            await _produtoService.ExcluirProduto(produtoId);            
            return ResultadoCustomizado(_mapper.Map<ProdutoDto>(produto));
        }
    }
}