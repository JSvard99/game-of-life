namespace GameOfLife.Logic.Test;

[TestFixture]
public class RunnerTest
{
    [Test]
    public void Constructor_CreatesGrid()
    {
        var runner = new Runner(10, 5);
        
        Assert.That(runner.Grid, Has.Length.EqualTo(5));
    }

    [Test]
    public void SwitchCellState_SwitchesState()
    {
        // Arrange
        const int  row = 3;
        const int  column = 5;
        
        var runner = new Runner(10, 5);
        var initialState = runner.Grid[row][column];
        
        // Act
        runner.SetCellState(row, column, true);
        var newState = runner.Grid[row][column];
        
        // Assert
        Assert.That(newState, Is.True);
    }
    
    [Test]
    public void SwitchCellState_InvalidCell_ThrowsException()
    {
        // Arrange
        const int row = 3;
        const int column = 15;
        
        var runner = new Runner(10, 5);
        // Act/Assert
        Assert.Throws<IndexOutOfRangeException>(() => runner.SetCellState(row, column, true));
    }
}