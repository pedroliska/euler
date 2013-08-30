using System;
using System.Linq;

namespace euler.solutions
{
    public class Problem5
    {
        public static void Run()
        {
            int number = 19;
            do
            {
                number++;
            } while (!EvenlyDivisible(number));
            Console.WriteLine(number);
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