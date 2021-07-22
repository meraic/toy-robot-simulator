using Robot.Simulator.Core.Simulator.Interfaces;

namespace Robot.Simulator.Core.Simulatior.State
{
    public class InMemoryTable : ITable
    {
        private readonly int minY;
        private readonly int maxY;
        private readonly int minX;
        private readonly int maxX;

        public InMemoryTable(int minY, int maxY, int minX, int maxX)
        {
            this.minY = minY;
            this.maxY = maxY;
            this.minX = minX;
            this.maxX = maxX;
        }

        public int MinX => minX;

        public int MinY => minY;

        public int MaxX => maxX;

        public int MaxY => maxY;
    }
}
