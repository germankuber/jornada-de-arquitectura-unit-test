using System;
using System.Linq;
using FluentAssertions;
using UnitTestExample.Core;
using Xunit;

namespace UnitTestExample.Tests
{
    public class AccountShould
    {
        ////TODO : 02 - Modifico mi Factory
        ////Varios test dependen de ese valor inicial aunque no lo sabiamos.
        //public Account CreateSut() =>
        //    new Account(new Client(DateTime.Now.AddYears(-20)), 1500, AccountType.Standard);

        //[Fact]
        //public void Not_Accept_Invalid_Client()
        //{
        //    Action act = () => new Account(new Client(DateTime.Now.AddYears(-10)), 100, AccountType.Standard);

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("client"); ;
        //}

        //[Fact]
        //public void Not_Accept_Zero_Amount()
        //{
        //    Action act = () => new Account(new Client(DateTime.Now.AddYears(-20)), 0, AccountType.Standard);

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("initialAmount"); ;
        //}

        //[Fact]
        //public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        //{
        //    var sut = CreateSut();

        //    Action act = () => sut.Transfer(450, new Client(DateTime.Now));

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("amount");
        //}

        //[Fact]
        //public void Not_Transfer_Money_Client_Is_Not_Valid()
        //{
        //    var sut = CreateSut();

        //    Action act = () => sut.Transfer(10, new Client(DateTime.Now));

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("client");
        //}

        //[Fact]
        //public void Transfer_Money_Reduce_Money_From_Current_Account()
        //{
        //    var sut = CreateSut();

        //    sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

        //    sut.Amount.Should().Be(150 - 45);
        //}

        //[Fact]
        //public void Create_New_Transactions()
        //{
        //    var sut = CreateSut();

        //    sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

        //    var transaction = sut.Transactions.First();

        //    sut.Transactions.Count.Should().Be(1);

        //    transaction.Amount.Should().Be(45);
        //    transaction.Type.Should().Be(TransactionsType.Transfer);
        //    //transaction.Date.Should().Be(DateTime.Now); // ?
        //}


        ////TODO : 04 - Creto Diferentes alternativas de Sut Factory
        public AccountBuilder CreateValidSut() => new AccountBuilder().For(new Client(DateTime.Now.AddYears(-20)));
        public AccountBuilder CreateInValidSut() => new AccountBuilder().For(new Client(DateTime.Now.AddYears(10)));

        public AccountBuilder WithEnoughMoney(AccountBuilder builder) => builder.Standard().With(1500);
        public AccountBuilder WithNoEnoughMoney(AccountBuilder builder) => builder.Standard().With(150);
        [Fact]
        public void Not_Accept_Invalid_Client()
        {
            //TODO: 05 - Utilizo el Sut Factory
            Action act = () => CreateInValidSut().Standard().With(10000).Build();

            act.Should().Throw<ArgumentException>()
                .WithMessage("client"); ;
        }

        [Fact]
        public void Not_Accept_Zero_Amount()
        {
            Action act = () => WithNoEnoughMoney(CreateValidSut()).Build();

            act.Should().Throw<ArgumentException>()
                .WithMessage("initialAmount"); ;
        }

        [Fact]
        public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        {
            //TODO: 05 - Me permite componer diferentes funciones que construyan mi SUT
            var sut = WithEnoughMoney(CreateValidSut()).Build();

            Action act = () => sut.Transfer(2000, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                .WithMessage("amount");
        }

        [Fact]
        public void Not_Transfer_Money_Client_Is_Not_Valid()
        {
            var sut = WithEnoughMoney(CreateValidSut()).Build();

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
            //TODO : 06 - Puedo personalizar mi sut si el test me lo demanda
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