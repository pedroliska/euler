using System;
using System.Collections.Generic;
using System.Linq;

namespace euler.solutions
{
    public class Problem024
    {
        public static void Run()
        {
            //string digits = "123456789";
            //string digits = "123";
            //var items = new List<int> { 1, 2, 3 };
            var items = "0123456789".ToList();

            var permutations = Permutate(items);
            DisplayPermutations(permutations);
        }

        private static List<List<T>> Permutate<T>(List<T> items)
        {
            // this is when recursion ends
            if (items.Count <= 1)
            {
                return new List<List<T>> { items };
            }

            var retVal = new List<List<T>>();
            for (int i = 0; i < items.Count; i++)
            {
                var pivot = items[i];
                var subCollection = items.ToList();
                subCollection.RemoveAt(i);

                var subResults = Permutate(subCollection);

                foreach (var result in subResults)
                {
                    var retItem = result.ToList();
                    retItem.Insert(0, pivot);
                    retVal.Add(retItem);
                }
            }
            return retVal;
        }

        private static void DisplayPermutations<T>(List<List<T>> permutations)
        {
            foreach (var permutation in permutations)
            {
                //Console.WriteLine(
                //    permutation.Aggregate((a, b) => a.ToString() + b.ToString())
                //    );
                foreach (var item in permutation)
                    Console.Write(item);
                Console.WriteLine();
            }
        }
    }
}