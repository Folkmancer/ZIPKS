using System;
using System.Numerics;

namespace Folkmancer.OSU.ZIPKS.PrimeNumber
{
    static class PrimeNumber
    {
        public static bool TrialDivision(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public static bool Ferma(int number, int count)
        {
            if (number == 2 || number == 3) return true;
            else if (number < 2) return false;
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                if ((int)BigInteger.ModPow(rand.Next(2, number - 2) , number - 1, number) != 1) return false;
            }
            return true;
        }

        public static bool MillerRabin(int number, int count)
        {        
            if (number == 2 || number == 3) return true;
            else if (number < 2 || number % 2 == 0) return false;
            int t = number - 1; // представим n − 1 в виде (2^s)·t, где t нечётно, это можно сделать последовательным делением n - 1 на 2
            int s = 0;
            Random rand = new Random();
            while (t % 2 == 0)
            {
                t /= 2;
                s += 1;
            }   
            for (int i = 0; i < count; i++)
            {
                int x = (int)BigInteger.ModPow(rand.Next(2, number - 2), t, number); // x ← a^t mod n, вычислим с помощью возведения в степень по модулю
                if (x == 1 || x == number - 1) continue;
                for (int r = 1; r < s; r++) // повторить s − 1 раз
                {
                    x = (int)BigInteger.ModPow(x, 2, number);  // x ← x^2 mod n
                    if (x == 1) return false;
                    else if (x == number - 1) break;
                }
                if (x != number - 1) return false;
            }
            return true;
        }
    }
}