using System.Diagnostics;

Console.WriteLine("Hello. Please pick a filter from the list: ");
Console.WriteLine("IsEven, IsPositive, IsMultipleOfTen");
string? input;
Sieve? sieve = null;
do{
    input = Console.ReadLine();
    switch(input) {
        case "IsEven" : sieve = new Sieve(Sieve.IsEven); break;
        case "IsPositive" : sieve = new Sieve(Sieve.IsPositive); break;
        case "IsMultipleOfTen" : sieve = new Sieve(Sieve.IsMultipleOfTen); break;
        default : Console.WriteLine("Enter a valid value."); break;
    }
} while (sieve == null);

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




public class Sieve {
    Predicate<int> _checkNumberIsGoodPredicate;
    public Sieve(Predicate<int> checkNumberIsGoodPredicate) {
        _checkNumberIsGoodPredicate = checkNumberIsGoodPredicate;
    }
    public bool IsGood(int number) {
        return _checkNumberIsGoodPredicate(number);
    }

    public static bool IsEven(int number) {
        return number % 2 == 0 ? true : false;
    }

    public static bool IsPositive(int number) {
        return number > 0;
    }

    public static bool IsMultipleOfTen(int number) {
        return number % 10 == 0 && number != 0 ? true : false;
    }
}

