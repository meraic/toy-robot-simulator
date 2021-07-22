namespace Robot.Simulator.Core.Model
{
    public class Facing
    {
        public Facing(string name, int xModifier, int yModifier)
        {
            Name = name;
            XModifier = xModifier;
            YModifier = yModifier;
        }

        public string Name { get; private set; }
        public int XModifier { get; private set; }
        public int YModifier { get; private set; }
    }
}
