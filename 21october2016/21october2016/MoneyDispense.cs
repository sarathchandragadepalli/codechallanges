using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21october2016
{
    class AtmMachine
    {
        static void Main(string[] args)
        {
            var inputAmount = 0;
            Console.WriteLine("Please enter the amount to be dispensed");
            var input = Console.ReadLine();
            if (int.TryParse(input, NumberStyles.None, null, out inputAmount))
            {
                Money myMoney = new Money();
                int minAmount = inputAmount%100;
                if (minAmount == 0)
                {
                   var outputstring= myMoney.DispenseAmount(inputAmount);
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

            Console.ReadLine();
        }
    }
}