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
            var factors = factorM(RSA.N);
            var k = D(factors[0], factors[1]);
            List<BigInteger> listOfDecryptedNumbers = new List<BigInteger>();
            foreach (var numberToDecrypt in listOfNumbers)
            {
                BigInteger decryptedNumber = BigInteger.ModPow(numberToDecrypt, k, RSA.N);

                listOfDecryptedNumbers.Add(decryptedNumber);
            }
            return listOfDecryptedNumbers;
        }

        public static BigInteger Decrypt(BigInteger numberToDecrypt)
        {
            var factors = factorM(RSA.N);
            var k = D(factors[0], factors[1]);

            return BigInteger.ModPow(numberToDecrypt, k, RSA.N);
        }

        public static List<BigInteger> factorM(BigInteger n)
        {
            var factors = factorNumber(n);
            //var factors = factorNumberEratostenesa(n);
            if (factors.Count != 2)
                throw new Exception("Nie podano 2 pierwszych liczb");
            return factors;
        }

            public static BigInteger D(BigInteger P, BigInteger Q)
        {
            var phi = (P - 1) * (Q - 1);

            return Tools.ModInverse(RSA.E, phi);
        }

        public static List<BigInteger> factorNumber(BigInteger n)
        {
            List<BigInteger> factors = new List<BigInteger>();

            if (n < 2)
            {
                return factors;
            }

            while (n % 2 == 0)
            {
                factors.Add(2);
                n = n / 2;
            }

            BigInteger sqrtN = (BigInteger)Math.Sqrt((double)n);

            for (BigInteger i = 3; i <= sqrtN; i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n = n / i;
                    sqrtN = (BigInteger)Math.Sqrt((double)n);
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
