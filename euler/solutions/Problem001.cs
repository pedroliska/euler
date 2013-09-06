using System;

namespace euler.solutions
{
    /// <summary>
    /// Multiples of 3 and 5
    /// </summary>
    public class Problem001
    {
        public static void Run()
        {
            var sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                    sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}