using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedImplicitVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            var simple = "some string literal";

            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            dictionary.Add("self", null);
        }
    }
}
