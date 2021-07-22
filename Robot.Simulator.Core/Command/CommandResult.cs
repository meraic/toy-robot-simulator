namespace Robot.Simulator.Core.Command
{
    public class CommandResult
    {
        public CommandResult(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
