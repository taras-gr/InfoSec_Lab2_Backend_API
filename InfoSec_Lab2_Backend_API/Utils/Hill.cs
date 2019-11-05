using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSec_Lab2_Backend_API.Utils
{
    public class Hill
    {
        private readonly string alfabet;

        protected readonly Dictionary<char, int> alphabetDictionary;

        private int[,] key;

        public Hill(string _alphabet)
        {
            alfabet = _alphabet;
            char[] alphToChar;
            alphToChar = alfabet.ToCharArray();
            alphabetDictionary = new Dictionary<char, int>();
            for(int i = 0; i < alphToChar.Length; i++)
            {
                alphabetDictionary.Add(alphToChar[i], i);
            }
        }

        #region Public Methods

        public string Encrypt(string plainText, string password)
        {
            if(plainText.Length % 3 == 1)
            {
                plainText = string.Concat(plainText, "  ");
            }
            if (plainText.Length % 3 == 2)
            {
                plainText = string.Concat(plainText, " ");
            }
            key = GetKeyMatrix(password);
            return Process(plainText, Mode.Encrypt);
        }

        public string Decrypt(string cipher, string password)
        {
            key = GetKeyMatrix(password);
            return Process(cipher, Mode.Decrypt);
        }

        #endregion

        #region Private Methods

        private string Process(string message, Mode mode)
        {
            MatrixClass matrix = new MatrixClass(key);

            if (mode == Mode.Decrypt)
            {
                matrix = matrix.Inverse();
            }

            int pos = 0, charPosition;
            string substring, result = "";
            int matrixSize = key.GetLength(0);

            while (pos < message.Length)
            {
                substring = message.Substring(pos, matrixSize);
                pos += matrixSize;

                for (int i = 0; i < matrixSize; i++)
                {
                    charPosition = 0;

                    for (int j = 0; j < matrixSize; j++)
                    {
                        charPosition += (int)matrix[j, i].Numerator * alphabetDictionary[substring[j]];
                    }

                    result += alphabetDictionary.Keys.ElementAt(charPosition % 26);
                }
            }

            return result;
        }

        private int[,] GetKeyMatrix (string password)
        {
            var key = password;
            if (key.Length != 9)
            {
                throw new ArgumentException("Key length is not 9");
            }

            List<int> passArrayInt = new List<int>();

            char[] passToArray = key.ToCharArray();

            foreach(char c in passToArray)
            {
                passArrayInt.Add(alphabetDictionary[c]);
            }

            int[,] keyMatrix = new int[3, 3];

            int index = 0;
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    keyMatrix[rowIndex, columnIndex] = passArrayInt[index];

                    index++;
                }
            }

            return keyMatrix;

        }

        #endregion
    }
}
