using UnitTestExample.Core.Builder;


namespace UnitTestExample.Core.Strategy
{
    //TODO : 07 - Creo una abstracción para la validaciones de creación
    public interface IValidateAccountCreation
    {
        ValidationResult Validate(AccountValidation data);
    }
}