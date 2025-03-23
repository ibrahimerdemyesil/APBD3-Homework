namespace APBD3Homework;

class Run
{
    public static void Main(string[] args)
    {
        LiquidContainer liquidContainer = new LiquidContainer(10, 2, 3, 4, 2, true);
        
        Console.WriteLine(liquidContainer.Mass);
        
    }
}