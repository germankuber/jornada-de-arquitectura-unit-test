using Castle.Core.Logging;
using UnitTestExample.Core;

namespace UnitTestExample.Tests
{
    //TODO: 06 -Implmento Builder especificos. 
    public class StandardAccountValidBuilder : IAccountWithBuilder, IAccountForBuilder
    {
        private readonly AccountBuilder _builder;

        private StandardAccountValidBuilder()
        {
            _builder = new AccountBuilder().Standard();
        }

        public static IAccountForBuilder Make() => new StandardAccountValidBuilder();
        public Account With(decimal amount) =>
            _builder.With(amount).Build();

        public IAccountWithBuilder For(Client client)
        {
            _builder.For(client);
            return this;
        }
    }

    //TODO: 07 - Version Premium del builder
    public interface IAccountForBuilder
    {
        IAccountWithBuilder For(Client client);
    }
    public interface IAccountWithBuilder
    {
        Account With(decimal amount);
    }
    public interface IAccountTypeBuilder
    {
        IAccountForBuilder Type(AccountType type);
    }

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