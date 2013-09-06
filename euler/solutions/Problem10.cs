using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace euler.solutions
{
    public class Problem10
    {
        public static void Run()
        {
            int maxPrime = 2000000;

            Stopwatch watch = Stopwatch.StartNew();

            var sieve = new SieveOfPedro();
            long sum = 0;
            var nextPrime = 0;
            while ((nextPrime = sieve.Next()) < maxPrime)
            {
                sum += nextPrime;
            }

            watch.Stop();
            Console.WriteLine("{0} is the sum of all the primes below {1}", sum, maxPrime);
            Console.WriteLine("it took {0} milliseconds to calcluate this", watch.ElapsedMilliseconds);
        }
    }
}