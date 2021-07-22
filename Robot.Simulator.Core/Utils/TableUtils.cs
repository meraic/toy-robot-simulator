using Robot.Simulator.Core.Simulator.Interfaces;

namespace Robot.Simulator.Core.Utils
{
    public static class TableUtils
    {
        public static bool ValidCoordinates(ITable table, int x, int y)
        {
            return (x >= table.MinX && x <= table.MaxX &&
                    y >= table.MinY && y <= table.MaxY);
        }
    }
}
