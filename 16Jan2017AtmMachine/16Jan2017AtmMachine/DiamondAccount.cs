using System;

namespace _16Jan2017AtmMachine
{
    public class DiamondAccount : AccountType,IAccountTypes
    {

        public double MinumumBalance { get; } = 5000;

        public double Interest { get; } = 0.04;

        public double Penalty { get; } = 1000;

        public double Cashback { get; } = 0.03;

        public double CashbackAmount { get; set; }

        public IAccountStates AccState { get; set; }

        // Constructor
        public DiamondAccount(double accbalance,double cashBack)
        {
            AccountBalance = accbalance;
            CashbackAmount = cashBack;
        }

        public DiamondAccount()
        {
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            AccountBalance += amount;
            GetCashBackAmount(amount);
            if (AccState is InOperativeState)
                ChangeState();
        }

        public override void Withdraw(double amount)
        {
            if (AccountBalance - amount < 0)
            {
                Console.WriteLine("No funds available for withdrawal!");
                return;
            }
            balance = balance - amount;
            accountbalance = AccountBalance - amount;
            if (accountbalance < MinumumBalance)
            {
                accountbalance = accountbalance - Penalty;
            }
            if (AccState is InOperativeState)
                ChangeState();
            //this.GetCashBackAmount(amount); // As cash back wont be there for withdran transactions

        }

        public double GetCashBackAmount(double amount)
        {
            var transactioncashback = amount * Cashback;
            balance = balance + transactioncashback;
            accountbalance = accountbalance + transactioncashback;
            CashbackAmount += transactioncashback;
            return CashbackAmount;

        }

        public override void SetInitialBalance(double amount)
        {
            balance = amount;
            AccountBalance = amount;
        }

        public double CalculateInterest()
        {
            //var finalBalance = this.balance * Interest + this.accountbalance;
            if (AccountBalance > 0)
                return (balance * Interest);
            return 0;
        }

        public double GetFinalCashBack()
        {
            return CashbackAmount;

        }

        public void SetAccountStates(IAccountStates accountStates)
        {
            AccState = accountStates;
        }

        public override void ChangeState()
        {
            AccState = new ActiveState();
        }

    }
}
