using AdventOfCode.Year2021.Day06;

namespace AdventOfCode.Year2021.UnitTests;

public class Day06
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();

        Assert.Equal((long)5934, sut.Solve());
    }

    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();

        Assert.Equal((long)390923, sut.Solve());
    }

    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();

        Assert.Equal(1749945484935, sut.Solve());
    }
}