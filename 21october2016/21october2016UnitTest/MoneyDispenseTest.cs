using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _21october2016;

namespace _21october2016UnitTest
{
    [TestClass]
    public class MoneyDispenseTest
    {
        [TestMethod]
        public void MoneyDispenseMethod()
        {
            int inputamount = 3500;
            Money money=new Money();
            string expetedOutput = "Thank you please visit again";
            string actualOutput = money.DispenseAmount(inputamount);
            Assert.AreEqual(actualOutput, expetedOutput);
        }

        [TestMethod]
        public void MoneyDispenseMethod2()
        {
            int inputamount = 3560;
            Money money = new Money();
            string expetedOutput = "please enter proper input";
            string actualOutput = money.DispenseAmount(inputamount);
            Assert.AreEqual(actualOutput, expetedOutput);
        }

        [TestMethod]
        public void MoneyDispenseMethod3()
        {
            int inputamount = 8200;
            Money money = new Money();
            string expetedOutput = "Thank you please visit again";
            string actualOutput = money.DispenseAmount(inputamount);
            Assert.AreEqual(actualOutput, expetedOutput);
        }
    }
}
