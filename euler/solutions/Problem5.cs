using System;
using System.Linq;

namespace euler.solutions
{
    public class Problem5
    {
        public static void Run()
        {
            var start = DateTime.Now;

            int number = 19;
            do
            {
                number++;
            } while (!EvenlyDivisible(number));

            Console.WriteLine(number);
            Console.WriteLine("it took {0} seconds to calcluate this", DateTime.Now.Subtract(start).TotalSeconds);
        }

        private static bool EvenlyDivisible(int number)
        {
            for (int i = 20; i > 0; i--)
                if (number%i != 0)
                    return false;

            return true;
        }
    }
}