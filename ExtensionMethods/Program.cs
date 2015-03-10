using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    static class Randomization
    {
        private static readonly Random RandomGenerator = new Random();

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(t => RandomGenerator.Next());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 20);

            var shuffledNumbers = numbers.Shuffle();

            foreach (var number in shuffledNumbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
