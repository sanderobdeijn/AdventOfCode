using AdventOfCode.Year2021.Day18;

namespace AdventOfCode.Year2021.UnitTests;

public class Day18
{
    [Fact]
    public void ListAdditionShouldBeCorrect()
    {
        var snailFishNumbers = new List<string>
        {
            "[1,1]",
            "[2,2]",
            "[3,3]",
            "[4,4]",
        };

        var result = Solver.Add(snailFishNumbers);

        Assert.Equal("[[[[1,1],[2,2]],[3,3]],[4,4]]", result);
    }
    
    [Fact]
    public void ListAdditionWithExplodeShouldBeCorrect()
    {
        var snailFishNumbers = new List<string>
        {
            "[1,1]",
            "[2,2]",
            "[3,3]",
            "[4,4]",
            "[5,5]",
        };

        var result = Solver.Add(snailFishNumbers);

        Assert.Equal("[[[[3,0],[5,3]],[4,4]],[5,5]]", result);
    }    
    
    [Fact]
    public void ListAdditionWithMultipleExplodesShouldBeCorrect()
    {
        var snailFishNumbers = new List<string>
        {
            "[1,1]",
            "[2,2]",
            "[3,3]",
            "[4,4]",
            "[5,5]",
            "[6,6]",
        };

        var result = Solver.Add(snailFishNumbers);

        Assert.Equal("[[[[5,0],[7,4]],[5,5]],[6,6]]", result);
    }  
    
    [Fact]
    public void ExplodeAndSplitShouldBeCorrect()
    {
        var input = "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]";
        Solver.Explode(ref input);
        Assert.Equal("[[[[0,7],4],[7,[[8,4],9]]],[1,1]]", input);
        Solver.Explode(ref input);
        Assert.Equal("[[[[0,7],4],[15,[0,13]]],[1,1]]", input);
        Solver.Split(ref input);
        Assert.Equal("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", input);
        Solver.Split(ref input);
        Assert.Equal("[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]", input);
        Solver.Explode(ref input);
        Assert.Equal("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", input);

        var result = Solver.Add("[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]");
        
        Assert.Equal("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", result);
    }   
    
    [Theory]
    [InlineData("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
    [InlineData("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
    [InlineData("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
    [InlineData("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
    [InlineData("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
    public void ExplodeShouldBeCorrect(string input, string expected)
    {
        Solver.Explode(ref input);
        Assert.Equal(expected, input);
    }    
    
    [Theory]
    [InlineData("[9,1]", 29)]
    [InlineData("[1,9]", 21)]
    [InlineData("[[9,1],[1,9]]", 129)]
    [InlineData("[[1,2],[[3,4],5]]", 143)]
    public void CalculateMagnitudShouldBeCorrect(string input, int expected)
    {
        var result = Solver.CalculateMagnitude(input);
        Assert.Equal(expected, result);
    }    
    
    [Fact]
    public void ComplexListAdditionShouldBeCorrect()
    {
        var snailFishNumbers = new List<string>
        {
            "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]",
            "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]",
            "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]",
            "[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]",
            "[7,[5,[[3,8],[1,4]]]]",
            "[[2,[2,2]],[8,[8,1]]]",
            "[2,9]",
            "[1,[[[9,3],9],[[9,0],[0,7]]]]",
            "[[[5,[7,4]],7],1]",
            "[[[[4,2],2],6],[8,7]]",
        };

        var result = Solver.Add(snailFishNumbers);

        Assert.Equal("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", result);
    }  
    
    [Fact]
    public void Challenge1ExampleShouldBeCorrect()
    {
        var sut = new Challenge1Example();

        Assert.Equal(4140, sut.Solve());
    }

    [Fact]
    public void Challenge1InputShouldBeCorrect()
    {
        var sut = new Challenge1Input();

        Assert.Equal(4289, sut.Solve());
    }

    [Fact]
    public void Challenge2ExampleShouldBeCorrect()
    {
        var sut = new Challenge2Example();
       
        Assert.Equal(3993, sut.Solve());
    }
    
    [Fact]
    public void Challenge2InputShouldBeCorrect()
    {
        var sut = new Challenge2Input();

        Assert.Equal(4807, sut.Solve());
    }
}