// See https://aka.ms/new-console-template for more information
ColouredItem<Sword> blueSword = new(ConsoleColor.Blue);
ColouredItem<Bow> redBow = new(ConsoleColor.Red);
ColouredItem<Axe> greenAxe = new(ConsoleColor.Green);

blueSword.Display();
redBow.Display();
greenAxe.Display();

public class Sword {}
public class Bow {}
public class Axe {}

public class ColouredItem<T> where T : new() {
    public T Item { get ; }
    public ConsoleColor Colour { get ; }
    public ColouredItem(ConsoleColor colour) {
        Item = new T();
        Colour = colour;
    }

    public void Display() {
        Console.ForegroundColor = Colour;
        Console.WriteLine($"{Item}");
    }
}
