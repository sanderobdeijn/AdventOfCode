using AdventOfCode.Year2022.Day04;

namespace AdventOfCode.Year2022.UnitTests;

public class Day04
{
    [Fact]
    public void Challenge1ExampleShouldBeCorrect()
    {
        var sut = new Challenge1Example();

        Assert.Equal(2, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(453, sut.Solve());
    }

    [Fact]
    public void Challenge2ExampleShouldBeCorrect()
    {
        var sut = new Challenge2Example();
       
        Assert.Equal(4, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();

        Assert.Equal(919, sut.Solve());
    }
}