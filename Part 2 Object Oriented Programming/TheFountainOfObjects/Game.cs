using System;

namespace TheFountainOfObjects;

public class Game {
    public Position PlayerPosition { get; private set; }
    public Cavern Cavern { get; }

    private bool _fountainActive = false;

    public Game () {
        PlayerPosition = new Position(0,0);
        Cavern = new Cavern(3,3,new[] { 
            new Room((0,0),RoomType.Entrance,"You see light coming from the cavern entrance."),
            new Room((2,0),RoomType.FountainOfObjects,"You hear water dripping in this room. The Fountain of Objects is here!")
        });
    }

    public void Run () {
        var input = "";
        string command = "";
        Direction direction;
        string[] inputs;

        do {
            Console.WriteLine($"You are in the cavern at {(PlayerPosition.X,PlayerPosition.Y)}");
            ReadRoom();
            Console.Write("What do you want to do?");
            input = Console.ReadLine();
            
            if(input != null) {
                
                inputs = input.Split(" ");
                command = inputs[0];

                if(command == "move" && inputs.Length > 1) {
                    bool gotDirection = Enum.TryParse<Direction>(inputs[1],true,out direction);
                    if(gotDirection) {
                        Move(direction);
                    }
                } else if (input == "enable fountain") {
                    ActivateFountain();
                }
            }
            
        } while(command != "exit");
    }

    void ActivateFountain() {
        if(!_fountainActive) {
            Room room = Cavern.Rooms[PlayerPosition.X,PlayerPosition.Y];
            room.Description = "You hear the rushing waters from The Fountain of Objects. It has been reactivated!";
            _fountainActive = true;
        }
        
    }
     void Move(Direction direction) {
        Position newPosition;
        switch(direction) {
            case Direction.north : newPosition = new Position(PlayerPosition.X, PlayerPosition.Y-1); break;
            case Direction.east : newPosition = new Position(PlayerPosition.X+1, PlayerPosition.Y);break;
            case Direction.south : newPosition = new Position(PlayerPosition.X, PlayerPosition.Y+1);break;
            case Direction.west : newPosition = new Position(PlayerPosition.X-1, PlayerPosition.Y);break;
            default: newPosition = new Position(PlayerPosition.X, PlayerPosition.Y); break;
        }
        if(newPosition.X >= 0 && newPosition.X < Cavern.Width && newPosition.Y >= 0 && newPosition.Y < Cavern.Height) {
            PlayerPosition = newPosition;
        }
    }

     void ReadRoom() {
        Room room = Cavern.Rooms[PlayerPosition.X,PlayerPosition.Y];
        if(room.Description != "")
            Console.WriteLine(room.Description);
    }

}