using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _12Aug2016Unittests
{
    [TestClass]
    public class EncryptDecryptText
    {

        [TestMethod]
        public void EncryptMessageTest1()
        {
            EncryptDecryptEngine engine = new EncryptDecryptEngine();

            string input = "if man was meant to stay on the ground god would have given us roots";
            string expetedOutput = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau numsp 3 6 9 14 16 20 22 25 31 34 39 43 48 50";

            string actualOutput = engine.EncryptMessage(input);
            Assert.AreEqual(actualOutput, expetedOutput);

        }
}
