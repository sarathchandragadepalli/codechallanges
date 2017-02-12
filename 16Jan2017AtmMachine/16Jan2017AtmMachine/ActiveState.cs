using System;

namespace _16Jan2017AtmMachine
{
    class ActiveState: AccountStates,IAccountStates
    {
        public double Deposit(double initialAmount, double depositAmount)
        {
            Console.Write("Deposit amount is " + depositAmount);
            return initialAmount + depositAmount;
        }

        public double WithDraw(double initialAmount, double withdrawAmount)
        {

            Console.Write("Withdraw amount is " + withdrawAmount);
            return initialAmount - withdrawAmount;
        }

        
    }
}
