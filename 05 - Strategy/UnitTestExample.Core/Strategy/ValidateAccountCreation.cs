using UnitTestExample.Core.Builder;

namespace UnitTestExample.Core.Strategy
{
    public abstract class ValidateAccountCreation : IValidateAccountCreation
    {
        private readonly IValidateAccountCreation _next;

        protected ValidateAccountCreation(IValidateAccountCreation next)
        {
            _next = next;
        }

        public abstract ValidationResult Validate(AccountValidation data);

        protected ValidationResult CallNext(AccountValidation data)
        {
            if (_next == null)
                return new ValidationResult();
            return _next.Validate(data);
        }
    }
}