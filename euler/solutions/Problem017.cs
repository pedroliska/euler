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
            int end = 20000;
            Timer.RecordMiliseconds(() =>
            {
                int result = Enumerable.Range(start, end - start + 1)
                    .Select(SpellOutLength)
                    .Aggregate((total, current) => total + current);

                Console.WriteLine("There are {0} letters when you spell out numbers from {1} to {2}", result, start, end);
            });
        }

        private static int SpellOutLength(int number)
        {
            return SpellOut(number).Replace(" ", "").Length;
        }

        private static string SpellOut(int number)
        {
            Console.Write("{0}: ", number);
            string retVal = "";
            bool spelledExponent = false;
            foreach (int exponent in new[] {4, 3, 2})
            {
                var divisor = (int)Math.Pow(10, exponent);
                int divisionResult = number/divisor;
                if (divisionResult > 0)
                {
                    retVal = LessThan100Spellout(divisionResult) + " " + ExponentSpellout(exponent) + " ";
                    number = number%divisor;
                    spelledExponent = true;
                }
            }
            if (spelledExponent && number > 0)
                retVal += "and ";

            retVal += LessThan100Spellout(number);

            Console.WriteLine(retVal);
            return retVal;
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

        private static string LessThan100Spellout(int number)
        {
            string retVal = "";
            if (number >= 20)
            {
                retVal += TenthsSpellout(number/10) + " ";
                number = number%10;
            }
            if (number > 0)
            {
                retVal += BasicSpellout(number);
            }
            return retVal;
        }

        private static string TenthsSpellout(int tenth)
        {
            var mapper = new Dictionary<int, string>
            {
                {2, "twenty"},
                {3, "thirty"},
                {4, "forty"},
                {5, "fifty"},
                {6, "sixty"},
                {7, "seventy"},
                {8, "eighty"},
                {9, "ninety"},
            };
            return mapper[tenth];
        }

        private static string ExponentSpellout(int exponent)
        {
            var mapper = new Dictionary<int, string>
            {
                {1, ""},
                {2, "hundred"},
                {3, "thousand"},
                {4, "million"},
            };
            return mapper.GetValueOrDefault(exponent, "");
        }
    }

    public static class EnumerationExtensions
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
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