using Ecommerce.Produto.Domain.Interfaces.Dtos;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Produto.Application.Dtos
{
    public class CategoriaDto : ICategoriaDto
    {
        //[Required(ErrorMessage = "O Campo nome é obrigatorio")]
        public string Nome { get; set; } = string.Empty;
        public string Descriao { get; set; } = string.Empty;

        public void Validator()
        {
            //if(string.IsNullOrEmpty(Nome))
            //    throw new Exception("O Campo nome não pode ser vazio");

            //if (Nome.Length < 5)
            //    throw new Exception("O Campo nome deve ter no minimo 5 caracteres");

            //if (Nome.Length < 5 && string.IsNullOrEmpty(Descriao))
            //    throw new Exception("O Campo nome e descricao deve ter no minimo 5 caracteres e algum valor");

            //FluentValidation
            var validateResult = new CategoriaDtoValidation().Validate(this);

            if (!validateResult.IsValid)
            {
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(e => e.ErrorMessage)));
            }
        }
    }


    internal class CategoriaDtoValidation : AbstractValidator<CategoriaDto>
    {
        public CategoriaDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O Campo {nameof(x.Nome)} deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O Campo {nameof(x.Nome)} não pode ser vazio");

            RuleFor(x => x.Descriao)
                .NotEmpty().WithMessage(x => $"O Campo {nameof(x.Descriao)} não pode ser vazio");
        }
    }

}
