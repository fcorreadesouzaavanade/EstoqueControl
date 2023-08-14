using AutoMapper;
using EstoqueControlApp.DTO;
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
        public async Task<IEnumerable<CategoriaDTO>> ObterTodasCategorias()
        {
            return  _mapper.Map<IEnumerable<CategoriaDTO>>(await _categoriaService.ObterTodasCategorias());
        }

        [HttpGet("{categoriaId:Guid}")]
        public async Task<ActionResult<CategoriaDTO>> ObterCategoriaPorId(Guid categoriaId)
        {
            var categoria = await _categoriaService.ObterCategoriaPorId(categoriaId);
            if(categoria is null) return NotFound();
            return ResultadoCustomizado(_mapper.Map<CategoriaDTO>(categoria));
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> AdicionarCategoria(CategoriaDTO categoriaDTO)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            await _categoriaService.AdicionarCategoria(_mapper.Map<Categoria>(categoriaDTO));
            return ResultadoCustomizado(categoriaDTO);
        }

        [HttpPut("{categoriaId:Guid}")]
        public async Task<ActionResult<CategoriaDTO>> AtualizarCategoria(Guid categoriaId, CategoriaDTO categoriaDTO)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            if(categoriaId != categoriaDTO.Id) return BadRequest();
            if(_categoriaService.ObterCategoriaPorId(categoriaId).Result is null) return NotFound();

            await _categoriaService.AtualizarCategoria(_mapper.Map<Categoria>(categoriaDTO));
            return ResultadoCustomizado(categoriaDTO);
        }

        [HttpDelete("{categoriaId:Guid}")]
        public async Task<ActionResult<CategoriaDTO>> ExcluirCategoria(Guid categoriaId)
        {
            var categoria = await _categoriaService.ObterCategoriaPorId(categoriaId);
            if(categoria is null) return NotFound();

            await _categoriaService.ExcluirCategoria(categoriaId);
            return ResultadoCustomizado(_mapper.Map<CategoriaDTO>(categoria));
        }
    }
}