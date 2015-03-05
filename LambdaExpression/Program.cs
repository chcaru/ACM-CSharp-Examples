using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    class Program
    {
        public static void Foo()
        {
            var x = 22;

            var z = Run(
                (y) =>
                {
                    return x + y;
                },
                20); //z will be 42

            Console.WriteLine(z);

            Console.ReadLine();
        }

        public static int Run(Func<int, int> func, int value)
        {
            return func(value);
        }

        static void Main(string[] args)
        {
            Foo();
        }
    }
}
