using System.Collections.Generic;

namespace _16Jan2017AtmMachine
{
    class AccountTypeFactory
    {
        public static Dictionary<string, IAccountTypes> AccountType =new Dictionary<string, IAccountTypes>();
        static AccountTypeFactory()
        {
            if (AccountType.Count == 0)
            {
                AccountType.Add("gold", new GoldAccount());
                AccountType.Add("diamond", new DiamondAccount());
                AccountType.Add("platinum", new PlatinumAccount());
            }
        }

        public static IAccountTypes GetAccountTypes(string accountType)
        {
            return AccountType[accountType];
        }
    }
}
