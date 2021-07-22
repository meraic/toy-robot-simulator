using Robot.Simulator.Core;
using Robot.Simulator.Core.Command;
using Robot.Simulator.Core.Enums;
using Robot.Simulator.Enums;
using Robot.Simulator.Exceptions;

namespace Robot.Simulator
{
    public class ToyRobotCommandFactory
    {
        public static IToyRobotCommand GetCommand(CommandlineOptions options)
        {
            try
            {
                switch (options.Command)
                {
                    case CliCommand.PLACE:
                        return new PlaceToyRobotCommand(options.XPosition.Value,
                            options.YPosition.Value,
                            FacingFactory.GetFacing(options.FacingDirection.ToString()));
                    case CliCommand.MOVE:
                        return new MoveToyRobotCommand();
                    case CliCommand.LEFT:
                        return new TurnToyRobotCommand(Turn.LEFT);
                    case CliCommand.RIGHT:
                        return new TurnToyRobotCommand(Turn.RIGHT);
                    default:
                        return new ReportToyRobotCommand();
                }
            }
            catch
            {
                throw new ToyRobotParseCommandException($"{options.Command} is invalid command");
            }
        }
    }
}
