namespace GameOfLife.Logic.Test;

[TestFixture]
public class RunnerTest
{
    [Test]
    public void Constructor_CreatesGrid()
    {
        // Arrange/Act
        var runner = new Runner(10, 5);
        
        // Assert
        Assert.That(runner.Grid, Has.Length.EqualTo(10));
    }

    [Test]
    public void SwitchCellState_SwitchesState()
    {
        // Arrange
        const int  row = 3;
        const int  column = 4;
        
        var runner = new Runner(10, 5);
        var initialState = runner.Grid[row][column];
        
        // Act
        runner.SetCellState(row, column, true);
        var newState = runner.Grid[row][column];
        
        // Assert
        Assert.That(newState, Is.Not.EqualTo(initialState));
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

    [Test]
    public void UpdateGrid_DeadCellStaysDead()
    {
        // Arrange
        const int row = 3;
        const int column = 4;
        
        var runner = new Runner(10, 5);
        
        // Act
        runner.UpdateGrid();
        
        // Assert
        Assert.That(!runner.Grid[row][column]);
    }

    [Test]
    public void UpdateGrid_AliveCellStaysAlive()
    {
        // Arrange
        const int row = 3;
        const int column = 4;
        
        var runner = new Runner(10, 10);
        
        runner.SetCellState(row, column, true);
        runner.SetCellState(row - 1, column - 1, true);
        runner.SetCellState(row - 1, column, true);
        runner.SetCellState(row - 1, column + 1, true);
        
        // Act
        runner.UpdateGrid();

        // Assert
        Assert.That(runner.Grid[row][column], Is.True);
    }

    [Test]
    public void UpdateGrid_DeadCellComesAlive()
    {
        // Arrange
        const int row = 3;
        const int column = 4;
        
        var runner = new Runner(10, 10);
        
        runner.SetCellState(row - 1, column - 1, true);
        runner.SetCellState(row - 1, column, true);
        runner.SetCellState(row - 1, column + 1, true);
        
        // Act
        runner.UpdateGrid();
        
        // Assert
        Assert.That(runner.Grid[row][column], Is.True);
    }

    [Test]
    public void UpdateGrid_AliveCellDiesByUnderpopulation()
    {
        // Arrange
        const int row = 3;
        const int column = 4;
        
        var runner = new Runner(10, 10);
        
        runner.SetCellState(row, column, true);
        
        // Act
        runner.UpdateGrid();
        
        // Assert
        Assert.That(runner.Grid[row][column], Is.False);
    }

    [Test]
    public void UpdateGrid_AliveCellDiesByOverpopulation()
    {
        // Arrange
        const int row = 3;
        const int column = 4;
        
        var runner = new Runner(10, 10);
        
        runner.SetCellState(row, column, true);
        runner.SetCellState(row - 1, column - 1, true);
        runner.SetCellState(row - 1, column, true);
        runner.SetCellState(row - 1, column + 1, true);
        runner.SetCellState(row, column - 1, true);
        
        // Act
        runner.UpdateGrid();
        
        // Assert
        Assert.That(runner.Grid[row][column], Is.False);
    }

    [Test]
    public void ClearGrid_EmptyGrid_StaysEmpty()
    {
        // Arrange
        var runner = new Runner(10, 5);
        // Act
        runner.ClearGrid();
        // Assert
        Assert.That(runner.Grid, Has.Length.EqualTo(10));
        foreach (var row in runner.Grid)
        {
            foreach (var cell in row)
            {
                Assert.That(cell, Is.False);
            }
        }
    }

    [Test]
    public void ClearGrid_PopulatedGrid_Empties()
    {
        // Arrange
        var runner = new Runner(10, 5);
        runner.SetCellState(5, 3, true);
        // Act
        runner.ClearGrid();
        // Assert
        Assert.That(runner.Grid, Has.Length.EqualTo(10));
        foreach (var row in runner.Grid)
        {
            foreach (var cell in row)
            {
                Assert.That(cell, Is.False);
            }
        }
    }
}