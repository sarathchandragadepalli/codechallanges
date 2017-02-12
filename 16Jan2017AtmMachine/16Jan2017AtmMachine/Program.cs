using System;
using System.CodeDom;
using System.Linq;

namespace _16Jan2017AtmMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the input in the following format /n" +
                              "Account Type1, Account state, initial balance, transaction 1, transaction 2, Account type 2, transaction 3....");
            var input = Console.ReadLine();
            double interest = 0;
            try
            {
                if (input != null)
                {
                    string[] values = input.Split(',').Select(value => value).ToArray();

                    var accountType = AccountTypeFactory.GetAccountTypes(values[0]);
                    var accountState = AccountStateFactory.GetAccountStates(values[1]);
                    if (accountState is ClosedState)
                    {
                        Console.WriteLine("We cant perfom operation in case of closed state");
                        return;


                    }
                    accountType.SetInitialBalance(Convert.ToDouble(values[2]));
                    for (var i = 3; i < values.Length; i++)
                    {
                        if (values[i].ToLowerInvariant() == "diamond" || values[i].ToLowerInvariant() == "platinum")
                        {
                            // cashbackAmount = cashbackAmount + accountType.GetFinalCashBack();
                            if (accountType.AccountBalance > 0)
                                interest = interest + accountType.CalculateInterest();
                            if (values[i].ToLowerInvariant() == "diamond")
                            {
                                if (accountType.AccountBalance < 5000)
                                {
                                    Console.WriteLine(
                                        "Funds not sufficient to migrate to Diamond account , min balance is 5000");

                                    GetOutput(0, accountType);
                                    return;
                                }
                                if (accountType is GoldAccount)
                                    accountType = new DiamondAccount(accountType.AccountBalance,
                                        accountType.GetFinalCashBack());
                                else
                                    accountType = new DiamondAccount(accountType.AccountBalance,
                                        accountType.GetFinalCashBack());
                            }
                            else if (values[i].ToLowerInvariant() == "platinum")
                            {
                                if (accountType.AccountBalance < 25000)
                                {
                                    Console.WriteLine(
                                        "Funds not sufficient to migrate to platinum account, min balance is 25000");
                                    GetOutput(0, accountType);
                                    return;
                                }
                                if (accountType is GoldAccount)
                                    accountType = new PlatinumAccount(accountType.Balance,
                                        accountType.GetFinalCashBack());
                                else
                                    accountType = new PlatinumAccount(accountType.Balance,
                                        accountType.GetFinalCashBack());
                            }
                            else
                            {
                                accountType = AccountTypeFactory.GetAccountTypes(values[i]);
                            }

                        }
                        else
                        {
                            var transaction = values[i].Split(' ').Select(value => value).ToArray();
                            if (transaction[1] == "deposit")
                            {
                                accountType.SetAccountStates(accountState);
                                accountType.Deposit(Convert.ToDouble(transaction[0]));
                            }
                            else if (transaction[1] == "withdrawn")
                            {
                                accountType.Withdraw(Convert.ToDouble(transaction[0]));
                            }

                        }
                    }

                    GetOutput(interest, accountType);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Inputs passed");
            }
            finally
            {
                Console.Read();
            }

        }

        static void GetOutput( double interest,IAccountTypes accountType)
        {

            interest+=accountType.CalculateInterest();
            Console.WriteLine("cahback amount is " + accountType.GetFinalCashBack());
            Console.WriteLine("Final Balance is" + (accountType.AccountBalance+interest));
            //Console.ReadLine();
        }


    }
}
