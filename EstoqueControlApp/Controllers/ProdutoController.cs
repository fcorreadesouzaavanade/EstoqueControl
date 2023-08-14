using AutoMapper;
using EstoqueControlApp.DTO;
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
        public async Task<IEnumerable<ProdutoDTO>> ObterProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoService.ObterTodosProdutos());
        }

        [HttpGet("categoria/{categoriaId:Guid}")]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodosProdutosPorCategoria(Guid categoriaId)
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoService.ObterTodosProdutosPorCategoria(categoriaId));
        }

        [HttpGet("{produtoId:Guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterProdutoId(Guid produtoId)
        {
            var produto = await _produtoService.ObterProdutoPorId(produtoId);
            if(produto is null) return NotFound();
            return ResultadoCustomizado(_mapper.Map<ProdutoDTO>(produto));
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> AdicionarProduto(ProdutoDTO produtoDTO)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            await _produtoService.AdicionarProduto(_mapper.Map<Produto>(produtoDTO));
            return ResultadoCustomizado(produtoDTO);
        }

        [HttpPut("{produtoId:Guid}")]
        public async Task<ActionResult<ProdutoDTO>> AtualizarProduto(Guid produtoId, ProdutoDTO produtoDTO)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            if(produtoId != produtoDTO.Id) return BadRequest();
            if(_produtoService.ObterProdutoPorId(produtoId).Result is null) return NotFound();

            await _produtoService.AtualizarProduto(_mapper.Map<Produto>(produtoDTO));
            return ResultadoCustomizado(produtoDTO);
        }

        [HttpDelete("{produtoId:Guid}")]
        public async Task<ActionResult<ProdutoDTO>> ExcluirProduto(Guid produtoId)
        {
            var produto = await _produtoService.ObterProdutoPorId(produtoId);
            if(produto is null) return NotFound();

            await _produtoService.ExcluirProduto(produtoId);            
            return ResultadoCustomizado(_mapper.Map<ProdutoDTO>(produto));
        }
    }
}