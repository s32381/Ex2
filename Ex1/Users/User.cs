namespace Ex1;

public abstract class User
{
    private static int _idCounter = 1;

    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public abstract int maxRentals { get; }

    protected User(string firstName, string lastName)
    {
        Id = _idCounter++;
        FirstName = firstName;
        LastName = lastName;
    }
}