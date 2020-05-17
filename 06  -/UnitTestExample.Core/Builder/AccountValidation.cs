namespace UnitTestExample.Core.Builder
{
    public class AccountValidation
    {
        public Client Client { get; }
        public decimal InitialAmount { get; }
        public AccountType Type { get; }

        public AccountValidation(Client client, decimal initialAmount, AccountType type)
        {
            Client = client;
            InitialAmount = initialAmount;
            Type = type;
        }
    }
}