using System;
public class PackingInventory : IDo {
    Pack pack;
    public void Do() {
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
                Console.WriteLine($"Pack item count: {pack.Count}/{pack.MaxItems}");
                Console.WriteLine($"Pack total weight: {pack.TotalWeight}/{pack.MaxWeight}");
                Console.WriteLine($"Pack total volume: {pack.TotalVolume}/{pack.MaxVolume}");
            }
        } while (added);

    }
}

public class InventoryItem {
    public float Weight { get; private set; }
    public float Volume { get; private set; }

    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem {
    public Arrow() : base(0.1f, 0.05f) { }
}
public class Bow : InventoryItem {
    public Bow() : base(1f, 4f) { }
}
public class Rope : InventoryItem {
    public Rope() : base(1f, 1.5f) { }
}
public class Water : InventoryItem {
    public Water() : base(2f, 3f) { }
}
public class Food : InventoryItem {
    public Food() : base(1f, 0.5f) { }
}
public class Sword : InventoryItem {
    public Sword() : base(5f, 3f) { }
}

public class Pack {
    public int MaxItems { get; private set; }
    public float MaxWeight { get; private set; }
    public float MaxVolume { get; private set; }
    private InventoryItem[] _items;

    public float TotalWeight {
        get {
            float weight = 0f;
            foreach (InventoryItem item in _items) {
                if (item != null)
                    weight += item.Weight;

            }
            return weight;
        }
    }

    public float TotalVolume {
        get {
            float volume = 0f;
            foreach (InventoryItem item in _items) {
                if (item != null)
                    volume += item.Volume;
            }
            return volume;
        }
    }

    public int Count {
        get {
            int count = 0;
            foreach (InventoryItem item in _items) {
                if (item != null)
                    count++;
            }
            return count;
        }
    }

    public Pack(int maxItems, float maxWeight, float maxVolume) {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        _items = new InventoryItem[maxItems];
    }

    public bool Add(InventoryItem item) {
        if (Count < MaxItems && TotalWeight + item.Weight < MaxWeight && TotalVolume + item.Volume < MaxVolume) {
            _items[Count] = item;
            return true;
        }
        return false;
    }
}