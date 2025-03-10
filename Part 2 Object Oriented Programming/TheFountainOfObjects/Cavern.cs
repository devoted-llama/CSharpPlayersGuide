using System;

namespace TheFountainOfObjects;

public class Cavern {
    
     
    Room[,] _rooms;
    public int Width { get; }
    public int Height { get ; }

    public Cavern(int width, int height, Room[] specialRooms) {
        Width = width;
        Height = height;
        _rooms = new Room[Width,Height];
        CreateRooms(specialRooms);
    }

    public Room? GetRoom(Position position) {
        int x = position.X; int y = position.Y;
        if(position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height)
            return _rooms[x,y];
        return null;
    }

    public Room[] Get8AdjacentRooms(Position position) {
        Room[] rooms = new Room[8];
        int i = 0;
        for(int x = 0;x < Width; x++) {
            for(int y = 0; y < Height; y ++) {
                if(((x == position.X+1 || x == position.X || x == position.X-1) && (y == position.Y+1 || y == position.Y-1)) ||
                    ((x == position.X+1 || x == position.X-1) && (y == position.Y+1 || y == position.Y || y == position.Y-1))) {
                    rooms[i++] = _rooms[x,y];
                }
            }
        }
        return rooms;
    }

    void CreateRooms(Room[] specialRooms) {
        Position position;
        for(int x = 0;x < Width; x++) {
            for(int y = 0; y < Height; y ++) {
                position = new Position(x,y);
                Room room = new Room(position);

                foreach (Room sr in specialRooms) {
                    if(sr.Position.Equals(position)) {
                        room = sr;
                    }
                }
                
                _rooms[x,y] = room;
            }
        }
    }
}
