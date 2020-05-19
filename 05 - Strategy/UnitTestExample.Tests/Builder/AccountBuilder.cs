using UnitTestExample.Core;
using UnitTestExample.Core.Builder;
using UnitTestExample.Core.Strategy;

namespace UnitTestExample.Tests.Builder
{
    public class AccountTestBuilder
    {
        private Client _client;
        private decimal _amount;
        private AccountType _type;

        public AccountTestBuilder Standard()
        {
            _type = AccountType.Standard;
            return this;
        }
        public AccountTestBuilder Premium()
        {
            _type = AccountType.Premium;
            return this;
        }

        public AccountTestBuilder For(Client client)
        {
            _client = client;
            return this;
        }

        public AccountTestBuilder With(decimal amount)
        {
            _amount = amount;
            return this;
        }
        //TODO: 07 -  Utilizo el builder para construir mi instancia de Account
        public Account Build() => AccountBuilder
            .Make(new StandardAccount(new PremiumAccount(new ValidClientAccount(null))))
            .Type(_type)
            .For(_client)
            .With(_amount)
            .Build();
    }
}