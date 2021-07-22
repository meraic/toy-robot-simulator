using Robot.Simulator.Core.Simulator.Interfaces;
using Robot.Simulator.Core.Utils;

namespace Robot.Simulator.Core.Command
{
    public class TurnToyRobotCommand : IToyRobotCommand
    {
        private readonly Enums.Turn turn;

        public TurnToyRobotCommand(Enums.Turn turn)
        {
            this.turn = turn;
        }

        public CommandResult Run(ISimulatorState simulatorState, ITable table)
        {
            if (!simulatorState.HasToyRobotBeenPlacedOnTable())
            {
                return CommandUtils.NOT_PLACED_COMMAND_RESULT;
            }

            var oldFacing = simulatorState.ToyRobotFacing;
            var newFacing = NavigationUtils.Turn(oldFacing, turn);

            simulatorState.ToyRobotFacing = newFacing;

            return new CommandResult($"Successfully turned the Toy Robot {turn.ToString().ToLower()} from {oldFacing.Name} to {newFacing.Name}");
        }
    }
}
