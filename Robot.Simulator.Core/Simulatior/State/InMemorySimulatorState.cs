using Robot.Simulator.Core.Model;
using Robot.Simulator.Core.Simulatior.Interfaces;
using Robot.Simulator.Core.Simulator.Interfaces;

namespace Robot.Simulator.Core.Simulatior.State
{
    public class InMemorySimulatorState : ISimulatorState
    {
        private IToyRobotState toyRobotState;

        private int toyRobotXPosition;
        private int toyRobotYPosition;
        private bool placed = false;

        public InMemorySimulatorState(IToyRobotState toyRobotState)
        {
            this.toyRobotState = toyRobotState;
        }

        public Facing ToyRobotFacing 
        {
            get => this.toyRobotState.Facing;
            set => this.toyRobotState.Facing = value; 
        }

        public int ToyRobotXPosition => toyRobotXPosition;

        public int ToyRobotYPosition => toyRobotYPosition;

        public void SetPosition(int x, int y)
        {
            this.toyRobotXPosition = x;
            this.toyRobotYPosition = y;
        }

        public bool HasToyRobotBeenPlacedOnTable()
        {
            return placed;
        }

        public void SetPlaceCommand()
        {
            this.placed = true;
        }
    }
}
