using FluentAssertions;
using UnitTestExample.Core;
using UnitTestExample.Core.Builder;
using UnitTestExample.Core.Strategy;
using Xunit;

namespace UnitTestExample.Tests
{
    public class PremiumAccountStrategyShould
    {
        //TODO: 08 - Testeo cada una de las estrategias
        [Fact]
        public void Be_Invalid()
        {
            var sut = new PremiumAccount(null);

            var result = sut.Validate(new AccountValidation(null, 200, AccountType.Premium));

            result.Valid.Should().Be(false);
        }

        [Fact]
        public void Be_Valid()
        {
            var sut = new PremiumAccount(null);

            var result = sut.Validate(new AccountValidation(null, 20000, AccountType.Premium));

            result.Valid.Should().Be(true);
        }
    }
}