using Robot.Simulator.Core.Exceptions;
using Robot.Simulator.Core.Model;
using System;

namespace Robot.Simulator.Core
{
    public static class FacingFactory
    {
        public static Facing NORTH = new Facing("north", 0, 1);
        public static Facing SOUTH = new Facing("south", 0, -1);
        public static Facing EAST = new Facing("east", 1, 0);
        public static Facing WEST = new Facing("west", -1, 0);

        public static Facing GetFacing(string facingString)
        {
            if ("NORTH".Equals(facingString, StringComparison.OrdinalIgnoreCase))
            {
                return NORTH;
            }
            if ("SOUTH".Equals(facingString, StringComparison.OrdinalIgnoreCase))
            {
                return SOUTH;
            }
            if ("EAST".Equals(facingString, StringComparison.OrdinalIgnoreCase))
            {
                return EAST;
            }
            if ("WEST".Equals(facingString, StringComparison.OrdinalIgnoreCase))
            {
                return WEST;
            }

            throw new FacingParseException($"'{facingString}' not recognised as Facing try NORTH, SOUTH, EAST, WEST.");
        }
    }
}
