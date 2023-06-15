namespace TodoApi.Models;

public sealed class Board
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public ICollection<Todo> Todos { get; set; } = new List<Todo>();
}