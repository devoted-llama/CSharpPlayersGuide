using System;

namespace DiscountedInventory {
    class Program {
        static void Main(string[] args) {
            String[] items = { "Rope", "Torches", "Climbing Equipment", "Clean Water", "Machete", "Canoe", "Food Supplies" };

            for (int i = 0; i < items.Length; i++) {
                Console.WriteLine($"{i + 1} - {items[i]}");
            }

            Console.Write("What number do you want to see the price of? ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("What is your name? ");
            string customerName = Console.ReadLine();

            if (number < 1 || number > items.Length) {
                Console.WriteLine("Invalid number!");
                return;
            }

            float cost = number switch {
                1 => 10f,
                2 => 15f,
                3 => 25f,
                4 => 1f,
                5 => 20f,
                6 => 200f,
                7 => 1f,
                _ => -1f
            };

            if (customerName == "Llama") {
                cost *= 0.5f;
            }



            Console.WriteLine($"{items[number - 1]} cost {cost} gold.");
        }
    }
}
