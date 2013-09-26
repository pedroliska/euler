using System;
using System.Collections.Generic;
using System.Linq;

namespace euler.solutions
{
    public class Problem017
    {
        public static void Run()
        {
            int start = 1;
            int end = 5;
            Timer.RecordMiliseconds(() =>
            {
                int result = Enumerable.Range(start, end)
                    .Select(SpellOutLength)
                    .Aggregate((total, current) => total + current);

                Console.WriteLine("There are {0} letters when you spell out numbers from {1} to {2}", result, start, end);
            });
        }

        private static int SpellOutLength(int number)
        {
            return SpellOut(number).Length;
        }

        private static string SpellOut(int number)
        {
            string sNumber = number.ToString();
            int length = sNumber.Length;


            return number.ToString();
        }

        private static string BasicSpellout(int number)
        {
            var mapper = new Dictionary<int, string>
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eighteen"},
                {19, "nineteen"},
            };
            return mapper.GetValueOrDefault(number, "");
        }

        private static string ExponentSpellout(int exponent)
        {
            var mapper = new Dictionary<int, string>
            {
                {0, ""},
                {1, ""},
                {2, "hundred"},
                {3, "thousand"},
            };
            return mapper.GetValueOrDefault(exponent, "");
        }

    }

    public static class EnumerationExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action(item);
        }

        public static TValue GetValueOrDefault<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary,
                TKey key,
                TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }
    }
}