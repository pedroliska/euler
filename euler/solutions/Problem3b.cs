using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace euler
{
    public class Problem3b
    {
        public static void Run()
        {
            long number = 1000;
            var generator = new SieveOfEratosthenes(number);

            int largest = 0;
            foreach (var prime in generator.Primes)
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

        public SieveOfEratosthenes(long searchLimit)
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
                    var retVal = bucket.First();

                    foreach (var item in bucket.ToArray())
                    {
                        if (item%retVal == 0)
                            bucket.Remove(item);
                    }
                    yield return retVal;
                }
            }
        }
    }
}