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
            var substitutionAlhabet = key.ToCharArray();
            char[] message = text.ToCharArray();

            string encryptedMessage = "";
            

            for (int i = 0; i < message.Length; i++)
            {
                encryptedMessage += substitutionAlhabet[_alphabet.IndexOf(message[i])].ToString();
            }

            return encryptedMessage;
        }
    }
}
