using Robot.Simulator.Core.Simulator.Interfaces;
using Robot.Simulator.Core.Model;
using Robot.Simulator.Core.Utils;

namespace Robot.Simulator.Core.Command
{
    public class MoveToyRobotCommand : IToyRobotCommand
    {
        public CommandResult Run(ISimulatorState simulatorState, ITable table)
        {
            if (!simulatorState.HasToyRobotBeenPlacedOnTable())
            {
                return CommandUtils.NOT_PLACED_COMMAND_RESULT;
            }

            var toyRobotFacing = simulatorState.ToyRobotFacing;

            int oldX = simulatorState.ToyRobotXPosition;
            int oldY = simulatorState.ToyRobotYPosition;
            int newX = oldX + toyRobotFacing.XModifier;
            int newY = oldY + toyRobotFacing.YModifier;

            if (!TableUtils.ValidCoordinates(table, newX, newY))
            {
                return new CommandResult(
                        $"Failed move: the Toy Robot is facing {toyRobotFacing.Name} and tried to move of the table from {oldX},{oldY} to {newX},{newY}");
            }

            simulatorState.SetPosition(newX, newY);

            return new CommandResult(
                    $"Successfully moved the Toy Robot {toyRobotFacing.Name} from {oldX},{oldY} to {simulatorState.ToyRobotXPosition},{simulatorState.ToyRobotYPosition}");
        }
    }
}
