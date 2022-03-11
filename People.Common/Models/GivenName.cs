namespace People.Common.Models;

internal class GivenName : INameRecord
{
    public string Name { get; set; }
    public decimal Frequency { get; set; }
}
