/*using System;
public class ArrowFactories : IDo {

    public void Do() {
        int answer;
        do {
            Console.WriteLine("Pick an option from the follow:");
            Console.WriteLine("1: Elite Arrow");
            Console.WriteLine("2: Beginner Arrow");
            Console.WriteLine("3: Marksman Arrow");
            Console.WriteLine("4: Custom Arrow");
            answer = int.Parse(Console.ReadLine());
        } while (answer < 1 && answer > 4);

        Arrow arrow;
        switch (answer) {
            case 1: arrow = Arrow.CreateEliteArrow(); break;
            case 2: arrow = Arrow.CreateBeginnerArrow(); break;
            case 3: arrow = Arrow.CreateMarksmanArrow(); break;
            case 4:
            default: arrow = DoCustomArrow(); break;
        }


        Console.WriteLine($"Cost will be: {arrow.GetCost()}");
    }

    Arrow DoCustomArrow() {
        Arrowhead arrowhead = Helper.GetEnumValueFromUser<Arrowhead>();
        Fletching fletching = Helper.GetEnumValueFromUser<Fletching>();
        int length = Helper.AskForNumberInRange("Pick a length between 60cm and 100cm", 60, 100);

        return new Arrow(arrowhead, fletching, length);
    }
}

class Arrow {
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private int _length;

    public Arrowhead ArrowHead => _arrowhead;
    public Fletching Fletching => _fletching;
    public int Length => _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, int length) {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost() {
        return (int)_arrowhead + (int)_fletching + _length * 0.05f;
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);
}
*/
