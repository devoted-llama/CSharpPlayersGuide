using System;
public class TheLockedDoor : IDo {

    public void Do() {
        Console.Write("Please enter a passcode: ");
        int passcode = int.Parse(Console.ReadLine());

        Door door = new(passcode);

        while (true) {
            Console.WriteLine($"Current state of the door: {door.DoorState}");
            Console.Write("What would you like to do? ");
            string command = Console.ReadLine();
            switch (command) {
                case "open":
                    door.Open();
                    break;
                case "close":
                    door.Close();
                    break;
                case "lock":
                    door.Lock();
                    break;
                case "unlock":
                    Console.Write("Enter passcode: ");
                    door.Unlock(int.Parse(Console.ReadLine()));
                    break;
                case "change passcode":
                    Console.Write("Enter current passcode: ");
                    int currentPasscode = int.Parse(Console.ReadLine());
                    Console.Write("Enter new passcode: ");
                    int newPasscode = int.Parse(Console.ReadLine());
                    bool status = door.ChangePasscode(currentPasscode, newPasscode);
                    Console.WriteLine($"Door passcode change: {status}");
                    break;

            }
        }

    }




}

public class Door {
    private DoorState _doorState;
    public DoorState DoorState => _doorState;

    private int _passcode;

    public Door(int passcode) {
        _passcode = passcode;
    }

    public void Close() {
        if (_doorState == DoorState.Open) {
            _doorState = DoorState.Closed;
        }
    }

    public void Open() {
        if (_doorState == DoorState.Closed) {
            _doorState = DoorState.Open;
        }
    }

    public void Lock() {
        if (_doorState == DoorState.Closed) {
            _doorState = DoorState.Locked;
        }
    }

    public void Unlock(int passcode) {
        if (_doorState == DoorState.Locked && passcode == _passcode) {
            _doorState = DoorState.Closed;
        }
    }

    public bool ChangePasscode(int currentPasscode, int newPasscode) {
        if (currentPasscode == _passcode) {
            _passcode = newPasscode;
            return true;
        }
        return false;
    }

}

public enum DoorState {
    Open, Closed, Locked
}


