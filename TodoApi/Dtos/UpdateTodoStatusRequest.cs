namespace TodoApi.Dtos;

public class UpdateTodoStatusRequest
{
    public Guid Id { get; set; }
    public bool IsDone { get; set; }
}
