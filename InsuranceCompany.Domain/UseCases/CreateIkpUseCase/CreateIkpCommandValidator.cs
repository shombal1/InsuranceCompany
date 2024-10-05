using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateIkpUseCase;

public class CreateIkpCommandValidator : AbstractValidator<CreateIkpCommand>
{
    public CreateIkpCommandValidator()
    {
        RuleFor((c) => string.IsNullOrWhiteSpace(c.Name));
    }
}