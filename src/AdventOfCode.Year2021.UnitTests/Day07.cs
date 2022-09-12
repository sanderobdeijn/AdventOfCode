using AdventOfCode.Year2021.Day07;

namespace AdventOfCode.Year2021.UnitTests;

public class Day07
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();

        Assert.Equal(37, sut.Solve());
    }

    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();

        Assert.Equal(354129, sut.Solve());
    }

    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();

        Assert.Equal(98905973, sut.Solve());
    }
}