using System;
public class TheMagicCannon : IDo {

    public void Do() {
        string type;
        for (int i = 1; i <= 100; i++) {
            type = "Normal";
            Console.ResetColor();
            if (i % 3 == 0 && i % 5 != 0) {
                type = "Fire";
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (i % 3 != 0 && i % 5 == 0) {
                type = "Electric";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (i % 3 == 0 && i % 5 == 0) {
                type = "Combined";
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            Console.WriteLine($"{i}: {type}");
        }

    }

}