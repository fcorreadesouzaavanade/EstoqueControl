using AutoMapper;
using EstoqueControlApp.DTO;
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
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public FornecedorController(
            INotificador notificador, 
            IFornecedorService fornecedorService, 
            IEnderecoRepository enderecoRepository,
            IMapper mapper
        ) : base(notificador)
        {
            _fornecedorService = fornecedorService;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorDTO>> ObterFornecedores()
        {
            return _mapper.Map<IEnumerable<FornecedorDTO>>(await _fornecedorService.ObterFornecedores());
        }

        [HttpGet("{fornecedorId:Guid}")]
        public async Task<ActionResult<FornecedorDTO>> ObterFornecedorId(Guid fornecedorId)
        {
            var fornecedor = await _fornecedorService.ObterFornecedorPorId(fornecedorId);
            if(fornecedor is null) return NotFound();
            return ResultadoCustomizado(_mapper.Map<FornecedorDTO>(fornecedor));
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDTO>> AdicionarCategoria(FornecedorDTO fornecedorDTO)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            await _fornecedorService.AdicionarFornecedor(_mapper.Map<Fornecedor>(fornecedorDTO));
            return ResultadoCustomizado(fornecedorDTO);
        }

        [HttpPut("{fornecedorId:Guid}")]
        public async Task<ActionResult<FornecedorDTO>> AtualizarCategoria(Guid fornecedorId, FornecedorDTO fornecedorDTO)
        {
            if(!ModelState.IsValid) return ResultadoCustomizado(ModelState);
            if(fornecedorId != fornecedorDTO.Id) return BadRequest();
            if(_fornecedorService.ObterFornecedorPorId(fornecedorId).Result is null) return NotFound();

            await _fornecedorService.AtualizarFornecedor(_mapper.Map<Fornecedor>(fornecedorDTO));
            return ResultadoCustomizado(fornecedorDTO);
        }

        [HttpDelete("{fornecedorId:Guid}")]
        public async Task<ActionResult<FornecedorDTO>> ExcluirCategoria(Guid fornecedorId)
        {
            var categoria = await _fornecedorService.ObterFornecedorPorId(fornecedorId);
            if(categoria is null) return NotFound();

            await _fornecedorService.ExcluirFonecedor(fornecedorId);
            return ResultadoCustomizado(_mapper.Map<FornecedorDTO>(categoria));
        }
    }

}
