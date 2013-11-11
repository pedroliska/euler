using System;
using System.Numerics;

namespace euler.solutions
{
    public class Problem025
    {
         public static void Run()
         {
             var targetDigitCount = 1000;

             var generator = new FibonacciGenerator();
             int digitCount;
             var fibCount = 0;
             do
             {
                 var nextInSequence = generator.Next();
                 fibCount++;
                 digitCount =nextInSequence.ToString().Length;
             } while (digitCount < targetDigitCount);

             Console.WriteLine("The {0}th fibonacci term is the first one with {1} digits", 
                 fibCount, targetDigitCount);
         }
    }
}