// Code to test all operators

BlockCoordinate startingCoords = new BlockCoordinate(4,3);
BlockOffset offset = new BlockOffset(2,0);
BlockCoordinate newCoords = startingCoords + offset;
if(newCoords.Row == 6 && newCoords.Column == 3) Console.WriteLine($"Pass. Got {newCoords}."); 
else Console.WriteLine($"Fail. Got {newCoords}.");


newCoords = startingCoords + Direction.East;
if(newCoords.Row == 4 && newCoords.Column == 4) Console.WriteLine($"Pass. Got {newCoords}."); 
else Console.WriteLine($"Fail. Got {newCoords}.");

public enum Direction {North,East,South,West};
public record BlockOffset (int RowOffset, int ColumnOffset);
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
}