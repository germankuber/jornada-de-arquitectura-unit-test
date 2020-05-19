using UnitTestExample.Core.Builder;


namespace UnitTestExample.Core.Strategy
{
    //TODO: 08 - Creo una abstracci�n para la validaciones de creaci�n
    public interface IValidateAccountCreation
    {
        ValidationResult Validate(AccountValidation data);
    }
}