using System;
using System.Collections.Generic;
namespace RoboticInterface {
    public class Robot {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public List<IRobotCommand> Commands { get; set; } = new List<IRobotCommand>();

        public Robot() {
            X = 0;
            Y = 0;
            IsPowered = false;
        }

        public void Run() {
            foreach (IRobotCommand command in Commands) {
                command.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }
}
