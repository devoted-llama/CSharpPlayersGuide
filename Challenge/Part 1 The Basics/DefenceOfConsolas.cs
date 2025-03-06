using System;
public class DefenceOfConsolas : IDo {

    public void Do() {

        Console.Title = "Defence of Consolas";

        Console.Write("Target Row? ");
        int y = int.Parse(Console.ReadLine());

        Console.Write("Target Column? ");
        int x = int.Parse(Console.ReadLine());

        int leftX = x - 1;
        int leftY = y;

        int downX = x;
        int downY = y - 1;

        int rightX = x + 1;
        int rightY = y;

        int upX = x;
        int upY = y + 1;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.Red;


        Console.WriteLine("Deply to:");
        Console.WriteLine($"({leftX},{leftY})");
        Console.WriteLine($"({downX},{downY})");
        Console.WriteLine($"({rightX},{rightY})");
        Console.WriteLine($"({upX},{upY})");
        Console.Beep();
    }

}