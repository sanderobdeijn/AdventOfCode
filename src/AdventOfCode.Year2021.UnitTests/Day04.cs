using AdventOfCode.Year2021.Day04;

namespace AdventOfCode.Year2021.UnitTests;

public class Day04
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();

        Assert.Equal(4512, sut.Solve());
    }

    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();

        Assert.Equal(25410, sut.Solve());
    }

    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();

        Assert.Equal(2730, sut.Solve());
    }
}