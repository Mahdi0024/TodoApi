using FluentValidation;
using TodoApi.Dtos;

namespace TodoApi.Validators;

public class UpdateTodoStatusRequestValidator : AbstractValidator<UpdateTodoStatusRequest>
{
    public UpdateTodoStatusRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}