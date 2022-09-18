using AdventOfCode.Year2021.Day11;

namespace AdventOfCode.Year2021.UnitTests;

public class Day11
{
    [Fact]
    public void Challenge1ExampleShouldBeCorrect()
    {
        var sut = new Challenge1Example();

        Assert.Equal(1656, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(1599, sut.Solve());
    }

    [Fact]
    public void Challenge2ExampleShouldBeCorrect()
    {
        var sut = new Challenge2Example();

        Assert.Equal(195, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();

        Assert.Equal(418, sut.Solve());
    }
}