namespace AdventOfCode.Core;

public interface ISolve
{
    public string Input { get; }
    
    public object Solve();
}
