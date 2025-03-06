using System;
public class FourSisters : IDo {

    public void Do() {
        Console.WriteLine("Eggs gathered: ");
        int eggs = int.Parse(Console.ReadLine());

        int numberOfSisters = 4;

        float share = eggs / numberOfSisters;
        float remainder = eggs % numberOfSisters;

        Console.Write($"Number of eggs each of the {numberOfSisters} sisters gets is { share }\n");
        Console.Write($"Number of eggs the duckbear gets is { remainder }\n");
    }

}