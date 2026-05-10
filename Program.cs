var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        status = "ok",
        timestamp = DateTime.UtcNow.ToString("o")
    });
});

app.MapGet("/version", () =>
{
    var name = app.Configuration["App:Name"] ?? "IsLabApp";
    var version = app.Configuration["App:Version"] ?? "0.1.1";
    return Results.Ok(new
    {
        application = name,
        version = version
    });
});

app.Run();
  
