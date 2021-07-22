using Robot.Simulator.Core.Model;
using System.Collections.Generic;

namespace Robot.Simulator.Core.Utils
{
    public class NavigationUtils
    {
        public static readonly Enums.Turn LEFT = Enums.Turn.LEFT;
        public static readonly Enums.Turn RIGHT = Enums.Turn.RIGHT;

        private static Dictionary<Facing, TurnDirections> TurnDirections = new Dictionary<Facing, TurnDirections>()
        {
            { FacingFactory.NORTH, new TurnDirections(FacingFactory.WEST, FacingFactory.EAST) },
            { FacingFactory.EAST, new TurnDirections(FacingFactory.NORTH, FacingFactory.SOUTH) },
            { FacingFactory.SOUTH, new TurnDirections(FacingFactory.EAST, FacingFactory.WEST) },
            { FacingFactory.WEST, new TurnDirections(FacingFactory.SOUTH, FacingFactory.NORTH) }
        };

        public static Facing Turn(Facing currentFacing, Enums.Turn turn)
        {
            var turnDirections = TurnDirections[currentFacing];
            return (turn == Enums.Turn.LEFT) ? turnDirections.Left : turnDirections.Right;
        }
    }
}
