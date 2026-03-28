namespace Ex1;

public class Student : User
{
    public override int maxRentals => 2;

    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}