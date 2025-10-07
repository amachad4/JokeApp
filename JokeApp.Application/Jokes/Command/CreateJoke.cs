using JokeApp.Domain;
using JokeApp.Persistence;
using MediatR;

namespace JokeApp.Application.Jokes.Command;

public class CreateJoke
{
    public class Command : IRequest<string>
    {
        public required Joke Joke { get; set; }
    }

    public class Handler(AppDbContext dbContext) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            request.Joke.Id = Guid.NewGuid().ToString();
            dbContext.Jokes.Add(request.Joke);
            await dbContext.SaveChangesAsync();
            return request.Joke.Id;
        }
    }
}