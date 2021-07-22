namespace Robot.Simulator.Extensions
{
    public static class StringExtension
    {
        public static bool Quit(this string command)
        {
            return command.Trim().ToUpper() == "Q" || command.Trim().ToUpper() == "EXIT";
        }
    }
}
