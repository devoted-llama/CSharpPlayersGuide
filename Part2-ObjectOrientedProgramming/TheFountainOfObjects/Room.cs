using System;
using System.ComponentModel.Design;

namespace TheFountainOfObjects;

public class Room {
    public Position Position { get; set; }
    public RoomType RoomType {get; set;} = RoomType.None;
    public string Description {get;set;} = "";
    public Room (Position position, RoomType roomType, string description) {
        Position = position;
        RoomType = roomType;
        Description = description;
    }
    public Room (Position position) {
        Position = position;
    }
}



