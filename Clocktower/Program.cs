using System;

namespace Clocktower {
    class Program {
        static void Main(string[] args) {
            int number = int.Parse(Console.ReadLine());

            string output = "tock";

            if (number % 2 == 0) {
                output = "tick";
            }

            Console.WriteLine(output);
        }
    }
}
