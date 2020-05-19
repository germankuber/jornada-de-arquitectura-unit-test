using System;
using System.Collections.Generic;

//TODO: 00 - Requerimiento
//Al momento de crear la cuenta se debe establecer que tipo de cuenta se esta creando
//Standard
//Premium
namespace UnitTestExample.Core
{
    public class Account
    {
        public Client Client { get; }
        public decimal Amount { get; private set; }
        public AccountType Type;

        public List<Transactions> Transactions { get; } = new List<Transactions>();
        //TODO: 01 - La cuenta debe de recibir el tipo de cuenta
        public Account(Client client, decimal initialAmount, AccountType type)
        {
            if (initialAmount <= 0)
                throw new ArgumentException(nameof(initialAmount));

            if (!client.IsValid())
                throw new ArgumentException(nameof(client));
            Client = client;
            Amount = initialAmount;
            Type = type;
        }

        public void Transfer(decimal amount, Client client)
        {
            if (amount >= Amount)
                throw new ArgumentException(nameof(amount));
            if (!client.IsValid())
                throw new ArgumentException(nameof(client));

            Amount = Amount - amount;
            Transactions.Add(new Transactions(TransactionsType.Transfer, amount));
        }

    }
}


//TODO: 09 - Requerimiento
//Las cuentas deben iniciar con al menos 1000