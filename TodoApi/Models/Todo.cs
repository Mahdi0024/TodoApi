namespace TodoApi.Models;

public sealed class Todo
{
    public Guid Id { get; set; }
    public Guid BoardId { get; set; }
    public string Title { get; set; } = null!;
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}