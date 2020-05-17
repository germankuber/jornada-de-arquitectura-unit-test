using UnitTestExample.Core;

namespace UnitTestExample.Tests.Builder
{
    public interface IAccountForBuilder
    {
        IAccountWithBuilder For(Client client);
    }
}