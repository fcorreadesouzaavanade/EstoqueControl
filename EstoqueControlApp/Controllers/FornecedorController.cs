using AutoMapper;
using EstoqueControlApp.Dto;
using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Interfaces.Services;
using EstoqueControlBusiness.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueControlApp.Controllers
{

    [Route("api/[controller]")]
    public class FornecedorController : RootController
    {
        
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;
        public FornecedorController(
            INotificador notificador, 
            IFornecedorService fornecedorService, 
            IMapper mapper
        ) : base(notificador)
        {
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorDto>> ObterTodosFornecedores()
        {
            return _mapper.Map<IEnumerable<FornecedorDto>>(await _fornecedorService.ObterTodosFornecedores());
        }

        [HttpGet("{fornecedorId:Guid}")]
        public async Task<ActionResult<FornecedorDto>> ObterFornecedorPorId(Guid fornecedorId)
        {
            var fornecedor = await _fornecedorService.ObterFornecedorPorId(fornecedorId);
            if(fornecedor is null) return NotFound();
            return ResultadoCustomizado(_mapper.Map<FornecedorDto>(fornecedor));
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDto>> AdicionarFornecedor(FornecedorDto fornecedorDto)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            await _fornecedorService.AdicionarFornecedor(_mapper.Map<Fornecedor>(fornecedorDto));
            return ResultadoCustomizado(fornecedorDto);
        }

        [HttpPut("{fornecedorId:Guid}")]
        public async Task<ActionResult<FornecedorDto>> AtualizarFornecedor(Guid fornecedorId, FornecedorDto fornecedorDto)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            if(fornecedorId != fornecedorDto.Id) return BadRequest();
            if(_fornecedorService.ObterFornecedorPorId(fornecedorId).Result is null) return NotFound();

            await _fornecedorService.AtualizarFornecedor(_mapper.Map<Fornecedor>(fornecedorDto));
            return ResultadoCustomizado(fornecedorDto);
        }

        [HttpDelete("{fornecedorId:Guid}")]
        public async Task<ActionResult<FornecedorDto>> ExcluirFonecedor(Guid fornecedorId)
        {
            var categoria = await _fornecedorService.ObterFornecedorPorId(fornecedorId);
            if(categoria is null) return NotFound();

            await _fornecedorService.ExcluirFonecedor(fornecedorId);
            return ResultadoCustomizado(_mapper.Map<FornecedorDto>(categoria));
        }
    }

}
