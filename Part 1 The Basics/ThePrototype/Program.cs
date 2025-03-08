using System;

namespace ThePrototype {
    class Program {
        static void Main(string[] args) {
            int number = AskForNumberInRange("User 1, enter a number between 0 and 100: ", 0, 100);

            Console.Clear();

            int guess;
            Console.WriteLine("User 2, guess the number.");
            do {
                Console.Write("What is your next guess? ");
                guess = int.Parse(Console.ReadLine());
                if (guess > number) {
                    Console.WriteLine($"{guess} is too high.");
                } else if (guess < number) {
                    Console.WriteLine($"{guess} is too low.");
                }
            }
            while (guess != number);
            Console.Write("You guessed the number!");

            int AskForNumberInRange(string text, int min, int max) {
                int number;
                do {
                    Console.WriteLine(text);
                    number = int.Parse(Console.ReadLine());

                } while (number < min || number > max);
                return number;
            }
        }

    }
}
