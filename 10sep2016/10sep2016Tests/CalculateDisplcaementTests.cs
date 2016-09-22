using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10sep2016;

namespace _10sep2016Tests
{
    [TestClass()]
    public class CalculateDisplcaementTests
    {
        [TestMethod()]
        public void CalculateLogicTest1()
        {
            CalculateDisplcaement objDisplcaement = new CalculateDisplcaement();
            int[,] inputarray = new int[4, 4] { { 0, 1, 1, 0 }, { 1, 1, 1, 1 }, { 1, 1, 0, 1 }, { 0, 1, 1, 1 } };
            Point p=new Point(0,1);
            Point q = new Point(3, 2);
            string expetedOutput = "Yes 4";
            string actualOutput=objDisplcaement.CalculateLogic(inputarray, p, q);
            Assert.AreEqual(actualOutput, expetedOutput);

    }
        [TestMethod()]
        public void CalculateLogicTest2()
        {
            CalculateDisplcaement objDisplcaement = new CalculateDisplcaement();
            int[,] inputarray = new int[4, 4] { { 0, 1, 1, 0 }, { 1, 0, 1, 1 }, { 1, 1, 0, 1 }, { 0, 0, 1, 1 } };
            Point p = new Point(0, 1);
            Point q = new Point(2, 1);
            string expetedOutput = "No";
            string actualOutput = objDisplcaement.CalculateLogic(inputarray, p, q);
            Assert.AreEqual(actualOutput, expetedOutput);

        }
        [TestMethod()]
        public void CalculateLogicTest3()
        {
            CalculateDisplcaement objDisplcaement = new CalculateDisplcaement();
            int[,] inputarray = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
            Point p = new Point(0, 0);
            Point q = new Point(3, 3);
            string expetedOutput = "Yes 6";
            string actualOutput = objDisplcaement.CalculateLogic(inputarray, p, q);
            Assert.AreEqual(actualOutput, expetedOutput);

        }
    }
}