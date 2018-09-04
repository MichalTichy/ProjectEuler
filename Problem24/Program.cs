using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem24
{
    class Program
    {
        /// <summary>
        /// https://projecteuler.net/problem=24
        /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
        /// 
        /// 012   021   102   120   201   210
        /// 
        /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const int maxNumber = 9;
            const int nth = 1000000;

            var numbers = new List<int>();
            for (int i = 0; i <= maxNumber; i++)
            {
                numbers.Add(i);
            }

            string result = "";
            var finalCount = numbers.Count;
            while (finalCount!=result.Length)
            {
                var nextNumber = GetNextNumberFromPermutation(numbers, nth);
                numbers.Remove(nextNumber);
                result += nextNumber;
            }

            Console.Out.WriteLine("result = {0}", result);
            Console.ReadKey();
        }

        static int GetNextNumberFromPermutation(ICollection<int> choices, int nth)
        {
            if (choices.Count == 1)
                return choices.First();

            int numberOfNumberChanges = CalculateFactorial(choices.Count-1);
            var index = (nth-1) / numberOfNumberChanges;
            return choices.ElementAt(index%choices.Count);
        }

        static int CalculateFactorial(int input)
        {
            var result = input;
            for ( var i = input - 1; i >= 1; i--)
            {
                result = result * i;
            }

            return result;
        }
    }
}
