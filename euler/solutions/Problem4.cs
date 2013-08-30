using System;

namespace euler.solutions
{
    /// <summary>
    /// Largest palindrome product
    /// </summary>
    public class Problem4
    {
        public static void Run()
        {
            //Console.WriteLine(IsPalindrome(9009));
            //return;


            int max = 999;
            bool found = false;
            int product = 0;
            int x = 0;
            int y = 0;
            for (x = max; x > 0; x--)
            {
                for (y = max; y >= x; y--)
                {
                    product = x*y;
                    Console.WriteLine("{0} = {1} x {2}", product, x, y);
                    if (IsPalindrome(product))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
            Console.WriteLine("{0} = {1} x {2} is the largest palindrome produced from the product of two three digit numbers.",
                product, x, y);
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
            Console.WriteLine(isPalindrome);
            return isPalindrome;
        }
    }
}