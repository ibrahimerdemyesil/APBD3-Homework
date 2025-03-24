namespace APBD3Homework;

public class GasContainer : Containers, IHazardNotifier
{
    public bool IsHazardous { get; set; }
    public double Pressure { get; set; }

    public GasContainer(double mass, double height, double tareWeight, double depth, int maxPayload, bool isHazardous, double pressure) 
        : base(mass, height, tareWeight, depth, maxPayload)
    {
        this.IsHazardous = isHazardous;
        this.Pressure = pressure;
    }

    public void HazardousNotify(string message)
    {
        Console.WriteLine($"[ALERT] {SerialNum}: {message}");
    }

    public override void LoadCargo(double addedMass)
    {
        if (IsHazardous && (Mass + addedMass) > MaxPayload * 0.5)
        {
            HazardousNotify("Overfill detected for hazardous gas!");
            throw new OverfillException(SerialNum, MaxPayload * 0.5, Mass + addedMass);
        }
        else if (!IsHazardous && (Mass + addedMass) > MaxPayload * 0.9)
        {
            HazardousNotify("Overfill detected for safe gas!");
            throw new OverfillException(SerialNum, MaxPayload * 0.9, Mass + addedMass);
        }

        Mass += addedMass;
        Console.WriteLine($"Gas container {SerialNum} loaded with {addedMass} kg.");
    }

    public override void EmptyCargo()
    {
        Mass *= 0.05; 
        Console.WriteLine($"Gas container {SerialNum} emptied, 5% cargo remains.");
    }
    public override string ToString()
    {
        string hazard = IsHazardous ? "Hazardous" : "Safe";
        return $"[Gas] {SerialNum} | {hazard} | Pressure: {Pressure} atm | Mass: {Mass} kg | MaxPayload: {MaxPayload} kg";
    }

}