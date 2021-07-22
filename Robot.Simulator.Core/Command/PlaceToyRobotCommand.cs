using Robot.Simulator.Core.Simulator.Interfaces;
using Robot.Simulator.Core.Model;
using Robot.Simulator.Core.Utils;

namespace Robot.Simulator.Core.Command
{
    public class PlaceToyRobotCommand : IToyRobotCommand
    {
        private readonly int x;
        private readonly int y;
        private readonly Facing facing;

        public PlaceToyRobotCommand(int x, int y, Facing facing)
        {
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public CommandResult Run(ISimulatorState simulatorState, ITable table)
        {
            if(!TableUtils.ValidCoordinates(table, x, y))
            {
                return new CommandResult(
                        $"Invalid coordinates {x},{y} please enter a values of x between {table.MinX} to {table.MaxX} and y between {table.MinY} to {table.MaxY}");
            }

            simulatorState.SetPosition(x, y);
            simulatorState.ToyRobotFacing = facing;
            simulatorState.SetPlaceCommand();

            return new CommandResult($"Successfully placed the Toy Robot at {x},{y} facing {facing.Name}");
        }
    }
}
