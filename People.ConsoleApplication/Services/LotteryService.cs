using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using People.Common.Services;
using System.Threading;
using System.Threading.Tasks;

namespace People.ConsoleApplication.Services;

public class LotteryService : BackgroundService
{
    private readonly ILogger<LotteryService> _logger;
    private readonly IPeopleService _people;

    public LotteryService(ILogger<LotteryService> logger, IPeopleService people)
    {
        _logger = logger;
        _people = people;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var winners = await _people.GetPersonsAsync(3);
            foreach (var person in winners)
            {
                _logger.LogInformation("Winner is: {Person}", person.FirstName + " " + person.LastName);
            }
            await Task.Delay(1000);
        }
    }
}
