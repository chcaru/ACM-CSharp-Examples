using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstClassAsynchronousSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await Foo()).Wait();

            Console.ReadLine();
        }

        public static async Task Foo()
        {
            Console.WriteLine("Starting SomeOtherBigCall. (timeout 5000)");
            var background = SomeOtherBigCall(); //This call will run in background, it’s not blocking!

            Console.WriteLine("Starting A. (timeout 2000)");
            var a = Bar(2000);

            Console.WriteLine("Starting B. (timeout 1000)");
            var b = Bar(1000); //These two calls will run in parallel!

            var c = await a + await b; //Blocks thread until a and b are evaluated
            Console.WriteLine("Computed c as: {0}", c);

            await background;
        }

        public static async Task<int> Bar(int timeout)
        {
            //Not good practice, simply for the sake of example
            await Task.Run(() => Thread.Sleep(timeout));
            Console.WriteLine("Bar with timeout of {0} complete.", timeout);
            return timeout;
        }

        public static async Task SomeOtherBigCall()
        {
            await Bar(5000);
            Console.WriteLine("SomeOtherBigCall complete.");
        }
    }
}
