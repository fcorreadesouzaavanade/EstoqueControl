using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using FluentValidation;

namespace EstoqueControlBusiness.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.Descricao)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório")
            .Length(2, 80)
            .WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} Caracteres");

            RuleFor(e => e.ValorUnitario)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório");
            
            RuleFor(e => e.QuantidadeEmEstoque)
            .NotEmpty()
            .WithMessage("{PropertyName} é Obrigatório");

        }
    }
}