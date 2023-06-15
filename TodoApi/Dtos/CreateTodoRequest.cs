namespace TodoApi.Dtos;

public class CreateTodoRequest
{
    public Guid BoardId { get; set; }
    public string Title { get; set; } = null!;
}
