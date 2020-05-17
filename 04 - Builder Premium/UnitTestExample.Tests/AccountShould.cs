using System;
using System.Linq;
using FluentAssertions;
using UnitTestExample.Core;
using Xunit;

namespace UnitTestExample.Tests
{
    public class AccountShould
    {

        public AccountBuilder CreateValidSut() => new AccountBuilder().For(new Client(DateTime.Now.AddYears(-20)));
        public AccountBuilder CreateInValidSut() => new AccountBuilder().For(new Client(DateTime.Now.AddYears(10)));

        public AccountBuilder WithEnoughMoney(AccountBuilder builder) => builder.Standard().With(1500);
        public AccountBuilder WithNoEnoughMoney(AccountBuilder builder) => builder.Standard().With(150);




        [Fact]
        public void Not_create_Invalid_Standard_Account()
        {
            //TODO: 02 - Creo un cliente standard invalido
            Action act = () => CreateInValidSut().Standard().With(100).Build();

            //TODO: 04 - Valido la exception personalizada
            act.Should().Throw<StandardClientDoesNotHaveEnoughInitialAmount>();
        }
        [Fact]
        public void Not_create_Invalid_Premium_Account()
        {
            //TODO: 02 - Creo un cliente standard invalido
            Action act = () => CreateInValidSut().Standard().With(100).Build();

            //TODO: 04 - Valido la exception personalizada
            act.Should().Throw<StandardClientDoesNotHaveEnoughInitialAmount>();
        }


        [Fact]
        public void Not_Accept_Invalid_Client()
        {
            Action act = () => CreateInValidSut().Standard().With(10000).Build();

            act.Should().Throw<ArgumentException>()
                .WithMessage("client"); ;
        }

        [Fact]
        public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        {
            var sut = WithEnoughMoney(CreateValidSut()).Build();

            Action act = () => sut.Transfer(2000, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                .WithMessage("amount");
        }

        private Client _validClient = new Client(DateTime.Now.AddYears(-20));
        [Fact]
        public void Not_Transfer_Money_Client_Is_Not_Valid()
        {
            //TODO: 08 - Utilización de builder especifico
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
            var sut = WithEnoughMoney(CreateValidSut()).With(currentAmount).Build();

            sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

            sut.Amount.Should().Be(currentAmount - 45);
        }

        [Fact]
        public void Create_New_Transactions()
        {
            var sut = WithEnoughMoney(CreateValidSut()).Build();

            sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

            var transaction = sut.Transactions.First();

            sut.Transactions.Count.Should().Be(1);

            transaction.Amount.Should().Be(45);
            transaction.Type.Should().Be(TransactionsType.Transfer);
            //transaction.Date.Should().Be(DateTime.Now); // ?
        }
    }

}