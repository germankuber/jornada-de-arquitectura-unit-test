using UnitTestExample.Core.Builder;


namespace UnitTestExample.Core.Strategy
{
    public interface IValidateAccountCreation
    {
        ValidationResult Validate(AccountValidation data);
    }
}