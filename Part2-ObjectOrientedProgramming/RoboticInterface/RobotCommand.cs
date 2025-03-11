using System;
namespace RoboticInterface {
    public interface IRobotCommand {
        void Run(Robot robot);
    }

    public class OnCommand : IRobotCommand {
        public void Run(Robot robot) {
            robot.IsPowered = true;
        }
    }

    public class OffCommand : IRobotCommand {
        public void Run(Robot robot) {
            robot.IsPowered = false;
        }
    }

    public class NorthCommand : IRobotCommand {
        public void Run(Robot robot) {
            if (robot.IsPowered)
                robot.Y += 1;
        }
    }

    public class EastCommand : IRobotCommand {
        public void Run(Robot robot) {
            if (robot.IsPowered)
                robot.X += 1;
        }
    }

    public class SouthCommand : IRobotCommand {
        public void Run(Robot robot) {
            if (robot.IsPowered)
                robot.Y -= 1;
        }
    }

    public class WestCommand : IRobotCommand {
        public void Run(Robot robot) {
            if (robot.IsPowered)
                robot.X -= 1;
        }
    }
}
