namespace APBD3Homework;

public class Containers : IContainerInterface
{
    public double Mass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    private static int IdCounter = 0;
    public int Id { get; private set; }
    public static string Type { get; set; }
    public string SerialNum { get; private set; }
    public int MaxPayload { get; set; }

    public Containers(double mass, double height, double tareWeight, double depth, int maxPayload)
    {
        Id = IdCounter++;
        this.Mass = mass;
        this.Height = height;
        this.TareWeight = tareWeight;
        this.Depth = depth;
        this.MaxPayload = maxPayload;
        this.SerialNum = $"KNO--{Type}--{Id}";
    }

    public virtual void EmptyCargo()
    {
        Console.WriteLine($"Container {SerialNum} emptied.");
        Mass = 0;
    }

    public virtual void LoadCargo(double addedMass)
    {
        Console.WriteLine($"Loading {addedMass} kg into {SerialNum}.");
    }
    public override string ToString()
    {
        return $"[Container] {SerialNum} | Mass: {Mass} kg | Height: {Height} cm | Tare: {TareWeight} kg | Depth: {Depth} cm | MaxPayload: {MaxPayload} kg";
    }

}