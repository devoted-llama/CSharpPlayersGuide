using System;

namespace TheReplicatorOfDTo {
    class Program {
        static void Main(string[] args) {
            int[] array1 = new int[5];

            Console.Write("Please give 5 numbers");

            for (int i = 0; i < array1.Length; i++) {
                array1[i] = int.Parse(Console.ReadLine());
            }

            int[] array2 = new int[array1.Length];

            for (int i = 0; i < array1.Length; i++) {
                array2[i] = array1[i];
            }

            Console.WriteLine("Array 1:");
            for (int i = 0; i < array1.Length; i++) {
                Console.WriteLine(array1[i]);
            }

            Console.WriteLine("Array 2:");
            for (int i = 0; i < array2.Length; i++) {
                Console.WriteLine(array2[i]);
            }
        }
    }
}
