using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidValue_ShouldSetValue()
    {
        // Arrange
        int x1 = 3; int y1 = 4;
        int x2 = 7; int y2 = 8;
        // Act
        var r = new Rectangle(x1,y1,x2,y2);
        // Assert
        Assert.Equal(x1, r.X1);
        Assert.Equal(y1, r.Y1);
        Assert.Equal(x2, r.X2);
        Assert.Equal(y2, r.Y2);

    }

    [Theory]
    [InlineData(1,1,1,3)]
    [InlineData(-1,5,5,5)]
    public void
        Constructor_InvalidValue_ShouldThrowArgumentOutOfRangeException
        (int x1, int y1, int x2, int y2)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(x1,y1,x2,y2));
    }

    [Theory]
    [InlineData(7,-2,10,3,12,4, false)]
    [InlineData(0,5,14,3,-4,6, true)]
    [InlineData(13, 2, 4, -6,5,7, false)]
    [InlineData(8,-9,5, 3, 2,15, false)]
    public void Contains_ShouldReturnCorrectValue(int x, int y, int x1, int y1, int x2, int y2, bool expected)
    {
        // Arrange
        var p = new Point(x,y);
        var r = new Rectangle(x1,y1,x2,y2);
        // Act
        var result = r.Contains(p);
        // Assert
        Assert.Equal(expected, result);
    }

}