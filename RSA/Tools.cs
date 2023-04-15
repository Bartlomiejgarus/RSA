using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public static class Tools
    {
        public static List<BigInteger> ToListBigInteger(this string stringToChange)
        {
            var listAfterChange = new List<BigInteger>(); 

            foreach (var charInText in stringToChange)
            {
                BigInteger ascii = charInText.ToBigInteger();
                listAfterChange.Add(ascii);
            }

            return listAfterChange;
        }

        public static BigInteger ToBigInteger(this char charToChange)
        {
            try
            {
                return Convert.ToUInt64(charToChange);
            }
            catch
            {
                throw new ArgumentException("Problem ze zmianą znaku na liczbe");
            }
        }

        public static void TryToConvertToStringAndWrite(this List<BigInteger> listBigInteger)
        {
            foreach(var number in listBigInteger)
            {
                try
                {
                    var charConverted = number.ToChar();
                    Console.Write(charConverted);
                }
                catch
                {
                    Console.Write("{"+number+"}");
                }
            }
            Console.WriteLine();
        }

        public static string ToString(this List<BigInteger> listBigInteger)
        {
            var stringAfterChange = "";
            foreach (var number in listBigInteger)
            {
                char charAfterChange = Convert.ToChar((UInt64)number);
                stringAfterChange += charAfterChange;
            }
            return stringAfterChange;
        }

        public static char ToChar(this BigInteger numberToChange)
        {
            try
            {
                return Convert.ToChar((UInt64)numberToChange);
            }
            catch
            {
                throw new ArgumentException("Element jest poza tablica ASCII");
            }
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
            {
                x += m0;
            }

            return x;
        }
    }
}
