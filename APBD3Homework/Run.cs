using System;
using System.Collections.Generic;

namespace APBD3Homework;

class Run
{
    public static void Main(string[] args)
    {
        try
        {
            ContainerShip ship1 = new ContainerShip("Titanic", 30, 5, 50);
            ContainerShip ship2 = new ContainerShip("Poseidon", 25, 5, 50);

            LiquidContainer container1 = new LiquidContainer(500, 200, 100, 300, 1000, false);
            GasContainer container2 = new GasContainer(200, 150, 80, 250, 500, true, 10);
            RefrigeratedContainer container3 = new RefrigeratedContainer(300, 180, 90, 280, 800, -5, "Banana", -10);
            RefrigeratedContainer container4 = new RefrigeratedContainer(400, 180, 90, 280, 800, -12, "Fish", -15);
            RefrigeratedContainer container5 = new RefrigeratedContainer(200, 180, 90, 280, 600, -8, "Meat", -10);

            ship1.AddContainers(new List<Containers> { container1, container2, container3 });

            ship1.PrintContainers();

            ship1.ReplaceContainer(1, container4);

            ship1.TransferContainer(ship2, container3);

            ship2.AddContainers(new List<Containers> { container5 });

            Console.WriteLine("\n--- Final Cargo Status ---\n");
            ship1.PrintContainers();
            ship2.PrintContainers();
        }
        catch (Exception ex)
        {
            Console.WriteLine($" ERROR: {ex.Message}");
        }
    }
}