CookieGame game = new();

try {
    game.Play();
} catch(CookieException e) {
    // Console.WriteLine(e);
    // Eat the exception!!
} finally {
    Console.WriteLine($"Player {game.Player} got the bad cookie!");
}

public class CookieGame {
    int _turn;
    public int Player {get => (_turn % 2)+1;}
    public void Play() {
        Random r = new Random();
        int badCookie = r.Next(10);
        _turn = 0;
        int cookieChoice;
        List<int> chosenCookies = new List<int>();
        do { 
            Console.Write($"Player {Player} - choose a cookie: ");
            string? input = Console.ReadLine();
            if(int.TryParse(input, out cookieChoice)){
                if(chosenCookies.Contains(cookieChoice)){
                    Console.WriteLine("Already chosen!");
                    continue;
                } else {
                    chosenCookies.Add(cookieChoice);
                    if(cookieChoice == badCookie) throw new CookieException();
                }
            }
            _turn++;
        } while(cookieChoice != badCookie);
    }
}

public class CookieException : Exception {
   public CookieException() : base() {}
   public CookieException(string? message) : base(message) {}
   public CookieException(string? message, Exception? innerException) : base(message, innerException) {}
}
