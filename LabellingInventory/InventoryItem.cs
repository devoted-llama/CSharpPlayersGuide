using System;
namespace LabellingInventory {
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
        public override string ToString() {
            return "Arrow";
        }
    }
    public class Bow : InventoryItem {
        public Bow() : base(1f, 4f) { }
        public override string ToString() {
            return "Bow";
        }
    }
    public class Rope : InventoryItem {
        public Rope() : base(1f, 1.5f) { }
        public override string ToString() {
            return "Rope";
        }
    }
    public class Water : InventoryItem {
        public Water() : base(2f, 3f) { }
        public override string ToString() {
            return "Water";
        }
    }
    public class Food : InventoryItem {
        public Food() : base(1f, 0.5f) { }
        public override string ToString() {
            return "Food";
        }
    }
    public class Sword : InventoryItem {
        public Sword() : base(5f, 3f) { }
        public override string ToString() {
            return "Sword";
        }
    }
}
