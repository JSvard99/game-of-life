namespace Logic;

public class Runner
{
    private Cell[,] _grid;

    public bool[,] Grid
    {
        get
        {
            bool[,] grid = new  bool[_grid.GetLength(0), _grid.GetLength(1)];
            
            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                for (int column = 0; column < _grid.GetLength(1); column++)
                {
                    grid[row, column] = _grid[row, column].IsAlive;
                }
            }

            return grid;
        }
    }
    
    public Runner(int width, int height)
    {
        _grid = new Cell[width, height];
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                _grid[column, row] = new Cell();
            }
        }
    }
    
    private class Cell
    {
        public bool IsAlive = false;
    }
}