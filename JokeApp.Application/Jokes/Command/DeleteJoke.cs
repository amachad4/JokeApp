using JokeApp.Domain;
using JokeApp.Persistence;
using MediatR;

namespace JokeApp.Application.Jokes.Command;

public class DeleteJoke
{
    public class Command : IRequest<Unit>
    {
        public required string Id { get; init; }
    }

    public class Handler(AppDbContext dbContext) : IRequestHandler<Command, Unit>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var joke = dbContext.Jokes.FirstOrDefault(x => x.Id == request.Id);
            dbContext.Jokes.Remove(joke);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}