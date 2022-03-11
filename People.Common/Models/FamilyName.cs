namespace People.Common.Models;

internal class FamilyName : INameRecord
{
    public string Name { get; set; }
    public int Rank { get; set; }
    public int Total { get; set; }
    public decimal Per100K { get; set; }
}
