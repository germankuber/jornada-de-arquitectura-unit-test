using System;
using System.Collections.Generic;

namespace UnitTestExample.Core
{
    public class StandardClientDoesNotHaveEnoughInitialAmount : Exception { }
    public class PremiumClientDoesNotHaveEnoughInitialAmount : Exception { }
    public class Account
    {
        public Client Client { get; }
        public decimal Amount { get; private set; }
        public AccountType Type;

        public List<Transactions> Transactions { get; } = new List<Transactions>();
        public Account(Client client, decimal initialAmount, AccountType type)
        {
            //TODO: 01 - Si es standard el minimo es 1000 si es premium el minimo es 5000
            //if (type == AccountType.Standard && initialAmount < 1000)
            //    throw new StandardClientDoesNotHaveEnoughInitialAmount();

            //if (type == AccountType.Premium && initialAmount < 5000)
            //    throw new PremiumClientDoesNotHaveEnoughInitialAmount();


            //TODO: 03 - Implemento exception personalizadas
            if (type == AccountType.Standard && initialAmount < 1000)
                throw new StandardClientDoesNotHaveEnoughInitialAmount();

            if (type == AccountType.Premium && initialAmount < 5000)
                throw new PremiumClientDoesNotHaveEnoughInitialAmount();

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