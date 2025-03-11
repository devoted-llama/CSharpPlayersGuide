using System;

namespace DominionOfKings {
    class Program {
        static void Main(string[] args) {
            int estateMultiplier = 1;
            int duchyMultiplier = 3;
            int provinceMultiplier = 6;

            Console.Write("Enter provinces: ");
            int provinces = int.Parse(Console.ReadLine());

            Console.Write("Enter duchies: ");
            int duchies = int.Parse(Console.ReadLine());

            Console.Write("Enter estates: ");
            int estates = int.Parse(Console.ReadLine());

            int provinceScore = provinces * provinceMultiplier;
            int duchyScore = duchies * duchyMultiplier;
            int estateScore = estates * estateMultiplier;
            int totalScore = provinceScore + duchyScore + estateScore;

            Console.Write($"Total score is {totalScore}");
        }
    }
}
