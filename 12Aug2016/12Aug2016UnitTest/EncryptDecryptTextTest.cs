using Microsoft.VisualStudio.TestTools.UnitTesting;
using _12Aug2016;

namespace _12Aug2016UnitTest
{
    [TestClass]
    public class EncryptDecryptTextTest
    {
        [TestMethod]
        public void EncryprMessageTest1()
        {
            EncryptDecryptText objencrpt = new EncryptDecryptText();
            string input = "if man was meant to stay on the ground god would have given us roots";
            string expetedOutput = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau numsp 3 6 9 14 16 20 22 25 31 34 39 43 48 50";
            string actualOutput = objencrpt.EncryptText(input);
            Assert.AreEqual(actualOutput, expetedOutput);
        }
        [TestMethod]
        public void EncryprMessageTest12()
        {
            EncryptDecryptText objencrpt = new EncryptDecryptText();
            string input = "have a nice day";
            string expetedOutput = "hae and via ecy numsp 5 6 10";
            string actualOutput = objencrpt.EncryptText(input);
            Assert.AreEqual(actualOutput, expetedOutput);
        }

        [TestMethod]
        public void DecryptMessageTest1()
        {
            EncryptDecryptText objencrpt = new EncryptDecryptText();
            string input = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau numsp 3 6 9 14 16 20 22 25 31 34 39 43 48 50";
            string expetedOutput = "if man was meant to stay on the ground god would have given us roots";
            string actualOutput = objencrpt.DecryptText(input);
            Assert.AreEqual(actualOutput, expetedOutput);
        }
        [TestMethod]
        public void DecryptMessageTest2()
        {
            EncryptDecryptText objencrpt = new EncryptDecryptText();
            string input = "hae and via ecy numsp 5 6 10";
            string expetedOutput = "have a nice day";
            string actualOutput = objencrpt.DecryptText(input);
            Assert.AreEqual(actualOutput, expetedOutput);
        }
    }
}
