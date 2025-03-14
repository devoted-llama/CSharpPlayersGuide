// See https://aka.ms/new-console-template for more information

int value;
bool isParsed;
string? input;
Console.WriteLine("Hello. Please enter a whole number.");
do {
    input = Console.ReadLine();
    isParsed = int.TryParse(input, out value);

    if(isParsed == false) {
        Console.WriteLine("Incorrect. Try again.");
    }else {
        Console.WriteLine($"Thank you for entering the value {value}.");
    }
} while(isParsed == false);

double value2;
Console.WriteLine("Hello. Please enter a floating point number.");
do {
    input = Console.ReadLine();
    isParsed = double.TryParse(input, out value2);

    if(isParsed == false) {
        Console.WriteLine("Incorrect. Try again.");
    }else {
        Console.WriteLine($"Thank you for entering the value {value2}.");
    }
} while(isParsed == false);

bool value3;
Console.WriteLine("Hello. Please enter a boolean.");
do {
    input = Console.ReadLine();
    isParsed = bool.TryParse(input, out value3);

    if(isParsed == false) {
        Console.WriteLine("Incorrect. Try again.");
    }else {
        Console.WriteLine($"Thank you for entering the value {value3}.");
    }
} while(isParsed == false);