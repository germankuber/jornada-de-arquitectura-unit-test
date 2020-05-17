using UnitTestExample.Core.Builder;

namespace UnitTestExample.Core.Strategy
{
    public class PremiumAccount : ValidateAccountCreation
    {
        public PremiumAccount(IValidateAccountCreation next) : base(next)
        {
        }

        public override ValidationResult Validate(AccountValidation data)
        {
            if (data.Type == AccountType.Premium && data.InitialAmount < 5000)
                return new ValidationResult("initialAmount");
            return CallNext(data);
        }
    }
}