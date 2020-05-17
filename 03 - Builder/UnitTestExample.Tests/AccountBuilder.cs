using UnitTestExample.Core;

namespace UnitTestExample.Tests
{
    //TODO: 03 - Implemento Un Account Builder
    public class AccountBuilder
    {
        private Client _client;
        private decimal _amount;
        private AccountType _type;

        public AccountBuilder Standard()
        {
            _type = AccountType.Standard;
            return this;
        }
        public AccountBuilder Premium()
        {
            _type = AccountType.Premium;
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
        public Account Build() => new Account(_client, _amount, _type);
    }
}