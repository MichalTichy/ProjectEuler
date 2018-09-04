using System;
using System.Linq;
using System.Numerics;

namespace Problem20
{
    class Program
    {
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
