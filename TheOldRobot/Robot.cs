using System;
namespace TheOldRobot {
    public class Robot {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public RobotCommand[] Commands { get; set; } = new RobotCommand[3];

        public Robot() {
            X = 0;
            Y = 0;
            IsPowered = false;
        }

        public void Run() {
            foreach (RobotCommand command in Commands) {
                command.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }
}
