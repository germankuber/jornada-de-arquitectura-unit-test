using UnitTestExample.Core;

namespace UnitTestExample.Tests.Builder
{
    public class StandardAccountValidBuilder : IAccountWithBuilder, IAccountForBuilder
    {
        private readonly AccountTestBuilder _builder;

        private StandardAccountValidBuilder()
        {
            _builder = new AccountTestBuilder().Standard();
        }

        public static IAccountForBuilder Make() => new StandardAccountValidBuilder();
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