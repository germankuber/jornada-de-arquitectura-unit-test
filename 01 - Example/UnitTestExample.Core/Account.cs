using System;
using System.Collections.Generic;

namespace UnitTestExample.Core
{
    public class Account
    {
        public Client Client { get; }
        public decimal Amount { get; private set; }
        public List<Transactions> Transactions { get; } = new List<Transactions>();
        public Account(Client client, decimal initialAmount)
        {
            if (initialAmount <= 0)
                throw new ArgumentException(nameof(initialAmount));

            if (!client.IsValid())
                throw new ArgumentException(nameof(client));
            Client = client;
            Amount = initialAmount;
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