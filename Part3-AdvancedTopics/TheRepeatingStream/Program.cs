RecentNumbers recent = new RecentNumbers();

Thread streamThread = new Thread(RunStream);
streamThread.Start();

Thread inputThread = new Thread(GetInput);
inputThread.Start();

void GetInput() {
    ConsoleKeyInfo key;
    while(true) {
        key = Console.ReadKey();
        if(key.Key == ConsoleKey.Spacebar) {
            if(recent.AreSame()) {
                Console.WriteLine("Correct, they're the same!");
            } else {
                Console.WriteLine("Incorrect, they're not the same!");
            }
        }
    }
}

void RunStream() {
    Random r = new Random();
    int number;
    while(true) {
        number = r.Next(10);
        Console.WriteLine(number);
        recent.Push(number);
        Thread.Sleep(1000);
    }
}

public class RecentNumbers {
    private int _last;
    private int _lastButOne;
    private object _numberLock = new object();

    public void Push(int last) {
        lock (_numberLock) {
            _lastButOne = _last;
            _last = last;
        }
    }

    public bool AreSame() {
        lock (_numberLock) {
            return _last == _lastButOne;
        }
    }
}
