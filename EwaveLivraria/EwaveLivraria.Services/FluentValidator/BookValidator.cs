using EwaveLivraria.Services.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.FluentValidator
{
    public class BookValidator : AbstractValidator<BookRequest>
    {     
        public BookValidator()
        {
            RuleFor(x => x.CoverUrl)
               .NotEmpty().WithMessage("Informe a URL da Capa");
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("Informe o Título");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Informe o Author");
            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("Informe o Genero");
            RuleFor(x => x.Isbn)
                .NotEmpty()
                .WithMessage("Informe o ISBN")
                .Must(i => i.Length == 13)
                .WithMessage("ISBN deve conter 13 caracteres");
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("O estoque deve ser maior que 0");
        }
    }
}
