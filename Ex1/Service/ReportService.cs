namespace Ex1;

public class ReportService
{
    public void PrintReport(
        List<Device> devices,
        List<Rental> rentals)
    {
        Console.WriteLine("REPORT");

        Console.WriteLine($"Total equipment: {devices.Count}");

        Console.WriteLine($"Available: {devices.Count(d => d.isAvailable)}");

        Console.WriteLine($"Rented: {rentals.Count(r => !r.IsReturned)}");
    }
}