using CommandLine;
using Robot.Simulator.Enums;

namespace Robot.Simulator
{
    public class CommandlineOptions
    {
        [Value(0, MetaName = "Command", HelpText = "Robot command name")]
        public CliCommand Command { get; set; }

        [Value(1, MetaName = "XPosition", HelpText = "X Position of Robot")]
        public int? XPosition { get; set; }

        [Value(2, MetaName = "YPosition", HelpText = "Y Position of Robot")]
        public int? YPosition { get; set; }

        [Value(3, MetaName = "FacingDirection", HelpText = "Robot facing direction (NORTH, EAST, WEST, SOUTH)")]
        public Direction? FacingDirection { get; set; }
    }
}
