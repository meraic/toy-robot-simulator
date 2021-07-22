using FluentAssertions;
using Robot.Simulator.Core.Command;
using Robot.Simulator.Core.Simulatior.State;
using Xunit;

namespace Robot.Simulator.Core.Tests.Command
{
    public class PlaceToyRobotCommandTest
    {
        [Fact]
        public void Should_Position_The_Robot_At_The_Given_Coordinates()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new PlaceToyRobotCommand(0, 0, FacingFactory.NORTH).Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(0);
            simulatorState.ToyRobotYPosition.Should().Be(0);
            simulatorState.ToyRobotFacing.Should().Be(FacingFactory.NORTH);
            commandResult.Message.Should().Be("Successfully placed the Toy Robot at 0,0 facing north");
        }

        [Fact]
        public void Should_Position_The_Robot_At_The_Given_Coordinates_Max_Boundaries()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new PlaceToyRobotCommand(4, 4, FacingFactory.SOUTH).Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(4);
            simulatorState.ToyRobotYPosition.Should().Be(4);
            simulatorState.ToyRobotFacing.Should().Be(FacingFactory.SOUTH);
            commandResult.Message.Should().Be("Successfully placed the Toy Robot at 4,4 facing south");
        }

        [Fact]
        public void Should_Fail_When_Positioning_The_Robot_At_Invalid_Negative_Coordinates()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new PlaceToyRobotCommand(-1, -1, FacingFactory.NORTH).Run(simulatorState, table);

            commandResult.Message.Should().Be("Invalid coordinates -1,-1 please enter a values of x between 0 to 4 and y between 0 to 4");
        }

        [Fact]
        public void Should_Fail_When_Positioning_The_Robot_At_Invalid_Exceeding_Coordinates()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new PlaceToyRobotCommand(5, 5, FacingFactory.NORTH).Run(simulatorState, table);

            commandResult.Message.Should().Be("Invalid coordinates 5,5 please enter a values of x between 0 to 4 and y between 0 to 4");
        }

        [Fact]
        public void Should_Succeed_As_The_First_Command()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new PlaceToyRobotCommand(3, 3, FacingFactory.EAST).Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(3);
            simulatorState.ToyRobotYPosition.Should().Be(3);
            simulatorState.ToyRobotFacing.Should().Be(FacingFactory.EAST);
            commandResult.Message.Should().Be("Successfully placed the Toy Robot at 3,3 facing east");
        }
    }
}
