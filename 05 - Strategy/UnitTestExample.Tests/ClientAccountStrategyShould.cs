using System;
using FluentAssertions;
using UnitTestExample.Core;
using UnitTestExample.Core.Builder;
using UnitTestExample.Core.Strategy;
using Xunit;

namespace UnitTestExample.Tests
{
    public class ClientAccountStrategyShould
    {

        [Fact]
        public void Be_Invalid()
        {
            var sut = new ValidClientAccount(null);

            var result = sut.Validate(new AccountValidation(new Client(DateTime.Now.AddYears(-10)), 10, AccountType.Standard));

            result.Valid.Should().Be(false);
        }

        [Fact]
        public void Be_Valid()
        {
            var sut = new ValidClientAccount(null);

            var result = sut.Validate(new AccountValidation(new Client(DateTime.Now.AddYears(-25)), 20000, AccountType.Standard));

            result.Valid.Should().Be(true);
        }
    }
}