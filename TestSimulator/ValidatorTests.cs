
using Simulator;
namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData("Ox",4,15, '#',"Ox##" )]
    [InlineData("Elf",4,15,'%',"Elf%")]
    public void Shortener_ValueSmallerThanMinimum_ShouldReturnValueWithPlaceholder
        (string description, int x, int y, char placeholder, string expected)
    {
        //Arrange
        var creature = description;
        
        //Act
        var actual = Validator.Shortener(creature, x, y, placeholder);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Shortener_ValueBiggerThanMaximum_ShouldReturnTruncated()
    {
        //Arrange
        var animal = "American Coonhound";
        var expected = "American Coonho";
        //Act
        var actual = Validator.Shortener(animal, 3, 15, '#');
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 2, 1)]
    [InlineData(2, 1, 2, 2)]
    [InlineData(1, 1, 10, 1)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(28, 1, 10, 10)]
    [InlineData(-18, 0, 36, 0)]

    public void Limiter_ReturnCorrectValue(int input, int min, int max, int expected)
    {
        //Act
        var check = Validator.Limiter(input, min, max);
        //Assert
        Assert.Equal(expected, check);
    }

}

