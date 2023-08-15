using AutoMapper;
using EstoqueControlApp.Dto;
using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueControlApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : RootController
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(
            INotificador notificador, 
            ICategoriaService categoriaService,
            IMapper mapper
        ) : base(notificador)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> ObterTodasCategorias()
        {
            return  _mapper.Map<IEnumerable<CategoriaDto>>(await _categoriaService.ObterTodasCategorias());
        }

        [HttpGet("{categoriaId:Guid}")]
        public async Task<ActionResult<CategoriaDto>> ObterCategoriaPorId(Guid categoriaId)
        {
            var categoria = await _categoriaService.ObterCategoriaPorId(categoriaId);
            if(categoria is null) return NotFound();
            return ResultadoCustomizado(_mapper.Map<CategoriaDto>(categoria));
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> AdicionarCategoria(CategoriaDto categoriaDto)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            await _categoriaService.AdicionarCategoria(_mapper.Map<Categoria>(categoriaDto));
            return ResultadoCustomizado(categoriaDto);
        }

        [HttpPut("{categoriaId:Guid}")]
        public async Task<ActionResult<CategoriaDto>> AtualizarCategoria(Guid categoriaId, CategoriaDto categoriaDto)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            if(categoriaId != categoriaDto.Id) return BadRequest();
            if(_categoriaService.ObterCategoriaPorId(categoriaId).Result is null) return NotFound();

            await _categoriaService.AtualizarCategoria(_mapper.Map<Categoria>(categoriaDto));
            return ResultadoCustomizado(categoriaDto);
        }

        [HttpDelete("{categoriaId:Guid}")]
        public async Task<ActionResult<CategoriaDto>> ExcluirCategoria(Guid categoriaId)
        {
            var categoria = await _categoriaService.ObterCategoriaPorId(categoriaId);
            if(categoria is null) return NotFound();

            await _categoriaService.ExcluirCategoria(categoriaId);
            return ResultadoCustomizado(_mapper.Map<CategoriaDto>(categoria));
        }
    }
}