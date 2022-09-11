using AdventOfCode.Year2021.Day03;

namespace AdventOfCode.Year2021.UnitTests;

public class Day03
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();

        Assert.Equal(198, sut.Solve());
    }

    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();

        Assert.Equal(1082324, sut.Solve());
    }

    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();

        Assert.Equal(1353024, sut.Solve());
    }
}