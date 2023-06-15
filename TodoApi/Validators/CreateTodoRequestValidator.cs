using FluentValidation;
using TodoApi.Dtos;

namespace TodoApi.Validators;

public class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest>
{
    public CreateTodoRequestValidator()
    {
        RuleFor(x => x.BoardId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
    }
}