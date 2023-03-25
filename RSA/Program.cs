using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var szyfr = RSA.Encrypt("asdkjsdklfhweyuisdbasdbkjasdnlk");
            Console.WriteLine(szyfr);
            var deszyfr = DecryptionRSA.Decrypt(szyfr);
            Console.WriteLine(deszyfr);
            Console.ReadKey();
        }
    }
}
