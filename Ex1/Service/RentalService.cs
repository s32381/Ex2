namespace Ex1;

public class RentalService
{
    private List<Rental> rentals = new();

    public bool RentDevice(User user, Device device, int days)
    {
        if (!device.isAvailable)
            return false;

        int activeRentals = rentals.Count(r =>
            r.User == user &&
            !r.IsReturned);

        if (activeRentals >= user.maxRentals)
            return false;

        var rental = new Rental(user, device, days);

        rentals.Add(rental);

        device.MarkUnavailable();

        return true;
    }

    public decimal ReturnDevice(Rental rental)
    {
        rental.ReturnDevice();

        rental.Device.MarkAvailable();

        return rental.Penalty;
    }

    public List<Rental> GetActiveRentals()
    {
        return rentals
            .Where(r => !r.IsReturned)
            .ToList();
    }

    public Rental? GetRentalByDeviceId(int id)
    {
        return rentals
            .FirstOrDefault(r =>
                r.Device.id == id &&
                !r.IsReturned);
    }

    public List<Rental> GetOverdueRentals()
    {
        return rentals
            .Where(r =>
                !r.IsReturned &&
                DateTime.Now > r.DueDate)
            .ToList();
    }

    public List<Rental> GetUserActiveRentals(User user)
    {
        return rentals
            .Where(r =>
                r.User == user &&
                !r.IsReturned)
            .ToList();
    }

    public List<Rental> GetAllRentals()
    {
        return rentals;
    }
}