namespace Ex1;

public class Employee : User
{
    public override int maxRentals => 5;

    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
        
    }
}