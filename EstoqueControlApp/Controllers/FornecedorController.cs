using EstoqueControlBusiness.Interfaces.Notificador;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueControlApp.Controllers
{

    [Route("[controller]")]
    public class FornecedorController : RootController
    {
        public FornecedorController(INotificador notificador) : base(notificador) { }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Lista dos Fornecedores");
        }
    }

}
