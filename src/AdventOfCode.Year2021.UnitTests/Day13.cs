using AdventOfCode.Year2021.Day13;

namespace AdventOfCode.Year2021.UnitTests;

public class Day13
{
    [Fact]
    public void Challenge1ExampleShouldBeCorrect()
    {
        var sut = new Challenge1Example();

        Assert.Equal(17, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(802, sut.Solve());
    }

    [Fact]
    public void Challenge2ExampleShouldBeCorrect()
    {
        var sut = new Challenge2Example();

        var code = @"
XXXXX
X   X
X   X
X   X
XXXXX
     
     
";
        
        Assert.Equal(code, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();
        
        var code = @"
XXX  X  X X  X XXXX XXXX  XX  X  X XXX  
X  X X X  X  X X       X X  X X  X X  X 
X  X XX   XXXX XXX    X  X    X  X XXX  
XXX  X X  X  X X     X   X XX X  X X  X 
X X  X X  X  X X    X    X  X X  X X  X 
X  X X  X X  X X    XXXX  XXX  XX  XXX  
";

        Assert.Equal(code, sut.Solve());
    }
}