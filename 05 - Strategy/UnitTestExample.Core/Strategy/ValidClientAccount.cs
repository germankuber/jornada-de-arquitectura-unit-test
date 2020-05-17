using UnitTestExample.Core.Builder;

namespace UnitTestExample.Core.Strategy
{
    public class ValidClientAccount : ValidateAccountCreation
    {
        public ValidClientAccount(IValidateAccountCreation next) : base(next)
        {
        }

        public override ValidationResult Validate(AccountValidation data)
        {
            if (!data.Client.IsValid())
                return new ValidationResult("client");
            return CallNext(data);
        }
    }
}