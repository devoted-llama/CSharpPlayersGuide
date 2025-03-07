using System;
namespace LabellingInventory {
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

        public override string ToString() {
            string s = "Pack containing";
            string itemS = "";
            foreach (InventoryItem item in _items) {
                if (item != null)
                    itemS += " " + item.ToString();
            }
            if (itemS == "") itemS = " nothing";
            return s + itemS;
        }
    }
}
