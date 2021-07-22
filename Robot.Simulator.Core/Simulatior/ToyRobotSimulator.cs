using Robot.Simulator.Core.Command;
using Robot.Simulator.Core.Simulator.Interfaces;
using System.Threading.Tasks;

namespace Robot.Simulator.Core.Simulatior
{
    public class ToyRobotSimulator
    {
        private ISimulatorState simulatorState;
        private ITable table;

        public ToyRobotSimulator(ISimulatorState simulatorState, ITable table)
        {
            this.simulatorState = simulatorState;
            this.table = table;
        }

        public async Task<CommandResult> Run(IToyRobotCommand command)
        {
            return await Task.FromResult(command.Run(simulatorState, table));
        }
    }
}
