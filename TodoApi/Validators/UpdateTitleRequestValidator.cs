using FluentValidation;
using TodoApi.Dtos;

namespace TodoApi.Validators;

public class UpdateTitleRequestValidator : AbstractValidator<UpdateTitleRequest>
{
    public UpdateTitleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
    }
}