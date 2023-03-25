using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RSA
{
    internal static class DecryptionRSA
    {
        public static string Decrypt(string encryptedString)
        {
            var factors = factorNumber(RSA.N);
            if (factors.Count != 2)
                throw new Exception("Nie podano 2 pierwszych liczb");
            var k = K(factors[0], factors[1]);
            var decryptString = "";
            foreach (var charintext in encryptedString)
            {
                BigInteger ascii = Convert.ToUInt64(charintext);
                BigInteger decrypt = J(ascii, k);
                char charEncrypted = Convert.ToChar((UInt64)decrypt);

                decryptString += charEncrypted;
            }
            return decryptString;
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
