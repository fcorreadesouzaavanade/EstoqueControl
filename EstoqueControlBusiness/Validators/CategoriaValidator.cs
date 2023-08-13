using EstoqueControlBusiness.Modelos;
using FluentValidation;

namespace EstoqueControlBusiness.Validations
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(a => a.Nome)
            .NotEmpty()
            .WithMessage("O Nome da Categoria é Obrigatório")
            .Length(2,80)
            .WithMessage("O Nome deve ter entre {MinLength} and {MaxLength} catacteres");
        }
    }
}