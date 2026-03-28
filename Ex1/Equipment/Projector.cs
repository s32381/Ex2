namespace Ex1;

public class Projector : Device
{
    public int lumens { get; set; }
    public bool wireless { get; set; }

    public Projector(string name, int lumens, bool wireless) : base(name)
    {
        this.lumens = lumens;
        this.wireless = wireless;
    }
}