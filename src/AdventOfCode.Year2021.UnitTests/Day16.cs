using AdventOfCode.Year2021.Day16;

namespace AdventOfCode.Year2021.UnitTests;

public class Day16
{
    [Fact]
    public void Challenge1Example1ShouldBeCorrect()
    {
        var sut = new Challenge1Example1();

        Assert.Equal(16, sut.Solve());
    }
    
    [Fact]
    public void Challenge1Example2ShouldBeCorrect()
    {
        var sut = new Challenge1Example2();

        Assert.Equal(12, sut.Solve());
    }
    
    [Fact]
    public void Challenge1Example3ShouldBeCorrect()
    {
        var sut = new Challenge1Example3();

        Assert.Equal(23, sut.Solve());
    }
    
    [Fact]
    public void Challenge1Example4ShouldBeCorrect()
    {
        var sut = new Challenge1Example4();

        Assert.Equal(31, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(1012, sut.Solve());
    }

    [Fact]
    public void Challenge2Example1ShouldBeCorrect()
    {
        var sut = new Challenge2Example1();
       
        Assert.Equal((long)3, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example2ShouldBeCorrect()
    {
        var sut = new Challenge2Example2();
       
        Assert.Equal((long)54, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example3ShouldBeCorrect()
    {
        var sut = new Challenge2Example3();
       
        Assert.Equal((long)7, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example4ShouldBeCorrect()
    {
        var sut = new Challenge2Example4();
       
        Assert.Equal((long)9, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example5ShouldBeCorrect()
    {
        var sut = new Challenge2Example5();
       
        Assert.Equal((long)1, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example6ShouldBeCorrect()
    {
        var sut = new Challenge2Example6();
       
        Assert.Equal((long)0, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example7ShouldBeCorrect()
    {
        var sut = new Challenge2Example7();
       
        Assert.Equal((long)0, sut.Solve());
    }
    
    [Fact]
    public void Challenge2Example8ShouldBeCorrect()
    {
        var sut = new Challenge2Example8();
       
        Assert.Equal((long)1, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();

        Assert.Equal(2223947372407, sut.Solve());
    }
}