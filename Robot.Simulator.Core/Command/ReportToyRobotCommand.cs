using Robot.Simulator.Core.Simulator.Interfaces;
using Robot.Simulator.Core.Utils;

namespace Robot.Simulator.Core.Command
{
    public class ReportToyRobotCommand : IToyRobotCommand
    {
        public CommandResult Run(ISimulatorState simulatorState, ITable table)
        {
            if (!simulatorState.HasToyRobotBeenPlacedOnTable())
            {
                return CommandUtils.NOT_PLACED_COMMAND_RESULT;
            }

            return new CommandResult(
                $"Output: {simulatorState.ToyRobotXPosition},{simulatorState.ToyRobotYPosition},{simulatorState.ToyRobotFacing?.Name}");
        }
    }
}
