using System;

namespace UnitTestExample.Core
{
    public class Transactions
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TransactionsType Type { get; set; }
        public Transactions(TransactionsType type, decimal amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}