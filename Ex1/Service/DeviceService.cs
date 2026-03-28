namespace Ex1;

public class DeviceService
{
    private List<Device> deviceList = new();

    public void AddDevice(Device device)
    {
        deviceList.Add(device);
    }

    public List<Device> GetAvailableDevices()
    {
        return deviceList
            .Where(d => d.isAvailable)
            .ToList();
    }

    public List<Device> GetAllDevices()
    {
        return deviceList;
    }
    public Device? GetDeviceById(int id)
    {
        return deviceList.FirstOrDefault(d => d.id == id);
    }
    public void MarkUnavailable(int id)
    {
        var device = GetDeviceById(id);

        if (device != null)
            device.MarkUnavailable();
    }
}