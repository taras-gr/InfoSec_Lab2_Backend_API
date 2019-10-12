using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TZI.Utils
{
    public class Caesar
    {
        const string alfabet = " .,;-'ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Encrypt(string plainMessage)
        {
            char theMost = GetLetter(plainMessage);
            int key = alfabet.IndexOf(theMost);
            return CodeEncode(plainMessage, key);
        }

        public string Decrypt(string encryptedMessage)
        {
            char theMost = GetLetter(encryptedMessage);
            int key = alfabet.IndexOf(theMost);
            return CodeEncode(encryptedMessage, -key);
        }

        private string CodeEncode(string text, int k)
        {
            var letterQty = alfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = alfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += alfabet[codeIndex];
                }
            }

            return retVal;
        }

        private char GetLetter(string text)
        {
            return text.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }
    }
}