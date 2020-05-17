using System;
using System.Collections.Generic;

namespace UnitTestExample.Core
{
    public class Account
    {
        public Client Client { get; }
        public decimal Amount { get; private set; }
        public AccountType Type;

        public List<Transactions> Transactions { get; } = new List<Transactions>();
        public Account(Client client, decimal initialAmount, AccountType type)
        {
            //TODO: 01 - Las cuentas deben iniciar con al menos 1000
            if (initialAmount < 1000)
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