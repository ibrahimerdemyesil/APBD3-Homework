namespace APBD3Homework;

public class RefrigeratedContainer : Containers
{
    public double Temperature { get; set; }
    public string ProductType { get; set; }
    public double RequiredTemperature { get; set; }

    public RefrigeratedContainer(
        double mass,
        double height,
        double tareWeight,
        double depth,
        int maxPayload,
        double temperature,
        string productType,
        double requiredTemperature)
        : base(mass, height, tareWeight, depth, maxPayload)
    {
        this.Temperature = temperature;
        this.ProductType = productType;
        this.RequiredTemperature = requiredTemperature;
    }

    public override void LoadCargo(double addedMass)
    {
        if (Temperature < RequiredTemperature)
        {
            throw new Exception($"[ERROR] {SerialNum}: Temperature too low for {ProductType}. Required: {RequiredTemperature}°C, Current: {Temperature}°C");
        }

        if (Mass + addedMass > MaxPayload * 0.9)
        {
            throw new OverfillException(SerialNum, MaxPayload * 0.9, Mass + addedMass);
        }

        Mass += addedMass;
        Console.WriteLine($"Refrigerated container {SerialNum} loaded with {addedMass} kg of {ProductType} at {Temperature}°C.");
    }

    public override void EmptyCargo()
    {
        Mass = 0;
        Console.WriteLine($"Refrigerated container {SerialNum} emptied.");
    }
    public override string ToString()
    {
        return $"[Refrigerated] {SerialNum} | Product: {ProductType} | Temp: {Temperature}°C (Required: {RequiredTemperature}°C) | Mass: {Mass} kg | MaxPayload: {MaxPayload} kg";
    }

}