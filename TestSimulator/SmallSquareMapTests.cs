using Simulator;
using Simulator.Maps;


namespace TestSimulator
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSize()
        {
            int sizeX = 10;
            int sizeY = 10;
            var map = new SmallSquareMap(sizeX,sizeY);
            Assert.Equal(sizeX,map.SizeX);
            Assert.Equal(sizeY, map.SizeY);
        }
        [Theory]
        [InlineData(4,15)]
        [InlineData(15,21)]
        [InlineData(1,21)]
        public void Constructor_InvalidSize_ShouldThrowArgumentOutOfException(int sizeX, int sizeY)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX,sizeY));
           
        }
        [Theory]
        [InlineData(20,19,20, 20, false)] //nie należy bo na etapie wchodzenia 20 < 20 
        [InlineData(3,4,5, 5, true)]
        [InlineData(19, 19, 20, 20, true)] //należy do map 
        [InlineData(20, 20, 20, 20, false)]
        public void Exist_PointAffiliation_PointDoesBelongToTheMap(int x,int y,int sizeX, int sizeY, bool expected)
        {
            //Arrange
            var point = new Point(x,y);
            var map = new SmallSquareMap(sizeX, sizeY);
            //Act - to co robię 
            var result = map.Exist(point);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        //punkty wejściowe są już sprawdzone przez Constructor 
        [InlineData(5,10, Direction.Up, 5, 11)]
        [InlineData(0, 0, Direction.Down, 0, 0)] //punkty od (0,0) do (Size -1, Size -1)
        [InlineData(0, 8, Direction.Left, 0, 8)]
        [InlineData(19, 10, Direction.Right, 19,10)] 

        public void Next_ShouldReturnCorrectPoint(int x, int y, Direction dir, int x1, int y1)
        {
            //Arrange
            var point = new Point(x, y);
            var map = new SmallSquareMap(20,20);
            var expectedPoint = new Point(x1, y1);
            //Act
            var nextPoint = map.Next(point, dir);
            //Assert
            Assert.Equal(expectedPoint, nextPoint); //to co chcemy, później actual

        }
        [Theory]
        
        [InlineData(5, 10, Direction.Up, 6, 11)]
        //warunki brzegowe
        [InlineData(0, 0, Direction.Down, 0, 0)]
        [InlineData(0, 8, Direction.Left, 0, 8)]
        [InlineData(19, 10, Direction.Right, 19, 10)]
        public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction dir, int x1, int y1)
        {
            //Arrange
            var p = new Point(x, y);
            var map = new SmallSquareMap(20,20 );
            var excPoint = new Point(x1, y1);
            //Act
            var nextDiagonalPoint = map.NextDiagonal(p, dir);
            //Assert
            Assert.Equal(excPoint, nextDiagonalPoint);
        }
    }
}




