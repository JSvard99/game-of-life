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
    
    public Runner(int width, int height)
    {
        _grid = new Cell[height, width];
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                _grid[row, column] = new Cell();
            }
        }
    }

    public void SwitchCellState(int row, int column)
    {
        _grid[row, column].SwitchState();
    }
    
    private class Cell
    {
        public bool IsAlive
        {
            get;
            private set;
        }

        public void SwitchState()
        {
            IsAlive = !IsAlive;
        }
    }
}