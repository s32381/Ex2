namespace Ex1;

public class Laptop : Device
{
    public string cpu {get; set;}
    public int ram {get; set;}

    public Laptop(string name, string cpu, int ram) : base(name)
    {
        this.cpu = cpu;
        this.ram = ram;
    }
   
}