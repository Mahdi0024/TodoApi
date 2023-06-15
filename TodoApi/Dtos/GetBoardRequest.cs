using FluentValidation;

namespace TodoApi.Dtos;

public class GetBoardRequest
{
    public Guid Id { get; set; }
    public bool IncludeTodos { get; set; }
}

public class GetBoardRequestValidator : AbstractValidator<GetBoardRequest>
{
    public GetBoardRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}