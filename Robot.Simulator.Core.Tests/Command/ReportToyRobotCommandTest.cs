using FluentAssertions;
using Robot.Simulator.Core.Command;
using Robot.Simulator.Core.Simulatior.State;
using Xunit;

namespace Robot.Simulator.Core.Tests.Command
{
    public class ReportToyRobotCommandTest
    {
        [Fact]
        public void Should_Fail_As_The_First_Command()
        {
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var table = new InMemoryTable(0, 4, 0, 4);

            var commandResult = new ReportToyRobotCommand().Run(simulatorState, table);

            commandResult.Message.Should().Be("Run the command place(x,y,facing) to get started simulating a toy robot.");
        }
    }
}
