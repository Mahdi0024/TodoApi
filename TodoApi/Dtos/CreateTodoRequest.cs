using FluentValidation;

namespace TodoApi.Dtos;

public class CreateTodoRequest
{
    public Guid BoardId { get; set; }
    public string Title { get; set; } = null!;
}

public class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest>
{
    public CreateTodoRequestValidator()
    {
        RuleFor(x => x.BoardId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
    }
}