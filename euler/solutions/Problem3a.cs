using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace euler
{
    public class Problem3a
    {
        public static void Run()
        {
            var generator = new PrimeGenerator();
            long number = 600851475143;

            int prime;
            int largest = 0;
            while ((prime = generator.Next()) <= number)
            {
                Console.WriteLine(prime);
                Thread.Sleep(300);
                if (number%prime == 0)
                    largest = prime;
            }
            Console.WriteLine(largest);
        }
    }

    /// <summary>
    /// absolutely no optimizations
    /// </summary>
    public class PrimeGenerator
    {
        private int last = 1;

        public int Next()
        {
            int i = last;
            do
            {
                i++;
            } while (!IsPrime(i));
            return last = i;
        }

        private bool IsPrime(int number)
        {
            if (number == 1) return true;

            for (int j = 2; j < number; j++)
            {
                if (number%j == 0) return false;
            }
            return true;
        }
    }

}