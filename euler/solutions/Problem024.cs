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
            var permutationPosition = 1000000;

            Timer.RecordMiliseconds(() =>
            {
                var permutation = Permutate(items).Skip(permutationPosition - 1).First();
                Console.WriteLine("{0} is the {1}th permutation", PermutationToString(permutation), permutationPosition);
            });
        }

        private static IEnumerable<List<T>> Permutate<T>(List<T> items)
        {
            // this is when recursion ends
            if (items.Count <= 1)
            {
                yield return items;
                yield break;
            }

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
                    yield return retItem;
                }
            }
        }

        private static void DisplayPermutations<T>(IEnumerable<List<T>> permutations)
        {
            foreach (var permutation in permutations)
                Console.WriteLine(PermutationToString(permutation));
        }
        private static string PermutationToString<T>(IEnumerable<T> permutation)
        {
            return permutation.Aggregate("", (current, item) => current + item.ToString());
        }
    }
}