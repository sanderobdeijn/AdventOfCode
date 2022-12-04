using AdventOfCode.Year2022.Day03;

namespace AdventOfCode.Year2022.UnitTests;

public class Day03
{
    [Fact]
    public void Challenge1ExampleShouldBeCorrect()
    {
        var sut = new Challenge1Example();

        Assert.Equal(157, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(7872, sut.Solve());
    }

    [Fact]
    public void Challenge2ExampleShouldBeCorrect()
    {
        var sut = new Challenge2Example();
       
        Assert.Equal(70, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();

        Assert.Equal(2497, sut.Solve());
    }
}