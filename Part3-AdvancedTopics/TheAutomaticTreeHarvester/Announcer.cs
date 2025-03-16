using System;
using System.Diagnostics.Contracts;

namespace TheAutomaticTreeHarvester;

public class Announcer
{

    public Announcer(Tree tree) {
        tree.GrowEvent += OnTreeRipe;
    }

    void OnTreeRipe() {
        Console.WriteLine("The tree is ripe.");
    }
}
