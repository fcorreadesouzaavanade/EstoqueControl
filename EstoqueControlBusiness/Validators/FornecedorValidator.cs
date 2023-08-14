using EstoqueControlBusiness.Modelos;
using FluentValidation;

namespace EstoqueControlBusiness.Validations
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {   
        public FornecedorValidator()
        {
            RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Contato)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.CNPJ)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(14)
            .WithMessage("{PropertyName} deve ter entre {Length} Caracteres");

            RuleFor(e => e.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Telefone)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(10, 11)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

        }
        
    }
}