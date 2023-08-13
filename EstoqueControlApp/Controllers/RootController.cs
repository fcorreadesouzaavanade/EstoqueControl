using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Notificador;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EstoqueControlApp.Controllers
{
    [ApiController]
    public abstract class RootController : ControllerBase
    {
        protected INotificador _notificador;

        public RootController(INotificador notificador)
        {
            _notificador = notificador;
        }
        
        protected bool EstaValido()
        {
            return !_notificador.TemNotifiicacoes();
        }

        public IEnumerable<Notificacao> ObtemNotificacoes()
        {
            return _notificador.ObterNotificacoes();
        }

        protected ActionResult ResultadoCustomizado(ModelStateDictionary modelstate)
        {
            if(!modelstate.IsValid)
                foreach(var erro in modelstate.Values.SelectMany(m => m.Errors))
                {
                    var mensagemErro = erro.Exception is null ?  erro.ErrorMessage : erro.Exception.Message;
                    _notificador.TratarNotificacao(new Notificacao(mensagemErro));
                }
            return ResultadoCustomizado();
        }

        protected ActionResult ResultadoCustomizado(object dataReturn = null)
        {
            if (EstaValido())
                return Ok(new
                {
                    success = true,
                    data = dataReturn
                });

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes()
            });
        }
    }
}