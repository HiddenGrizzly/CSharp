using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> temperatures = new List<double>();

        temperatures.Add(23.5);
        temperatures.Add(26.8);
        temperatures.Add(24.0);
        temperatures.Add(22.3);
        temperatures.Add(27.5);

        Console.WriteLine($"Number of temperatures equal or exceeding 25 degrees: {GreaterCount(temperatures, 25)}");
    }
    static int GreaterCount(IEnumerable enumerable, double min)
    {
        int count = 0;
        foreach (object value in enumerable)
        {
            if (value is double && (double)value >= min)
            {
                count++;
            }
        }
        return count;
    }
}

