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

var runner = new Runner(10, 5);

app.MapGet("/grid", () => runner.Grid);

app.MapPut("/grid/{row:int}/{column:int}", (int row, int column, bool state) =>
{
    try
    {
        runner.SetCellState(row, column, state);
        return Results.Ok(runner.Grid);
    }
    catch (IndexOutOfRangeException e)
    {
        return Results.BadRequest("Invalid cell.");
    }
});

app.MapPost("/grid/update", () =>
{
    runner.UpdateGrid();
    
    return runner.Grid;
});

app.Run();
