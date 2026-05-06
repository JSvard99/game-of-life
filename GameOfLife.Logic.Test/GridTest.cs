namespace GameOfLife.Logic.Test;

[TestFixture]
public class GridTest
{
    [Test]
    public void Constructor_CreatesGrid()
    {
        // Arrange/Act
        var runner = new Grid(10, 5);

        // Assert
        Assert.That(runner.Cells, Has.Length.EqualTo(10));
    }

    [Test]
    public void SwitchCellState_SwitchesState()
    {
        // Arrange
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 5);
        var initialState = runner.Cells[row][column];

        // Act
        runner.SetCellState(new Coordinate(row, column), true);
        var newState = runner.Cells[row][column];

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

        var runner = new Grid(10, 5);

        // Act/Assert
        Assert.Throws<IndexOutOfRangeException>(() => runner.SetCellState(new Coordinate(row, column), true));
    }

    [Test]
    public void UpdateGrid_DeadCellStaysDead()
    {
        // Arrange
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 5);

        // Act
        runner.Update();

        // Assert
        Assert.That(!runner.Cells[row][column]);
    }

    [Test]
    public void UpdateGrid_AliveCellStaysAlive()
    {
        // Arrange
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 10);

        runner.SetCellState(new Coordinate(row, column), true);
        runner.SetCellState(new Coordinate(row - 1, column - 1), true);
        runner.SetCellState(new Coordinate(row - 1, column), true);
        runner.SetCellState(new Coordinate(row - 1, column + 1), true);

        // Act
        runner.Update();

        // Assert
        Assert.That(runner.Cells[row][column], Is.True);
    }

    [Test]
    public void UpdateGrid_DeadCellComesAlive()
    {
        // Arrange
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 10);

        runner.SetCellState(new Coordinate(row - 1, column - 1), true);
        runner.SetCellState(new Coordinate(row - 1, column), true);
        runner.SetCellState(new Coordinate(row - 1, column + 1), true);

        // Act
        runner.Update();

        // Assert
        Assert.That(runner.Cells[row][column], Is.True);
    }

    [Test]
    public void UpdateGrid_AliveCellDiesByUnderpopulation()
    {
        // Arrange
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 10);

        runner.SetCellState(new Coordinate(row, column), true);

        // Act
        runner.Update();

        // Assert
        Assert.That(runner.Cells[row][column], Is.False);
    }

    [Test]
    public void UpdateGrid_AliveCellDiesByOverpopulation()
    {
        // Arrange
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 10);

        runner.SetCellState(new Coordinate(row, column), true);
        runner.SetCellState(new Coordinate(row - 1, column - 1), true);
        runner.SetCellState(new Coordinate(row - 1, column), true);
        runner.SetCellState(new Coordinate(row - 1, column + 1), true);
        runner.SetCellState(new Coordinate(row, column - 1), true);

        // Act
        runner.Update();

        // Assert
        Assert.That(runner.Cells[row][column], Is.False);
    }

    [Test]
    public void ClearGrid_EmptyGrid_StaysEmpty()
    {
        // Arrange
        var runner = new Grid(10, 5);
        // Act
        runner.Clear();
        // Assert
        Assert.That(runner.Cells, Has.Length.EqualTo(10));
        foreach (var row in runner.Cells)
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
        const int row = 3;
        const int column = 4;

        var runner = new Grid(10, 5);

        runner.SetCellState(new Coordinate(row, column), true);

        // Act
        runner.Clear();

        // Assert
        Assert.That(runner.Cells, Has.Length.EqualTo(10));
        foreach (var cellRow in runner.Cells)
        {
            foreach (var cell in cellRow)
            {
                Assert.That(cell, Is.False);
            }
        }
    }

    [Test]
    public void RandomizeGrid_Randomizes()
    {
        // Arrange
        var runner = new Grid(10, 5);
        var original = runner.Cells.Clone();

        // Act
        runner.Randomize();

        // Assert
        Assert.That(runner.Cells, Is.Not.EqualTo(original));
    }
}