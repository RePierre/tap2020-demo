namespace Tap2020Demo
{
    abstract class AccountBase
    {
        public string Ibnan { get; set; }

        public decimal Amount { get; protected set; }

        public void Deposit(decimal amount)
        {
            Amount += amount;
        }
    }
}
