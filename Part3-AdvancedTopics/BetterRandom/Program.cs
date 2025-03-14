while(true) {
    Console.WriteLine("Please choose an option: double, string, coin, exit");
    string? option = Console.ReadLine();

    switch(option) {
        case "double" : RandomDouble(); break;
        case "string" : RandomString(); break;
        case "coin": CoinFlip(); break;
        case "exit": Environment.Exit(0); break;
    }
}

void RandomDouble() {
    Random r = new Random();
    Console.Write("Please provide a double: ");
    string? input = Console.ReadLine();
    double max;
    if(double.TryParse(input, out max)) {
        Console.WriteLine($"Here's a random double between 0 and {max}: {r.NextDouble(max)}");
    }
}

void RandomString() {
    Random r = new Random();
    Console.Write("Please provide a set of strings separated by a space: ");
    string? input = Console.ReadLine();
    string[]? strings = input?.Split(" ");
    if(strings != null)
        Console.WriteLine($"Here's a random string : {r.NextString(strings)}");
    
}

void CoinFlip() {
    Random r = new Random();
    Console.Write("Please provide the frequency of getting heads (0-1), or leave blank for 50%: ");
    string? input = Console.ReadLine();
    bool? result = null;
    float headFrequency;
    string headFrequencyS = "50";
    if(float.TryParse(input, out headFrequency)) {
        result = r.CoinFlip(headFrequency);
        headFrequencyS = ((int)(headFrequency * 100f)).ToString();
    } else {
        result = r.CoinFlip();
    }
    
    if(result != null) {
        string resultString = result == true ? "heads" : "tails";
        Console.WriteLine($"Here's the result, with the frequency of heads at {headFrequencyS}% : {resultString}");
    }
    
}


public static class RandomExtensions {
    public static double NextDouble(this Random random, double max) {
        return random.NextDouble() * max;
    }

    public static string? NextString(this Random random, params string[] strings) {
        if(strings.Length > 0)
            return strings[random.Next(strings.Length)];

        return null;
    }

    public static bool CoinFlip(this Random random, float headFrequency = 0.5f) {
        return random.NextDouble() <= headFrequency ? true : false;
    }
}


