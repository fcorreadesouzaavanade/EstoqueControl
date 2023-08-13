using Microsoft.AspNetCore.Mvc;

namespace EstoqueControlApp.Controllers;

[ApiController]
[Route("[controller]")]
public class InitialController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Tá Funcionando");
    }
}
