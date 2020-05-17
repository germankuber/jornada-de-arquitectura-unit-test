using System;
using System.Collections.Generic;
using System.Threading;

namespace UnitTestExample.Core
{
    public class Account
    {
        public Client Client { get; }
        public decimal Amount { get; private set; }
        public AccountType Type;
        public List<Transactions> Transactions { get; } = new List<Transactions>();

        //public Account(Client client, decimal initialAmount, AccountType type)
        //{
        //    //TODO: 02 - Mas requerimiento significa un contructor mas y mas grande.
        //    if (type == AccountType.Standard && initialAmount < 1000)
        //        throw new StandardClientDoesNotHaveEnoughInitialAmount();

        //    if (type == AccountType.Premium && initialAmount < 5000)
        //        throw new PremiumClientDoesNotHaveEnoughInitialAmount();

        //    if (!client.IsValid())
        //        throw new ArgumentException(nameof(client));
        //    Client = client;
        //    Amount = initialAmount;
        //    Type = type;
        //}
        internal Account(Client client, decimal initialAmount, AccountType type)
        {
            //TODO: 06 -Libero al constructor de responsabilidades y futuras modificaciones por reglas de negocio

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