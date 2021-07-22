using System;

namespace Robot.Simulator.Exceptions
{
    public class ToyRobotParseCommandException : Exception
    {
        public ToyRobotParseCommandException(string message) : base(message) { }
    }
}
