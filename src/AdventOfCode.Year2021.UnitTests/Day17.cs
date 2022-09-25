using AdventOfCode.Year2021.Day17;

namespace AdventOfCode.Year2021.UnitTests;

public class Day17
{
    [Fact]
    public void Challenge1ExampleShouldBeCorrect()
    {
        var sut = new Challenge1Example();

        Assert.Equal(45, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(7626, sut.Solve());
    }

    [Fact]
    public void Challenge2ExampleShouldBeCorrect()
    {
        var sut = new Challenge2Example();
       
        Assert.Equal(112, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();

        Assert.Equal(2032, sut.Solve());
    }
}