namespace Ex1;

public class Rental
{
    public Device Device { get; }
    public User User { get; }
    

    public DateTime RentDate { get; }
    public DateTime DueDate { get; }

    public DateTime? ReturnDate { get; private set; }

    public decimal Penalty { get; private set; }

    public bool IsReturned => ReturnDate != null;

    public Rental(User user, Device device, int days)
    {
        User = user;
        Device =  device;

        RentDate = DateTime.Now;
        DueDate = RentDate.AddDays(days);
    }

    public void ReturnDevice()
    {
        ReturnDate = DateTime.Now;

        if (ReturnDate > DueDate)
        {
            var delayDays = (ReturnDate.Value - DueDate).Days;
            Penalty = delayDays * 10;
        }
    }
}