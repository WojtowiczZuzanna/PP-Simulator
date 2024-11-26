using SimConsole;
using System.Numerics;
using Xunit;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(26, 0, 25, 25)]
    [InlineData(4, 4, 0, 4)]
    public void Limiter_ShouldLimitCorrectly(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("  donkey ", 3, 7, '#', "donkey")]
    [InlineData("Puss in Boots – a clever and brave cat.",0, 15, '#', "Puss in Boots –")]
    [InlineData("A", 3, 5, '#', "A##")]
    [InlineData("a                   b", 0, 4, '#',"A###")]
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }

}
