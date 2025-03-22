int[] input = [1,9,2,8,3,7,4,6,5];

IEnumerable<int> result1 = Lens1(input);
Console.WriteLine(string.Join(",",result1));

IEnumerable<int> result2 = Lens2(input);
Console.WriteLine(string.Join(",",result2));

IEnumerable<int> result3 = Lens3(input);
Console.WriteLine(string.Join(",",result3));

// Lens1 does stuff procedurally
IEnumerable<int> Lens1(int[] numbers) {
    List<int> result = new List<int>();

    // step 1
    foreach (int number in numbers) {
        if(number % 2 == 0) {
            result.Add(number);
        }
    }

    // step 2 
    result.Sort();

    // step 3
    for(int i = 0; i<result.Count; i++) {
        result[i] = result[i] *= 2;
    }

    return result;
}

// Lens2 does stuff with LINQ query expressions
IEnumerable<int> Lens2(int[] numbers) { 
    IEnumerable<int> result = 
        from n in numbers
        where n % 2 == 0
        orderby n
        select n*2;
    return result;
}

// Lens3 does stuff with method call syntax
IEnumerable<int> Lens3(int[] numbers) { 
    IEnumerable<int> result = numbers
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n*2);
    return result;
}