using EwaveLivraria.Services.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.FluentValidator
{
    public class AdministratorValidator : AbstractValidator<AdministratorRequest>
    {
        public AdministratorValidator()
        {
            RuleFor(i => i.Email)
                .NotEmpty()
                .WithMessage("Informe o Email")
                .EmailAddress()
                .WithMessage("Email Inválido");
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Informe o Nome");
            RuleFor(i => i.Password)
                .NotEmpty()
                .WithMessage("Informe a Senha.");
            RuleFor(i => i.Cpf)
              .NotEmpty()
              .WithMessage("Informe o CPF.")
              .IsCpf();
        }
    }
}
