using System;
public class Countdown : IDo {

    public void Do() {

        CountDown(10);

        int CountDown(int x) {
            Console.WriteLine(x);
            if (x == 1) return 1;
            return CountDown(x - 1);
        }

    }



}

