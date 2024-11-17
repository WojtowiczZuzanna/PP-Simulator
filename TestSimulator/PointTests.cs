using Simulator;

namespace TestSimulator;

public class PointTests
{ 

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(-3, 15, Direction.Down, -3, 14)]
    [InlineData(7, 7, Direction.Left, 6, 7)]
    [InlineData(19, -6, Direction.Right, 20, -6)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var p = new Point(x, y);
        // Act
        var nextPoint = p.Next(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(-3, 15, Direction.Down, -4, 14)]
    [InlineData(7, 7, Direction.Left, 6, 8)]
    [InlineData(19, -6, Direction.Right, 20, -7)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var p = new Point(x, y);
        // Act
        var nextPoint = p.NextDiagonal(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}