using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{

    class Question 
    {
        public int Number { get; set; }
        public bool Correct { get; private set; }

        public void Grade()
        {
            this.Correct = Program.random.NextDouble() >= .5;
        }
    }

    class Paper
    {
        public string Name { get; set; }
        public double Score { get; private set; }
        public IEnumerable<Question> Questions { get; private set; }

        public Paper(string name, IEnumerable<Question> questions)
        {
            this.Name = name;
            this.Questions = questions;
        }

        public Paper Grade()
        {
            foreach (var question in this.Questions)
            {
                question.Grade();
            }

            this.Score = this.Questions.Where(q => q.Correct).Count() / (double)this.Questions.Count();

            return this;
        }
    }

    class Program
    {

        internal static Random random = new Random();

        static void Main(string[] args)
        {
            //Create the paper questions
            var paperQuestions =
                Enumerable.Range(1, 50)
                .Select(i => new Question
                {
                    Number = i
                });

            //Create the papers. Let's make a large sample size, say.... 1000
            var papers =
                Enumerable.Range(1, 1000)
                .Select(i => new Paper(MakeRandomName(), paperQuestions.ToArray()));

            //Code from slide.
            var gradedPapersGroups = papers
                .Select(p => p.Grade())
                .Where(p => p.Score < 70 && !p.Questions.ElementAt(6).Correct)
                .GroupBy(p => p.Name.FirstOrDefault())
                .Select(g => g.OrderByDescending(p => p.Score).Reverse());

            //Print out the result
            foreach (var gradedPaperGroup in gradedPapersGroups)
            {
                foreach (var gradePaper in gradedPaperGroup)
                {
                    Console.WriteLine("{0}: {1}", gradePaper.Name, (int)(gradePaper.Score * 100));
                }

                Console.WriteLine("\n");
            }

            Console.ReadLine();
        }

        //Simply makes a random string to serve as a name
        static string MakeRandomName()
        {
            var nameLength = random.Next(3, 8);

            return
                new String(
                    Enumerable.Range(0, nameLength)
                    .Select(i => (char)random.Next(97, 123))
                    .ToArray());
        }
    }
}
