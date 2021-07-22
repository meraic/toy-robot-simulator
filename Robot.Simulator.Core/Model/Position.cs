namespace Robot.Simulator.Core.Model
{
    public class Position
    {
        public Position(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
    }
}
