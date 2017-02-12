namespace _16Jan2017AtmMachine
{
    public abstract class AccountType
    {
        protected double balance;
        protected double accountbalance;
        protected double interest;
        protected double minimumBalance;

        // Properties

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public double AccountBalance
        {
            get { return accountbalance; }
            set { accountbalance = value; }
        }

        public double MinimumBalance
        {
            get { return minimumBalance; }
            set { minimumBalance = value; }
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void SetInitialBalance(double amount);

        public abstract void ChangeState();

    }
}
