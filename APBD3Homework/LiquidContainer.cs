namespace APBD3Homework;

public class LiquidContainer : Containers, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double mass, double height, double tareWeight, double depth, int maxPayload, bool isHazardous) 
        : base(mass, height, tareWeight, depth, maxPayload)
    {
        this.IsHazardous = isHazardous;
    }

    public void HazardousNotify(string message)
    {
        Console.WriteLine($"[ALERT] {SerialNum}: {message}");
    }

    public override void LoadCargo(double addedMass)
    {
        if (IsHazardous && (Mass + addedMass) > MaxPayload * 0.5)
        {
            HazardousNotify("Overfill detected! Hazardous cargo cannot exceed 50% capacity.");
            throw new OverfillException(SerialNum, MaxPayload * 0.5, Mass + addedMass);
        }
        else if (!IsHazardous && (Mass + addedMass) > MaxPayload * 0.9)
        {
            HazardousNotify("Overfill detected! Safe cargo cannot exceed 90% capacity.");
            throw new OverfillException(SerialNum, MaxPayload * 0.9, Mass + addedMass);
        }

        Mass += addedMass;
        Console.WriteLine($"Container {SerialNum} loaded with {addedMass} kg.");
    }
    public override string ToString()
    {
        string hazard = IsHazardous ? "Hazardous" : "Safe";
        return $"[Liquid] {SerialNum} | {hazard} | Mass: {Mass} kg | MaxPayload: {MaxPayload} kg";
    }

}