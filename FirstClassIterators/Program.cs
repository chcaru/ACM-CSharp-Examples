using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstClassIterators
{
    class Program
    {
        static void Main(string[] args)
        {
            //iterates over the enumerable 
            foreach (var n in Range(1000))
            {
                Console.WriteLine(n);
            }

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
