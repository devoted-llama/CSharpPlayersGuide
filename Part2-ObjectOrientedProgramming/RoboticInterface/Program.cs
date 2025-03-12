using System;
using System.Collections.Generic;

namespace RoboticInterface {

    class Program {
        public static void Main(string[] args) {
            Robot robot = new();
            List<IRobotCommand> commands = new List<IRobotCommand>();

            Console.WriteLine("Hello and welcome to the robot interface. Please input as many commands as you wish. When you are done, type 'stop'.");
            string input;
            do {
                input = Console.ReadLine();
                switch (input) {
                    case "on"   : commands.Add(new OnCommand()); break;
                    case "off"  : commands.Add(new OffCommand()); break;
                    case "north": commands.Add(new NorthCommand()); break;
                    case "east" : commands.Add(new EastCommand()); break;
                    case "south": commands.Add(new SouthCommand()); break;
                    case "west" : commands.Add(new WestCommand()); break;
                }
            } while(input != "stop");
            Console.WriteLine("Commands have been collected. Sending to robot.");
            robot.Commands = commands;
            robot.Run();
        }
    }
}
