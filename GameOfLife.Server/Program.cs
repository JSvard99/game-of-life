using GameOfLife.Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    }));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();

var runner = new Grid(15, 30);

app.MapGet("/grid", () => runner.Cells);

app.MapPut("/grid/{row:int}/{column:int}", (int row, int column, bool state) =>
{
    try
    {
        runner.SetCellState(row, column, state);
        return Results.Ok(runner.Cells);
    }
    catch (IndexOutOfRangeException)
    {
        return Results.BadRequest("Invalid cell.");
    }
});

app.MapPost("/grid/update", () =>
{
    runner.UpdateGrid();

    return runner.Cells;
});

app.MapPost("grid/clear", () =>
{
    runner.ClearGrid();

    return runner.Cells;
});

app.MapPost("grid/randomize", () =>
{
    runner.RandomizeGrid();

    return runner.Cells;
});

app.Run();