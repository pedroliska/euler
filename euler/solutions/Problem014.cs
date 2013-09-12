using System;

namespace euler.solutions
{
    public class Problem014
    {
        public static void Run()
        {
            int maxNumber = 1000000;
            long numberWithLongestCollatz = 0;
            int lengthOfNumberWithLongestCollats = 0;
            Timer.RecordMiliseconds(() =>
            {
                for (int i = 1; i < maxNumber; i++)
                {
                    var length = ChainLength(i);
                    if (length > lengthOfNumberWithLongestCollats)
                    {
                        lengthOfNumberWithLongestCollats = length;
                        numberWithLongestCollatz = i;
                    }
                    //Console.WriteLine("{0} {1} {2}", longest, i, length);
                }
                Console.WriteLine("{0} is the number with the longest Collatz sequence for all numbers under {1}.", numberWithLongestCollatz, maxNumber);
            });
        }

        private static int ChainLength(int number)
        {
            int length = 1;
            long n = number;
            while (n != 1)
            {
                //Console.WriteLine(n);
                length++;
                if (n % 2 == 0)
                    n = n / 2;
                else
                    n = (3 * n) + 1;
            }
            return length;
        }
    }
}