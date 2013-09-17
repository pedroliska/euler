using System;

namespace euler.solutions
{
    /// <summary>
    /// This is trully my own solution. It ran for 30 hours without
    /// reaching the answer.
    /// </summary>
    public class Problem015a
    {
        public static void Run()
        {
            int size = 20;

            Timer.RecordMiliseconds(() =>
            {
                double outerRange = Math.Pow(2, size*2);

                int pathCount = 0;
                for (int i = 1; i < outerRange; i++)
                {
                    int count = CountOnes2(i, size);
                    if (count == size)
                        pathCount++;

                    Console.WriteLine("{0} {1} {2}", outerRange, i, count);
                }
                Console.WriteLine("There are {0} Lattice paths.", pathCount);
            });
        }

        /// <summary>
        /// Counts the number of "ones" in the decimal number's binary
        /// representation.
        /// </summary>
        private static int CountOnes(int decNumber, int gridSize)
        {
            // we're counting how many ones in the integer's binary equivalent
            int remainderCount = 0;
            int dividend = decNumber;
            while (dividend != 0)
            {
                if (dividend%2 == 1)
                    remainderCount++;
                if (remainderCount > gridSize)
                    break;
                dividend = dividend/2;
            }
            return remainderCount;
        }
        /// <summary>
        /// This one is a bit more optimized but it still takes days to 
        /// come to an answer. It can be optimized a bit more by counting
        /// the zeros also, but it would still take too long.
        /// </summary>
        private static int CountOnes2(int decNumber, int gridSize)
        {
            int mask = 1;
            int shiftingNumber = decNumber;
            int oneCount = 0;
            for (int i = 0; i < gridSize*2; i++)
            {
                if ((shiftingNumber & mask) == mask)
                    oneCount++;
                shiftingNumber = shiftingNumber >> 1;
            }
            //Console.WriteLine("{0} has {1} ones in its binary representation", decNumber, oneCount);
            return oneCount;
        }
    }
}