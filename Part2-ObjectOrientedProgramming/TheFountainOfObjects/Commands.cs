namespace TheFountainOfObjects;

public interface IGameCommand {
    void Run(Game game) {}
}

public class ShootCommand : IGameCommand {
    Position _direction;
    
    public ShootCommand(Position direction) {
        _direction = direction;
    }
    public void Run(Game game) {
        Position roomPosition = new Position(game.PlayerPosition.X + _direction.X, game.PlayerPosition.Y + _direction.Y);
        Room? room = game.Cavern.GetRoom(roomPosition);
        if(game.ArrowCount == 0) {
            Console.WriteLine("You are out of arrows!");
        } else {
            if(room != null && room.RoomType == RoomType.Amarok) {
                Console.WriteLine("You hear a loud roar as the Amarok is hit by your arrow. You have defeated the Amarok!");
                room.RoomType = RoomType.None;
                room.Description = "You can smell the rotten remains of the Amarok here.";
            } else {
                Console.WriteLine("You hit nothing but air.");
            }
            game.ArrowCount--;
        }
        
    }
}

public class MoveCommand : IGameCommand {
    Position _direction;
    
    public MoveCommand(Position direction) {
        _direction = direction;
    }
    public void Run(Game game) {
        game.PlayerPosition = new Position(game.PlayerPosition.X + _direction.X, game.PlayerPosition.Y + _direction.Y); 
    }
}

public class EnableFountainCommand : IGameCommand { public void Run(Game game){
    if(!game.FountainActive && game.CurrentRoom?.RoomType == RoomType.FountainOfObjects) {
        game.CurrentRoom.Description = "You hear the rushing waters from The Fountain of Objects. It has been reactivated!";
        game.FountainActive = true;
    } else if(game.FountainActive && game.CurrentRoom?.RoomType != RoomType.FountainOfObjects) {
        Console.WriteLine("You are not near The Fountain of Objects; you cannot activate it here.");
    } else if(game.FountainActive) {
        Console.WriteLine("The Fountain of Objects is already active!");
    }
}}
public class ExitCommand : IGameCommand {
    public void Run(Game game) {
        Environment.Exit(0);
    }
}