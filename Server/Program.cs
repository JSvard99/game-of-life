using Logic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

var runner = new Runner(10, 5);

app.MapGet("/grid", () => runner.Grid);

app.Run();
