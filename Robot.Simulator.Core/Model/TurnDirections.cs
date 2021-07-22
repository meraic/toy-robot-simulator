namespace Robot.Simulator.Core.Model
{
    public class TurnDirections
    {
        public TurnDirections(Facing left, Facing right)
        {
            Left = left;
            Right = right;
        }

        public Facing Left { get; private set; }

        public Facing Right { get; private set; }
    }
}
