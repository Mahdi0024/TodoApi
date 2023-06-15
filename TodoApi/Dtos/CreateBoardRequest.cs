using FluentValidation;

namespace TodoApi.Dtos;

public class CreateBoardRequest
{
    public string Name { get; set; } = null!;
}

public class CreateBoradRequestValidator : AbstractValidator<CreateBoardRequest>
{
    public CreateBoradRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
    }
}