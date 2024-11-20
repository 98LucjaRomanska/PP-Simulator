using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator
{
    public class PointTests
    {

        [Theory]
        [InlineData(1, 3, Direction.Up, 1, 4)]
        [InlineData(17, 3, Direction.Left, 16, 3)]
        [InlineData(17, 3, Direction.Right, 18, 3)]
        //nazwaMetody_działanie_oczekiwanyScenariusz
        public void Next_MovePoint_MovePointInADesignatedDirection
            (int x, int y, Direction direction, int x1, int y1)
        {
            //Arrange
            var p = new Point(x, y);
            //Act
            var nextPoint = p.Next(direction);
            //Assert
            Assert.Equal(new Point(x1, y1), nextPoint);

        }
        [Theory]
        [InlineData(1,3, Direction.Up, 2,4)]
        [InlineData(1,3, Direction.Right,2,2)]
        [InlineData(1, 3, Direction.Down,0,2)]
        [InlineData(1, 3, Direction.Left,0,4)]
        public void NextDiagonal_MovePoint_MoveInProperDirection(
            int x, int y, Direction direction, int x1, int y1)
        {
            //Arrange
            var p = new Point(x, y);
            var expected = new Point(x1, y1);
            //Act
            var nextPoint = p.NextDiagonal(direction);
            //Assert
            Assert.Equal(expected, nextPoint);
        }
    }
}
