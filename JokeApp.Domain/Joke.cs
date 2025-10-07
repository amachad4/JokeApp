namespace JokeApp.Domain;

public class Joke
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string SetUp { get; set; } = string.Empty;
    public string Punchline { get; set; } = string.Empty;
}