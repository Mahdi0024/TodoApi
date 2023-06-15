using FluentValidation;
using TodoApi.Dtos;

namespace TodoApi.Validators;

public class CreateBoradRequestValidator : AbstractValidator<CreateBoardRequest>
{
    public CreateBoradRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
    }
}