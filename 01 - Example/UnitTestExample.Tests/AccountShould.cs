using System;
using System.Linq;
using FluentAssertions;
using UnitTestExample.Core;
using Xunit;

namespace UnitTestExample.Tests
{
    public class AccountShould
    {
        [Fact]
        public void Not_Accept_Invalid_Client()
        {
            Action act = () => new Account(new Client(DateTime.Now.AddYears(-10)), 100);

            act.Should().Throw<ArgumentException>()
                .WithMessage("client"); ;
        }

        [Fact]
        public void Not_Accept_Zero_Amount()
        {
            Action act = () => new Account(new Client(DateTime.Now.AddYears(-20)), 0);

            act.Should().Throw<ArgumentException>()
                .WithMessage("initialAmount"); ;
        }

        [Fact]
        public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        {
            var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 150);

            Action act = () => sut.Transfer(450, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                .WithMessage("amount");
        }

        [Fact]
        public void Not_Transfer_Money_Client_Is_Not_Valid()
        {
            var sut = new Account(new Client(DateTime.Now.AddYears(-19)), 1500);

            Action act = () => sut.Transfer(450, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                .WithMessage("client");
        }

        [Fact]
        public void Transfer_Money_Reduce_Money_From_Current_Account()
        {
            var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 1500);

            sut.Transfer(450, new Client(DateTime.Now.AddYears(-19)));

            sut.Amount.Should().Be(1500 - 450);
        }

        [Fact]
        public void Create_New_Transactions()
        {
            var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 1500);

            sut.Transfer(450, new Client(DateTime.Now.AddYears(-19)));

            var transaction = sut.Transactions.First();

            sut.Transactions.Count.Should().Be(1);

            transaction.Amount.Should().Be(450);
            transaction.Type.Should().Be(TransactionsType.Transfer);
            //transaction.Date.Should().Be(DateTime.Now); // ?

        }
    }
}