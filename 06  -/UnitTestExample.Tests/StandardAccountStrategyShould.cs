using FluentAssertions;
using UnitTestExample.Core;
using UnitTestExample.Core.Builder;
using UnitTestExample.Core.Strategy;
using Xunit;

namespace UnitTestExample.Tests
{
    public class StandardAccountStrategyShould
    {

        [Fact]
        public void Be_Invalid()
        {
            var sut = new StandardAccount(null);

            var result = sut.Validate(new AccountValidation(null, 10, AccountType.Standard));

            result.Valid.Should().Be(false);
        }

        [Fact]
        public void Be_Valid()
        {
            var sut = new StandardAccount(null);

            var result = sut.Validate(new AccountValidation(null, 20000, AccountType.Standard));

            result.Valid.Should().Be(true);
        }
    }
}