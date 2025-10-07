using JokeApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace JokeApp.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Joke> Jokes { get; set; }
}