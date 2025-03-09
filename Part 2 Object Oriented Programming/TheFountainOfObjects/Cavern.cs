using System;

namespace TheFountainOfObjects;

public class Cavern {
    public Room[,] Rooms { get; private set; }
    public int Width { get; }
    public int Height { get ; }

    public Cavern(int width, int height, Room[] specialRooms) {
        Width = width;
        Height = height;
        CreateRooms(specialRooms);
    }

    void CreateRooms(Room[] specialRooms) {
        Rooms = new Room[Width,Height];
        (int,int) coordinates;
        for(int x = 0;x < Width; x++) {
            for(int y = 0; y < Height; y ++) {
                coordinates = (x,y);
                Room room = new Room(coordinates);

                foreach (Room sr in specialRooms) {
                    if(sr.Coordinates == coordinates) {
                        room = sr;
                    }
                }
                
                Rooms[x,y] = room;
            }
        }
    }
}
