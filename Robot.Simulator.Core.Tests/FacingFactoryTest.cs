using FluentAssertions;
using Robot.Simulator.Core.Exceptions;
using Xunit;

namespace Robot.Simulator.Core.Tests
{
    public class FacingFactoryTest
    {
        [Fact]
        public void Should_Return_The_Correct_Value_For_North()
        {
            var facing = FacingFactory.GetFacing("NORTH");
            facing.Should().Be(FacingFactory.NORTH);
        }

        [Fact]
        public void Should_Return_The_Correct_Value_For_South()
        {
            var facing = FacingFactory.GetFacing("SOUTH");
            facing.Should().Be(FacingFactory.SOUTH);
        }

        [Fact]
        public void Should_Return_The_Correct_Value_For_East()
        {
            var facing = FacingFactory.GetFacing("EAST");
            facing.Should().Be(FacingFactory.EAST);
        }

        [Fact]
        public void Should_Return_The_Correct_Value_For_west()
        {
            var facing = FacingFactory.GetFacing("WEST");
            facing.Should().Be(FacingFactory.WEST);
        }

        [Fact]
        public void Should_Return_The_Correct_Value_For_Lower_Case()
        {
            var facing = FacingFactory.GetFacing("north");
            facing.Should().Be(FacingFactory.NORTH);
        }

        [Fact]
        public void Should_Return_The_Correct_Value_For_Mixed_Case()
        {
            var facing = FacingFactory.GetFacing("North");
            facing.Should().Be(FacingFactory.NORTH);
        }

        [Fact]
        public void Should_Throw_Facing_Parse_Exception_When_Given_Non_Matching_Facing_String()
        {
            try
            {
                var facing = FacingFactory.GetFacing("Zoo");
            }
            catch (FacingParseException ex)
            {
                ex.Message.Should().Be("'Zoo' not recognised as Facing try NORTH, SOUTH, EAST, WEST.");
            }
        }
    }
}
