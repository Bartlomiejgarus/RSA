using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    internal static class RSA
    {
        private static BigInteger P = 11; //3671267; // 11;
        private static BigInteger Q = 17;// 543671; //17;

        //Klucze publiczne
        public static BigInteger E = 7;

        /// <summary>
        /// Iloczyn liczb pierwszych P, Q
        /// </summary>
        public static BigInteger N => P * Q;

        private static BigInteger Je(BigInteger ascii) => ascii.Pow(E);

        private static BigInteger C(BigInteger ascii)
        {
            var J = Je(ascii);
            return J % N;
        }

        public static string Encrypt(string text)
        {
            var encryptedString = "";
            foreach (var charintext in text)
            {
                BigInteger ascii = Convert.ToUInt64(charintext);
                BigInteger encrypted = C(ascii);
                char charEncrypted = Convert.ToChar(((UInt64)encrypted));

                encryptedString += charEncrypted;
            }

            return encryptedString;
        }

        public static BigInteger Pow(this BigInteger number, BigInteger pow)
        {
            BigInteger wynik = 1;
            for (BigInteger i = 0; i<pow; i++)
            {
                wynik *= number;
            }

            return wynik;
        }
    }
}
