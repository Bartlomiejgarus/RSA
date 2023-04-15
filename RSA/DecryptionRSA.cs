using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace RSA
{
    internal static class DecryptionRSA
    {
        public static List<BigInteger> Decrypt(List<BigInteger> listOfNumbers)
        {
            var factors = factorNumber(RSA.N);
            if (factors.Count != 2)
                throw new Exception("Nie podano 2 pierwszych liczb");
            var k = K(factors[0], factors[1]);
            List<BigInteger> listOfDecryptedNumbers = new List<BigInteger>();
            foreach (var numberToDecrypt in listOfNumbers)
            {
                BigInteger decryptedNumber = J(numberToDecrypt, k);

                listOfDecryptedNumbers.Add(decryptedNumber);
            }
            return listOfDecryptedNumbers;
        }

        public static BigInteger Decrypt(BigInteger numberToDecrypt)
        {
            var factors = factorNumber(RSA.N);
            if (factors.Count != 2)
                throw new Exception("Nie podano 2 pierwszych liczb");
            var k = K(factors[0], factors[1]);

            return J(numberToDecrypt, k);
        }

        public static BigInteger J(BigInteger ascii, BigInteger k)
        {
            var a = ascii.Pow(k);
            return a % RSA.N;
        }

        public static BigInteger K(BigInteger P, BigInteger Q)
        {
            return ((P - 1) * (Q - 1) + 1) / RSA.E;
        }

        public static List<BigInteger> factorNumber(BigInteger n)
        {
            List<BigInteger> factors = new List<BigInteger>();

            while (n % 2 == 0)
            {
                factors.Add(2);
                n = n / 2;
            }

            for (BigInteger i = 3; i <= (BigInteger)Math.Sqrt((double)n); i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n = n / i;
                }
            }

            if (n > 2)
            {
                factors.Add(n);
            }

            return factors;
        }
    }
}
