using System;

namespace RoboticInterface {
    using Helper;
    class Program {
        public static void Main(string[] args) {
            Robot robot = new();
            IRobotCommand[] commands = new IRobotCommand[3];

            Console.WriteLine("Hello and welcome to the robot interface. Please input 3 commands.");

            for (int i = 0; i < 3; i++) {
                Options o = Helper.GetEnumValueFromUser<Options>();

                switch (o) {
                    case Options.on: commands[i] = new OnCommand(); break;
                    case Options.off: commands[i] = new OffCommand(); break;
                    case Options.north: commands[i] = new NorthCommand(); break;
                    case Options.east: commands[i] = new EastCommand(); break;
                    case Options.south: commands[i] = new SouthCommand(); break;
                    case Options.west: commands[i] = new WestCommand(); break;
                }



            }

            Console.WriteLine("Commands have been collected. Sending to robot.");

            robot.Commands = commands;
            robot.Run();

        }
    }

    public enum Options { on, off, north, east, south, west }
}
