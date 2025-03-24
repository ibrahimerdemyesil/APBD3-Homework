using System;
using System.Collections.Generic;

namespace APBD3Homework;

public class ContainerShip
{
    public string Name { get; private set; }
    public double MaxSpeed { get; private set; } 
    public int MaxContainerCapacity { get; private set; }
    public double MaxWeightCapacity { get; private set; } 
    private List<Containers> ContainersOnBoard;

    public ContainerShip(string name, double maxSpeed, int maxContainerCapacity, double maxWeightCapacity)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxWeightCapacity = maxWeightCapacity * 1000; 
        ContainersOnBoard = new List<Containers>();
    }

    public void AddContainer(Containers container)
    {
        if (ContainersOnBoard.Count >= MaxContainerCapacity)
        {
            throw new Exception($" {Name} has reached its container limit of {MaxContainerCapacity}!");
        }

        double totalWeight = GetTotalWeight() + container.Mass;
        if (totalWeight > MaxWeightCapacity)
        {
            throw new Exception($" {Name} cannot exceed {MaxWeightCapacity / 1000} tons! Current: {totalWeight / 1000} tons.");
        }

        ContainersOnBoard.Add(container);
        Console.WriteLine($" Container {container.SerialNum} added to {Name}.");
    }

    public void AddContainers(List<Containers> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }

    public void RemoveContainer(Containers container)
    {
        if (ContainersOnBoard.Remove(container))
        {
            Console.WriteLine($" Container {container.SerialNum} removed from {Name}.");
        }
        else
        {
            Console.WriteLine($" Container {container.SerialNum} not found on {Name}.");
        }
    }

    public void ReplaceContainer(int index, Containers newContainer)
    {
        if (index < 0 || index >= ContainersOnBoard.Count)
        {
            Console.WriteLine("Invalid container index.");
            return;
        }

        double totalWeight = GetTotalWeight() - ContainersOnBoard[index].Mass + newContainer.Mass;
        if (totalWeight > MaxWeightCapacity)
        {
            Console.WriteLine($"Cannot replace container. Weight limit exceeded: {totalWeight / 1000} tons");
            return;
        }

        var oldContainer = ContainersOnBoard[index];
        ContainersOnBoard[index] = newContainer;
        Console.WriteLine($"Replaced container {oldContainer.SerialNum} with {newContainer.SerialNum} on {Name}.");
    }

    public void TransferContainer(ContainerShip targetShip, Containers container)
    {
        if (!ContainersOnBoard.Contains(container))
        {
            Console.WriteLine($" Container {container.SerialNum} not found on {Name}.");
            return;
        }

        try
        {
            targetShip.AddContainer(container);
            RemoveContainer(container);
            Console.WriteLine($" Container {container.SerialNum} transferred from {Name} to {targetShip.Name}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($" Transfer failed: {e.Message}");
        }
    }

    public double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in ContainersOnBoard)
        {
            totalWeight += container.Mass;
        }
        return totalWeight;
    }
    
    public void PrintContainers()
    {
        Console.WriteLine($" {Name} contains {ContainersOnBoard.Count}/{MaxContainerCapacity} containers:");
        for (int i = 0; i < ContainersOnBoard.Count; i++)
        {
            Console.WriteLine($"  {i}. {ContainersOnBoard[i]}");
        }
    }

}
