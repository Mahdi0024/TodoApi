using FluentValidation;

namespace TodoApi.Dtos;

public class UpdateTitleRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
}

public class UpdateTitleRequestValidator : AbstractValidator<UpdateTitleRequest>
{
    public UpdateTitleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
    }
}