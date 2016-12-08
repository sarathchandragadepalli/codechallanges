using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

public static class AccountTypeFactory
{
    public static Dictionary<string, IAccountType> AccountType  = 
        
        new Dictionary<string, IAccountType>();
    static AccountTypeFactory()
    {
        if (AccountType.Count == 0)
        {
            AccountType.Add("active", new ActiveAccount());
            AccountType.Add("closed", new ClosedAccount());
            AccountType.Add("inoperative", new InOperativeAccount());
        }
    }
    public static IAccountType GetAccountTypes(string accountType)
    {
            return AccountType[accountType];
    }

    public static void GetOperationAndDispalyResult(AcountTypes accounttype, string operation)
    {
        var opearationStatus = false;
        var balanceenquiryflag = false;
        if (operation.ToLowerInvariant() == "deposit")
        {
            opearationStatus=accounttype.Deposit();
        }
        if (operation.ToLowerInvariant() == "withdraw")
        {
            opearationStatus=accounttype.WithDraw();
        }
        if (operation.ToLowerInvariant() == "balance enquiry")
        {
            opearationStatus=accounttype.BalanceEnquiry();
            balanceenquiryflag = true;
        }
        Console.WriteLine(opearationStatus);
        if (accounttype.GetType().FullName == "InOperativeAccount" && !balanceenquiryflag)
        {
            Console.WriteLine("Active");
            return;
        }
        Console.WriteLine(accounttype);
    }
}