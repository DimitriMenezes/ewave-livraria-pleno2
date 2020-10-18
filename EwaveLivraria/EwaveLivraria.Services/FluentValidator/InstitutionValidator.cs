using EwaveLivraria.Services.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.FluentValidator
{
    public class InstitutionValidator : AbstractValidator<InstitutionRequest>
    {
        public InstitutionValidator()
        {          
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Informe o Nome");          
            RuleFor(i => i.Cnpj)
                .NotEmpty()
                .WithMessage("Informe o CNPJ.")
                .IsCnpj();

            new AddressValidator();
        }
    }
}
