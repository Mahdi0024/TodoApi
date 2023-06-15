using FluentValidation;
using TodoApi.Dtos;

namespace TodoApi.Validators;

public class GetBoardRequestValidator : AbstractValidator<GetBoardRequest>
{
    public GetBoardRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}