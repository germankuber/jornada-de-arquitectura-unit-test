using UnitTestExample.Core;

namespace UnitTestExample.Tests.Builder
{
    public interface IAccountTypeBuilder
    {
        IAccountForBuilder Type(AccountType type);
    }
}