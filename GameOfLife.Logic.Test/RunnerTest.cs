using GameOfLife.Logic;

namespace GameOfLife.Logic.Test;

[TestFixture]
public class RunnerTest
{
    [Test]
    public void RunnerCreatesGrid()
    {
        var runner = new Runner(10, 5);
        
        Assert.That(runner.Grid, Has.Length.EqualTo(5));
    }
}