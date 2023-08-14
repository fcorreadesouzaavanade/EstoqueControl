
using EstoqueControlBusiness.Interfaces.Notificador;
using EstoqueControlBusiness.Modelos;
using EstoqueControlBusiness.Notificador;
using FluentValidation;
using FluentValidation.Results;

namespace EstoqueControlBusiness.Services
{
    public class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.TratarNotificacao(new Notificacao(mensagem));
        }

        protected void Notificar(ValidationResult result)
        {
            foreach(var erro in result.Errors)
                Notificar(erro.ErrorMessage);
        }

        protected bool EstaValido()
        {
            return !_notificador.TemNotifiicacoes();
        }

        protected bool Validar<TValidador, TEntidade>(TValidador validador, TEntidade entidade)
            where TValidador : AbstractValidator<TEntidade>
            where TEntidade : _BaseModel
        {
            var resultado = validador.Validate(entidade);
            if(resultado.IsValid) return true;

            Notificar(resultado);
            return false;
        }
    }
}