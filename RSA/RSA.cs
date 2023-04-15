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
        private static BigInteger P = 11; //2339 ; // 11;
        private static BigInteger Q = 17; // 543671; //17;

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
