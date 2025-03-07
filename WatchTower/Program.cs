using System;

namespace WatchTower {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter the x position of the enemy.");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the y position of the enemy.");
            int y = int.Parse(Console.ReadLine());

            string xDirection = "", yDirection = "", direction = "";


            if (x > 0) {
                xDirection = "east";
            } else if (x < 0) {
                xDirection = "west";
            }

            if (y > 0) {
                yDirection = "north";
            } else if (y < 0) {
                yDirection = "south";
            }


            if (x == 0 && y == 0) {
                direction = "here";
            } else {
                direction = "to the " + yDirection + xDirection;
            }

            Console.WriteLine($"The enemy is {direction}!");
        }
    }
}
