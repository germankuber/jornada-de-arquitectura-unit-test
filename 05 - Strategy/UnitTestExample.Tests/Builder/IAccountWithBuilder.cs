using UnitTestExample.Core;

namespace UnitTestExample.Tests.Builder
{
    public interface IAccountWithBuilder
    {
        Account With(decimal amount);
    }
}