using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace InfoSec_Lab2_Backend_API.Utils
{
    public class Substitution
    {
        private readonly string _alphabet;

        public Substitution(string alphabet)
        {
            _alphabet = alphabet;
        }

        public string Encrypt(string text, string key)
        {
            var substitutionAlphabet = key.ToCharArray();
            char[] message = text.ToCharArray();

            string encryptedMessage = "";
            

            for (int i = 0; i < message.Length; i++)
            {
                encryptedMessage += substitutionAlphabet[_alphabet.IndexOf(message[i])].ToString();
            }

            return encryptedMessage;
        }

        public string Decrypt(string text, string key)
        {
            var substitutionAlphabet = key.ToCharArray();
            char[] message = text.ToCharArray();

            string decryptedMessage = "";


            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage += _alphabet[substitutionAlphabet.IndexOf(message[i])].ToString();
            }

            return decryptedMessage;
        }
    }
}
