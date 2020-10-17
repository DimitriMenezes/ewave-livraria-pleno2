using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EwaveLivraria.Services.FluentValidator
{
    public class PhoneValidator : PropertyValidator
    {
        public PhoneValidator() : base("Telefone Inválido")
        {

        }

        public bool IsPhoneValid(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            if (!phone.All(char.IsDigit))
                return false;

            return phone.Length >= 10 && phone.Length <= 13;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var phone = context.PropertyValue as string;
            return IsPhoneValid(phone);
        }
    }
}
