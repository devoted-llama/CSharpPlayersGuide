﻿/*using System;
public class VinFletchersArrows : IDo {

    public void Do() {
        Arrowhead arrowhead = Helper.GetEnumValueFromUser<Arrowhead>();
        Fletching fletching = Helper.GetEnumValueFromUser<Fletching>();
        int length = Helper.AskForNumberInRange("Pick a length between 60cm and 100cm", 60, 100);

        Arrow arrow = new Arrow(arrowhead, fletching, length);

        Console.WriteLine($"Cost will be: {arrow.GetCost()}");
    }
}

class Arrow {
    Arrowhead _arrowhead;
    Fletching _fletching;
    int _length;



    public Arrow(Arrowhead arrowhead, Fletching fletching, int length) {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost() {
        return (int)_arrowhead + (int)_fletching + _length * 0.05f;
    }
}*/


public enum Arrowhead { Steel = 10, Wood = 3, Obsidian = 5 }

public enum Fletching { Plastic = 10, TurkeyFeathers = 5, GooseFeathers = 3 }