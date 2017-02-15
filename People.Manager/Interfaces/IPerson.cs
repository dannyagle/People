namespace People.Manager
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        bool IsMale { get; set; }
    }
}
