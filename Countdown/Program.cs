using System;

namespace Countdown {
    class Program {
        static void Main(string[] args) {
            CountDown(10);

            int CountDown(int x) {
                Console.WriteLine(x);
                if (x == 1) return 1;
                return CountDown(x - 1);
            }
        }
    }
}
