using FluentValidation;

namespace TodoApi.Dtos;

public class UpdateTodoStatusRequest
{
    public Guid Id { get; set; }
    public bool IsDone { get; set; }
}

public class UpdateTodoStatusRequestValidator : AbstractValidator<UpdateTodoStatusRequest>
{
    public UpdateTodoStatusRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}