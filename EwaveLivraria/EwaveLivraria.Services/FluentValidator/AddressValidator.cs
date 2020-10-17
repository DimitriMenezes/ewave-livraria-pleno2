using EwaveLivraria.Services.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EwaveLivraria.Services.FluentValidator
{
    public class AddressValidator : AbstractValidator<AddressRequest>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street)
               .NotEmpty().WithMessage("Informe o Endereço");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Informe a Cidade");
            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("Informe o Bairro");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Informe o Número");
            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("Informe o Estado")
                .Must((a, b) => a.State.Length == 2
                    && a.State.All(Char.IsLetter))
                .WithMessage("Estado deve conter duas letras");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Informe o CEP")
                .IsZipCode();
        }
    }
}
