using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using FluentValidation;

namespace EstoqueControlBusiness.Validations
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.Rua)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Numero)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(1, 5)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Complemento)
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Bairro)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Cidade)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.UF)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2)
            .WithMessage("{PropertyName} deve ter {Length} Caracteres");

            RuleFor(e => e.CEP)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(8)
            .WithMessage("{PropertyName} deve ter {Length} Caracteres");

        }
        
    }
}