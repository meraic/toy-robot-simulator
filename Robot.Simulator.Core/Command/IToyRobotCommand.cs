using Robot.Simulator.Core.Simulator.Interfaces;

namespace Robot.Simulator.Core.Command
{
    public interface IToyRobotCommand
    {
        CommandResult Run(ISimulatorState simulatorState, ITable table);
    }
}
