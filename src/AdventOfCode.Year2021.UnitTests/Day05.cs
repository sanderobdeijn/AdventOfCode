using AdventOfCode.Year2021.Day05;

namespace AdventOfCode.Year2021.UnitTests;

public class Day05
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();

        Assert.Equal(5, sut.Solve());
    }

    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();

        Assert.Equal(7674, sut.Solve());
    }

    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();

        Assert.Equal(20898, sut.Solve());
    }
}