using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace People.ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            
            // normally done by DI, but taking a short cut here.
            var repository = new People.Common.Services.PeopleRepository();
            var peopleService = new People.Common.Services.PeopleService(repository);

            var quantity = 10;
            var userInput = "q";

            do
            {
                Console.Clear();

                stopWatch.Restart();
                var people = await peopleService.GetPersonsAsync(quantity);
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
