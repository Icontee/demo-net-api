var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weather", () =>
{
    return new[]
    {
        new { Date = DateTime.Now, TempC = 25, Summary = "Warm" }
    };
});

app.Run();
