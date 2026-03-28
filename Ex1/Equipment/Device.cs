namespace Ex1;

public abstract class Device
{
    private static int _idCounter = 1;

    public int id { get; }
    public string Name { get; }
    public bool isAvailable { get; protected set; } = true;

    public Device(string name)
    {
        id = _idCounter++;
        Name = name;
    }

    public void MarkUnavailable()
    {
        isAvailable = false;
    }
    
    public void MarkAvailable()
    {
        isAvailable = true;
    }
}