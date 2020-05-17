using UnitTestExample.Core.Builder;

namespace UnitTestExample.Core.Strategy
{
    public class StandardAccount : ValidateAccountCreation
    {

        public StandardAccount(IValidateAccountCreation next) : base(next)
        {
        }

        public override ValidationResult Validate(AccountValidation data)
        {
            if (data.Type == AccountType.Standard && data.InitialAmount < 1000)
                return new ValidationResult("initialAmount");
            return CallNext(data);
        }
    }
}