﻿using System;

namespace Bread {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Bread is ready.");
            Console.WriteLine("Who is the bread for?");
            string name = Console.ReadLine();
            Console.WriteLine("Noted: " + name + " got the bread.");
        }
    }
}
