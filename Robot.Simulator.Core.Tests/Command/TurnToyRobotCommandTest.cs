using FluentAssertions;
using Robot.Simulator.Core.Command;
using Robot.Simulator.Core.Enums;
using Robot.Simulator.Core.Simulatior.State;
using Xunit;


namespace Robot.Simulator.Core.Tests.Command
{
    public class TurnToyRobotCommandTest
    {
        [Fact]
        public void Should_Fail_As_The_First_Command()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new TurnToyRobotCommand(Turn.LEFT).Run(simulatorState, table);

            commandResult.Message.Should().Be("Run the command place(x,y,facing) to get started simulating a toy robot.");
        }

        [Fact]
        public void Should_Face_The_Toy_Robot_From_North_To_West()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            new PlaceToyRobotCommand(0, 0, FacingFactory.NORTH).Run(simulatorState, table);
            var commandResult = new TurnToyRobotCommand(Turn.LEFT).Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(0);
            simulatorState.ToyRobotYPosition.Should().Be(0);
            simulatorState.ToyRobotFacing.Should().Be(FacingFactory.WEST);
            commandResult.Message.Should().Be("Successfully turned the Toy Robot left from north to west");
        }

        [Fact]
        public void Should_Face_The_Toy_Robot_From_North_To_East()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            new PlaceToyRobotCommand(0, 0, FacingFactory.NORTH).Run(simulatorState, table);
            var commandResult = new TurnToyRobotCommand(Turn.RIGHT).Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(0);
            simulatorState.ToyRobotYPosition.Should().Be(0);
            simulatorState.ToyRobotFacing.Should().Be(FacingFactory.EAST);
            commandResult.Message.Should().Be("Successfully turned the Toy Robot right from north to east");
        }
    }
}
