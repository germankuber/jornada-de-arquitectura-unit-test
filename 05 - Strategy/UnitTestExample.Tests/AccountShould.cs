using System;
using System.Linq;
using FluentAssertions;
using UnitTestExample.Core;
using UnitTestExample.Core.Exceptions;
using UnitTestExample.Tests.Builder;
using Xunit;

namespace UnitTestExample.Tests
{
    public class AccountShould
    {
        private readonly Client _validClient = new Client(DateTime.Now.AddYears(-20));
        private readonly Client _invalidClient = new Client(DateTime.Now.AddYears(-5));

        public Account WithEnoughMoney(IAccountWithBuilder builder) => builder.With(1500);

        //[Fact]
        //public void Not_create_Invalid_Standard_Account()
        //{
        //    //TODO: 01 - Debemos evitar tener el constructor lleno de validaciones y tener que utilizar assert de constructor
        //    Action act = () => StandardAccountValidBuilder.Make()
        //        .For(_invalidClient)
        //        .With(100);

        //    act.Should().Throw<StandardClientDoesNotHaveEnoughInitialAmount>();
        //}

        //[Fact]
        //public void Not_create_Invalid_Standard_Account()
        //{
        //    Action act = () => StandardAccountValidBuilder.Make()
        //        .For(_invalidClient)
        //        .With(100);

        //    act.Should().Throw<InvalidAccountException>();
        //}
        //[Fact]
        //public void Not_create_Invalid_Premium_Account()
        //{
        //    //TODO: 09 -Puedo retirar todos estos test de aqui
        //    Action act = () => PremiumAccountValidBuilder.Make()
        //                                                 .For(_invalidClient)
        //                                                 .With(100);

        //    act.Should().Throw<InvalidAccountException>();
        //}


        //[Fact]
        //public void Not_Accept_Invalid_Client()
        //{
        //    Action act = () => StandardAccountValidBuilder.Make()
        //                                                  .For(_invalidClient)
        //                                                  .With(10000);

        //    act.Should().Throw<InvalidAccountException>()
        //        .WithMessage("client");
        //}

        [Fact]
        public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        {
            var sut = WithEnoughMoney(StandardAccountValidBuilder.Make().For(_validClient));

            Action act = () => sut.Transfer(2000, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                .WithMessage("amount");
        }

        [Fact]
        public void Not_Transfer_Money_Client_Is_Not_Valid()
        {
            var sut = StandardAccountValidBuilder.Make()
                                                       .For(_validClient)
                                                       .With(1500);

            Action act = () => sut.Transfer(10, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                .WithMessage("client");
        }

        [Theory]
        [InlineData(1800)]
        [InlineData(2800)]
        [InlineData(15800)]
        public void Transfer_Money_Reduce_Money_From_Current_Account(decimal currentAmount)
        {

            var sut = StandardAccountValidBuilder.Make()
                                                       .For(_validClient)
                                                       .With(currentAmount);
            sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

            sut.Amount.Should().Be(currentAmount - 45);
        }

        [Fact]
        public void Create_New_Transactions()
        {
            var sut = WithEnoughMoney(StandardAccountValidBuilder.Make().For(_validClient));

            sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

            var transaction = sut.Transactions.First();

            sut.Transactions.Count.Should().Be(1);

            transaction.Amount.Should().Be(45);
            transaction.Type.Should().Be(TransactionsType.Transfer);
            //transaction.Date.Should().Be(DateTime.Now); // ?
        }
    }

}