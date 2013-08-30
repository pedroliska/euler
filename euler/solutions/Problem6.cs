using System;

namespace euler.solutions
{
    public class Problem6
    {
        public static void Run()
        {
            int amountOfNumbers = 100;
            int sumOfSquares = 0;
            int squareOfSum = 0;
            int sum = 0;

            for (int i = 1; i <= amountOfNumbers; i++)
            {
                sumOfSquares += i*i;
                sum += i;
            }
            squareOfSum = sum*sum;

            Console.WriteLine("{0} - {1} = {2}", squareOfSum, sumOfSquares, squareOfSum - sumOfSquares);
        }
    }
}