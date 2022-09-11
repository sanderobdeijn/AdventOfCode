using AdventOfCode.Year2021.Day02;

namespace AdventOfCode.Year2021.UnitTests;

public class Day02
{
    [Fact]
    public void Example1ShouldBeCorrect()
    {
        var sut = new Example1();
        
        Assert.Equal(150 ,sut.Solve());
    }
    
    [Fact]
    public void Challenge1ShouldBeCorrect()
    {
        var sut = new Challenge1();
        
        Assert.Equal(1690020 ,sut.Solve());
    }
    
    [Fact]
    public void Challenge2ShouldBeCorrect()
    {
        var sut = new Challenge2();
        
        Assert.Equal(1408487760 ,sut.Solve());
    }
}