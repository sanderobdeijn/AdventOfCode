using AdventOfCode.Year2021.Day08;

namespace AdventOfCode.Year2021.UnitTests;

public class Day08
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();

        Assert.Equal(26, sut.Solve());
    }

    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();

        Assert.Equal(274, sut.Solve());
    }

    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();

        Assert.Equal(1012089, sut.Solve());
    }
}