using System.Collections.Generic;

namespace _16Jan2017AtmMachine
{
    class AccountStateFactory
    {
        public static Dictionary<string, IAccountStates> AccountState = new Dictionary<string, IAccountStates>();
        static AccountStateFactory()
        {
            if (AccountState.Count == 0)
            {
                AccountState.Add("active", new ActiveState());
                AccountState.Add("inoperative", new InOperativeState());
                AccountState.Add("closed", new ClosedState());
            }
        }

        public static IAccountStates GetAccountStates(string accountState)
        {
            return AccountState[accountState];
        }

    }
}
