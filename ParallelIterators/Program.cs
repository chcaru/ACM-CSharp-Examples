using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelIterators
{
    class Program
    {
        static void Main(string[] args)
        {

            Range(1000).AsParallel().ForAll(
                n => Console.WriteLine(n)
            );

            Console.ReadLine();
        }

        //returns the sequence 0, 1, 2, 3, ..., max
        public static IEnumerable<int> Range(int max)
        {
            var n = 0;
            while (n <= max)
            {
                yield return n++;
            }
        }

    }
}
