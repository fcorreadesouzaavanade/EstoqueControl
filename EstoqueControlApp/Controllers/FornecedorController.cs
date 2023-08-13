using Microsoft.AspNetCore.Mvc;

namespace EstoqueControlApp.Controllers
{

    [Route("[controller]")]
    public class FornecedorController : RootController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Lista dos Fornecedores");
        }
    }

}
