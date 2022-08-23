using AdventOfCode.Year2021.Day01;

namespace AdventOfCode.Year2021.UnitTests;

public class Day01
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();
        
        Assert.Equal(7 ,sut.Solve());
    }
    
    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();
        
        Assert.Equal(1832 ,sut.Solve());
    }
    
    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();
        
        Assert.Equal(1858 ,sut.Solve());
    }
}