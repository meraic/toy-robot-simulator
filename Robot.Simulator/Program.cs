using CommandLine;
using Robot.Simulator.Core.Simulatior;
using Robot.Simulator.Core.Simulatior.State;
using Robot.Simulator.Extensions;
using System;
using static Robot.Simulator.Helpers.CommandlineParser;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter commands to send to Robot: (Press Q or type EXIT at any time to quit)");

            var table = new InMemoryTable(0, 4, 0, 4);
            var toyRobotState = new InMemoryToyRobotState();
            var simulatorState = new InMemorySimulatorState(toyRobotState);
            var simulator = new ToyRobotSimulator(simulatorState, table);

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Quit()) break;

                var parser = new Parser(settings =>
                {
                    settings.CaseSensitive = false;
                    settings.CaseInsensitiveEnumValues = true;
                });
                parser.ParseArguments<CommandlineOptions>(input.Split(new char[] { ',', ' '}))
                    .WithParsed(Parse)
                    .WithNotParsed(HandleParseError);

                if (!IsValidCommand)
                {
                    Console.WriteLine("Please enter valid Robot command");
                    continue;
                }

                var result = simulator.Run(ToyRobotCommandFactory.GetCommand(Options)).Result;
                Console.WriteLine(result.Message);
            }
        }
    }
}
