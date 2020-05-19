using UnitTestExample.Core.Builder;


namespace UnitTestExample.Core.Strategy
{
    //TODO: 08 - Creo una abstracción para la validaciones de creación
    public interface IValidateAccountCreation
    {
        ValidationResult Validate(AccountValidation data);
    }
}