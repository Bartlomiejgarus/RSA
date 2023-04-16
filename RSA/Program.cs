using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    internal class main
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = new Stopwatch();

            string text = "Automaty, Jezyki i Obliczenia";
            Console.WriteLine("Tekst do zmiany:");
            Console.WriteLine(text);

            stopwatch.Start();
            var szyfr = RSA.Encrypt(text);
            stopwatch.Stop();
            Console.WriteLine($"Czas wykonania szyforowania: {stopwatch.Elapsed}");

            Console.WriteLine("Tekst po zaszyfrowaniu:");
            szyfr.TryToConvertToStringAndWrite();

            stopwatch.Restart();
            stopwatch.Start();
            var deszyfr = DecryptionRSA.Decrypt(szyfr);
            stopwatch.Stop();
            Console.WriteLine($"Czas wykonania deszyfrowania: {stopwatch.Elapsed}");

            Console.WriteLine("Tekst po odszyfrowaniu:");


            deszyfr.TryToConvertToStringAndWrite();
            Console.ReadKey();
        }
    }
}
