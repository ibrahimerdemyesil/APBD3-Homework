using System;

namespace APBD3Homework;

public class OverfillException : Exception
{
    public OverfillException(string serialNum, double maxCapacity, double attemptedLoad)
        : base($"ERROR: {serialNum} - Attempted to load {attemptedLoad} kg, but max capacity is {maxCapacity} kg.")
    {
    }
}