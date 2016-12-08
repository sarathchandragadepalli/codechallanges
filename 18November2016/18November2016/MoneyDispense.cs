using System;
using System.Globalization;

class AtmMachine
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {

                Console.WriteLine("Please enter the operation Type 1.Deposit 2.Withdraw 3.Balance Enquiry");
                var operationType = Console.ReadLine();
                Console.WriteLine("Please enter the account Types 1.active 2.inoperative 3.closed");
                var accountType = Console.ReadLine();
                var acctype = (AcountTypes) AccountTypeFactory.GetAccountTypes(accountType);
                AccountTypeFactory.GetOperationAndDispalyResult(acctype, operationType);

                Console.WriteLine("please enter exit to exit the application or continue to continue the application");
                var value = Console.ReadLine();
                if (value != null)
                    if (value.ToUpper() == "EXIT") return;
            }

            catch (Exception ex)
            {
                Console.WriteLine("please enter proper input" + ex.InnerException);
            }

        }
    }

    public void ShowDispenseAmount()
    {
        var inputAmount = 0;
        Console.WriteLine("Please enter the amount to be dispensed");
        var input = Console.ReadLine();
        if (int.TryParse(input, NumberStyles.None, null, out inputAmount))
        {
            Money myMoney = new Money();
            int minAmount = inputAmount % 100;
            if (minAmount == 0)
            {
                var outputstring = myMoney.DispenseAmount(inputAmount);
                Console.WriteLine(outputstring);
            }
            else
            {
                Console.WriteLine("input should end with 100's");
            }
        }
        else
        {
            Console.WriteLine("input amount should be an integer");
        }
    }
}