namespace Ex1;

public class Camera : Device
{
    public int resolution { get; set; }
    public bool hasFlash { get; set; }
    
    public Camera(string name, int resolution, bool hasFlash) : base(name)
    {
        this.resolution = resolution;
        this.hasFlash = hasFlash;
        
    }
}