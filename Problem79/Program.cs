using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;

namespace Problem79
{
    class Program
    {
        /// <summary>
        /// https://projecteuler.net/problem=79
        /// A common security method used for online banking is to ask the user for three random characters from a passcode. For example, if the passcode was 531278, they may ask for the 2nd, 3rd, and 5th characters; the expected reply would be: 317.
        /// 
        /// The text file, keylog.txt, contains fifty successful login attempts.
        /// 
        /// Given that the three characters are always asked for in order, analyse the file so as to determine the shortest possible secret passcode of unknown length.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] ruleDefinitions = new[]{"319","680","180","690","129","620","762","689","762","318","368","710","720","710","629","168","160","689","716","731","736","729","316","729","729","710","769","290","719","680","318","389","162","289","162","718","729","319","790","680","890","362","319","760","316","729","380","319","728","716"};
            var rules= ruleDefinitions.Select(ruleDefinition => new Rule(ruleDefinition)).ToList();

            int number = CreateFirstNumber(GetCountOfUniqueNumbers(ruleDefinitions));

            var sw = Stopwatch.StartNew();
            while (rules.Any(t => !t.DoesRulePass(number.ToString())))
            {
                number++;
            }
            sw.Stop();
            Console.Out.WriteLine("number = {0}", number);
            Console.Out.WriteLine("sw = {0}", sw.Elapsed);
            Console.ReadKey();
        }

        static int GetCountOfUniqueNumbers(IEnumerable<string> ruleDefinitions)
        {
            return ruleDefinitions.SelectMany(t => t.ToCharArray()).Distinct().Count();
        }

        static int CreateFirstNumber(int lenght)
        {
            int result = 1;
            for (int i = 1; i < lenght; i++)
            {
                result *= 10;
            }

            return result;
        }
    }
}
