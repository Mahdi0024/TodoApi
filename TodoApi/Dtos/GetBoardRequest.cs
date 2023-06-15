namespace TodoApi.Dtos;

public class GetBoardRequest
{
    public Guid Id { get; set; }
    public bool IncludeTodos { get; set; }
}
