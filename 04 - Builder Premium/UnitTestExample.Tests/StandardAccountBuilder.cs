using UnitTestExample.Core;

namespace UnitTestExample.Tests
{
    //TODO: 06 -Implmento Builder especificos. 
    public class StandardAccountBuilder : IAccountWithBuilder, IAccountForBuilder
    {
        private readonly AccountBuilder _builder;

        private StandardAccountBuilder()
        {
            _builder = new AccountBuilder().Standard();
        }

        public static IAccountForBuilder Make() => new StandardAccountBuilder();

        public Account With(decimal amount) =>
            _builder.With(amount)
                    .Build();

        public IAccountWithBuilder For(Client client)
        {
            _builder.For(client);
            return this;
        }
    }
}