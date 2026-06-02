# About
This app is a runner for [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life). Game of Life is
a cellular automation on a 2D grid following 4 simple rules: 
1. Any live cell with fewer than two live neighbors dies, as if by underpopulation.
2. Any live cell with two or three live neighbors lives on to the next generation.
3. Any live cell with more than three live neighbors dies, as if by overpopulation.
4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

To draw in the grid you simply click any cell you want to change the state of, you can also hold and drag to switch 
multiple cells quickly. Below the grid is a control menu with four features. They are from left to right, randomize the 
grid, clear the grid, play/auto update the grid and step to the next generation.

The project is structured as a fullstack app, with the logic and backend written in C# with .NET, and the frontend is 
written with Angular. The app is Dockerized and can be run through the compose file, in the project root folder. When 
running the frontend is accessed at http://localhost:4200/. The backend server can be reached at http://localhost:5081, 
an example GET request is http://localhost:5081/grid.

## Screenshots
![img_1.png](img_1.png)

![img_2.png](img_2.png)