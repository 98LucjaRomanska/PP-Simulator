using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
namespace TestSimulator
{
    public class RectangleTests
    {
        [Fact]
        public void Constructor_ReversedOrderPoints_ShouldReturnRectangle()
        {
            //Arrange
            int x1 = 9; int y1 = 10;
            int x2 = 3; int y2 = 2;
            //Act
            var rect = new Rectangle(x1, y1, x2, y2);
            //Assert
            //jeśli współrzędne są w złej kolejności mają zostać zmienione
            Assert.Equal(3, rect.X1);
            Assert.Equal(2, rect.Y1);
            Assert.Equal(9, rect.X2);
            Assert.Equal(10, rect.Y2);
        }

        [Theory]
        [InlineData(1,2,1,3)]
        [InlineData(14,16,15,16)]
        public void Contructor_InvalidSize_ShouldThrowArgException
            (int x, int y, int x1, int y1)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(x, y, x1, y1));
        }

        [Fact]
        public void ConstructorPoint_ShouldBuildRectangleWithTwoPoints()
        {
            //Arrange
            int x1 = 1; int y1 = 2;
            int x2 = 3; int y2 = 5; //also expected coordinates

            //Act
            var p1 =new Point(x1, y1);
            var p2 =new Point(x2, y2);
            var obtainedRect = new Rectangle(p1, p2);
            //Assert
            Assert.Equal(1,obtainedRect.X1);
            Assert.Equal(2, obtainedRect.Y1);
            Assert.Equal(3, obtainedRect.X2);
            Assert.Equal(5, obtainedRect.Y2);
        }

        [Theory]
        [InlineData(3,14, false)] //point coordinates + bool condiction
        [InlineData(7,10, true)]
        [InlineData(5,11, true)]
        [InlineData(10,20,true)] //brzegowe
        [InlineData(7,3, false)]
        [InlineData(-2,20,false)]
        [InlineData(5, 0,false)]
        public void Contains_PointAffiliation_ShouldBelongToRectangle(int x, int y, bool contain)
        {
            //Arrange
            var p1 = new Point(10,20);
            var p2 = new Point(5, 10);
            var rect = new Rectangle(p1, p2);
            var checkPoint = new Point(x, y);
            //Act
            var question = rect.Contains(checkPoint);
            //Assert
            Assert.Equal(contain, question);


        }
    }
}
