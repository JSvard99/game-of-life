using Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        {
        policy.WithOrigins("*"); 
        }));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();

var runner = new Runner(10, 5);

app.MapGet("/grid", () => runner.Grid);

app.Run();
