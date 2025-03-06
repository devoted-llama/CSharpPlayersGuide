using System;
public class TheColour : IDo {

    public void Do() {
        Colour c1 = new Colour(60, 100, 200);
        Colour c2 = Colour.Purple;

        Console.WriteLine($"C1 RGB: ({c1.R},{c1.G},{c1.B})");
        Console.WriteLine($"C2 RGB: ({c2.R},{c2.G},{c2.B})");
    }


}

public class Colour {
    private int _red;
    public int R => _red;

    private int _green;
    public int G => _green;

    private int _blue;
    public int B => _blue;

    public static Colour White => new Colour(255, 255, 255);
    public static Colour Black => new Colour(0, 0, 0);
    public static Colour Red => new Colour(255, 0, 0);
    public static Colour Orange => new Colour(255, 165, 0);
    public static Colour Yellow => new Colour(255, 255, 0);
    public static Colour Green => new Colour(0, 128, 0);
    public static Colour Blue => new Colour(0, 0, 255);
    public static Colour Purple => new Colour(128, 0, 128);

    public Colour(int red, int green, int blue) {
        _red = red;
        _green = green;
        _blue = blue;
    }
}