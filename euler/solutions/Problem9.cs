using System;
using System.Diagnostics;
using System.Security.Policy;

namespace euler.solutions
{
    public class Problem9
    {
        public static void Run()
        {
            int sumOfTriplets = 1000;

            Stopwatch watch = Stopwatch.StartNew();

            int a = 0, b = 0, c = 0;
            bool found = false;

            for (c = 0; !found && c <= sumOfTriplets; )
            {
                c++;
                for (b = 0; !found && b <= sumOfTriplets && b < c; )
                {
                    b++;
                    for (a = 0; !found && a <= sumOfTriplets && a < b; )
                    {
                        a++;
                        if (a + b + c == sumOfTriplets && a*a + b*b == c*c)
                            found = true;
                    }
                }
            }



            watch.Stop();
            Console.WriteLine("{0}x{1}x{2}={3} is the pythagorean triplet whose sum is {4}", a, b, c, a*b*c, sumOfTriplets);
            Console.WriteLine("it took {0} milliseconds to calcluate this", watch.ElapsedMilliseconds);
        }
    }
}