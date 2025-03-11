using System;

namespace HuntingTheManticore {
    class Program {
        static void Main(string[] args) {
            int mHealth = 10, mHealthMax = 10;
            int cHealth = 15, cHealthMax = 15;
            int round = 0;

            Random random = new Random();
            int mDistance = random.Next(0, 100);

            Console.Clear();

            while (mHealth > 0 && cHealth > 0) {
                round++;
                int damage = GetCannonDamage(round);
                Console.WriteLine($"STATUS: Round: {round}  City: {cHealth}/{cHealthMax}  Manticore: {mHealth}/{mHealthMax}");
                Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");

                int range = AskForNumberInRange("Enter desired cannon range: ", 0, 100);

                if (range > mDistance) {
                    Console.WriteLine("The round OVERSHOT the target.");
                } else if (range < mDistance) {
                    Console.WriteLine("The round FELL SHORT of the target.");
                } else {
                    Console.WriteLine("The round was a DIRECT HIT!");
                    mHealth -= damage;
                }

                if (mHealth > 0) {
                    cHealth -= 1;
                }

            }
            if (mHealth <= 0) {
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            }
            if (cHealth <= 0) {
                Console.WriteLine("You failed to destroy the Manticore! The city of Consolas has been lost!");
            }

            int GetCannonDamage(int round) {
                if (round % 3 == 0 && round % 5 == 0) {
                    return 10;
                } else if (round % 3 == 0 || round % 5 == 0) {
                    return 3;
                }
                return 1;

            }

            int AskForNumberInRange(string text, int min, int max) {
                int number;
                do {
                    Console.Write(text);
                    number = int.Parse(Console.ReadLine());

                } while (number < min || number > max);
                return number;
            }
        }
    }
}
