using System;

namespace _16Jan2017AtmMachine
{
    class ClosedState: AccountStates,IAccountStates
    {
        public double Deposit(double initialAmount, double depositAmount)
        {
            Console.WriteLine("we cant deposit in case of closed account");
            return 0;
        }

        public double WithDraw(double initialAmount, double depositAmount)
        {
            Console.WriteLine("we cant withdraw in case of closed account");
            return 0;
        }
    }
}
