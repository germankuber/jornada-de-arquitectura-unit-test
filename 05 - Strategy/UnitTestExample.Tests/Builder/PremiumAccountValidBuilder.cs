using UnitTestExample.Core;

namespace UnitTestExample.Tests.Builder
{
    public class PremiumAccountValidBuilder : IAccountWithBuilder, IAccountForBuilder
    {
        private readonly AccountTestBuilder _builder;

        private PremiumAccountValidBuilder()
        {
            _builder = new AccountTestBuilder().Premium();
        }

        public static IAccountForBuilder Make() => new PremiumAccountValidBuilder();
        public Account With(decimal amount) =>
            _builder.With(amount).Build();

        public IAccountWithBuilder For(Client client)
        {
            _builder.For(client);
            return this;
        }
    }
}