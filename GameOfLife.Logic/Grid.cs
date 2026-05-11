using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace GameOfLife.Logic;

public class Grid
{
    private readonly Cell[,] _cells;

    public bool[][] Cells
    {
        get
        {
            var grid = new bool[_cells.GetLength(0)][];
            
            for (var row = 0; row < _cells.GetLength(0); row++)
            {
                grid[row] = new bool[_cells.GetLength(1)];
                
                for (var column = 0; column < _cells.GetLength(1); column++)
                {
                    grid[row][column] = _cells[row, column].IsAlive;
                }
            }

            return grid;
        }
    }
    
    public Grid(int height, int width)
    {
        _cells = new Cell[height, width];
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                _cells[row, column] = new Cell();
            }
        }

        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                
                var cell = _cells[row, column];
                for (var neighborRow = row - 1; neighborRow <= row + 1; neighborRow++)
                {
                    for (var neighborColumn = column - 1; neighborColumn <= column + 1; neighborColumn++)
                    {
                        if (neighborRow == row && neighborColumn == column) continue;
                        
                        try
                        {
                            var neighbor = _cells[neighborRow, neighborColumn];
                            cell.AddNeighbor(neighbor);
                        }
                        catch (IndexOutOfRangeException) {}
                    }
                }
            }
        }
    }

    public void SetCellState(Coordinate coordinate, bool state)
    {
        _cells[coordinate.Row, coordinate.Column].IsAlive = state;
    }

    public void Update()
    {
        var cellsToSwitch = new List<Cell>();

        foreach (var cell in _cells)
        {
            if (cell.ShouldSwitchState())
            {
                cellsToSwitch.Add(cell);
            }
        }

        foreach (var cell in cellsToSwitch)
        {
            cell.IsAlive = !cell.IsAlive;
        }
    }

    public void Clear()
    {
        foreach (var cell in _cells)
        {
            cell.IsAlive = false;
        }
    }

    public void Randomize()
    {
        var random = new Random();
        
        foreach (var cell in _cells)
        {
            cell.IsAlive = random.NextSingle() < 0.3;
        }
    }
    
    private class Cell
    {
        public bool IsAlive { get; set; }
        private readonly List<Cell> _neighbors = [];
        private const int MaxNeighbours = 8;

        public void AddNeighbor(Cell neighbor)
        {
            if (_neighbors.Count >= MaxNeighbours)
            {
                throw new InvalidOperationException();
            }
            
            _neighbors.Add(neighbor);
        }

        public bool ShouldSwitchState()
        {
            var aliveNeighbors = _neighbors.Count(neighbor => neighbor.IsAlive);

            switch (IsAlive)
            {
                case true when aliveNeighbors < 2:
                case true when aliveNeighbors > 3:
                case false when aliveNeighbors == 3:
                    return true;
                default:
                    return false;
            }
        }
    }
}