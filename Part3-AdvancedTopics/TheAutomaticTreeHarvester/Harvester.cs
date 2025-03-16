using System;

namespace TheAutomaticTreeHarvester;

public class Harvester
{
    int _harvestCount = 0;
    Tree _tree;
    public Harvester(Tree tree) {
        _tree = tree;
        _tree.GrowEvent += OnTreeRipe;
    }

    void OnTreeRipe() {
        _harvestCount++;
        Console.WriteLine($"Harvested {_harvestCount} times.");
        _tree.Ripe = false;
    }
}
