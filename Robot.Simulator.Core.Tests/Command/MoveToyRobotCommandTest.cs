using FluentAssertions;
using Robot.Simulator.Core.Command;
using Robot.Simulator.Core.Simulatior.State;
using Xunit;

namespace Robot.Simulator.Core.Tests.Command
{
    public class MoveToyRobotCommandTest
    {
        [Fact]
        public void Move_Command_Should_Fail_As_The_First_Command()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new MoveToyRobotCommand().Run(simulatorState, table);
            commandResult.Message.Should().Be("Run the command place(x,y,facing) to get started simulating a toy robot.");
        }

        [Fact]
        public void Move_Command_Should_Move_Toy_Robot_On_Unit()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            new PlaceToyRobotCommand(0, 0, FacingFactory.NORTH).Run(simulatorState, table);
            var commandResult = new MoveToyRobotCommand().Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(0);
            simulatorState.ToyRobotYPosition.Should().Be(1);
            commandResult.Message.Should().Be("Successfully moved the Toy Robot north from 0,0 to 0,1");
        }

        [Fact]
        public void Move_Command_Should_Fail_When_Robot_Tries_To_Move_Over_Edge_Of_Table()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            new PlaceToyRobotCommand(0, 0, FacingFactory.SOUTH).Run(simulatorState, table);

            var commandResult = new MoveToyRobotCommand().Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(0);
            simulatorState.ToyRobotYPosition.Should().Be(0);
            commandResult.Message.Should().Be("Failed move: the Toy Robot is facing south and tried to move of the table from 0,0 to 0,-1");
        }

        [Fact]
        public void Move_Command_Should_Work_With_Multiple_Moves_Of_Toy_Robot_On_Unit()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            new PlaceToyRobotCommand(0, 0, FacingFactory.NORTH).Run(simulatorState, table);

            MoveToyRobotCommand moveToyRobotCommand = new MoveToyRobotCommand();
            moveToyRobotCommand.Run(simulatorState, table);
            moveToyRobotCommand.Run(simulatorState, table);

            var commandResult = moveToyRobotCommand.Run(simulatorState, table);

            simulatorState.ToyRobotXPosition.Should().Be(0);
            simulatorState.ToyRobotYPosition.Should().Be(3);
            commandResult.Message.Should().Be("Successfully moved the Toy Robot north from 0,2 to 0,3");
        }
    }
}
