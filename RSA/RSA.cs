using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using System.Numerics;

namespace RSA
{
    internal static class RSA
    {
        private static BigInteger P = 34412123; //2339 ; // 11;
        private static BigInteger Q = 3429893; // 543671; //17;

        //Klucze publiczne
        public static BigInteger E = 7;

        /// <summary>
        /// Iloczyn liczb pierwszych P, Q
        /// </summary>
        public static BigInteger N => P * Q;

        private static BigInteger phi => (P - 1) * (Q - 1);

        private static BigInteger C(BigInteger ascii)
        {
            return BigInteger.ModPow(ascii, E, N);
        }

        public static BigInteger Encrypt(BigInteger numberToEncrypt)
        {
            return C(numberToEncrypt);
        }

        public static List<BigInteger> Encrypt(string text) => Encrypt(text.ToListBigInteger());
        

        public static List<BigInteger> Encrypt(List<BigInteger> listOfNumbers)
        {
            List<BigInteger> result = new List<BigInteger>();
            foreach (var numberToEncrypt in listOfNumbers)
            {
                result.Add(Encrypt(numberToEncrypt));
            }
            return result;
        }
    }
}
