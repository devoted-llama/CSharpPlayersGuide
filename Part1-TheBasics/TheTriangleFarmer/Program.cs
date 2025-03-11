using System;

namespace TheTriangleFarmer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter base size");
            float tBase = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter height");
            float tHeight = float.Parse(Console.ReadLine());


            float tArea = tBase * tHeight / 2;
            Console.Write($"Area is { tArea }\n");
        }
    }
}
