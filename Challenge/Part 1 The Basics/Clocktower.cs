using System;
public class Clocktower : IDo {

    public void Do() {

        int number = int.Parse(Console.ReadLine());

        string output = "tock";

        if (number % 2 == 0) {
            output = "tick";
        }

        Console.WriteLine(output);
    }

}