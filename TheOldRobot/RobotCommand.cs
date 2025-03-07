using System;
namespace TheOldRobot {
    public abstract class RobotCommand {
        public abstract void Run(Robot robot);
    }

    public class OnCommand : RobotCommand {
        public override void Run(Robot robot) {
            robot.IsPowered = true;
        }
    }

    public class OffCommand : RobotCommand {
        public override void Run(Robot robot) {
            robot.IsPowered = false;
        }
    }

    public class NorthCommand : RobotCommand {
        public override void Run(Robot robot) {
            if (robot.IsPowered)
                robot.Y += 1;
        }
    }

    public class EastCommand : RobotCommand {
        public override void Run(Robot robot) {
            if (robot.IsPowered)
                robot.X += 1;
        }
    }

    public class SouthCommand : RobotCommand {
        public override void Run(Robot robot) {
            if (robot.IsPowered)
                robot.Y -= 1;
        }
    }

    public class WestCommand : RobotCommand {
        public override void Run(Robot robot) {
            if (robot.IsPowered)
                robot.X -= 1;
        }
    }
}
