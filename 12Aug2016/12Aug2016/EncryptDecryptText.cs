using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _12Aug2016
{
   public  class EncryptDecryptText
    {
        static void Main(string[] args)
         {
            try {
                Console.WriteLine("please enter the text to be encrypted");
                string inputstr = Console.ReadLine();   // Taking the Input from user to encrypt
                EncryptDecryptText p = new EncryptDecryptText();
                var encryptedmsg = p.EncryptText(inputstr);
                Console.WriteLine( "Encrypted text is :{0}",encryptedmsg);
                Console.WriteLine("please enter the encrypted text to be decrypted");
                var decrypttext = Console.ReadLine();  // Taking the encrypted Input from user to decrypt
                var decryptedmsg = p.DecryptText(decrypttext);
                Console.WriteLine("Decrypted text is :{0}", decryptedmsg);
                

            }
            catch(Exception ex)
            {
                Console.WriteLine("please enter proper input");
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.ReadLine();
            }         
        }
        public  string FormattedString(string inputstr)
        {
            Regex rgx = new Regex("\\s+");
            var formattedInput = rgx.Replace(inputstr, "");
            return formattedInput;

        }

        public string EncryptText(string inputstr)
        {
            var encryptedmsg = "";
            EncryptDecryptText p = new EncryptDecryptText();
            var formattedInput = p.FormattedString(inputstr);
            int indexcount = 1;
            List<int> formattedIndex = new List<int>();
            var inputlength = formattedInput.Length;
            foreach (char c in inputstr)
            {
                if (c == ' ')
                {
                    formattedIndex.Add(indexcount);
                }
                else
                {
                    indexcount++;
                }
            }
            if (inputlength > 81)
            {
                Console.WriteLine("The input should not exceed 81 characters ignoring spaces");
                return "";
            }

            var sqrRoot = Math.Sqrt(inputlength);
            int noofRows = Convert.ToInt16(Math.Floor(sqrRoot));
            int noofColumns = noofRows;
            while (noofRows * noofColumns < inputlength)
            {
                noofColumns = noofColumns + 1;

            }
            int i = 0, j = 0;
            while (j < noofColumns)
            {
                i = j;
                int count = 0;
                while (i < inputlength)
                {
                    encryptedmsg = encryptedmsg + formattedInput[i];
                    i = i + noofColumns;
                    count++;
                }
                j++;
                encryptedmsg = encryptedmsg + " ";
            }
            encryptedmsg += "numsp " + String.Join(" ", formattedIndex);
            return encryptedmsg;
        }

        public string DecryptText(string inputstr)
        {
            EncryptDecryptText p = new EncryptDecryptText();
            var formattedstring=p.FormattedString(inputstr);
            formattedstring=formattedstring.Substring(0,formattedstring.IndexOf("numsp"));
            var indexes = inputstr.Substring(inputstr.IndexOf("numsp")+5);
            string[] formattedIndex = indexes.Split(' ');
            int inputLength=formattedstring.Length;
            var sqrRoot = Math.Sqrt(inputLength);
            int noofRows = Convert.ToInt16(Math.Floor(sqrRoot));
            int noofColumns = noofRows;
            if (noofRows * noofColumns < inputLength)
            {
                noofColumns = noofColumns + 1;
            }
            if(noofRows * noofColumns - inputLength != 0) {
                var insertIndex = noofRows * (noofColumns - (noofRows * noofColumns - inputLength-1)) - 1;
                for (int extrainput= inputLength; extrainput < noofRows * noofColumns; extrainput++)
                {
                   
                    formattedstring = formattedstring.Insert(insertIndex, "-");
                    insertIndex += noofRows;
                }
            }
            var decryptedmsg = "";
            int i = 0, j = 0;
            int count = 1, formattedindexcount = 1 ;
            while (j < noofRows)
            {
                i = j;
               
                while (i < formattedstring.Length)
                {
                    if (formattedstring[i] != '-') {
                        decryptedmsg = decryptedmsg + formattedstring[i];
                    }
                    
                    i = i + noofRows;
                    count++;
                    if (formattedindexcount <= formattedIndex.Length-1 && count == Convert.ToInt16(formattedIndex[formattedindexcount]))
                    {
                        decryptedmsg = decryptedmsg + " ";
                        formattedindexcount++;
                    }
  
                }
                j++;
            }
            return decryptedmsg;
        }
    }
}
