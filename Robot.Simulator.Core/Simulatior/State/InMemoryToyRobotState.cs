using Robot.Simulator.Core.Model;
using Robot.Simulator.Core.Simulatior.Interfaces;

namespace Robot.Simulator.Core.Simulatior.State
{
    public class InMemoryToyRobotState : IToyRobotState
    {
        public Facing Facing { get; set; }
    }
}
