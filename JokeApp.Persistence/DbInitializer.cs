using System;
using JokeApp.Domain;

namespace JokeApp.Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Jokes.Any()) return;

        var jokes = new List<Joke>
        {
            new Joke { SetUp = "Why did the bicycle fall over?", Punchline = "Because it was two tired!" }
        };

        context.Jokes.AddRange(jokes);

        await context.SaveChangesAsync();
    }
}
