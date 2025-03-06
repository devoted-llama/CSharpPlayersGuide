using System;
public class BuyingInventory : IDo {

    public void Do() {

        String[] items = { "Rope", "Torches", "Climbing Equipment", "Clean Water", "Machete", "Canoe", "Food Supplies" };

        for (int i = 0; i < items.Length; i++) {
            Console.WriteLine($"{i + 1} - {items[i]}");
        }

        Console.Write("What number do you want to see the price of? ");
        int number = int.Parse(Console.ReadLine());

        if (number < 1 || number > items.Length) {
            Console.WriteLine("Invalid number!");
            return;
        }

        int cost = number switch {
            1 => 10,
            2 => 15,
            3 => 25,
            4 => 1,
            5 => 20,
            6 => 200,
            7 => 1,
            _ => -1
        };



        Console.WriteLine($"{items[number - 1]} cost {cost} gold.");
    }



}