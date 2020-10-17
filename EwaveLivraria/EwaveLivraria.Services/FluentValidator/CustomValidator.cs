using FluentValidation;

namespace EwaveLivraria.Services.FluentValidator
{
    public static class CustomValidator
    {
        public static IRuleBuilderOptions<T, string> IsCnpj<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CnpjValidator());
        }

        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator());
        }

        public static IRuleBuilderOptions<T, string> IsPhone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new PhoneValidator());
        }

        public static IRuleBuilderOptions<T, string> IsZipCode<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new ZipCodeValidator());
        }
    }
}
