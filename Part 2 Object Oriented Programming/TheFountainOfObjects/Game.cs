using System;
using System.Linq.Expressions;
using System.Windows.Input;

namespace TheFountainOfObjects;

public class Game {
    Position _playerPosition;
    public Position PlayerPosition { 
        get => _playerPosition; 
        set {
            if(value.X >= 0 && value.X < Cavern.Width && value.Y >= 0 && value.Y < Cavern.Height) {
                _playerPosition = value;
            }
        } 
    }
    public Cavern Cavern { get; }

    public bool FountainActive {get;set;} = false;
    private bool _hasWon = false;
    public Room? CurrentRoom {get {
        return Cavern.GetRoom(PlayerPosition);
    }}

    IGameCommand _gameCommand;

    public Game () {
        Cavern = new Cavern(3,3,new[] { 
            new Room(new Position(0,0),RoomType.Entrance,"You see light coming from the cavern entrance."),
            new Room(new Position(2,0),RoomType.FountainOfObjects,"You hear water dripping in this room. The Fountain of Objects is here!")
        });
        PlayerPosition = new Position(0,0);
    }

    public void Run () {
        do {
            Console.WriteLine($"You are in the cavern at {(PlayerPosition.X,PlayerPosition.Y)}");
            DoWinCheck();
            
            if(_hasWon) {
                return;
            } else { 
                ReadRoom();
                Console.Write("What do you want to do? ");
                GetCommand();
                RunCommand();
            }
        } while(true);
    }

    void GetCommand() {
        var input = Console.ReadLine();
        switch(input) {
            case "move north": _gameCommand = new MoveNorthCommand(); break;
            case "move east": _gameCommand = new MoveEastCommand(); break;
            case "move south": _gameCommand = new MoveSouthCommand(); break;
            case "move west": _gameCommand = new MoveWestCommand(); break;
            case "enable fountain": _gameCommand = new EnableFountainCommand(); break;
            case "exit" : _gameCommand = new ExitCommand(); break;
        }
    }

    void RunCommand() {
        _gameCommand.Run(this);
    }

    void DoWinCheck() {
        if(!_hasWon && FountainActive && CurrentRoom?.RoomType == RoomType.Entrance) {
            _hasWon = true;
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.WriteLine("You win!");
        }
    }

    public void Move(Direction direction) {
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
        Room? room = Cavern.GetRoom(PlayerPosition);
        if(room!=null && room.Description != "")
            Console.WriteLine(room.Description);
    } 

}