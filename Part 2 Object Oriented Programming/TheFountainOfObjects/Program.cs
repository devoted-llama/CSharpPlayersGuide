// See https://aka.ms/new-console-template for more information
Game game = new Game();
game.Run();

public class Cavern {
    public Room[,] Rooms { get; private set; }

    public Cavern() {
        CreateRooms();
    }

    void CreateRooms() {
        Rooms = new Room[3,3];
        (int,int) coords;
        RoomType roomType;
        for(int x = 0;x < 3; x++) {
            for(int y = 0; y < 3; y ++) {
                coords = (x,y);
                roomType = RoomType.none;
                switch(coords) {
                    case (0,0) : roomType = RoomType.entrance; break;
                    case (2,0) : roomType = RoomType.fountainOfObjects; break;
                }
                Rooms[x,y] = new Room(roomType);
            }
        }
    }
}

public enum RoomType {none, entrance,fountainOfObjects}

public class Room {
    public RoomType RoomType {get; }
    public Room (RoomType roomType) {
        RoomType = roomType;
    }
}

public class Game {
    public Position PlayerPosition { get; private set; }
    public Cavern Cavern { get; }

    public Game () {
        PlayerPosition = new Position(0,0);
        Cavern = new Cavern();
    }

    public void Run () {
        var input = "";
        string command = "";
        string directionS = "";
        Direction direction;
        do {
            ReadRoom();
            Console.WriteLine($"You are in the cavern at {(PlayerPosition.X,PlayerPosition.Y)}");
            Console.WriteLine("What do you want to do?");
            input = Console.ReadLine();
            if(input != null) {
                command = (string)input.Substring(0,5);
                directionS = (string)input.Substring(5);
                if(command == "move ") {
                    bool gotDirection = Enum.TryParse<Direction>(directionS,true,out direction);
                    if(gotDirection) {
                        Move(direction);
                        ReadRoom();
                    }
                }
            }
            
        } while(true);
    }
     void Move(Direction direction) {
        switch(direction) {
            case Direction.north : PlayerPosition = new Position(PlayerPosition.X, PlayerPosition.Y-1); break;
            case Direction.east : PlayerPosition = new Position(PlayerPosition.X+1, PlayerPosition.Y);break;
            case Direction.south : PlayerPosition = new Position(PlayerPosition.X, PlayerPosition.Y+1);break;
            case Direction.west : PlayerPosition = new Position(PlayerPosition.X-1, PlayerPosition.Y);break;
        }
    }

     void ReadRoom() {
        string roomString = "";
        RoomType roomType = Cavern.Rooms[PlayerPosition.X,PlayerPosition.Y].RoomType;
        switch(roomType) {
            case RoomType.entrance : roomString = "You are at the entrance!"; break;
            case RoomType.fountainOfObjects : roomString = "You are at the fountain of objects!"; break;
            default: break;
        }
        Console.WriteLine(roomString);
    }

}

public enum Direction {north,east,south,west}
public struct Position {
    public int X { get ;}
    public int Y { get ;}
    public Position (int x, int y) {
        X = x;
        Y = y;
    }
}