using System;
public class TakingANumber : IDo {

    public void Do() {

        int AskForNumber(string text) {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }

        int AskForNumberInRange(string text, int min, int max) {
            int number;
            do {
                Console.WriteLine(text);
                number = int.Parse(Console.ReadLine());

            } while (number < min || number > max);
            return number;
        }

        int result = AskForNumber("What is the airspeed velocity of an unladen swallow?");

    }

}