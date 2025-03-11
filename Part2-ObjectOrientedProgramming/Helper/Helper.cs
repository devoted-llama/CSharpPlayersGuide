using System;

namespace Helper {
    public static class Helper {
        public static int AskForNumberInRange(string text, int min, int max) {
            int number;
            do {
                Console.WriteLine(text);
                number = int.Parse(Console.ReadLine());

            } while (number < min || number > max);
            return number;
        }

        public static T GetEnumValueFromUser<T>() where T : Enum {
            object val;
            do {
                Console.WriteLine("Choose one of the following: ");
                foreach (string t in Enum.GetNames(typeof(T))) {
                    Console.Write($"{t} ");
                }
                Console.Write("\n");
            } while (!Enum.TryParse(typeof(T), Console.ReadLine(), out val));
            return (T)val;
        }

        public static T GetEnumValueFromUserWithoutText<T>() where T : Enum {
            object val;
            do {

            } while (!Enum.TryParse(typeof(T), Console.ReadLine(), out val));
            return (T)val;
        }
    }
}
