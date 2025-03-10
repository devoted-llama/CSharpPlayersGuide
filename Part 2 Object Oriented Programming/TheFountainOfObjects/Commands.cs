namespace TheFountainOfObjects;

public interface IGameCommand {
    void Run(Game game) {
        
    }
}

public class MoveNorthCommand : IGameCommand {
    public void Run(Game game) {
        Position p = game.PlayerPosition;
        game.PlayerPosition = new Position(p.X,p.Y-1);
    }
}

public class MoveSouthCommand : IGameCommand { public void Run(Game game){
    Position p = game.PlayerPosition;
    game.PlayerPosition = new Position(p.X,p.Y+1);
}}
public class MoveEastCommand : IGameCommand { public void Run(Game game){
    Position p = game.PlayerPosition;
    game.PlayerPosition = new Position(p.X+1,p.Y);
}}
public class MoveWestCommand : IGameCommand { public void Run(Game game){
    Position p = game.PlayerPosition;
    game.PlayerPosition = new Position(p.X-1,p.Y);
}}
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