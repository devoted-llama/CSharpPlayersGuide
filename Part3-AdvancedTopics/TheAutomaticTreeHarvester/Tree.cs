using System;

namespace TheAutomaticTreeHarvester;

public class Tree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action? GrowEvent;

    public void TryGrow() {
        if(_random.NextDouble() < 0.000000001 && !Ripe) {
            Ripe = true;
            GrowEvent?.Invoke();
        }
    }
}
