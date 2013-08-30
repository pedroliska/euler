using System;
using System.Collections.Generic;

namespace euler.solutions
{
    /// <summary>
    /// Largest palindrome product
    /// </summary>
    public class Problem4
    {
        public static void Run()
        {
            var start = DateTime.Now;

            int max = 999;
            int product = 0;
            int biggest = 0;
            for (int x = max; x > 100; x--)
            {
                for (int y = max; y >= x; y--)
                {
                    product = x*y;
                    if (IsPalindrome(product) && product > biggest)
                        biggest = product;
                }
            }
            Console.WriteLine("{0} is the largest palindrome produced from the product of two three digit numbers.",
                biggest);
            Console.WriteLine("it took {0} seconds to calcluate this", DateTime.Now.Subtract(start).TotalSeconds);
        }

        private static bool IsPalindrome(int product)
        {
            string sProduct = product.ToString();
            bool isPalindrome = true;
            for (int i = 0; i < sProduct.Length/2; i++)
            {
                if (sProduct[i] != sProduct[sProduct.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }
    }
}