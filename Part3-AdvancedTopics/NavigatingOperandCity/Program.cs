// Code to test all operators

using System.ComponentModel;
using System.Net.Http.Headers;

BlockCoordinate startingCoords = new BlockCoordinate(4,3);
BlockOffset offset = new BlockOffset(2,0);
BlockCoordinate newCoords = startingCoords + offset;
Console.WriteLine(newCoords); // Should be 6,3

newCoords = startingCoords + Direction.East;
Console.WriteLine(newCoords); // Should be 4,4

Console.WriteLine($"{startingCoords[0]},{startingCoords[1]}"); // should be 4,3

try {
    Console.WriteLine(startingCoords[2]);
} catch (IndexOutOfRangeException){
    Console.WriteLine("Caught exception");
}

Console.WriteLine ((BlockOffset)Direction.South); // Should be 1,0

public enum Direction {North,East,South,West};
public record BlockOffset (int RowOffset, int ColumnOffset) {
    public static explicit operator BlockOffset(Direction d) {
        return d switch {
            Direction.North => new BlockOffset(-1,0),
            Direction.East => new BlockOffset(0,1),
            Direction.South => new BlockOffset(1,0),
            Direction.West => new BlockOffset(0,-1),
            _ => new BlockOffset(0,0)
        };
    } 
}
public record BlockCoordinate(int Row, int Column) {
    public static BlockCoordinate operator +(BlockCoordinate c, BlockOffset o) =>
        new BlockCoordinate(c.Row + o.RowOffset, c.Column + o.ColumnOffset);
    public static BlockCoordinate operator +(BlockOffset o, BlockCoordinate c) =>
        c + o;
    public static BlockCoordinate operator +(BlockCoordinate c, Direction d) {
        return d switch {
            Direction.North => c + new BlockOffset(-1,0),
            Direction.East => c + new BlockOffset(0,1),
            Direction.South => c + new BlockOffset(1,0),
            Direction.West => c + new BlockOffset(0,-1),
            _ => c
        };
    }
    public static BlockCoordinate operator +(Direction d, BlockCoordinate c) =>
        c + d;

    public double this[int number] {
        get {
            return number switch {
                0 => this.Row,
                1 => this.Column,
                _ => throw new IndexOutOfRangeException() 
            };
        }
    }
}