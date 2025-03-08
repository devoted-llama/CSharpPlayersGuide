using System;

namespace SimulasSoups {
    enum type { Soup, Stew, Gumbo };
    enum mainIngredient { Mushrooms, Chicken, Carrots, Potatoes };
    enum seasoning { Spicy, Salty, Sweet };
    class Program {
        static void Main(string[] args) {
            int count = 3;
            (type type, mainIngredient main, seasoning seasoning)[] soups = new (type, mainIngredient, seasoning)[count];

            for (int i = 0; i < count; i++) {
                soups[i].type = GetEnumValueFromUser<type>();
                soups[i].main = GetEnumValueFromUser<mainIngredient>();
                soups[i].seasoning = GetEnumValueFromUser<seasoning>();
            }

            Console.WriteLine("Here are the soups you chose:");

            foreach (var soup in soups) {
                Console.WriteLine($"{soup.seasoning} {soup.main} {soup.type}");
            }


            for (int i = 0; i < count; i++) {

            }

            T GetEnumValueFromUser<T>() where T : Enum {
                object val;
                do {
                    Console.WriteLine("Choose one of the following ingredients: ");
                    foreach (string t in Enum.GetNames(typeof(T))) {
                        Console.WriteLine($"{t}");
                    }
                } while (!Enum.TryParse(typeof(T), Console.ReadLine(), out val));
                return (T)val;
            }
        }
    }
}
