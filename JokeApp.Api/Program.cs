using JokeApp.Application.Jokes.Command;
using JokeApp.Domain;
using JokeApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblyContaining<CreateJoke.Command>();
});

var app = builder.Build();

app.MapGet("/api/jokes", async (AppDbContext db) =>
{
    var jokes = await db.Jokes.AsNoTracking().ToListAsync();
    return Results.Ok(jokes);
});

app.MapGet("/api/jokes/{id}", async (string id,AppDbContext db) =>
{
    var joke = await db.Jokes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    return Results.Ok(joke);
});

app.MapPost("/api/jokes/", async (Joke joke, ISender sender) =>
{
    return await sender.Send(new CreateJoke.Command { Joke = joke });
});

app.MapPut("/api/jokes/{id}", async (string id, Joke input, AppDbContext db) =>
{
    var joke = await db.Jokes.FirstOrDefaultAsync(x => x.Id == id);
    joke.SetUp = input.SetUp;
    joke.Punchline = input.Punchline;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/jokes/{id}", async (string id, AppDbContext db) =>
{
    var joke = await db.Jokes.FirstOrDefaultAsync(x => x.Id == id);
    db.Jokes.Remove(joke);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// creating a service scope
// when we run the application, this will be cleaned up
using var scope = app.Services.CreateScope();

var service = scope.ServiceProvider;

try
{
    var context = service.GetRequiredService<AppDbContext>();

    await context.Database.MigrateAsync();

    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
