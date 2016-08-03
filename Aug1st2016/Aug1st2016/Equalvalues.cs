using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1staug2016
{
    class Equalvalues
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Enter the values of array seperated with ,");
                int[] values = Array.ConvertAll(Console.ReadLine().Split(','), Int32.Parse);
                Equalvalues eq = new Equalvalues();
                eq.isEqual(values);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter proper values");
            }
            Console.ReadLine();

        }

        public bool isEqual(int[] values){
            int sum = 0,sumLeft=0,sumRight;
            sum = values.Sum();
             sumRight = sum;
             for (int i = 0; i < values.Length; i++)
            {
                sumLeft += values[i];
                if (sumLeft == sumRight)
                {
                    Console.WriteLine("TEST CASE : PASSED & The index is " + (i+1));
                    return true;
                }
                sumRight -= values[i];
            }
             Console.WriteLine("TEST CASE : FAILED");
             return false;
        }
    }
}
