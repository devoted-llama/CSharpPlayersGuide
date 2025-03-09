using System;
using System.ComponentModel.Design;

namespace TheFountainOfObjects;

public class Room {
    public (int,int) Coordinates { get; set; }
    public RoomType RoomType {get; set;} = RoomType.None;
    public string Description {get;set;} = "";
    public Room ((int,int)coordinates, RoomType roomType, string description) {
        Coordinates= coordinates;
        RoomType = roomType;
        Description = description;
    }
    public Room ((int,int)coordinates) {
        Coordinates= coordinates;
    }
}



