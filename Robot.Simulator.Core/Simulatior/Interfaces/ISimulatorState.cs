using Robot.Simulator.Core.Model;

namespace Robot.Simulator.Core.Simulator.Interfaces
{
    public interface ISimulatorState
    {
        void SetPlaceCommand();
        bool HasToyRobotBeenPlacedOnTable();
        Facing ToyRobotFacing { get; set; }
        void SetPosition(int x, int y);
        int ToyRobotXPosition { get; }
        int ToyRobotYPosition { get; }
    }
}
