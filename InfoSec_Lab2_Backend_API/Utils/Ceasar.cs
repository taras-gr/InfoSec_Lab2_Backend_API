﻿using System.Linq;

namespace TZI.Utils
{
    public class Caesar
    {
        private readonly string alfabet;

        public Caesar(string alphabet)
        {
            this.alfabet = alphabet;
        }

        public string Encrypt(string plainMessage, int key)
        {
            char theMost = GetLetter(plainMessage);
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