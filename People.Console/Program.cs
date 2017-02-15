using System.Diagnostics;

namespace People.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var resource = new People.Manager.PeopleResource();
            var stopWatch = new Stopwatch();

            var quantity = 10;

            do
            {
                stopWatch.Restart();
                var people = resource.GetPersons(quantity);
                stopWatch.Stop();

                System.Console.WriteLine("Generated {0} people in {1} milliseonds", quantity, stopWatch.ElapsedMilliseconds);
                var ts = stopWatch.ElapsedMilliseconds;

                if (quantity <= 20)
                {
                    System.Console.WriteLine();
                    foreach (var person in people)
                    {
                        System.Console.WriteLine("{0}, {1}", person.LastName, person.FirstName);
                    }
                    System.Console.WriteLine();
                    System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }

                System.Console.WriteLine("Press 'q' to quit or any other key for another batch.");

            } while (System.Console.ReadLine() != "q");


        }
    }
}
