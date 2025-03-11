using System;

namespace LabellingInventory {
    class Program {
        static Pack pack;
        static void Main(string[] args) {
            int answer;
            InventoryItem item;
            pack = new Pack(10, 20, 20);
            bool added = false;
            do {
                do {
                    Console.WriteLine("Pick an option from the follow:");
                    Console.WriteLine("1: Arrow");
                    Console.WriteLine("2: Bow");
                    Console.WriteLine("3: Rope");
                    Console.WriteLine("4: Water");
                    Console.WriteLine("5: Food");
                    Console.WriteLine("6: Sword");
                    answer = int.Parse(Console.ReadLine());
                } while (answer < 1 && answer > 6);


                switch (answer) {
                    case 1: item = new Arrow(); break;
                    case 2: item = new Bow(); break;
                    case 3: item = new Rope(); break;
                    case 4: item = new Water(); break;
                    case 5: item = new Food(); break;
                    case 6: item = new Sword(); break;
                    default: return;
                }

                Console.WriteLine($"Item: {item}, Weight: {item.Weight}, Volume: {item.Volume}");
                added = pack.Add(item);
                if (!added) {
                    Console.WriteLine($"Item not added to pack. ");
                    printPackTotals();
                    return;
                }
                Console.WriteLine($"Added to pack.");
                printPackTotals();

                void printPackTotals() {
                    Console.WriteLine(pack.ToString());
                    Console.WriteLine($"Pack item count: {pack.Count}/{pack.MaxItems}");
                    Console.WriteLine($"Pack total weight: {pack.TotalWeight:#.##}/{pack.MaxWeight:#.##}");
                    Console.WriteLine($"Pack total volume: {pack.TotalVolume:#.##}/{pack.MaxVolume:#.##}\n");
                }
            } while (added);
        }
    }
}
