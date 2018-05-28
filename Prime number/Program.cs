using System;
using System.Diagnostics;

namespace Folkmancer.OSU.ZIPKS.PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch SW = new Stopwatch();
            
            Console.WriteLine("Простый перебор");
            SW.Start();
            Console.WriteLine(PrimeNumber.TrialDivision(2067894344));
            SW.Stop();
            Console.WriteLine(SW.Elapsed);
            /* Console.WriteLine(PrimeNumber.TrialDivision(42) + " 42");
             Console.WriteLine(PrimeNumber.TrialDivision(15) + " 15");
             Console.WriteLine(PrimeNumber.TrialDivision(3) + " 3");*/
            Console.WriteLine("Ферма");
            SW.Restart();
            Console.WriteLine(PrimeNumber.Ferma(2067894344, 1000));
            SW.Stop();
            Console.WriteLine(SW.Elapsed);
            /* Console.WriteLine(PrimeNumber.Ferma(42, 100) + " 42");
             Console.WriteLine(PrimeNumber.Ferma(15, 100) + " 15");
             Console.WriteLine(PrimeNumber.Ferma(3, 100) + " 3");*/
            Console.WriteLine("Миллер-Рабин");
            SW.Restart();
            Console.WriteLine(PrimeNumber.MillerRabin(2067894344, 1000));
            SW.Stop();
            Console.WriteLine(SW.Elapsed);
            /*Console.WriteLine(PrimeNumber.MillerRabin(42, 100) + " 42");
            Console.WriteLine(PrimeNumber.MillerRabin(15, 100) + " 15");
            Console.WriteLine(PrimeNumber.MillerRabin(3, 100) + " 3");*/
        }
    }
}
