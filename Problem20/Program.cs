using System;
using System.Linq;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        /// <summary>
        /// https://projecteuler.net/problem=20
        /// n! means n × (n − 1) × ... × 3 × 2 × 1
        /// 
        /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
        /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
        /// 
        /// Find the sum of the digits in the number 100!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var bigInteger = new BigInteger(100);
            for (int i = 99; i != 0; i--)
            {
                bigInteger *= i;
            }

            var result = GetSumOfCharacters(bigInteger.ToString());
            Console.Out.WriteLine("result = {0}", result);
            Console.ReadKey();
        }

        private static int GetSumOfCharacters(string input)
        {
            return input.ToString().Sum(t => t - '0');
        }
    }
}
