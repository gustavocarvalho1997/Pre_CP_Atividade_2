using Ecommerce.Produto.Domain.Interfaces.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Produto.Application.Dtos
{
    public class ProdutoDto : IProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descriao {  get; set; } = string.Empty;
        public int Quantidade { get; set; }

        public void Validator()
        {
            var validateResult = new ProdutoDtoValidation().Validate(this);
            if (!validateResult.IsValid)
            {
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(e => e.ErrorMessage)));
            }
        }

    }

    internal class ProdutoDtoValidation : AbstractValidator<ProdutoDto>
    {
        public ProdutoDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O Campo {nameof(x.Nome)} deve ter no mínimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O Campo {nameof(x.Nome)} não pode ser vazio");

            RuleFor(x => x.Descriao)
                .MinimumLength(10).WithMessage(x => $"O Campo {nameof(x.Descriao)} deve ter no mínimo 10 caracteres")
                .NotEmpty().WithMessage(x => $"O Campo {nameof(x.Descriao)} não pode ser vazio");

            RuleFor(x => x.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage(x => $"O Campo {nameof(x.Quantidade)} não pode ser vazio ou negativo");
        }
    }
}
