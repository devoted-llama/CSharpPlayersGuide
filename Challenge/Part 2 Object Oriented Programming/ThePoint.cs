using System;
public class ThePoint : IDo {

    public void Do() {
        Point p1 = new Point(2, 3);
        Point p2 = new Point(-4, 0);
        Console.WriteLine($"({p1.X}, {p1.Y})");
        Console.WriteLine($"({p2.X}, {p2.Y})");
    }


}

public class Point {
    private int _x;
    private int _y;
    public int X => _x;
    public int Y => _y;

    public Point(int x, int y) {
        _x = x;
        _y = y;
    }

    public Point() {
        _x = _y = 0;
    }
}