using System;
using System.Numerics;

namespace euler.solutions
{
    public class Problem016
    {
        public static void Run()
        {
            Timer.RecordMiliseconds(() =>
            {
                BigInteger result = BigInteger.Pow(2, 1000);
                int sum = 0;
                foreach (char c in result.ToString())
                    sum += (int)char.GetNumericValue(c);

                Console.WriteLine(sum);
            });
        }
    }
}