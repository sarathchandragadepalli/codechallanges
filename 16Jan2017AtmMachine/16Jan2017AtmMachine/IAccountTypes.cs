namespace _16Jan2017AtmMachine
{
    public interface IAccountTypes
    {
        double Balance { get; set; }

        double AccountBalance { get; set; }

        //double PerformTransaction(double amount,string trasaction);

        void SetInitialBalance(double amount);

        void Deposit(double amount);

        void Withdraw(double amount);

        double GetCashBackAmount(double amount);

        double CalculateInterest();

        double GetFinalCashBack();

        void SetAccountStates(IAccountStates accountStates);

    }

}