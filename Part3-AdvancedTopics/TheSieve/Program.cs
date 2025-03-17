using TheSieve;

Console.WriteLine("Hello. Please pick a filter from the list: ");
Console.WriteLine("IsEven, IsPositive, IsMultipleOfTen");
string? input;
Sieve? sieve = null;

// Pick the sieve
do{
    input = Console.ReadLine();
    switch(input) {
        case "IsEven" : sieve = new Sieve(x => x % 2 == 0); break;
        case "IsPositive" : sieve = new Sieve(x => x > 0); break;
        case "IsMultipleOfTen" : sieve = new Sieve(x => x % 10 == 0 && x != 0); break;
        default : Console.WriteLine("Enter a valid value."); break;
    }
} while (sieve == null);

// Pick a number
do {
    Console.Write("Pick a number: ");
    input = Console.ReadLine();
    int number;
    if(int.TryParse(input, out number)) {
        bool result = sieve.IsGood(number);
        string goodness = result ? "good" : "bad";
        Console.WriteLine($"Number is {goodness}");
    } 
} while(input != "exit");
