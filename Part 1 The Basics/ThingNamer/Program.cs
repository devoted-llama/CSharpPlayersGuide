﻿using System;

namespace ThingNamer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("What kind of thing are we talking about?");
            string a = Console.ReadLine();
            Console.WriteLine("How would you describe it? Big, Azure, Tattered?");
            string b = Console.ReadLine();
            string c = "of Doom";
            string d = "3000";
            Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");
        }
    }
}
