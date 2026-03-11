namespace GameOfLife.Logic;

public class Runner
{
    private readonly Cell[,] _grid;

    public bool[][] Grid
    {
        get
        {
            var grid = new bool[_grid.GetLength(0)][];
            
            for (var row = 0; row < _grid.GetLength(0); row++)
            {
                grid[row] = new bool[_grid.GetLength(1)];
                
                for (var column = 0; column < _grid.GetLength(1); column++)
                {
                    grid[row][column] = _grid[row, column].IsAlive;
                }
            }

            return grid;
        }
    }
    
    public Runner(int height, int width)
    {
        _grid = new Cell[height, width];
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                _grid[row, column] = new Cell();
            }
        }

        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                
                var cell = _grid[row, column];
                for (var neighborRow = row - 1; neighborRow <= row + 1; neighborRow++)
                {
                    for (var neighborColumn = column - 1; neighborColumn <= column + 1; neighborColumn++)
                    {
                        if (neighborRow == row && neighborColumn == column) continue;
                        
                        try
                        {
                            var neighbor = _grid[neighborRow, neighborColumn];
                            cell.AddNeighbor(neighbor);
                        }
                        catch (IndexOutOfRangeException) {}
                    }
                }
            }
        }
    }

    public void SetCellState(int row, int column, bool state)
    {
        _grid[row, column].IsAlive = state;
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