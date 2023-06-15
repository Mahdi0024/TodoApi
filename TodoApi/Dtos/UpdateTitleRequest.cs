namespace TodoApi.Dtos;

public class UpdateTitleRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
}
