﻿using SimConsole;
using SimConsole.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal((size, size), (map.SizeX, map.SizeY));

    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int size)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(3, 4, 5, false)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, false)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(19, 10, Direction.Right, 19, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(19, 10, Direction.Right, 19, 10)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}