using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var chris = new 
            {
	            StudentName = "Chris Caruso",
	            Grade = 97
            };

            var kevin = new 
            {
	            StudentName = "Kevin Lockwood",
	            Grade = 89
            }; 	

            //Strongly typed array of anonymous types
            var students = new[] { chris, kevin };

            var me = students[0].StudentName; //me is "Chris Caruso"

            Console.WriteLine(me + "\n");

            foreach (var student in students)
            {
                Console.WriteLine("{0} is {1}", student.StudentName, student.Grade);
            }

            Console.ReadLine();
        }
    }
}
