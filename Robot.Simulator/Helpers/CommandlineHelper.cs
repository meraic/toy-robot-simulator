using CommandLine;
using Robot.Simulator.Enums;
using System.Collections.Generic;

namespace Robot.Simulator.Helpers
{
    public static class CommandlineParser
    {
        public static void Parse(CommandlineOptions options)
        {
            switch(options.Command)
            {
                case CliCommand.PLACE:
                    IsValidCommand =  options.XPosition.HasValue &&
                                        options.YPosition.HasValue &&
                                        options.FacingDirection.HasValue &&
                                        (options.FacingDirection.Value == Direction.EAST || options.FacingDirection.Value == Direction.NORTH ||
                                        options.FacingDirection.Value == Direction.WEST || options.FacingDirection.Value == Direction.SOUTH);
                    Options = options;
                    break;
                case CliCommand.MOVE:
                case CliCommand.LEFT:
                case CliCommand.RIGHT:
                case CliCommand.REPORT:
                    IsValidCommand = options.XPosition == null &&
                                        options.YPosition == null &&
                                        options.FacingDirection == null;
                    Options = options;
                    break;
                default:
                    IsValidCommand = true;
                    break;
            }
        }

        public static void HandleParseError(IEnumerable<Error> errors)
        {
            IsValidCommand = false;
        }

        public static CommandlineOptions Options { get; private set; }

        public static bool IsValidCommand { get; private set; }

        public static CliCommand Command => Options.Command;
    }
}
