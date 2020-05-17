using System.Collections.Generic;
using System.Linq;
using UnitTestExample.Core.Exceptions;
using UnitTestExample.Core.Strategy;

namespace UnitTestExample.Core.Builder
{
    public class AccountBuilder
    {
        //TODO: 03 - Implementamos un builder
        private readonly IValidateAccountCreation _createValidationStrategy;
        private Client _client;
        private decimal _amount;
        private AccountType _type;
        private AccountBuilder(IValidateAccountCreation createValidationStrategy)
        {
            _createValidationStrategy = createValidationStrategy;
        }

        //TODO: 04 - Recibo una cadena de validaciones para la creación de la cuenta
        public static AccountBuilder Make(IValidateAccountCreation createValidationStrategy) => new AccountBuilder(createValidationStrategy);

        public AccountBuilder Type(AccountType type)
        {
            _type = type;
            return this;
        }

        public AccountBuilder For(Client client)
        {
            _client = client;
            return this;
        }

        public AccountBuilder With(decimal amount)
        {
            _amount = amount;
            return this;
        }

        public Account Build()
        {
            //TODO: 05 - Valido antes de crear la instancia de Account
            var validate = _createValidationStrategy.Validate(new AccountValidation(_client, _amount, _type));

            if (validate.Valid)
                return new Account(_client, _amount, _type);

            throw new InvalidAccountException(validate.Error);
        }
    }
}