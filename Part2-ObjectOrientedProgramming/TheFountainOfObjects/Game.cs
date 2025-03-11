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
    private bool _hasLost= false;
    public Room? CurrentRoom {get {
        return Cavern.GetRoom(PlayerPosition);
    }}

    public int ArrowCount {get;set;} = 5;

    IGameCommand? _gameCommand;

    public Game () {
        Cavern = new Cavern(3,3,new[] { 
            new Room(new Position(0,0),RoomType.Entrance,"You see light coming from the cavern entrance."),
            new Room(new Position(2,0),RoomType.FountainOfObjects,"You hear water dripping in this room. The Fountain of Objects is here!"),
            new Room(new Position(1,0),RoomType.Amarok,"You feel the Amarok's breath on your neck. It looks like this is the end.")
        });
        PlayerPosition = new Position(0,0);
    }

    public void Run () {
        do {
            Console.WriteLine($"You are in the cavern at {(PlayerPosition.X,PlayerPosition.Y)} with {ArrowCount} arrows.");
            DoWinCheck();
            DoLoseCheck();
            if(_hasWon || _hasLost) {
                return;
            } else { 
                ReadRoom();
                SenseAdjacentRooms();
                Console.Write("What do you want to do? ");
                GetCommand();
                RunCommand();
            }
        } while(true);
    }

    void GetCommand() {
        var input = Console.ReadLine();
        switch(input) {
            case "move north": _gameCommand = new MoveCommand(new Position(0,-1)); break;
            case "move east" : _gameCommand = new MoveCommand(new Position(1,0)); break;
            case "move south": _gameCommand = new MoveCommand(new Position(0,1)); break;
            case "move west" : _gameCommand = new MoveCommand(new Position(-1,0)); break;
            case "shoot north": _gameCommand = new ShootCommand(new Position(0,-1)); break;
            case "shoot east" : _gameCommand = new ShootCommand(new Position(1,0)); break;
            case "shoot south": _gameCommand = new ShootCommand(new Position(0,1)); break;
            case "shoot west" : _gameCommand = new ShootCommand(new Position(-1,0)); break;
            case "enable fountain": _gameCommand = new EnableFountainCommand(); break;
            case "exit" : _gameCommand = new ExitCommand(); break;
        }
    }

    void RunCommand() {
        _gameCommand?.Run(this);
    }

    void DoWinCheck() {
        if(!_hasWon && FountainActive && CurrentRoom?.RoomType == RoomType.Entrance) {
            _hasWon = true;
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.WriteLine("You win!");
        }
    }

    void SenseAdjacentRooms() {
        Room[] rooms = Cavern.Get8AdjacentRooms(PlayerPosition);
        foreach (Room room in rooms) {
            if(room?.RoomType == RoomType.Amarok) {
                Console.WriteLine("You can smell the rotten stench of an Amarok in a nearby room.");
            }
        }
    }

    void DoLoseCheck() {
        if(CurrentRoom?.RoomType == RoomType.Amarok) {
            _hasLost = true;
            Console.WriteLine("You are eaten by an Amarok.");
        }
    }

     void ReadRoom() {
        Room? room = Cavern.GetRoom(PlayerPosition);
        if(room!=null && room.Description != "")
            Console.WriteLine(room.Description);
    } 

}