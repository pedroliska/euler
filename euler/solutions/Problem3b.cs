using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace euler
{
    public class Problem3b
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
                if (number%prime == 0)
                    largest = prime;
            }
            Console.WriteLine(largest);
        }
    }

    public class SieveOfEratosthenes
    {
        private List<int> bucket;

        public SieveOfEratosthenes(int searchLimit)
        {
            bucket = new List<int>();
            for (int i = 2; i <= searchLimit; i++)
                bucket.Add(i);
        }

        public IEnumerable<int> Primes
        {
            get
            {
                while (bucket.Count > 0)
                {
                }
                return null;
            }
        }
    }
}