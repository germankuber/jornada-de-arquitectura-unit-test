using System;
using System.Linq;
using FluentAssertions;
using UnitTestExample.Core;
using Xunit;

namespace UnitTestExample.Tests
{
    public class AccountShould
    {
        //TODO: 02 - Todos mis test Rompen
        // [Fact]
        // public void Not_Accept_Invalid_Client()
        // {
        //    Action act = () => new Account(new Client(DateTime.Now.AddYears(-10)), 100);

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("client");
        // }

        // [Fact]
        // public void Not_Accept_Zero_Amount()
        // {
        //    Action act = () => new Account(new Client(DateTime.Now.AddYears(-20)), 0);

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("initialAmount");
        // }

        // [Fact]
        // public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        // {
        //    var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 150);

        //    Action act = () => sut.Transfer(450, new Client(DateTime.Now));

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("amount");
        // }

        // [Fact]
        // public void Not_Transfer_Money_Client_Is_Not_Valid()
        // {
        //    var sut = new Account(new Client(DateTime.Now.AddYears(-19)), 1500);

        //    Action act = () => sut.Transfer(450, new Client(DateTime.Now));

        //    act.Should().Throw<ArgumentException>()
        //        .WithMessage("client");
        // }

        // [Fact]
        // public void Transfer_Money_Reduce_Money_From_Current_Account()
        // {
        //    var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 1500);

        //    sut.Transfer(450, new Client(DateTime.Now.AddYears(-19)));

        //    sut.Amount.Should().Be(1500 - 450);
        // }

        // [Fact]
        // public void Create_New_Transactions()
        // {
        //    var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 1500);

        //    sut.Transfer(450, new Client(DateTime.Now.AddYears(-19)));

        //    var transaction = sut.Transactions.First();

        //    sut.Transactions.Count.Should().Be(1);

        //    transaction.Amount.Should().Be(450);
        //    transaction.Type.Should().Be(TransactionsType.Transfer);
        //    //transaction.Date.Should().Be(DateTime.Now); // ?
        // }


        // //TODO: 03 - Implemento un Sut Factory
        public Account CreateSut() =>
            new Account(new Client(DateTime.Now.AddYears(-20)), 150, AccountType.Standard);

        [Fact]
        public void Not_Accept_Invalid_Client()
        {
            //TODO: 08 - Los casos excepcionales los dejo fuera del Factory
            Action act = () => new Account(new Client(DateTime.Now.AddYears(-10)), 100, AccountType.Standard);

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("client"); ;
        }


        [Fact]
        public void Not_Accept_Less_Or_Equal_Zero()
        {
            Action act = () => new Account(new Client(DateTime.Now.AddYears(-20)), 1, AccountType.Standard);

            act.Should()
                .NotThrow<ArgumentException>();
        }

        [Fact]
        public void Not_Transfer_Money_Does_Not_Have_Enough_Money()
        {
            //TODO: 04 - Utilizo mi factory
            var sut = CreateSut();

            Action act = () => sut.Transfer(450, new Client(DateTime.Now));

            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("amount");
        }

        [Fact]
        public void Not_Transfer_Money_Client_Is_Not_Valid()
        {
            var sut = CreateSut();

            //TODO : 05 - Debo refactorizar los test para que pasen a mis Sut General
            // var sut = new Account(new Client(DateTime.Now.AddYears(-19)), 1500);
            // Action act = () => sut.Transfer(450, new Client(DateTime.Now));
            Action act = () => sut.Transfer(10, new Client(DateTime.Now));

            act.Should().Throw<ArgumentException>()
                         .WithMessage("client");
        }

        [Fact]
        public void Transfer_Money_Reduce_Money_From_Current_Account()
        {
            var sut = CreateSut();

            //sut.Transfer(450, new Client(DateTime.Now.AddYears(-19)));
            // var sut = new Account(new Client(DateTime.Now.AddYears(-20)), 1500);
            ////TODO: 06 - Debo de refactorizar mis assert
            //sut.Amount.Should().Be(1500 - 450);

            sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

            //TODO: 07 - código hardcodeado
            sut.Amount.Should().Be(150 - 45);
        }

        [Fact]
        public void Create_New_Transactions()
        {
            var sut = CreateSut();

            sut.Transfer(45, new Client(DateTime.Now.AddYears(-19)));

            var transaction = sut.Transactions.First();

            sut.Transactions.Count.Should().Be(1);

            transaction.Amount.Should().Be(45);
            transaction.Type.Should().Be(TransactionsType.Transfer);
            //transaction.Date.Should().Be(DateTime.Now); // ?
        }
    }
}