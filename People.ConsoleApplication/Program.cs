using System;
using System.Diagnostics;

namespace People.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            
            // normally done by DI, but taking a short cut here.
            var resource = new People.Common.PeopleResource();
            var engine = new People.Common.PeopleEngine(resource);
            var manager = new People.Common.PeopleManager(engine);

            var quantity = 10;
            var userInput = "q";

            do
            {
                Console.Clear();

                stopWatch.Restart();
                var people = manager.GetPersons(quantity);
                stopWatch.Stop();

                Console.WriteLine($"Generated {quantity} people in {stopWatch.ElapsedMilliseconds} milliseonds");
                Console.WriteLine();

                if (quantity <= 20)
                {
                    foreach (var person in people)
                    {
                        Console.WriteLine($"{person.FullName}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }

                Console.WriteLine("Press 'q' to quit, Enter to search again, or a number and Enter to get a different quantity.");
                userInput = Console.ReadLine();

                if (userInput != string.Empty)
                    int.TryParse(userInput, out quantity);

            } while (userInput != "q");
        }
    }
}
