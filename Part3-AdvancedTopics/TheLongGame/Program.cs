Console.Write("Enter your name. ");
string? name = Console.ReadLine();
string? path = string.Join(".",name,"txt");

int score = 0;
if(File.Exists(path)) {
    string scoreS = File.ReadAllText(path);
    int.TryParse(scoreS, out score);
}

Console.WriteLine($"Welcome, {name}!");
Console.WriteLine($"Your current score is {score}.");
Console.WriteLine("Type some stuff to build your score!");

while(Console.ReadKey().Key != ConsoleKey.Escape) {
    score++;
}

Console.SetCursorPosition(0,Console.CursorTop+1);
Console.WriteLine($"Nice job. Your new score is {score}. Saving. Bye.");

File.WriteAllText(path,score.ToString());
